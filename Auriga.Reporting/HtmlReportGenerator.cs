// ------------------------------------------------------------------------------------------------
// <copyright file="HtmlReportGenerator.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Auriga.Reporting.Model;

    using HandlebarsDotNet;

    /// <summary>
    /// Renders the <see cref="ReportModel"/> into a self-contained static HTML site: a landing page, one
    /// page per package, class and enumeration, and a single bundled stylesheet. Every page is a flat file
    /// with a package-qualified name (e.g. <c>class.capellamodeller.Project.html</c>) so cross-links are
    /// plain relative file names that work from a web root or straight off the file system. Output is
    /// deterministic — a pure function of the vendored <c>.ecore</c> files.
    /// </summary>
    public sealed class HtmlReportGenerator
    {
        private const string StyleSheetFileName = "styles.css";

        private readonly string ecoreDirectory;

        private readonly HandlebarsTemplate<object, object> indexTemplate;

        private readonly HandlebarsTemplate<object, object> packageTemplate;

        private readonly HandlebarsTemplate<object, object> classTemplate;

        private readonly HandlebarsTemplate<object, object> enumTemplate;

        private readonly string styleSheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlReportGenerator"/> class.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        public HtmlReportGenerator(string ecoreDirectory)
        {
            this.ecoreDirectory = ecoreDirectory;

            var handlebars = Handlebars.Create();
            handlebars.RegisterTemplate("typelink", LoadResource("typelink.hbs"));
            handlebars.RegisterTemplate("doc", LoadResource("doc.hbs"));

            this.indexTemplate = handlebars.Compile(LoadResource("index-content.hbs"));
            this.packageTemplate = handlebars.Compile(LoadResource("package-content.hbs"));
            this.classTemplate = handlebars.Compile(LoadResource("class-content.hbs"));
            this.enumTemplate = handlebars.Compile(LoadResource("enum-content.hbs"));
            this.styleSheet = LoadResource(StyleSheetFileName);
        }

        /// <summary>
        /// Generates the report and returns its files keyed by file name (e.g. <c>index.html</c>,
        /// <c>class.pa.PhysicalComponent.html</c>, <c>styles.css</c>). Calling it twice yields identical
        /// content.
        /// </summary>
        /// <returns>a file-name-keyed dictionary of file contents</returns>
        public IReadOnlyDictionary<string, string> Generate()
        {
            var model = ReportModelBuilder.Build(this.ecoreDirectory);

            var files = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                [ReportModelBuilder.IndexHref] = this.Page("Capella metamodel", this.indexTemplate(model)),
                [StyleSheetFileName] = Normalize(this.styleSheet),
            };

            foreach (var package in model.Packages)
            {
                files[package.Href] = this.Page($"package {package.Name}", this.packageTemplate(package));

                foreach (var eClass in package.Classes)
                {
                    files[eClass.Href] = this.Page($"{eClass.Name} ({package.Name})", this.classTemplate(eClass));
                }

                foreach (var eEnum in package.Enums)
                {
                    files[eEnum.Href] = this.Page($"{eEnum.Name} ({package.Name})", this.enumTemplate(eEnum));
                }
            }

            return files;
        }

        /// <summary>
        /// Generates the report and writes it into <paramref name="outputDirectory"/>, creating the
        /// directory and overwriting any existing files.
        /// </summary>
        /// <param name="outputDirectory">the directory the site is written to</param>
        public void Write(string outputDirectory)
        {
            Directory.CreateDirectory(outputDirectory);

            foreach (var file in this.Generate())
            {
                File.WriteAllText(Path.Combine(outputDirectory, file.Key), file.Value);
            }
        }

        /// <summary>
        /// Wraps rendered page content in the shared HTML document shell (doctype, head with the bundled
        /// stylesheet, header navigation and footer).
        /// </summary>
        /// <param name="title">the page title</param>
        /// <param name="content">the rendered inner content</param>
        /// <returns>the complete HTML document</returns>
        private string Page(string title, string content)
        {
            var html =
                "<!doctype html>\n" +
                "<html lang=\"en\">\n" +
                "<head>\n" +
                "<meta charset=\"utf-8\">\n" +
                "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n" +
                $"<title>{Escape(title)} — Capella metamodel</title>\n" +
                $"<link rel=\"stylesheet\" href=\"{StyleSheetFileName}\">\n" +
                "</head>\n" +
                "<body>\n" +
                "<header><a class=\"home\" href=\"index.html\">Capella metamodel</a></header>\n" +
                "<main>\n" +
                content +
                "</main>\n" +
                "<footer>Generated from the vendored Capella <code>.ecore</code> metamodel by Auriga.Reporting.</footer>\n" +
                "</body>\n" +
                "</html>\n";

            return Normalize(html);
        }

        /// <summary>
        /// Minimally HTML-escapes a plain-text value for safe interpolation into markup.
        /// </summary>
        private static string Escape(string value)
        {
            return value
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;");
        }

        /// <summary>
        /// Normalizes rendered output to LF line endings so generation is deterministic regardless of the
        /// line endings the embedded templates were checked out with.
        /// </summary>
        private static string Normalize(string content)
        {
            return content.Replace("\r\n", "\n");
        }

        /// <summary>
        /// Loads an embedded template or asset by file name.
        /// </summary>
        private static string LoadResource(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(n => n.EndsWith("." + fileName, StringComparison.Ordinal));

            using var stream = assembly.GetManifestResourceStream(resourceName)!;
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}
