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

        private readonly string xmiRootNamespace;

        private readonly string outputSubfolder;

        private readonly HandlebarsTemplate<object, object> writerTemplate;

        private readonly HandlebarsTemplate<object, object> facadeTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriterGenerator"/> class.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        /// <param name="rootNamespace">
        /// the root namespace of the object model whose writers are generated (e.g. <c>Auriga.Model</c> or
        /// <c>Auriga.Diagram</c>); defaults to <c>Auriga.Model</c>
        /// </param>
        /// <param name="xmiRootNamespace">
        /// the root namespace of the generated writers (e.g. <c>Auriga.Xmi.Model</c> or
        /// <c>Auriga.Xmi.Diagram</c>); defaults to <c>Auriga.Xmi.Model</c>
        /// </param>
        /// <param name="outputSubfolder">
        /// the sub-folder of the <c>AutoGenXmiWriters</c> tree the writers are written into (<c>Model</c>
        /// for Capella or <c>Diagram</c> for Sirius), so both metamodels can live in the same project
        /// without one regeneration clearing the other's files; defaults to <c>Model</c>
        /// </param>
        public XmiWriterGenerator(string ecoreDirectory, string rootNamespace = NamingContext.DefaultModelRoot, string xmiRootNamespace = NamingContext.DefaultXmiRoot, string outputSubfolder = "Model")
        {
            this.ecoreDirectory = ecoreDirectory;
            this.rootNamespace = rootNamespace;
            this.xmiRootNamespace = xmiRootNamespace;
            this.outputSubfolder = outputSubfolder;

            var handlebars = Handlebars.Create();
            handlebars.RegisterXmiWriterHelper();
            this.writerTemplate = handlebars.Compile(LoadTemplate("xmi-writer-template.hbs"));
            this.facadeTemplate = handlebars.Compile(LoadTemplate("xmi-writer-facade-template.hbs"));
        }

        /// <summary>
        /// Generates the XMI-writer files and returns them keyed by repository-relative path
        /// (e.g. <c>AutoGenXmiWriters/Model/Pa/PhysicalFunctionWriter.cs</c>). A writer is emitted for every
        /// concrete class, plus the single facade. Pure function of the input, so calling it twice yields
        /// identical content.
        /// </summary>
        /// <returns>a path-keyed dictionary of generated file contents</returns>
        public IReadOnlyDictionary<string, string> Generate()
        {
            var rootPackages = MetamodelLoader.Load(this.ecoreDirectory);
            var allPackages = rootPackages.SelectMany(MetamodelLoader.AllPackages).ToList();

            using var _ = NamingContext.Use(this.rootNamespace, this.xmiRootNamespace, CSharpNaming.DetectMemberCollisions(allPackages));

            var concreteClasses = allPackages
                .SelectMany(p => p.EClassifiers.OfType<EClass>())
                .Where(XmiWriterHelper.IsConcrete)
                .OrderBy(c => $"{c.EPackage.Name}:{c.Name}", StringComparer.Ordinal)
                .ToList();

            var files = new SortedDictionary<string, string>(StringComparer.Ordinal);

            foreach (var eClass in concreteClasses)
            {
                var name = CSharpNaming.Capitalize(eClass.Name);
                files[$"AutoGenXmiWriters/{this.outputSubfolder}/{XmiWriterHelper.WriterFolder(eClass)}/{name}Writer.cs"] = Normalize(this.writerTemplate(eClass));
            }

            files[$"AutoGenXmiWriters/{this.outputSubfolder}/XmiElementWriterFacade.cs"] = Normalize(this.facadeTemplate(concreteClasses));

            return files;
        }

        /// <summary>
        /// Generates the writers and writes them into the supplied <c>Auriga.Xmi</c> project directory,
        /// clearing this generator's sub-folder of <c>AutoGenXmiWriters</c> first so removed writers do
        /// not linger. Only the configured sub-folder (e.g. <c>AutoGenXmiWriters/Model</c>) is cleared,
        /// never the whole tree, so the other metamodel's generated writers survive a regeneration.
        /// </summary>
        /// <param name="xmiProjectDirectory">the path of the <c>Auriga.Xmi</c> project</param>
        public void Write(string xmiProjectDirectory)
        {
            var files = this.Generate();

            var autoGen = Path.Combine(xmiProjectDirectory, "AutoGenXmiWriters", this.outputSubfolder);
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
