// ------------------------------------------------------------------------------------------------
// <copyright file="DefaultValuesTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests
{
    using System;
    using System.IO;
    using System.Linq;

    using Auriga.CodeGenerator.Helpers;

    using ECoreNetto;
    using ECoreNetto.Resource;

    using NUnit.Framework;

    /// <summary>
    /// Tests <see cref="DefaultValues"/> against the vendored Sirius/GMF metamodels: a scalar
    /// feature's <c>defaultValueLiteral</c> resolves to the C# initializer expression the generated
    /// classes use (and the generated writers pass back as the suppression default), and features
    /// without an expressible default resolve to <c>null</c> (issue #76).
    /// </summary>
    [TestFixture]
    public class DefaultValuesTestFixture
    {
        private EPackage notation = null!;

        private EPackage diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore-sirius");
            var resourceSet = new ResourceSet(null);

            this.notation = LoadRootPackage(resourceSet, Path.Combine(ecoreDirectory, "notation.ecore"));
            this.diagram = LoadRootPackage(resourceSet, Path.Combine(ecoreDirectory, "diagram.ecore"));
        }

        [Test]
        public void Verify_that_enum_defaults_resolve_to_the_literal_expression()
        {
            var edgeStyle = (EClass)this.diagram.EClassifiers.Single(c => c.Name == "EdgeStyle");

            // The enum type is namespace-rooted by the ambient NamingContext, exactly as the Sirius
            // generators configure it for a generation run.
            using (NamingContext.Use("Auriga.Diagram", "Auriga.Xmi.Diagram"))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(DefaultValues.Expression(Feature(edgeStyle, "targetArrow")), Is.EqualTo("Auriga.Diagram.Diagram.EdgeArrows.InputArrow"));
                    Assert.That(DefaultValues.Expression(Feature(edgeStyle, "sourceArrow")), Is.EqualTo("Auriga.Diagram.Diagram.EdgeArrows.NoDecoration"));
                });
            }
        }

        [Test]
        public void Verify_that_scalar_defaults_resolve_to_typed_literals()
        {
            var size = (EClass)this.notation.EClassifiers.Single(c => c.Name == "Size");
            var fontStyle = (EClass)this.notation.EClassifiers.Single(c => c.Name == "FontStyle");
            var fillStyle = (EClass)this.notation.EClassifiers.Single(c => c.Name == "FillStyle");
            var edgeStyle = (EClass)this.diagram.EClassifiers.Single(c => c.Name == "EdgeStyle");

            Assert.Multiple(() =>
            {
                Assert.That(DefaultValues.Expression(Feature(size, "width")), Is.EqualTo("-1"), "GMF's unset-size sentinel");
                Assert.That(DefaultValues.Expression(Feature(fontStyle, "fontName")), Is.EqualTo("\"Tahoma\""));
                Assert.That(DefaultValues.Expression(Feature(fontStyle, "fontHeight")), Is.EqualTo("9"));
                Assert.That(DefaultValues.Expression(Feature(fontStyle, "bold")), Is.EqualTo("false"));
                Assert.That(DefaultValues.Expression(Feature(fillStyle, "fillColor")), Is.EqualTo("16777215"), "white, GMF-packed");
                Assert.That(DefaultValues.Expression(Feature(edgeStyle, "size")), Is.EqualTo("1"));
            });
        }

        [Test]
        public void Verify_that_features_without_an_expressible_default_resolve_to_null()
        {
            var view = (EClass)this.notation.EClassifiers.Single(c => c.Name == "View");
            var bendpoints = (EClass)this.notation.EClassifiers.Single(c => c.Name == "RelativeBendpoints");
            var fontStyle = (EClass)this.notation.EClassifiers.Single(c => c.Name == "FontStyle");

            Assert.Multiple(() =>
            {
                Assert.That(DefaultValues.Expression(Feature(bendpoints, "points")), Is.Null, "no default declared");
                Assert.That(DefaultValues.Expression(Feature(view, "element")), Is.Null, "references never take defaults");
                Assert.That(DefaultValues.Expression(Feature(view, "persistedChildren")), Is.Null, "collections never take defaults");
                Assert.That(DefaultValues.Expression(Feature(view, "type")), Is.EqualTo("\"\""), "an explicitly empty string default is expressible");
                Assert.That(DefaultValues.Expression(Feature(fontStyle, "fontColor")), Is.EqualTo("0"), "black is expressible");
            });
        }

        [Test]
        public void Verify_the_remaining_type_mappings_on_a_synthetic_package()
        {
            // The vendored metamodels only default ints, booleans, strings and enums; a synthetic
            // package pins the remaining scalar mappings, the escaping, and the skip-on-garbage rules.
            var directory = Path.Combine(Path.GetTempPath(), "auriga-defaults-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);

            try
            {
                var path = Path.Combine(directory, "synthetic.ecore");
                File.WriteAllText(
                    path,
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<ecore:EPackage xmi:version=\"2.0\" xmlns:xmi=\"http://www.omg.org/XMI\" " +
                    "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                    "xmlns:ecore=\"http://www.eclipse.org/emf/2002/Ecore\" " +
                    "name=\"synthetic\" nsURI=\"http://example.org/defaults\" nsPrefix=\"synthetic\">" +
                    "<eClassifiers xsi:type=\"ecore:EEnum\" name=\"Mood\">" +
                    "<eLiterals name=\"calm\"/><eLiterals name=\"wild\" value=\"1\"/>" +
                    "</eClassifiers>" +
                    "<eClassifiers xsi:type=\"ecore:EClass\" name=\"Holder\">" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aLong\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//ELong\" defaultValueLiteral=\"42\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aFloat\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EFloat\" defaultValueLiteral=\"1.5\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aDouble\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EDouble\" defaultValueLiteral=\"2.25\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aDecimal\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EBigDecimal\" defaultValueLiteral=\"9.99\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aChar\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EChar\" defaultValueLiteral=\"x\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aQuote\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EString\" defaultValueLiteral=\"say &quot;hi&quot;\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"garbageInt\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EInt\" defaultValueLiteral=\"abc\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"garbageBool\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EBoolean\" defaultValueLiteral=\"maybe\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"garbageLong\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//ELong\" defaultValueLiteral=\"abc\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aTick\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EChar\" defaultValueLiteral=\"'\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aBackslash\" eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EString\" defaultValueLiteral=\"a\\b\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"aMood\" eType=\"#//Mood\" defaultValueLiteral=\"wild\"/>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"ghostMood\" eType=\"#//Mood\" defaultValueLiteral=\"missing\"/>" +
                    "</eClassifiers>" +
                    "</ecore:EPackage>");

                var synthetic = LoadRootPackage(new ResourceSet(null), path);
                var holder = (EClass)synthetic.EClassifiers.Single(c => c.Name == "Holder");

                Assert.Multiple(() =>
                {
                    Assert.That(DefaultValues.Expression(Feature(holder, "aLong")), Is.EqualTo("42L"));
                    Assert.That(DefaultValues.Expression(Feature(holder, "aFloat")), Is.EqualTo("1.5f"));
                    Assert.That(DefaultValues.Expression(Feature(holder, "aDouble")), Is.EqualTo("2.25d"));
                    Assert.That(DefaultValues.Expression(Feature(holder, "aDecimal")), Is.EqualTo("9.99m"));
                    Assert.That(DefaultValues.Expression(Feature(holder, "aChar")), Is.EqualTo("'x'"));
                    Assert.That(DefaultValues.Expression(Feature(holder, "aQuote")), Is.EqualTo("\"say \\\"hi\\\"\""));
                    Assert.That(DefaultValues.Expression(Feature(holder, "garbageInt")), Is.Null, "an unparsable literal is skipped");
                    Assert.That(DefaultValues.Expression(Feature(holder, "garbageBool")), Is.Null);
                    Assert.That(DefaultValues.Expression(Feature(holder, "garbageLong")), Is.Null);
                    Assert.That(DefaultValues.Expression(Feature(holder, "aTick")), Is.EqualTo("'\\''"), "a quote character escapes");
                    Assert.That(DefaultValues.Expression(Feature(holder, "aBackslash")), Is.EqualTo("\"a\\\\b\""), "a backslash escapes");
                    Assert.That(DefaultValues.Expression(Feature(holder, "aMood")), Is.EqualTo("Auriga.Model.Synthetic.Mood.Wild"));
                    Assert.That(DefaultValues.Expression(Feature(holder, "ghostMood")), Is.Null, "a literal absent from the enum is skipped");
                });
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        /// <summary>
        /// Loads the root <see cref="EPackage"/> of the ecore file at the supplied path, reusing a
        /// resource the resource set may already have demand-loaded.
        /// </summary>
        /// <param name="resourceSet">the resource set the file is loaded into</param>
        /// <param name="path">the ecore file path</param>
        /// <returns>the root package</returns>
        private static EPackage LoadRootPackage(ResourceSet resourceSet, string path)
        {
            var uri = new Uri(path);
            var resource = resourceSet.Resources.SingleOrDefault(x => x.URI == uri) ?? resourceSet.CreateResource(uri);

            return resource.IsLoaded()
                ? (EPackage)resource.Contents.OfType<EPackage>().First()
                : resource.Load(null)!;
        }

        /// <summary>
        /// Gets the named structural feature declared directly on the class.
        /// </summary>
        /// <param name="eClass">the declaring class</param>
        /// <param name="name">the Ecore feature name</param>
        /// <returns>the structural feature</returns>
        private static EStructuralFeature Feature(EClass eClass, string name)
        {
            return eClass.EStructuralFeatures.Single(f => f.Name == name);
        }
    }
}
