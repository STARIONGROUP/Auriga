// ------------------------------------------------------------------------------------------------
// <copyright file="ObjectModelGenerator.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Auriga.CodeGenerator.Models;

    using ECoreNetto;
    using ECoreNetto.Extensions;
    using ECoreNetto.Resource;

    using HandlebarsDotNet;

    /// <summary>
    /// Generates the Auriga Capella object model (interfaces, implementation classes and enums) from
    /// the vendored Capella <c>.ecore</c> files, following <c>docs/codegen-design.md</c>. The whole
    /// metamodel is loaded into one <see cref="ResourceSet"/> (the graph is cyclic and cannot be
    /// generated file-by-file). By default every package is generated (the v1 scope of issue #1); a
    /// caller may instead name a subset of packages, in which case implementation classes are emitted
    /// only for those packages while the interfaces and enums they transitively reference are emitted
    /// so the generated code still compiles.
    /// </summary>
    public sealed class ObjectModelGenerator
    {
        /// <summary>
        /// Member names supplied by <c>Auriga.IAurigaElement</c>; a same-named Capella feature is
        /// mapped onto the inherited member rather than re-declared (which would hide the base).
        /// </summary>
        private static readonly HashSet<string> ReservedMembers = new(StringComparer.Ordinal) { "Id", "Container" };

        private readonly string ecoreDirectory;

        private readonly HandlebarsTemplate<object, object> enumTemplate;

        private readonly HandlebarsTemplate<object, object> interfaceTemplate;

        private readonly HandlebarsTemplate<object, object> classTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectModelGenerator"/> class.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        public ObjectModelGenerator(string ecoreDirectory)
        {
            this.ecoreDirectory = ecoreDirectory;

            var handlebars = Handlebars.Create();
            this.enumTemplate = handlebars.Compile(LoadTemplate("core-enumeration-template.hbs"));
            this.interfaceTemplate = handlebars.Compile(LoadTemplate("core-poco-interface-template.hbs"));
            this.classTemplate = handlebars.Compile(LoadTemplate("core-poco-class-template.hbs"));
        }

        /// <summary>
        /// Generates the object model and returns the files as a dictionary keyed by repository-relative
        /// path (e.g. <c>AutoGenInterfaces/Pa/IPhysicalFunction.cs</c>). When no target package names are
        /// supplied the whole metamodel is generated (the confirmed v1 scope, issue #1); otherwise only
        /// the named packages get implementation classes, and the interfaces and enums those classes
        /// transitively reference are emitted so the output still compiles. Each classifier is written to
        /// a per-package sub-folder so classes with the same simple name in different packages (e.g.
        /// <c>Folder</c> in <c>capellamodeller</c> and <c>Requirements</c>) do not collide. Pure function
        /// of the input, so calling it twice yields identical content.
        /// </summary>
        /// <param name="targetPackageNames">
        /// the Ecore package names whose concrete classes are emitted, or none to generate the whole metamodel
        /// </param>
        /// <returns>a path-keyed dictionary of generated file contents</returns>
        public IReadOnlyDictionary<string, string> Generate(params string[] targetPackageNames)
        {
            var rootPackages = this.LoadMetamodel();
            var allPackages = rootPackages.SelectMany(AllPackages).ToList();

            var targetPackages = targetPackageNames.Length == 0
                ? allPackages
                : allPackages.Where(p => targetPackageNames.Contains(p.Name, StringComparer.Ordinal)).ToList();

            if (targetPackages.Count == 0)
            {
                throw new InvalidOperationException(
                    $"None of the target packages [{string.Join(", ", targetPackageNames)}] were found in the metamodel.");
            }

            var (closureClasses, closureEnums) = ComputeClosure(targetPackages);
            var targetPackageSet = new HashSet<EPackage>(targetPackages);

            var files = new SortedDictionary<string, string>(StringComparer.Ordinal);

            foreach (var eEnum in closureEnums.OrderBy(CSharpNaming.EnumType, StringComparer.Ordinal))
            {
                var name = CSharpNaming.Capitalize(eEnum.Name);
                files[$"AutoGenEnumeration/{PackageFolder(eEnum)}/{name}.cs"] = this.enumTemplate(this.BuildEnum(eEnum));
            }

            foreach (var eClass in closureClasses.OrderBy(CSharpNaming.InterfaceType, StringComparer.Ordinal))
            {
                var name = CSharpNaming.Capitalize(eClass.Name);
                files[$"AutoGenInterfaces/{PackageFolder(eClass)}/I{name}.cs"] = this.interfaceTemplate(this.BuildInterface(eClass));

                if (targetPackageSet.Contains(eClass.EPackage) && !eClass.Abstract && !eClass.Interface)
                {
                    files[$"AutoGenClasses/{PackageFolder(eClass)}/{name}.cs"] = this.classTemplate(this.BuildClass(eClass));
                }
            }

            return files;
        }

        /// <summary>
        /// The single-level output sub-folder for a classifier: the PascalCased name of its immediate
        /// Ecore package (e.g. <c>Pa</c>, <c>Deployment</c>, <c>Requirements</c>).
        /// </summary>
        private static string PackageFolder(EClassifier classifier)
        {
            return CSharpNaming.Capitalize(classifier.EPackage.Name);
        }

        /// <summary>
        /// Whether an <see cref="EClass"/> belongs to the Capella metamodel (and is therefore generated).
        /// Ecore built-ins reached as a supertype or feature type — notably <c>ecore::EObject</c>, whose
        /// <see cref="EClassifier.EPackage"/> is not part of the loaded resource set — return false.
        /// </summary>
        private static bool IsGenerated(EClass eClass)
        {
            return eClass?.EPackage != null;
        }

        /// <summary>
        /// Generates the object model and writes it into the supplied <c>Auriga</c> project directory,
        /// clearing the <c>AutoGen*</c> folders first so removed types do not linger.
        /// </summary>
        /// <param name="aurigaProjectDirectory">the path of the <c>Auriga</c> project</param>
        /// <param name="targetPackageNames">
        /// the Ecore package names whose concrete classes are emitted, or none to write the whole metamodel
        /// </param>
        public void Write(string aurigaProjectDirectory, params string[] targetPackageNames)
        {
            var files = this.Generate(targetPackageNames);

            foreach (var folder in new[] { "AutoGenEnumeration", "AutoGenInterfaces", "AutoGenClasses" })
            {
                var path = Path.Combine(aurigaProjectDirectory, folder);
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, recursive: true);
                }

                Directory.CreateDirectory(path);
            }

            foreach (var file in files)
            {
                var path = Path.Combine(aurigaProjectDirectory, file.Key.Replace('/', Path.DirectorySeparatorChar));
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                File.WriteAllText(path, file.Value);
            }
        }

        private List<EPackage> LoadMetamodel()
        {
            var resourceSet = new ResourceSet(null);
            var rootPackages = new List<EPackage>();

            foreach (var file in Directory.GetFiles(this.ecoreDirectory, "*.ecore").OrderBy(f => f, StringComparer.Ordinal))
            {
                var uri = new Uri(file);
                var resource = resourceSet.Resources.SingleOrDefault(x => x.URI == uri) ?? resourceSet.CreateResource(uri);
                var root = resource.IsLoaded()
                    ? resource.Contents.OfType<EPackage>().FirstOrDefault()
                      ?? resource.GetEObject($"{Path.GetFileNameWithoutExtension(file)}.ecore#/") as EPackage
                    : resource.Load(null);

                if (root != null)
                {
                    rootPackages.Add(root);
                }
            }

            return rootPackages;
        }

        private static (HashSet<EClass> Classes, HashSet<EEnum> Enums) ComputeClosure(IEnumerable<EPackage> targetPackages)
        {
            var classes = new HashSet<EClass>();
            var enums = new HashSet<EEnum>();
            var queue = new Queue<EClass>();

            foreach (var eClass in targetPackages.SelectMany(p => p.EClassifiers.OfType<EClass>()))
            {
                queue.Enqueue(eClass);
            }

            while (queue.Count > 0)
            {
                var eClass = queue.Dequeue();
                if (!classes.Add(eClass))
                {
                    continue;
                }

                foreach (var super in eClass.ESuperTypes.Where(IsGenerated))
                {
                    queue.Enqueue(super);
                }

                foreach (var feature in eClass.EStructuralFeatures)
                {
                    switch (feature.EType)
                    {
                        case EEnum eEnum:
                            enums.Add(eEnum);
                            break;
                        case EClass referenced when IsGenerated(referenced):
                            queue.Enqueue(referenced);
                            break;
                    }
                }
            }

            return (classes, enums);
        }

        private EnumModel BuildEnum(EEnum eEnum)
        {
            var name = CSharpNaming.Capitalize(eEnum.Name);
            var literals = eEnum.ELiterals.ToList();

            return new EnumModel
            {
                Namespace = CSharpNaming.Namespace(eEnum),
                Name = name,
                Documentation = Summary(eEnum, $"The <c>{name}</c> enumeration."),
                Literals = literals.Select((literal, index) => new LiteralModel
                {
                    Name = CSharpNaming.Escape(CSharpNaming.Capitalize(literal.Name)),
                    Documentation = Summary(literal, $"The <c>{CSharpNaming.Capitalize(literal.Name)}</c> literal."),
                    IsLast = index == literals.Count - 1
                }).ToList()
            };
        }

        private InterfaceModel BuildInterface(EClass eClass)
        {
            var name = CSharpNaming.Capitalize(eClass.Name);
            var supertypes = eClass.ESuperTypes.Where(IsGenerated).ToList();
            var extends = supertypes.Count > 0
                ? " : " + string.Join(", ", supertypes.Select(CSharpNaming.InterfaceType))
                : " : Auriga.IAurigaElement";

            var features = eClass.EStructuralFeatures
                .Where(f => f.EType != null && !IsReserved(f))
                .OrderBy(MemberName, StringComparer.Ordinal)
                .ToList();

            return new InterfaceModel
            {
                Namespace = CSharpNaming.Namespace(eClass),
                Usings = Usings(features),
                Name = name,
                Documentation = Summary(eClass, $"Definition of the <c>{name}</c> interface."),
                Extends = extends,
                Members = features.Select(f => BuildMember(f, forInterface: true)).ToList()
            };
        }

        private ClassModel BuildClass(EClass eClass)
        {
            var className = CSharpNaming.Capitalize(eClass.Name);
            var features = new List<EStructuralFeature>();
            var seen = new HashSet<string>(StringComparer.Ordinal);

            foreach (var feature in eClass.AllEStructuralFeatures.Where(f => f.EType != null && !IsReserved(f)))
            {
                var memberName = CSharpNaming.Escape(CSharpNaming.Capitalize(feature.Name));

                if (!seen.Add(memberName))
                {
                    continue;
                }

                if (string.Equals(memberName, className, StringComparison.Ordinal))
                {
                    throw new NotSupportedException(
                        $"Feature '{eClass.Name}.{feature.Name}' collides with its enclosing type name; " +
                        "member/type name-collision handling is deferred to #8.");
                }

                features.Add(feature);
            }

            features = features.OrderBy(MemberName, StringComparer.Ordinal).ToList();

            return new ClassModel
            {
                Namespace = CSharpNaming.Namespace(eClass),
                Usings = Usings(features),
                Name = className,
                Documentation = Summary(eClass, $"Definition of the <c>{className}</c> class."),
                Bases = $" : Auriga.AurigaElement, {CSharpNaming.InterfaceType(eClass)}",
                Members = features.Select(f => BuildMember(f, forInterface: false)).ToList()
            };
        }

        private static MemberModel BuildMember(EStructuralFeature feature, bool forInterface)
        {
            var name = MemberName(feature);
            var type = CSharpType.MemberType(feature);
            var baseType = CSharpType.BaseType(feature.EType);
            var computed = CSharpType.IsComputed(feature);
            var collection = CSharpType.IsCollection(feature);
            var containment = feature is EReference { IsContainment: true };
            var writable = !computed && !collection;
            var summary = $"{(writable ? "Gets or sets" : "Gets")} the {Humanize(feature.Name)}.";

            string declaration;

            if (forInterface)
            {
                var accessor = writable ? "{ get; set; }" : "{ get; }";
                declaration = $"{type} {name} {accessor}";
            }
            else if (computed)
            {
                declaration = collection
                    ? $"public {type} {name} => Enumerable.Empty<{baseType}>();"
                    : $"public {type} {name} => default;";
            }
            else if (collection && containment)
            {
                var field = "backing" + name;
                declaration = $"public {type} {name} => this.{field} ??= new Auriga.ContainerList<{baseType}>(this);\n\n" +
                              $"        /// <summary>\n" +
                              $"        /// Backing field for <see cref=\"{name}\"/>.\n" +
                              $"        /// </summary>\n" +
                              $"        private {type} {field};";
            }
            else if (collection)
            {
                declaration = $"public {type} {name} {{ get; }} = new List<{baseType}>();";
            }
            else
            {
                declaration = $"public {type} {name} {{ get; set; }}";
            }

            return new MemberModel
            {
                Documentation = Summary(feature, summary),
                Declaration = declaration
            };
        }

        private static string MemberName(EStructuralFeature feature)
        {
            return CSharpNaming.Escape(CSharpNaming.Capitalize(feature.Name));
        }

        private static bool IsReserved(EStructuralFeature feature)
        {
            return ReservedMembers.Contains(CSharpNaming.Capitalize(feature.Name));
        }

        private static IReadOnlyList<string> Usings(IEnumerable<EStructuralFeature> features)
        {
            return features
                .SelectMany(CSharpType.RequiredNamespaces)
                .Distinct()
                .OrderBy(n => n, StringComparer.Ordinal)
                .ToList();
        }

        private static IReadOnlyList<string> Summary(EModelElement element, string fallback)
        {
            List<string> lines;

            try
            {
                lines = element.QueryDocumentation().Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
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

        private static IEnumerable<EPackage> AllPackages(EPackage package)
        {
            yield return package;

            foreach (var nested in package.ESubPackages.SelectMany(AllPackages))
            {
                yield return nested;
            }
        }

        private static string LoadTemplate(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(n => n.EndsWith(fileName, StringComparison.Ordinal));

            using var stream = assembly.GetManifestResourceStream(resourceName)!;
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}
