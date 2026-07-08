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
    using System.Linq;
    using System.Text;

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
            return $"[\"{key}\"] = (xmlReader, documentName, namespaceUri) => new {readerType}(this.cache, this, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),";
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
        /// The reference structural features that can appear as child elements, ordered by member name.
        /// Containment is always a child element; a non-containment reference is a child element only when
        /// its target is in another document, in which case EMF serializes it as an <c>href</c> proxy.
        /// Scalars and enumerations are always attributes in Capella, so they are not read here.
        /// </summary>
        private static List<EStructuralFeature> ElementFeatures(EClass eClass)
        {
            return ReaderFeatures(eClass)
                .Where(f => f is EReference)
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

        /// <summary>
        /// The indentation (in spaces) at which an attribute-read statement is injected in the reader
        /// template — the first line is indented by the template, the rest by <see cref="Block"/>.
        /// </summary>
        private const int AttributeIndent = 16;

        /// <summary>
        /// The indentation (in spaces) at which a <c>switch</c> element-case is injected.
        /// </summary>
        private const int ElementCaseIndent = 28;

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
                return Block(
                    AttributeIndent,
                    "{",
                    $"    if (TryParseEnum<{enumType}>(xmlReader.GetAttribute(\"{xmlName}\"), out var parsed))",
                    "    {",
                    $"        poco.{propertyName} = parsed;",
                    "    }",
                    "}");
            }

            // A multi-valued primitive attribute is a whitespace-delimited list; only string lists occur in
            // the metamodel and are handled, anything more exotic is left unpopulated on purpose.
            if (CSharpType.IsCollection(feature))
            {
                if (CSharpType.BaseType(feature.EType) == "string")
                {
                    return Block(
                        AttributeIndent,
                        $"foreach (var token in (xmlReader.GetAttribute(\"{xmlName}\") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries))",
                        "{",
                        $"    poco.{propertyName}.Add(token);",
                        "}");
                }

                return $"// '{xmlName}' is a multi-valued primitive of an unsupported element type and is not read";
            }

            return ScalarAttributeRead(feature, propertyName, xmlName);
        }

        private static string ScalarAttributeRead(EStructuralFeature feature, string propertyName, string xmlName)
        {
            var baseType = CSharpType.BaseType(feature.EType);

            switch (baseType)
            {
                case "string":
                    return $"poco.{propertyName} = xmlReader.GetAttribute(\"{xmlName}\");";
                case "bool":
                    return ScalarParseBlock(propertyName, xmlName, "bool.TryParse(raw, out var parsed)");
                case "sbyte":
                    return ScalarParseBlock(propertyName, xmlName, "sbyte.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "short":
                    return ScalarParseBlock(propertyName, xmlName, "short.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "int":
                    return ScalarParseBlock(propertyName, xmlName, "int.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "long":
                    return ScalarParseBlock(propertyName, xmlName, "long.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "float":
                    return ScalarParseBlock(propertyName, xmlName, "float.TryParse(raw, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "double":
                    return ScalarParseBlock(propertyName, xmlName, "double.TryParse(raw, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "decimal":
                    return ScalarParseBlock(propertyName, xmlName, "decimal.TryParse(raw, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "BigInteger":
                    return ScalarParseBlock(propertyName, xmlName, "System.Numerics.BigInteger.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)");
                case "DateTime":
                    return ScalarParseBlock(propertyName, xmlName, "System.DateTime.TryParse(raw, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var parsed)");
                case "char":
                    return Block(
                        AttributeIndent,
                        "{",
                        $"    var raw = xmlReader.GetAttribute(\"{xmlName}\");",
                        "    if (!string.IsNullOrEmpty(raw))",
                        "    {",
                        $"        poco.{propertyName} = raw[0];",
                        "    }",
                        "}");
                default:
                    return $"// '{xmlName}' has unsupported primitive type '{baseType}' and is not read";
            }
        }

        private static string ScalarParseBlock(string propertyName, string xmlName, string tryParse)
        {
            return Block(
                AttributeIndent,
                "{",
                $"    var raw = xmlReader.GetAttribute(\"{xmlName}\");",
                $"    if (!string.IsNullOrEmpty(raw) && {tryParse})",
                "    {",
                $"        poco.{propertyName} = parsed;",
                "    }",
                "}");
        }

        private static string ElementCase(EStructuralFeature feature)
        {
            var propertyName = MemberName(feature);
            var xmlName = feature.Name;
            var elementType = CSharpType.BaseType(feature.EType);
            var collection = CSharpType.IsCollection(feature);
            var containment = feature is EReference { IsContainment: true };

            // A child element carrying an href is a cross-document proxy (e.g. into a .capellafragment):
            // it is collected as an unresolved reference rather than instantiated as an empty object.
            // Otherwise an inline containment element is read recursively; a non-containment element
            // (no href) is an unexpected encoding and is skipped.
            var lines = new List<string>
            {
                $"case \"{xmlName}\":",
                "{",
                "    var href = xmlReader.GetAttribute(\"href\");",
                "    if (!string.IsNullOrEmpty(href))",
                "    {",
                collection
                    ? $"        CollectMultiValueReferences(poco, \"{propertyName}\", href);"
                    : $"        CollectSingleValueReference(poco, \"{propertyName}\", href);",
                "        SkipElement(xmlReader);",
                "    }",
                "    else",
                "    {",
            };

            if (!containment)
            {
                lines.Add("        SkipElement(xmlReader);");
            }
            else if (collection)
            {
                lines.Add($"        poco.{propertyName}.Add(({elementType})this.Facade.QueryElement(xmlReader, documentName, namespaceUri));");
            }
            else
            {
                lines.Add($"        poco.{propertyName} = ({elementType})this.Facade.QueryElement(xmlReader, documentName, namespaceUri);");
            }

            lines.Add("    }");
            lines.Add(string.Empty);
            lines.Add("    break;");
            lines.Add("}");

            return Block(ElementCaseIndent, lines.ToArray());
        }

        /// <summary>
        /// Joins the supplied lines into a single block. The first line is emitted without indentation —
        /// the reader template indents it — while every subsequent non-empty line is prefixed with
        /// <paramref name="baseIndent"/> spaces (on top of the relative indentation baked into the line).
        /// </summary>
        private static string Block(int baseIndent, params string[] lines)
        {
            var padding = new string(' ', baseIndent);
            var builder = new StringBuilder();

            for (var i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append('\n');

                    if (lines[i].Length > 0)
                    {
                        builder.Append(padding);
                    }
                }

                builder.Append(lines[i]);
            }

            return builder.ToString();
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
