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

        private readonly HandlebarsTemplate<object, object> readerTemplate;

        private readonly HandlebarsTemplate<object, object> facadeTemplate;

        private readonly HandlebarsTemplate<object, object> registryTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderGenerator"/> class.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        public XmiReaderGenerator(string ecoreDirectory)
        {
            this.ecoreDirectory = ecoreDirectory;

            var handlebars = Handlebars.Create();
            handlebars.RegisterXmiReaderHelper();
            this.readerTemplate = handlebars.Compile(LoadTemplate("xmi-reader-template.hbs"));
            this.facadeTemplate = handlebars.Compile(LoadTemplate("xmi-reader-facade-template.hbs"));
            this.registryTemplate = handlebars.Compile(LoadTemplate("xmi-namespace-registry-template.hbs"));
        }

        /// <summary>
        /// Generates the XMI-reader files and returns them keyed by repository-relative path
        /// (e.g. <c>AutoGenXmiReaders/Pa/PhysicalFunctionReader.cs</c>). A reader is emitted for every
        /// concrete class, plus the single facade and namespace-registry files. Pure function of the
        /// input, so calling it twice yields identical content.
        /// </summary>
        /// <returns>a path-keyed dictionary of generated file contents</returns>
        public IReadOnlyDictionary<string, string> Generate()
        {
            var rootPackages = MetamodelLoader.Load(this.ecoreDirectory);
            var allPackages = rootPackages.SelectMany(MetamodelLoader.AllPackages).ToList();

            var concreteClasses = allPackages
                .SelectMany(p => p.EClassifiers.OfType<EClass>())
                .Where(XmiReaderHelper.IsConcrete)
                .OrderBy(c => $"{c.EPackage.Name}:{c.Name}", StringComparer.Ordinal)
                .ToList();

            var files = new SortedDictionary<string, string>(StringComparer.Ordinal);

            foreach (var eClass in concreteClasses)
            {
                var name = CSharpNaming.Capitalize(eClass.Name);
                files[$"AutoGenXmiReaders/{XmiReaderHelper.ReaderFolder(eClass)}/{name}Reader.cs"] = Normalize(this.readerTemplate(eClass));
            }

            files["AutoGenXmiReaders/XmiReaderFacade.cs"] = Normalize(this.facadeTemplate(concreteClasses));

            var packagesWithNamespace = allPackages
                .Where(p => !string.IsNullOrEmpty(p.NsUri))
                .OrderBy(p => p.NsUri, StringComparer.Ordinal)
                .ToList();

            files["AutoGenXmiReaders/AutoGenNamespaceRegistry.cs"] = Normalize(this.registryTemplate(packagesWithNamespace));

            return files;
        }

        /// <summary>
        /// Generates the readers and writes them into the supplied <c>Auriga.Xmi</c> project directory,
        /// clearing the <c>AutoGenXmiReaders</c> folder first so removed readers do not linger.
        /// </summary>
        /// <param name="xmiProjectDirectory">the path of the <c>Auriga.Xmi</c> project</param>
        public void Write(string xmiProjectDirectory)
        {
            var files = this.Generate();

            var autoGen = Path.Combine(xmiProjectDirectory, "AutoGenXmiReaders");
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
