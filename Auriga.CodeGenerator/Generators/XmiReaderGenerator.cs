// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderGenerator.cs" company="Starion Group S.A.">
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
    /// Generates the <c>Auriga.Xmi</c> per-type XMI readers (one per concrete class), the reader facade
    /// that dispatches an <c>xsi:type</c> to its reader, and the namespace registry that maps a Capella
    /// namespace URI to its package. It reads the same metamodel as the <see cref="CorePocoGenerator"/>
    /// and, like it, drives the templates directly from the ECoreNetto POCOs through registered helpers.
    /// This mirrors uml4net's separate <c>XmiReaderGenerator</c>.
    /// </summary>
    public sealed class XmiReaderGenerator
    {
        private readonly string ecoreDirectory;

        private readonly string rootNamespace;

        private readonly string xmiRootNamespace;

        private readonly string outputSubfolder;

        private readonly HandlebarsTemplate<object, object> readerTemplate;

        private readonly HandlebarsTemplate<object, object> facadeTemplate;

        private readonly HandlebarsTemplate<object, object> registryTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderGenerator"/> class.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        /// <param name="rootNamespace">
        /// the root namespace of the object model whose readers are generated (e.g. <c>Auriga.Model</c> or
        /// <c>Auriga.Diagram</c>); defaults to <c>Auriga.Model</c>
        /// </param>
        /// <param name="xmiRootNamespace">
        /// the root namespace of the generated readers (e.g. <c>Auriga.Xmi.Model</c> or
        /// <c>Auriga.Xmi.Diagram</c>); defaults to <c>Auriga.Xmi.Model</c>
        /// </param>
        /// <param name="outputSubfolder">
        /// the sub-folder of the <c>AutoGenXmiReaders</c> tree the readers are written into (<c>Model</c>
        /// for Capella or <c>Diagram</c> for Sirius), so both metamodels can live in the same project
        /// without one regeneration clearing the other's files; defaults to <c>Model</c>
        /// </param>
        public XmiReaderGenerator(string ecoreDirectory, string rootNamespace = NamingContext.DefaultModelRoot, string xmiRootNamespace = NamingContext.DefaultXmiRoot, string outputSubfolder = "Model")
        {
            this.ecoreDirectory = ecoreDirectory;
            this.rootNamespace = rootNamespace;
            this.xmiRootNamespace = xmiRootNamespace;
            this.outputSubfolder = outputSubfolder;

            var handlebars = Handlebars.Create();
            handlebars.RegisterXmiReaderHelper();
            this.readerTemplate = handlebars.Compile(LoadTemplate("xmi-reader-template.hbs"));
            this.facadeTemplate = handlebars.Compile(LoadTemplate("xmi-reader-facade-template.hbs"));
            this.registryTemplate = handlebars.Compile(LoadTemplate("xmi-namespace-registry-template.hbs"));
        }

        /// <summary>
        /// Generates the XMI-reader files and returns them keyed by repository-relative path
        /// (e.g. <c>AutoGenXmiReaders/Model/Pa/PhysicalFunctionReader.cs</c>). A reader is emitted for every
        /// concrete class, plus the single facade and namespace-registry files. Pure function of the
        /// input, so calling it twice yields identical content.
        /// </summary>
        /// <returns>a path-keyed dictionary of generated file contents</returns>
        public IReadOnlyDictionary<string, string> Generate()
        {
            var rootPackages = MetamodelLoader.Load(this.ecoreDirectory);
            var allPackages = rootPackages.SelectMany(MetamodelLoader.AllPackages).ToList();

            using var _ = NamingContext.Use(this.rootNamespace, this.xmiRootNamespace, CSharpNaming.DetectMemberCollisions(allPackages));

            var concreteClasses = allPackages
                .SelectMany(p => p.EClassifiers.OfType<EClass>())
                .Where(XmiReaderHelper.IsConcrete)
                .OrderBy(c => $"{c.EPackage.Name}:{c.Name}", StringComparer.Ordinal)
                .ToList();

            var files = new SortedDictionary<string, string>(StringComparer.Ordinal);

            foreach (var eClass in concreteClasses)
            {
                var name = CSharpNaming.Capitalize(eClass.Name);
                files[$"AutoGenXmiReaders/{this.outputSubfolder}/{XmiReaderHelper.ReaderFolder(eClass)}/{name}Reader.cs"] = Normalize(this.readerTemplate(eClass));
            }

            files[$"AutoGenXmiReaders/{this.outputSubfolder}/XmiReaderFacade.cs"] = Normalize(this.facadeTemplate(concreteClasses));

            var packagesWithNamespace = allPackages
                .Where(p => !string.IsNullOrEmpty(p.NsUri))
                .OrderBy(p => p.NsUri, StringComparer.Ordinal)
                .ToList();

            files[$"AutoGenXmiReaders/{this.outputSubfolder}/AutoGenNamespaceRegistry.cs"] = Normalize(this.registryTemplate(packagesWithNamespace));

            return files;
        }

        /// <summary>
        /// Generates the readers and writes them into the supplied <c>Auriga.Xmi</c> project directory,
        /// clearing this generator's sub-folder of <c>AutoGenXmiReaders</c> first so removed readers do
        /// not linger. Only the configured sub-folder (e.g. <c>AutoGenXmiReaders/Model</c>) is cleared,
        /// never the whole tree, so the other metamodel's generated readers survive a regeneration.
        /// </summary>
        /// <param name="xmiProjectDirectory">the path of the <c>Auriga.Xmi</c> project</param>
        public void Write(string xmiProjectDirectory)
        {
            var files = this.Generate();

            var autoGen = Path.Combine(xmiProjectDirectory, "AutoGenXmiReaders", this.outputSubfolder);
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
