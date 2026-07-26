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

        private static string ReaderRootNamespace => NamingContext.ReaderRoot;

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

            handlebars.RegisterHelper("ReaderFacadeNamespace", (writer, _, _) =>
                writer.WriteSafeString(ReaderRootNamespace));

            handlebars.RegisterHelper("ReaderAttributeFeatures", (_, arguments) => AttributeFeatures((EClass)arguments[0]!));

            handlebars.RegisterHelper("ReaderElementFeatures", (_, arguments) => ElementFeatures((EClass)arguments[0]!));

            handlebars.RegisterHelper("KnownAttributeNames", (writer, _, arguments) =>
                writer.WriteSafeString(KnownAttributeNames((EClass)arguments[0]!)));
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
            return string.Concat(ReaderRootNamespace, CSharpNaming.Namespace(eClass).AsSpan(CSharpNaming.RootNamespace.Length));
        }

        private static string ReaderClassName(EClass eClass)
        {
            return CSharpNaming.Capitalize(eClass.Name) + "Reader";
        }

        private static string FacadeEntry(EClass eClass)
        {
            var key = $"{eClass.EPackage.Name}:{eClass.Name}";
            var readerType = ReaderNamespace(eClass) + "." + ReaderClassName(eClass);
            return $"[\"{key}\"] = (xmlReader, documentName, namespaceUri) => new {readerType}(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),";
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
        /// The structural features that can appear as child elements, ordered by member name. Containment
        /// is always a child element; a non-containment reference is a child element only when its target
        /// is in another document, in which case EMF serializes it as an <c>href</c> proxy. A single-valued
        /// scalar or enumeration is always an attribute, but a <em>multi-valued</em> one is serialized by
        /// EMF as one child element per value, so it is read here as well as from the attribute form.
        /// </summary>
        private static List<EStructuralFeature> ElementFeatures(EClass eClass)
        {
            return ReaderFeatures(eClass)
                .Where(f => f is EReference || IsMultiValuedSimpleAttribute(f))
                .ToList();
        }

        /// <summary>
        /// Whether the feature is a multi-valued simple (non-reference) attribute of a type the generator
        /// can read — a string or an enumeration. EMF serializes such a feature as repeated child elements
        /// rather than a whitespace-delimited attribute, which is the form every Capella and Sirius file in
        /// circulation uses.
        /// </summary>
        /// <param name="feature">the structural feature to test</param>
        /// <returns>true when the feature is read from repeated child elements</returns>
        private static bool IsMultiValuedSimpleAttribute(EStructuralFeature feature)
        {
            return feature is not EReference
                   && CSharpType.IsCollection(feature)
                   && (feature.EType is EEnum || SimpleElementParse(feature) != null);
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
            var xmlName = XmlNames.XmlName(feature);

            if (feature is EReference reference && !reference.IsContainment)
            {
                return CSharpType.IsCollection(feature)
                    ? $"CollectMultiValueReferences(poco, \"{propertyName}\", xmlReader.GetAttribute(\"{xmlName}\"));"
                    : $"CollectSingleValueReference(poco, \"{propertyName}\", xmlReader.GetAttribute(\"{xmlName}\"));";
            }

            if (feature.EType is EEnum attributeEnum)
            {
                if (CSharpType.IsCollection(feature))
                {
                    // A multi-valued enum attribute is a whitespace-delimited list of literals.
                    return Block(
                        AttributeIndent,
                        $"foreach (var token in (xmlReader.GetAttribute(\"{xmlName}\") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries))",
                        "{",
                        $"    if ({TryParse(attributeEnum)}(token.AsSpan(), out var parsed))",
                        "    {",
                        $"        poco.{propertyName}.Add(parsed);",
                        "    }",
                        "    else",
                        "    {",
                        $"        this.HandleUnknownEnumLiteral(\"{attributeEnum.Name}\", \"{xmlName}\", token, xmlLineInfo);",
                        "    }",
                        "}");
                }

                return Block(
                    AttributeIndent,
                    "{",
                    $"    var raw = xmlReader.GetAttribute(\"{xmlName}\");",
                    "    if (!string.IsNullOrEmpty(raw))",
                    "    {",
                    $"        if ({TryParse(attributeEnum)}(raw.AsSpan(), out var parsed))",
                    "        {",
                    $"            poco.{propertyName} = parsed;",
                    "        }",
                    "        else",
                    "        {",
                    $"            this.HandleUnknownEnumLiteral(\"{attributeEnum.Name}\", \"{xmlName}\", raw, xmlLineInfo);",
                    "        }",
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
            var xmlName = XmlNames.XmlName(feature);
            var collection = CSharpType.IsCollection(feature);
            var containment = feature is EReference { IsContainment: true };

            if (IsMultiValuedSimpleAttribute(feature))
            {
                return SimpleAttributeElementCase(feature, propertyName, xmlName);
            }

            var elementType = containment ? CSharpType.ContainmentElementType(feature) : CSharpType.BaseType(feature.EType);

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

        /// <summary>
        /// The child-element case for a multi-valued simple attribute: each occurrence contributes one
        /// value, read from the element's text content. There is no <c>href</c> branch — a simple attribute
        /// is never a proxy — and the text is read through <c>ReadElementText</c> so the cursor is left on
        /// the end tag, letting the enclosing loop reach the next sibling occurrence.
        /// </summary>
        private static string SimpleAttributeElementCase(EStructuralFeature feature, string propertyName, string xmlName)
        {
            if (feature.EType is EEnum eEnum)
            {
                return Block(
                    ElementCaseIndent,
                    $"case \"{xmlName}\":",
                    "{",
                    "    var text = ReadElementText(xmlReader);",
                    $"    if ({TryParse(eEnum)}(text.AsSpan(), out var parsed))",
                    "    {",
                    $"        poco.{propertyName}.Add(parsed);",
                    "    }",
                    "    else",
                    "    {",
                    $"        this.HandleUnknownEnumLiteral(\"{eEnum.Name}\", \"{xmlName}\", text, xmlLineInfo);",
                    "    }",
                    string.Empty,
                    "    break;",
                    "}");
            }

            if (CSharpType.BaseType(feature.EType) == "string")
            {
                return Block(
                    ElementCaseIndent,
                    $"case \"{xmlName}\":",
                    "{",
                    $"    poco.{propertyName}.Add(ReadElementText(xmlReader));",
                    string.Empty,
                    "    break;",
                    "}");
            }

            return Block(
                ElementCaseIndent,
                $"case \"{xmlName}\":",
                "{",
                $"    if ({SimpleElementParse(feature)})",
                "    {",
                $"        poco.{propertyName}.Add(parsed);",
                "    }",
                string.Empty,
                "    break;",
                "}");
        }

        /// <summary>
        /// The <c>TryParse</c> expression that converts a multi-valued simple attribute's element text into
        /// its primitive type, or <c>null</c> when the generator does not support the type. The text is
        /// always read through <c>ReadElementText</c> so the cursor lands on the end tag.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the parse expression binding <c>parsed</c>, or <c>null</c> when unsupported</returns>
        private static string? SimpleElementParse(EStructuralFeature feature)
        {
            const string Text = "ReadElementText(xmlReader)";
            const string Invariant = "System.Globalization.CultureInfo.InvariantCulture";

            return CSharpType.BaseType(feature.EType) switch
            {
                "string" => $"!string.IsNullOrEmpty({Text})",
                "bool" => $"bool.TryParse({Text}, out var parsed)",
                "sbyte" => $"sbyte.TryParse({Text}, System.Globalization.NumberStyles.Integer, {Invariant}, out var parsed)",
                "short" => $"short.TryParse({Text}, System.Globalization.NumberStyles.Integer, {Invariant}, out var parsed)",
                "int" => $"int.TryParse({Text}, System.Globalization.NumberStyles.Integer, {Invariant}, out var parsed)",
                "long" => $"long.TryParse({Text}, System.Globalization.NumberStyles.Integer, {Invariant}, out var parsed)",
                "float" => $"float.TryParse({Text}, System.Globalization.NumberStyles.Float, {Invariant}, out var parsed)",
                "double" => $"double.TryParse({Text}, System.Globalization.NumberStyles.Float, {Invariant}, out var parsed)",
                "decimal" => $"decimal.TryParse({Text}, System.Globalization.NumberStyles.Number, {Invariant}, out var parsed)",
                "BigInteger" => $"System.Numerics.BigInteger.TryParse({Text}, System.Globalization.NumberStyles.Integer, {Invariant}, out var parsed)",
                _ => null,
            };
        }

        /// <summary>
        /// The fully qualified <c>TryParse</c> of an enumeration's generated provider. Reading goes through
        /// the provider rather than <c>Enum.TryParse</c> so it matches the Ecore literal names
        /// case-sensitively, exactly as the writer emits them.
        /// </summary>
        /// <param name="eEnum">the enumeration</param>
        /// <returns>the qualified method name</returns>
        private static string TryParse(EEnum eEnum)
        {
            return $"Auriga.Extensions.{EnumProviderHelper.EnumProviderName(eEnum)}.TryParse";
        }

        /// <summary>
        /// The XML names of every attribute the class declares, as initializer entries for the reader's
        /// <c>KnownAttributes</c> set. An attribute outside this set is uninterpreted and captured
        /// verbatim. Multi-valued simple attributes are included: they may still appear in the attribute
        /// form even though EMF writes them as child elements.
        /// </summary>
        /// <param name="eClass">the class</param>
        /// <returns>the generated set initializer entries</returns>
        private static string KnownAttributeNames(EClass eClass)
        {
            var builder = new StringBuilder();

            foreach (var name in ReaderFeatures(eClass)
                         .Where(f => f is not EReference { IsContainment: true })
                         .Select(XmlNames.XmlName)
                         .Distinct(StringComparer.Ordinal)
                         .OrderBy(n => n, StringComparer.Ordinal))
            {
                builder.Append("            \"").Append(name).AppendLine("\",");
            }

            return builder.ToString();
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
