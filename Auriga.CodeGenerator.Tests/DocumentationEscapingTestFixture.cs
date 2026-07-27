// ------------------------------------------------------------------------------------------------
// <copyright file="DocumentationEscapingTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.CodeGenerator.Generators;

    using NUnit.Framework;

    /// <summary>
    /// Tests how the generator renders the ecore documentation annotation into a C# doc comment. The
    /// annotation is vendor prose: it contains bare ampersands, which are not valid in a doc comment, and
    /// inline markup such as <c>&lt;code&gt;</c>, which is. A throw-away <c>.ecore</c> holding one class
    /// per case is generated so both outcomes are asserted on real generator output.
    /// </summary>
    [TestFixture]
    public class DocumentationEscapingTestFixture
    {
        private string ecoreDirectory = null!;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(Path.GetTempPath(), "auriga-docfixture-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(this.ecoreDirectory);
            File.WriteAllText(Path.Combine(this.ecoreDirectory, "docfixture.ecore"), Fixture);

            this.files = new CorePocoGenerator(this.ecoreDirectory).Generate();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(this.ecoreDirectory))
            {
                Directory.Delete(this.ecoreDirectory, recursive: true);
            }
        }

        [Test]
        public void Verify_that_a_bare_ampersand_is_escaped()
        {
            // The annotation value arrives XML-decoded, so its '&' is a literal one and would otherwise
            // leave the emitted comment malformed (CS1570).
            Assert.That(this.Class("Ampersand"), Does.Contain("/// Tool that describes a Drag &amp; Drop operation."));
        }

        [Test]
        public void Verify_that_inline_markup_is_left_intact()
        {
            // <code> is valid in a doc comment and renders as intended, so escaping it would turn working
            // markup into visible angle brackets.
            Assert.That(this.Class("Markup"), Does.Contain("/// <code>true</code> if the node is resizable."));
        }

        [Test]
        public void Verify_that_documentation_that_does_not_parse_is_escaped_wholesale()
        {
            // An unclosed tag cannot be salvaged, so the prose is shown verbatim rather than emitted as a
            // broken comment.
            Assert.That(this.Class("Malformed"), Does.Contain("/// A &lt;br&gt; separated value &amp; a stray &lt; bracket."));
        }

        [Test]
        public void Verify_that_a_member_comment_is_escaped_as_well()
        {
            // Feature documentation goes through the same path as the class documentation.
            Assert.That(this.Class("Ampersand"), Does.Contain("/// The drag &amp; drop label."));
        }

        /// <summary>
        /// The generated class file for the fixture class with the supplied name.
        /// </summary>
        /// <param name="name">the simple class name</param>
        /// <returns>the generated source</returns>
        private string Class(string name)
        {
            var key = this.files.Keys.Single(k => k.StartsWith("AutoGenClasses/", StringComparison.Ordinal) && k.EndsWith($"/{name}.cs", StringComparison.Ordinal));

            return this.files[key];
        }

        /// <summary>
        /// A minimal metamodel whose classes carry the documentation shapes under test. The values are
        /// XML-escaped here exactly as they are in a vendored <c>.ecore</c>, so the loader hands the
        /// generator the same decoded prose it sees in production.
        /// </summary>
        private const string Fixture = """
            <?xml version="1.0" encoding="UTF-8"?>
            <ecore:EPackage xmi:version="2.0" xmlns:xmi="http://www.omg.org/XMI" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:ecore="http://www.eclipse.org/emf/2002/Ecore" name="docfixture" nsURI="http://stariongroup.eu/auriga/docfixture"
                nsPrefix="docfixture">
              <eClassifiers xsi:type="ecore:EClass" name="Ampersand">
                <eAnnotations source="http://www.eclipse.org/emf/2002/GenModel">
                  <details key="documentation" value="Tool that describes a Drag &amp; Drop operation."/>
                </eAnnotations>
                <eStructuralFeatures xsi:type="ecore:EAttribute" name="label" eType="ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EString">
                  <eAnnotations source="http://www.eclipse.org/emf/2002/GenModel">
                    <details key="documentation" value="The drag &amp; drop label."/>
                  </eAnnotations>
                </eStructuralFeatures>
              </eClassifiers>
              <eClassifiers xsi:type="ecore:EClass" name="Markup">
                <eAnnotations source="http://www.eclipse.org/emf/2002/GenModel">
                  <details key="documentation" value="&lt;code&gt;true&lt;/code&gt; if the node is resizable."/>
                </eAnnotations>
              </eClassifiers>
              <eClassifiers xsi:type="ecore:EClass" name="Malformed">
                <eAnnotations source="http://www.eclipse.org/emf/2002/GenModel">
                  <details key="documentation" value="A &lt;br&gt; separated value &amp; a stray &lt; bracket."/>
                </eAnnotations>
              </eClassifiers>
            </ecore:EPackage>
            """;
    }
}
