// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterHelper.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using ECoreNetto;

    using HandlebarsDotNet;

    /// <summary>
    /// The HandleBars helpers that render the generated per-type XMI writers and the writer facade directly
    /// from the ECoreNetto POCOs. It is the inverse of <see cref="XmiReaderHelper"/>: it classifies each
    /// stored structural feature the same way — scalar / enum / containment / cross-reference, single or
    /// multi — and emits the matching write code. Capella encodes non-containment references as <c>#id</c>
    /// attributes and containment as child elements carrying an <c>xsi:type</c>. Features are emitted
    /// alphabetically by member name (matching the reader) for a stable, deterministic order.
    /// </summary>
    public static class XmiWriterHelper
    {
        private static readonly HashSet<string> ReservedMembers = new(StringComparer.Ordinal) { "Id", "Container" };

        private static string WriterRootNamespace => NamingContext.WriterRoot;

        /// <summary>
        /// Registers the <see cref="XmiWriterHelper"/> helpers with the supplied HandleBars context.
        /// </summary>
        /// <param name="handlebars">the HandleBars context</param>
        public static void RegisterXmiWriterHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("WriterNamespace", (writer, _, arguments) =>
                writer.WriteSafeString(WriterNamespace((EClass)arguments[0]!)));

            handlebars.RegisterHelper("WriterClassName", (writer, _, arguments) =>
                writer.WriteSafeString(WriterClassName((EClass)arguments[0]!)));

            handlebars.RegisterHelper("PocoInterface", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.InterfaceType((EClass)arguments[0]!)));

            handlebars.RegisterHelper("TypeNameRaw", (writer, _, arguments) =>
                writer.WriteSafeString(((EClass)arguments[0]!).Name));

            handlebars.RegisterHelper("NamespacePrefix", (writer, _, arguments) =>
                writer.WriteSafeString(((EClass)arguments[0]!).EPackage.NsPrefix));

            handlebars.RegisterHelper("NamespaceUri", (writer, _, arguments) =>
                writer.WriteSafeString(((EClass)arguments[0]!).EPackage.NsUri));

            handlebars.RegisterHelper("AttributeWrite", (writer, _, arguments) =>
                writer.WriteSafeString(AttributeWrite((EStructuralFeature)arguments[0]!)));

            handlebars.RegisterHelper("ElementWrite", (writer, _, arguments) =>
                writer.WriteSafeString(ElementWrite((EStructuralFeature)arguments[0]!)));

            handlebars.RegisterHelper("WriterFacadeEntry", (writer, _, arguments) =>
                writer.WriteSafeString(WriterFacadeEntry((EClass)arguments[0]!)));

            handlebars.RegisterHelper("WriterFacadeNamespace", (writer, _, _) =>
                writer.WriteSafeString(WriterRootNamespace));

            handlebars.RegisterHelper("WriterAttributeFeatures", (_, arguments) => AttributeFeatures((EClass)arguments[0]!));

            handlebars.RegisterHelper("WriterElementFeatures", (_, arguments) => ElementFeatures((EClass)arguments[0]!));
        }

        /// <summary>
        /// Whether the class needs a writer, i.e. it is a concrete (instantiable) generated class.
        /// </summary>
        /// <param name="eClass">the class to test</param>
        /// <returns>true when a writer must be generated for the class</returns>
        public static bool IsConcrete(EClass eClass)
        {
            return eClass.EPackage != null && !eClass.Abstract && !eClass.Interface;
        }

        /// <summary>
        /// The single-level output sub-folder for a classifier's writer (the PascalCased immediate package
        /// name), matching the reader layout.
        /// </summary>
        /// <param name="eClass">the class</param>
        /// <returns>the writer sub-folder name</returns>
        public static string WriterFolder(EClass eClass)
        {
            return CSharpNaming.Capitalize(eClass.EPackage.Name);
        }

        /// <summary>
        /// The writer class name of a class (e.g. <c>PhysicalFunctionWriter</c>).
        /// </summary>
        /// <param name="eClass">the class</param>
        /// <returns>the writer class name</returns>
        public static string WriterClassName(EClass eClass)
        {
            return CSharpNaming.Capitalize(eClass.Name) + "Writer";
        }

        private static string WriterNamespace(EClass eClass)
        {
            return string.Concat(WriterRootNamespace, CSharpNaming.Namespace(eClass).AsSpan(CSharpNaming.RootNamespace.Length));
        }

        private static string PocoType(EClass eClass)
        {
            return CSharpNaming.Namespace(eClass) + "." + CSharpNaming.Capitalize(eClass.Name);
        }

        private static string WriterFacadeEntry(EClass eClass)
        {
            var writerType = WriterNamespace(eClass) + "." + WriterClassName(eClass);
            return $"[typeof({PocoType(eClass)})] = new {writerType}(this, loggerFactory),";
        }

        /// <summary>
        /// The non-containment structural features, written as XML attributes (scalars, enums and
        /// <c>#id</c> cross-references), in Ecore declaration order.
        /// </summary>
        private static List<EStructuralFeature> AttributeFeatures(EClass eClass)
        {
            return WriterFeatures(eClass)
                .Where(f => f is not EReference { IsContainment: true })
                .ToList();
        }

        /// <summary>
        /// The containment structural features, written as child elements, in Ecore declaration order.
        /// </summary>
        private static List<EStructuralFeature> ElementFeatures(EClass eClass)
        {
            return WriterFeatures(eClass)
                .Where(f => f is EReference { IsContainment: true })
                .ToList();
        }

        /// <summary>
        /// The stored (non-derived) structural features of the concrete class, flattened over its
        /// supertypes and de-duplicated by member name, ordered alphabetically by member name (matching the
        /// reader) so the written attributes and children are emitted in a stable, deterministic order.
        /// </summary>
        private static IEnumerable<EStructuralFeature> WriterFeatures(EClass eClass)
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

        private static string AttributeWrite(EStructuralFeature feature)
        {
            var propertyName = MemberName(feature);
            var xmlName = XmlNames.XmlName(feature);

            if (feature is EReference reference && !reference.IsContainment)
            {
                if (CSharpType.IsCollection(feature))
                {
                    return $"this.WriteReferenceListAttribute(xmlWriter, \"{xmlName}\", poco.{propertyName}, poco, \"{propertyName}\", context);";
                }

                var target = CSharpType.BaseType(feature.EType) == "object"
                    ? $"poco.{propertyName} as Auriga.Core.IAurigaElement"
                    : $"poco.{propertyName}";
                return $"this.WriteReferenceAttribute(xmlWriter, \"{xmlName}\", {target}, poco, \"{propertyName}\", context);";
            }

            if (feature.EType is EEnum eEnum)
            {
                var enumType = CSharpNaming.EnumType(eEnum);
                return CSharpType.IsCollection(feature)
                    ? $"WriteEnumListAttribute<{enumType}>(xmlWriter, \"{xmlName}\", poco.{propertyName});"
                    : $"WriteEnumAttribute<{enumType}>(xmlWriter, \"{xmlName}\", poco.{propertyName});";
            }

            if (CSharpType.IsCollection(feature))
            {
                if (CSharpType.BaseType(feature.EType) == "string")
                {
                    return $"WriteStringListAttribute(xmlWriter, \"{xmlName}\", poco.{propertyName});";
                }

                return $"// '{xmlName}' is a multi-valued primitive of an unsupported element type and is not written";
            }

            return ScalarAttributeWrite(feature, propertyName, xmlName);
        }

        private static string ScalarAttributeWrite(EStructuralFeature feature, string propertyName, string xmlName)
        {
            var baseType = CSharpType.BaseType(feature.EType);

            var helper = baseType switch
            {
                "string" => "WriteStringAttribute",
                "bool" => "WriteBooleanAttribute",
                "sbyte" => "WriteByteAttribute",
                "short" => "WriteShortAttribute",
                "int" => "WriteIntegerAttribute",
                "long" => "WriteLongAttribute",
                "float" => "WriteFloatAttribute",
                "double" => "WriteDoubleAttribute",
                "decimal" => "WriteDecimalAttribute",
                "BigInteger" => "WriteBigIntegerAttribute",
                "DateTime" => "WriteDateTimeAttribute",
                "char" => "WriteCharAttribute",
                _ => null,
            };

            if (helper == null)
            {
                return $"// '{xmlName}' has unsupported primitive type '{baseType}' and is not written";
            }

            return $"{helper}(xmlWriter, \"{xmlName}\", poco.{propertyName});";
        }

        private static string ElementWrite(EStructuralFeature feature)
        {
            var propertyName = MemberName(feature);
            var xmlName = XmlNames.XmlName(feature);

            return CSharpType.IsCollection(feature)
                ? $"this.WriteContainedElements(xmlWriter, \"{xmlName}\", poco.{propertyName}, poco, \"{propertyName}\", context);"
                : $"this.WriteContainedElement(xmlWriter, \"{xmlName}\", poco.{propertyName}, poco, \"{propertyName}\", context);";
        }

        private static string MemberName(EStructuralFeature feature)
        {
            return CSharpNaming.MemberName(feature);
        }

        private static bool IsReserved(EStructuralFeature feature)
        {
            return ReservedMembers.Contains(CSharpNaming.Capitalize(feature.Name));
        }
    }
}
