// ------------------------------------------------------------------------------------------------
// <copyright file="XmlNamesTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests <see cref="XmlNames"/> against the vendored GMF <c>notation.ecore</c>: a feature carrying
    /// an <c>ExtendedMetaData</c> <c>name</c> detail serializes under that XML name
    /// (<c>persistedChildren</c> → <c>children</c>, <c>persistedEdges</c> → <c>edges</c> — the renames
    /// GMF hard-codes in its generated package initialization), every other feature keeps its Ecore
    /// feature name, and annotations of any other source (e.g. GenModel documentation) are ignored.
    /// This also pins the vendored annotations themselves: losing them on a re-vendor fails here first.
    /// </summary>
    [TestFixture]
    public class XmlNamesTestFixture
    {
        private EPackage notation = null!;

        private EPackage viewpoint = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore-sirius");
            var resourceSet = new ResourceSet(null);

            this.notation = LoadRootPackage(resourceSet, Path.Combine(ecoreDirectory, "notation.ecore"));
            this.viewpoint = LoadRootPackage(resourceSet, Path.Combine(ecoreDirectory, "viewpoint.ecore"));
        }

        [Test]
        public void Verify_that_an_extended_meta_data_name_overrides_the_feature_name()
        {
            var view = (EClass)this.notation.EClassifiers.Single(c => c.Name == "View");
            var diagram = (EClass)this.notation.EClassifiers.Single(c => c.Name == "Diagram");

            Assert.Multiple(() =>
            {
                Assert.That(XmlNames.XmlName(Feature(view, "persistedChildren")), Is.EqualTo("children"));
                Assert.That(XmlNames.XmlName(Feature(diagram, "persistedEdges")), Is.EqualTo("edges"));
            });
        }

        [Test]
        public void Verify_that_a_feature_without_the_annotation_keeps_its_name()
        {
            var view = (EClass)this.notation.EClassifiers.Single(c => c.Name == "View");
            var node = (EClass)this.notation.EClassifiers.Single(c => c.Name == "Node");

            Assert.Multiple(() =>
            {
                Assert.That(XmlNames.XmlName(Feature(view, "styles")), Is.EqualTo("styles"));
                Assert.That(XmlNames.XmlName(Feature(view, "element")), Is.EqualTo("element"));
                Assert.That(XmlNames.XmlName(Feature(node, "layoutConstraint")), Is.EqualTo("layoutConstraint"));
            });
        }

        [Test]
        public void Verify_that_an_annotation_without_a_usable_name_detail_is_ignored()
        {
            // An ExtendedMetaData annotation that carries no name detail (e.g. only kind), or an empty
            // name value, must fall back to the Ecore feature name. No vendored metamodel has these
            // shapes, so a synthetic package pins them.
            var directory = Path.Combine(Path.GetTempPath(), "auriga-xmlnames-" + Guid.NewGuid().ToString("N"));
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
                    "name=\"synthetic\" nsURI=\"http://example.org/synthetic\" nsPrefix=\"synthetic\">" +
                    "<eClassifiers xsi:type=\"ecore:EClass\" name=\"Holder\">" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"kindOnly\" " +
                    "eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EString\">" +
                    "<eAnnotations source=\"http:///org/eclipse/emf/ecore/util/ExtendedMetaData\">" +
                    "<details key=\"kind\" value=\"element\"/>" +
                    "</eAnnotations>" +
                    "</eStructuralFeatures>" +
                    "<eStructuralFeatures xsi:type=\"ecore:EAttribute\" name=\"emptyName\" " +
                    "eType=\"ecore:EDataType http://www.eclipse.org/emf/2002/Ecore#//EString\">" +
                    "<eAnnotations source=\"http:///org/eclipse/emf/ecore/util/ExtendedMetaData\">" +
                    "<details key=\"name\" value=\"\"/>" +
                    "</eAnnotations>" +
                    "</eStructuralFeatures>" +
                    "</eClassifiers>" +
                    "</ecore:EPackage>");

                var synthetic = LoadRootPackage(new ResourceSet(null), path);
                var holder = (EClass)synthetic.EClassifiers.Single(c => c.Name == "Holder");

                Assert.Multiple(() =>
                {
                    Assert.That(XmlNames.XmlName(Feature(holder, "kindOnly")), Is.EqualTo("kindOnly"));
                    Assert.That(XmlNames.XmlName(Feature(holder, "emptyName")), Is.EqualTo("emptyName"));
                });
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        [Test]
        public void Verify_that_annotations_of_other_sources_are_ignored()
        {
            // The Sirius viewpoint metamodel is full of GenModel documentation annotations; none of
            // them may leak into the serialized XML name.
            var annotated = this.viewpoint.EClassifiers
                .OfType<EClass>()
                .SelectMany(c => c.EStructuralFeatures)
                .First(f => f.EAnnotations != null && f.EAnnotations.Any());

            Assert.That(XmlNames.XmlName(annotated), Is.EqualTo(annotated.Name));
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
