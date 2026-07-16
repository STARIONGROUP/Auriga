// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterGenerator.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Auriga.CodeGenerator.Helpers;

    using ECoreNetto;

    using HandlebarsDotNet;

    /// <summary>
    /// Generates the <c>Auriga.Xmi</c> per-type XMI writers (one per concrete class) and the writer facade
    /// that dispatches an element's runtime type to its writer. It reads the same metamodel as the
    /// <see cref="XmiReaderGenerator"/> and is its inverse: where the reader parses XMI into the object
    /// graph, the writer serializes the object graph back to XMI.
    /// </summary>
    public sealed class XmiWriterGenerator
    {
        private readonly string ecoreDirectory;

        private readonly string rootNamespace;

        private readonly HandlebarsTemplate<object, object> writerTemplate;

        private readonly HandlebarsTemplate<object, object> facadeTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriterGenerator"/> class.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        /// <param name="rootNamespace">
        /// the root namespace of the object model whose writers are generated (e.g. <c>Auriga</c> or
        /// <c>Auriga.Sirius</c>); the writer namespaces are derived from it. Defaults to <c>Auriga</c>
        /// </param>
        public XmiWriterGenerator(string ecoreDirectory, string rootNamespace = NamingContext.DefaultModelRoot)
        {
            this.ecoreDirectory = ecoreDirectory;
            this.rootNamespace = rootNamespace;

            var handlebars = Handlebars.Create();
            handlebars.RegisterXmiWriterHelper();
            this.writerTemplate = handlebars.Compile(LoadTemplate("xmi-writer-template.hbs"));
            this.facadeTemplate = handlebars.Compile(LoadTemplate("xmi-writer-facade-template.hbs"));
        }

        /// <summary>
        /// Generates the XMI-writer files and returns them keyed by repository-relative path
        /// (e.g. <c>AutoGenXmiWriters/Pa/PhysicalFunctionWriter.cs</c>). A writer is emitted for every
        /// concrete class, plus the single facade. Pure function of the input, so calling it twice yields
        /// identical content.
        /// </summary>
        /// <returns>a path-keyed dictionary of generated file contents</returns>
        public IReadOnlyDictionary<string, string> Generate()
        {
            var rootPackages = MetamodelLoader.Load(this.ecoreDirectory);
            var allPackages = rootPackages.SelectMany(MetamodelLoader.AllPackages).ToList();

            using var _ = NamingContext.Use(this.rootNamespace, CSharpNaming.DetectMemberCollisions(allPackages));

            var concreteClasses = allPackages
                .SelectMany(p => p.EClassifiers.OfType<EClass>())
                .Where(XmiWriterHelper.IsConcrete)
                .OrderBy(c => $"{c.EPackage.Name}:{c.Name}", StringComparer.Ordinal)
                .ToList();

            var files = new SortedDictionary<string, string>(StringComparer.Ordinal);

            foreach (var eClass in concreteClasses)
            {
                var name = CSharpNaming.Capitalize(eClass.Name);
                files[$"AutoGenXmiWriters/{XmiWriterHelper.WriterFolder(eClass)}/{name}Writer.cs"] = Normalize(this.writerTemplate(eClass));
            }

            files["AutoGenXmiWriters/XmiElementWriterFacade.cs"] = Normalize(this.facadeTemplate(concreteClasses));

            return files;
        }

        /// <summary>
        /// Generates the writers and writes them into the supplied <c>Auriga.Xmi</c> project directory,
        /// clearing the <c>AutoGenXmiWriters</c> folder first so removed writers do not linger.
        /// </summary>
        /// <param name="xmiProjectDirectory">the path of the <c>Auriga.Xmi</c> project</param>
        public void Write(string xmiProjectDirectory)
        {
            var files = this.Generate();

            var autoGen = Path.Combine(xmiProjectDirectory, "AutoGenXmiWriters");
            if (Directory.Exists(autoGen))
            {
                Directory.Delete(autoGen, recursive: true);
            }

            Directory.CreateDirectory(autoGen);

            foreach (var file in files)
            {
                var path = Path.Combine(xmiProjectDirectory, file.Key.Replace('/', Path.DirectorySeparatorChar));
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                File.WriteAllText(path, file.Value);
            }
        }

        private static string Normalize(string content)
        {
            return content.Replace("\r\n", "\n");
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
