// ------------------------------------------------------------------------------------------------
// <copyright file="RealModelReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using NUnit.Framework;

    /// <summary>
    /// Exercises the <see cref="XmiReader"/> against the real, non-trivial Capella models in
    /// <c>TestData</c> (the coffee-machine demo, the In-Flight Entertainment System, and the fragmented
    /// system model). These stress the reader far beyond the minimal fixture: every identified element
    /// must load into a typed object and the vast majority of intra-file cross-references must resolve.
    /// </summary>
    [TestFixture]
    public class RealModelReaderTestFixture
    {
        [Test]
        [TestCase("coffee-machine-demo.capella")]
        [TestCase("in-flight-entertainment-system.capella")]
        public void Verify_that_every_element_of_a_single_file_model_is_read(string fileName)
        {
            var path = ModelPath(fileName);
            var expectedIdentifiers = DistinctIdentifiers(path);

            var result = XmiReaderBuilder.Create().Build().Read(path);

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Has.Count.EqualTo(expectedIdentifiers.Count));
                Assert.That(result.Elements.Values, Has.All.Matches<IAurigaElement>(e => !string.IsNullOrEmpty(e.Id)));
                Assert.That(result.Elements.Keys, Is.EquivalentTo(expectedIdentifiers));
            });
        }

        [Test]
        [TestCase("coffee-machine-demo.capella")]
        [TestCase("in-flight-entertainment-system.capella")]
        public void Verify_that_intra_file_references_resolve(string fileName)
        {
            var result = XmiReaderBuilder.Create().Build().Read(ModelPath(fileName));

            var (total, resolved) = CountReferences(result);

            Assert.That(total, Is.GreaterThan(0), "the model is expected to contain cross-references");
            Assert.That(resolved, Is.EqualTo(total), "every intra-file reference of a single-file model should resolve");
        }

        [Test]
        public void Verify_that_a_model_with_external_references_still_loads()
        {
            // The fragmented system model carries a handful of external href references (out of scope for
            // this single-file reader). It must still load its intra-file graph without error.
            var result = XmiReaderBuilder.Create().Build().Read(ModelPath("sysmodel.capella"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Has.Count.GreaterThan(2000));
            });
        }

        private static (int Total, int Resolved) CountReferences(XmiReaderResult result)
        {
            var total = 0;
            var resolved = 0;

            foreach (var element in result.Elements.Values)
            {
                foreach (var id in element.SingleValueReferencePropertyIdentifiers.Values)
                {
                    total++;
                    if (result.Elements.ContainsKey(id))
                    {
                        resolved++;
                    }
                }

                foreach (var ids in element.MultiValueReferencePropertyIdentifiers.Values)
                {
                    foreach (var id in ids)
                    {
                        total++;
                        if (result.Elements.ContainsKey(id))
                        {
                            resolved++;
                        }
                    }
                }
            }

            return (total, resolved);
        }

        private static HashSet<string> DistinctIdentifiers(string path)
        {
            var text = File.ReadAllText(path);
            return Regex.Matches(text, "\\sid=\"([^\"]+)\"")
                .Select(m => m.Groups[1].Value)
                .ToHashSet(System.StringComparer.Ordinal);
        }

        private static string ModelPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }
    }
}
