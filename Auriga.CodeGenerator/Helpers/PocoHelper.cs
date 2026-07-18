// ------------------------------------------------------------------------------------------------
// <copyright file="PocoHelper.cs" company="Starion Group S.A.">
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
    using ECoreNetto.Extensions;

    using HandlebarsDotNet;

    /// <summary>
    /// The HandleBars helpers that render the Auriga object model directly from the ECoreNetto POCOs
    /// (<see cref="EClass"/>, <see cref="EEnum"/>, <see cref="EStructuralFeature"/>), following the
    /// uml4net/SysML2.NET convention of driving the templates from the metamodel elements plus helpers
    /// rather than intermediate view-model classes.
    /// </summary>
    public static class PocoHelper
    {
        /// <summary>
        /// Member names supplied by <c>Auriga.Core.IAurigaElement</c>; a same-named Capella feature is mapped
        /// onto the inherited member rather than re-declared (which would hide the base).
        /// </summary>
        private static readonly HashSet<string> ReservedMembers = new(StringComparer.Ordinal) { "Id", "Container" };

        /// <summary>
        /// Whether an <see cref="EClass"/> belongs to the Capella metamodel (and is therefore generated).
        /// Ecore built-ins reached as a supertype or feature type — notably <c>ecore::EObject</c>, whose
        /// <see cref="EClassifier.EPackage"/> is not part of the loaded resource set — return false.
        /// </summary>
        /// <param name="eClass">the class to test</param>
        /// <returns>true when the class is part of the generated metamodel</returns>
        public static bool IsGenerated(EClass eClass)
        {
            return eClass?.EPackage != null;
        }

        /// <summary>
        /// Registers the <see cref="PocoHelper"/> helpers with the supplied HandleBars context.
        /// </summary>
        /// <param name="handlebars">the HandleBars context</param>
        public static void RegisterPocoHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Namespace", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.Namespace((EClassifier)arguments[0]!)));

            handlebars.RegisterHelper("TypeName", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.Capitalize(((EClassifier)arguments[0]!).Name)));

            handlebars.RegisterHelper("Extends", (writer, _, arguments) =>
                writer.WriteSafeString(Extends((EClass)arguments[0]!)));

            handlebars.RegisterHelper("Bases", (writer, _, arguments) =>
                writer.WriteSafeString($" : Auriga.Core.AurigaElement, {CSharpNaming.InterfaceType((EClass)arguments[0]!)}"));

            handlebars.RegisterHelper("InterfaceDeclaration", (writer, _, arguments) =>
                writer.WriteSafeString(Declaration((EStructuralFeature)arguments[0]!, forInterface: true)));

            handlebars.RegisterHelper("ClassDeclaration", (writer, _, arguments) =>
                writer.WriteSafeString(Declaration((EStructuralFeature)arguments[0]!, forInterface: false)));

            handlebars.RegisterHelper("LiteralName", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.Escape(CSharpNaming.Capitalize(((EEnumLiteral)arguments[0]!).Name))));

            handlebars.RegisterHelper("EnumerationDocumentation", (_, arguments) =>
            {
                var eEnum = (EEnum)arguments[0]!;
                return Summary(eEnum, $"The <c>{CSharpNaming.Capitalize(eEnum.Name)}</c> enumeration.");
            });

            handlebars.RegisterHelper("InterfaceDocumentation", (_, arguments) =>
            {
                var eClass = (EClass)arguments[0]!;
                return Summary(eClass, $"Definition of the <c>{CSharpNaming.Capitalize(eClass.Name)}</c> interface.");
            });

            handlebars.RegisterHelper("ClassDocumentation", (_, arguments) =>
            {
                var eClass = (EClass)arguments[0]!;
                return Summary(eClass, $"Definition of the <c>{CSharpNaming.Capitalize(eClass.Name)}</c> class.");
            });

            handlebars.RegisterHelper("LiteralDocumentation", (_, arguments) =>
            {
                var literal = (EEnumLiteral)arguments[0]!;
                return Summary(literal, $"The <c>{CSharpNaming.Capitalize(literal.Name)}</c> literal.");
            });

            handlebars.RegisterHelper("MemberDocumentation", (_, arguments) =>
            {
                var feature = (EStructuralFeature)arguments[0]!;
                var writable = !CSharpType.IsComputed(feature) && !CSharpType.IsCollection(feature);
                return Summary(feature, $"{(writable ? "Gets or sets" : "Gets")} the {Humanize(feature.Name)}.");
            });

            handlebars.RegisterHelper("InterfaceFeatures", (_, arguments) => InterfaceFeatures((EClass)arguments[0]!));

            handlebars.RegisterHelper("ClassFeatures", (_, arguments) => ClassFeatures((EClass)arguments[0]!));

            handlebars.RegisterHelper("InterfaceUsings", (_, arguments) => Usings(InterfaceFeatures((EClass)arguments[0]!)));

            handlebars.RegisterHelper("ClassUsings", (_, arguments) => Usings(ClassFeatures((EClass)arguments[0]!)));

            handlebars.RegisterHelper("ContainmentTraversal", (writer, _, arguments) =>
                writer.WriteSafeString(ContainmentTraversal((EClass)arguments[0]!)));
        }

        /// <summary>
        /// Returns the own structural features rendered on an interface, filtered and ordered by name.
        /// </summary>
        private static List<EStructuralFeature> InterfaceFeatures(EClass eClass)
        {
            return eClass.EStructuralFeatures
                .Where(f => f.EType != null && !IsReserved(f))
                .OrderBy(MemberName, StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        /// Returns the flattened structural features rendered on a concrete class: inherited features are
        /// pulled onto the class, deduped by name and ordered by name.
        /// </summary>
        private static List<EStructuralFeature> ClassFeatures(EClass eClass)
        {
            var features = new List<EStructuralFeature>();
            var seen = new HashSet<string>(StringComparer.Ordinal);
            var className = CSharpNaming.Capitalize(eClass.Name);

            foreach (var feature in eClass.AllEStructuralFeatures.Where(f => f.EType != null && !IsReserved(f)))
            {
                var memberName = MemberName(feature);

                if (!seen.Add(memberName))
                {
                    continue;
                }

                if (string.Equals(memberName, className, StringComparison.Ordinal))
                {
                    throw new NotSupportedException(
                        $"Feature '{eClass.Name}.{feature.Name}' collides with its enclosing type name; " +
                        "member/type name-collision handling is deferred to a later issue.");
                }

                features.Add(feature);
            }

            return features.OrderBy(MemberName, StringComparer.Ordinal).ToList();
        }

        private static string Extends(EClass eClass)
        {
            var supertypes = eClass.ESuperTypes.Where(IsGenerated).ToList();

            return supertypes.Count > 0
                ? " : " + string.Join(", ", supertypes.Select(CSharpNaming.InterfaceType))
                : " : Auriga.Core.IAurigaElement";
        }

        private static string Declaration(EStructuralFeature feature, bool forInterface)
        {
            var name = MemberName(feature);
            var type = CSharpType.MemberType(feature);
            var baseType = CSharpType.BaseType(feature.EType);
            var computed = CSharpType.IsComputed(feature);
            var collection = CSharpType.IsCollection(feature);
            var containment = feature is EReference { IsContainment: true };

            if (forInterface)
            {
                var accessor = !computed && !collection ? "{ get; set; }" : "{ get; }";
                return $"{type} {name} {accessor}";
            }

            if (computed)
            {
                return collection
                    ? $"public {type} {name} => Enumerable.Empty<{baseType}>();"
                    : $"public {type} {name} => default;";
            }

            if (collection && containment)
            {
                var field = "backing" + name;
                var elementType = CSharpType.ContainmentElementType(feature);
                return $"public {type} {name} => this.{field} ??= new Auriga.Core.ContainerList<{elementType}>(this);\n\n" +
                       $"        /// <summary>\n" +
                       $"        /// Backing field for <see cref=\"{name}\"/>.\n" +
                       $"        /// </summary>\n" +
                       $"        private {type} {field};";
            }

            if (collection)
            {
                return $"public {type} {name} {{ get; }} = new List<{baseType}>();";
            }

            if (containment)
            {
                // Single-valued containment: the setter re-parents the value so containment navigation
                // (eContainer/eContents) works whether the value is set inline by the reader or through the
                // reflection-based reference resolver.
                var field = "backing" + name;
                return $"public {type} {name}\n" +
                       $"        {{\n" +
                       $"            get => this.{field};\n" +
                       $"            set\n" +
                       $"            {{\n" +
                       $"                if (value != null)\n" +
                       $"                {{\n" +
                       $"                    value.Container = this;\n" +
                       $"                }}\n" +
                       $"\n" +
                       $"                this.{field} = value;\n" +
                       $"            }}\n" +
                       $"        }}\n\n" +
                       $"        /// <summary>\n" +
                       $"        /// Backing field for <see cref=\"{name}\"/>.\n" +
                       $"        /// </summary>\n" +
                       $"        private {type} {field};";
            }

            var initializer = DefaultValues.Expression(feature);

            return initializer == null
                ? $"public {type} {name} {{ get; set; }}"
                : $"public {type} {name} {{ get; set; }} = {initializer};";
        }

        /// <summary>
        /// Emits the <c>QueryContainedElements</c> override (the analogue of EMF's <c>eContents()</c>) for a
        /// concrete class, yielding the value(s) of each of its containment features, or an empty string
        /// when the class has no containment features (the base returns none).
        /// </summary>
        /// <param name="eClass">the class</param>
        /// <returns>the override method, or an empty string</returns>
        private static string ContainmentTraversal(EClass eClass)
        {
            var containments = ClassFeatures(eClass)
                .Where(f => f is EReference { IsContainment: true })
                .ToList();

            if (containments.Count == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            builder.Append("        /// <summary>\n");
            builder.Append($"        /// Gets the elements directly contained by this <c>{CSharpNaming.Capitalize(eClass.Name)}</c>.\n");
            builder.Append("        /// </summary>\n");
            builder.Append("        /// <returns>the directly contained elements</returns>\n");
            builder.Append("        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()\n");
            builder.Append("        {\n");

            for (var i = 0; i < containments.Count; i++)
            {
                if (i > 0)
                {
                    builder.Append('\n');
                }

                var name = MemberName(containments[i]);

                if (CSharpType.IsCollection(containments[i]))
                {
                    builder.Append($"            foreach (var element in this.{name})\n");
                    builder.Append("            {\n");
                    builder.Append("                yield return element;\n");
                    builder.Append("            }\n");
                }
                else
                {
                    builder.Append($"            if (this.{name} != null)\n");
                    builder.Append("            {\n");
                    builder.Append($"                yield return this.{name};\n");
                    builder.Append("            }\n");
                }
            }

            builder.Append("        }");
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

        private static List<string> Usings(IEnumerable<EStructuralFeature> features)
        {
            return features
                .SelectMany(CSharpType.RequiredNamespaces)
                .Distinct()
                .OrderBy(n => n, StringComparer.Ordinal)
                .ToList();
        }

        private static List<string> Summary(EModelElement element, string fallback)
        {
            List<string> lines;

            try
            {
                // Read the raw GenModel documentation annotation rather than ECoreNetto's
                // QueryDocumentation(): the latter word-wraps long documentation, and that wrapping is
                // platform-dependent (it breaks at different positions on Windows and Linux, and can even
                // insert a space that is not in the source, e.g. "edge.All" -> "edge. All"), which makes
                // generation non-deterministic. The raw annotation value is the verbatim ecore text, so it
                // is identical on every platform. Its only line breaks are the source's own (deterministic).
                // Capella's short single-line documentation is unchanged by this.
                var documentation = RawDocumentation(element);

                lines = documentation == null
                    ? new List<string>()
                    : documentation.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n')
                        .Select(l => l.Trim())
                        .Where(l => l.Length > 0)
                        .ToList();
            }
            catch (Exception)
            {
                lines = new List<string>();
            }

            if (lines.Count == 0)
            {
                lines = new List<string> { fallback };
            }

            var result = new List<string> { "<summary>" };
            result.AddRange(lines);
            result.Add("</summary>");

            return result;
        }

        private const string GenModelAnnotationSource = "http://www.eclipse.org/emf/2002/GenModel";

        private static string? RawDocumentation(EModelElement element)
        {
            var annotation = element.EAnnotations?.FirstOrDefault(a => a.Source == GenModelAnnotationSource);

            return annotation != null && annotation.Details.TryGetValue("documentation", out var documentation)
                ? documentation
                : null;
        }

        private static string Humanize(string name)
        {
            var builder = new StringBuilder(name.Length + 8);

            foreach (var character in name)
            {
                if (char.IsUpper(character) && builder.Length > 0)
                {
                    builder.Append(' ');
                }

                builder.Append(char.ToLowerInvariant(character));
            }

            return builder.ToString();
        }
    }
}
