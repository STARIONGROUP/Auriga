// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderHelper.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using ECoreNetto;

    using HandlebarsDotNet;

    /// <summary>
    /// The HandleBars helpers that render the generated per-type XMI readers, the reader facade and the
    /// namespace registry directly from the ECoreNetto POCOs. It classifies each structural feature the
    /// same way uml4net's <c>PropertyHelper</c> does — scalar / enum / containment / cross-reference,
    /// single or multi — and emits the matching read code. Capella encodes non-containment references as
    /// <c>#id</c> attributes and containment as child elements carrying an <c>xsi:type</c>.
    /// </summary>
    public static class XmiReaderHelper
    {
        private static readonly HashSet<string> ReservedMembers = new(StringComparer.Ordinal) { "Id", "Container" };

        private const string ReaderRootNamespace = "Auriga.Xmi.AutoGenXmiReaders";

        private const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// Registers the <see cref="XmiReaderHelper"/> helpers with the supplied HandleBars context.
        /// </summary>
        /// <param name="handlebars">the HandleBars context</param>
        public static void RegisterXmiReaderHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("ReaderNamespace", (writer, _, arguments) =>
                writer.WriteSafeString(ReaderNamespace((EClass)arguments[0]!)));

            handlebars.RegisterHelper("ReaderClassName", (writer, _, arguments) =>
                writer.WriteSafeString(ReaderClassName((EClass)arguments[0]!)));

            handlebars.RegisterHelper("PocoType", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.Namespace((EClass)arguments[0]!) + "." + CSharpNaming.Capitalize(((EClass)arguments[0]!).Name)));

            handlebars.RegisterHelper("PocoInterface", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.InterfaceType((EClass)arguments[0]!)));

            handlebars.RegisterHelper("TypeNameRaw", (writer, _, arguments) =>
                writer.WriteSafeString(((EClass)arguments[0]!).Name));

            handlebars.RegisterHelper("AttributeRead", (writer, _, arguments) =>
                writer.WriteSafeString(AttributeRead((EStructuralFeature)arguments[0]!)));

            handlebars.RegisterHelper("ElementCase", (writer, _, arguments) =>
                writer.WriteSafeString(ElementCase((EStructuralFeature)arguments[0]!)));

            handlebars.RegisterHelper("FacadeEntry", (writer, _, arguments) =>
                writer.WriteSafeString(FacadeEntry((EClass)arguments[0]!)));

            handlebars.RegisterHelper("RegistryEntry", (writer, _, arguments) =>
                writer.WriteSafeString(RegistryEntry((EPackage)arguments[0]!)));

            handlebars.RegisterHelper("XsiNamespaceUri", (writer, _, _) =>
                writer.WriteSafeString(XsiNamespace));

            handlebars.RegisterHelper("ReaderAttributeFeatures", (_, arguments) => AttributeFeatures((EClass)arguments[0]!));

            handlebars.RegisterHelper("ReaderElementFeatures", (_, arguments) => ElementFeatures((EClass)arguments[0]!));
        }

        /// <summary>
        /// Whether the class needs a reader, i.e. it is a concrete (instantiable) generated class.
        /// </summary>
        /// <param name="eClass">the class to test</param>
        /// <returns>true when a reader must be generated for the class</returns>
        public static bool IsConcrete(EClass eClass)
        {
            return eClass.EPackage != null && !eClass.Abstract && !eClass.Interface;
        }

        /// <summary>
        /// The single-level output sub-folder for a classifier's reader (the PascalCased immediate package
        /// name, matching the model layout so same-named types in different packages do not collide).
        /// </summary>
        /// <param name="eClass">the class</param>
        /// <returns>the reader sub-folder name</returns>
        public static string ReaderFolder(EClass eClass)
        {
            return CSharpNaming.Capitalize(eClass.EPackage.Name);
        }

        private static string ReaderNamespace(EClass eClass)
        {
            return ReaderRootNamespace + CSharpNaming.Namespace(eClass).Substring(CSharpNaming.RootNamespace.Length);
        }

        private static string ReaderClassName(EClass eClass)
        {
            return CSharpNaming.Capitalize(eClass.Name) + "Reader";
        }

        private static string FacadeEntry(EClass eClass)
        {
            var key = $"{eClass.EPackage.Name}:{eClass.Name}";
            var readerType = ReaderNamespace(eClass) + "." + ReaderClassName(eClass);
            return $"[\"{key}\"] = xmlReader => new {readerType}(this.cache, this, this.loggerFactory).Read(xmlReader),";
        }

        private static string RegistryEntry(EPackage package)
        {
            return $"[\"{package.NsUri}\"] = \"{package.Name}\",";
        }

        /// <summary>
        /// The non-containment structural features, read from XML attributes (scalars, enums and
        /// <c>#id</c> cross-references), ordered by member name.
        /// </summary>
        private static List<EStructuralFeature> AttributeFeatures(EClass eClass)
        {
            return ReaderFeatures(eClass)
                .Where(f => f is not EReference { IsContainment: true })
                .ToList();
        }

        /// <summary>
        /// The containment structural features, read from child elements, ordered by member name.
        /// </summary>
        private static List<EStructuralFeature> ElementFeatures(EClass eClass)
        {
            return ReaderFeatures(eClass)
                .Where(f => f is EReference { IsContainment: true })
                .ToList();
        }

        /// <summary>
        /// The stored (non-derived) structural features of the concrete class, flattened over its
        /// supertypes, de-duplicated by member name and ordered by member name — the same set the
        /// generated implementation class exposes, minus the computed members it cannot round-trip.
        /// </summary>
        private static IEnumerable<EStructuralFeature> ReaderFeatures(EClass eClass)
        {
            var seen = new HashSet<string>(StringComparer.Ordinal);
            var features = new List<EStructuralFeature>();

            foreach (var feature in eClass.AllEStructuralFeatures)
            {
                if (feature.EType == null || IsReserved(feature) || CSharpType.IsComputed(feature))
                {
                    continue;
                }

                if (seen.Add(MemberName(feature)))
                {
                    features.Add(feature);
                }
            }

            return features.OrderBy(MemberName, StringComparer.Ordinal);
        }

        private static string AttributeRead(EStructuralFeature feature)
        {
            var propertyName = MemberName(feature);
            var xmlName = feature.Name;

            if (feature is EReference reference && !reference.IsContainment)
            {
                return CSharpType.IsCollection(feature)
                    ? $"CollectMultiValueReferences(poco, \"{propertyName}\", xmlReader.GetAttribute(\"{xmlName}\"));"
                    : $"CollectSingleValueReference(poco, \"{propertyName}\", xmlReader.GetAttribute(\"{xmlName}\"));";
            }

            if (feature.EType is EEnum)
            {
                var enumType = CSharpNaming.EnumType((EEnum)feature.EType);
                return $"{{ if (TryParseEnum<{enumType}>(xmlReader.GetAttribute(\"{xmlName}\"), out var parsed)) {{ poco.{propertyName} = parsed; }} }}";
            }

            // A multi-valued primitive attribute is a whitespace-delimited list; only string lists occur in
            // the metamodel and are handled, anything more exotic is left unpopulated on purpose.
            if (CSharpType.IsCollection(feature))
            {
                if (CSharpType.BaseType(feature.EType) == "string")
                {
                    return $"foreach (var token in (xmlReader.GetAttribute(\"{xmlName}\") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries)) {{ poco.{propertyName}.Add(token); }}";
                }

                return $"// '{xmlName}' is a multi-valued primitive of an unsupported element type and is not read";
            }

            return ScalarAttributeRead(feature, propertyName, xmlName);
        }

        private static string ScalarAttributeRead(EStructuralFeature feature, string propertyName, string xmlName)
        {
            var baseType = CSharpType.BaseType(feature.EType);
            var getter = $"xmlReader.GetAttribute(\"{xmlName}\")";

            switch (baseType)
            {
                case "string":
                    return $"poco.{propertyName} = {getter};";
                case "bool":
                    return TryParse(propertyName, getter, "bool.TryParse(raw, out var parsed)");
                case "sbyte":
                    return TryParse(propertyName, getter, "sbyte.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "short":
                    return TryParse(propertyName, getter, "short.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "int":
                    return TryParse(propertyName, getter, "int.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "long":
                    return TryParse(propertyName, getter, "long.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "float":
                    return TryParse(propertyName, getter, "float.TryParse(raw, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "double":
                    return TryParse(propertyName, getter, "double.TryParse(raw, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "decimal":
                    return TryParse(propertyName, getter, "decimal.TryParse(raw, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "BigInteger":
                    return TryParse(propertyName, getter, "System.Numerics.BigInteger.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "DateTime":
                    return TryParse(propertyName, getter, "System.DateTime.TryParse(raw, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var parsed)");
                case "char":
                    return $"{{ var raw = {getter}; if (!string.IsNullOrEmpty(raw)) {{ poco.{propertyName} = raw[0]; }} }}";
                default:
                    return $"// '{xmlName}' has unsupported primitive type '{baseType}' and is not read";
            }
        }

        private static string TryParse(string propertyName, string getter, string tryParse)
        {
            return $"{{ var raw = {getter}; if (!string.IsNullOrEmpty(raw) && {tryParse}) {{ poco.{propertyName} = parsed; }} }}";
        }

        private static string ElementCase(EStructuralFeature feature)
        {
            var propertyName = MemberName(feature);
            var xmlName = feature.Name;
            var elementType = CSharpType.BaseType(feature.EType);

            if (CSharpType.IsCollection(feature))
            {
                return $"case \"{xmlName}\":\n" +
                       $"                        poco.{propertyName}.Add(({elementType})this.Facade.QueryElement(xmlReader));\n" +
                       $"                        break;";
            }

            return $"case \"{xmlName}\":\n" +
                   $"                    {{\n" +
                   $"                        var contained = ({elementType})this.Facade.QueryElement(xmlReader);\n" +
                   $"                        contained.Container = poco;\n" +
                   $"                        poco.{propertyName} = contained;\n" +
                   $"                        break;\n" +
                   $"                    }}";
        }

        private static string MemberName(EStructuralFeature feature)
        {
            return CSharpNaming.Escape(CSharpNaming.Capitalize(feature.Name));
        }

        private static bool IsReserved(EStructuralFeature feature)
        {
            return ReservedMembers.Contains(CSharpNaming.Capitalize(feature.Name));
        }
    }
}
