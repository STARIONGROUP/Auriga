// ------------------------------------------------------------------------------------------------
// <copyright file="HrefReferenceTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for <see cref="HrefReference"/>: the parsing and (de)relativization of the EMF/Capella
    /// cross-reference token forms shared by the reader, the resolver and the writer.
    /// </summary>
    [TestFixture]
    public class HrefReferenceTestFixture
    {
        [Test]
        public void Verify_that_an_intra_document_token_parses_to_an_empty_path()
        {
            var (path, id) = HrefReference.Parse("a0000000-0000-4000-8000-000000000001");

            Assert.Multiple(() =>
            {
                Assert.That(path, Is.Empty);
                Assert.That(id, Is.EqualTo("a0000000-0000-4000-8000-000000000001"));
            });
        }

        [Test]
        public void Verify_that_a_same_document_hash_token_parses_to_an_empty_path()
        {
            var (path, id) = HrefReference.Parse("#abc");

            Assert.Multiple(() =>
            {
                Assert.That(path, Is.Empty);
                Assert.That(id, Is.EqualTo("abc"));
            });
        }

        [Test]
        public void Verify_that_a_cross_document_token_parses_the_path_and_id()
        {
            var (path, id) = HrefReference.Parse("fragments/SA.capellafragment#abc");

            Assert.Multiple(() =>
            {
                Assert.That(path, Is.EqualTo("fragments/SA.capellafragment"));
                Assert.That(id, Is.EqualTo("abc"));
            });
        }

        [Test]
        public void Verify_that_a_typed_cross_fragment_token_strips_the_xsi_type_prefix()
        {
            var (path, id) = HrefReference.Parse("org.polarsys.capella.core.data.pa:PhysicalComponent ../sysmodel.capella#abc");

            Assert.Multiple(() =>
            {
                Assert.That(path, Is.EqualTo("../sysmodel.capella"));
                Assert.That(id, Is.EqualTo("abc"));
            });
        }

        [Test]
        public void Verify_that_canonicalize_resolves_a_sibling_fragment()
        {
            var canonical = HrefReference.Canonicalize("sysmodel.capella", "fragments/SA.capellafragment");

            Assert.That(canonical, Is.EqualTo("fragments/SA.capellafragment"));
        }

        [Test]
        public void Verify_that_canonicalize_collapses_a_parent_traversal()
        {
            var canonical = HrefReference.Canonicalize("fragments/SA.capellafragment", "../sysmodel.capella");

            Assert.That(canonical, Is.EqualTo("sysmodel.capella"));
        }

        [Test]
        public void Verify_that_canonicalize_skips_current_directory_and_empty_segments()
        {
            var canonical = HrefReference.Canonicalize("a/b.capella", "./c.capella");

            Assert.That(canonical, Is.EqualTo("a/c.capella"));
        }

        [Test]
        public void Verify_that_canonicalize_ignores_a_parent_traversal_past_the_root()
        {
            var canonical = HrefReference.Canonicalize(null, "../x.capella");

            Assert.That(canonical, Is.EqualTo("x.capella"));
        }

        [Test]
        public void Verify_that_canonicalize_url_decodes_the_path()
        {
            var canonical = HrefReference.Canonicalize("a/b.capella", "sub%20dir/c.capella");

            Assert.That(canonical, Is.EqualTo("a/sub dir/c.capella"));
        }

        [Test]
        public void Verify_that_relativize_computes_a_sibling_fragment_path()
        {
            var relative = HrefReference.Relativize("sysmodel.capella", "fragments/SA.capellafragment");

            Assert.That(relative, Is.EqualTo("fragments/SA.capellafragment"));
        }

        [Test]
        public void Verify_that_relativize_computes_a_parent_traversal()
        {
            var relative = HrefReference.Relativize("fragments/SA.capellafragment", "sysmodel.capella");

            Assert.That(relative, Is.EqualTo("../sysmodel.capella"));
        }

        [Test]
        public void Verify_that_relativize_shares_a_common_prefix()
        {
            var relative = HrefReference.Relativize("a/b/x.capella", "a/c/y.capella");

            Assert.That(relative, Is.EqualTo("../c/y.capella"));
        }

        [Test]
        public void Verify_that_relativize_handles_a_null_referring_document()
        {
            var relative = HrefReference.Relativize(null, "fragments/x.capellafragment");

            Assert.That(relative, Is.EqualTo("fragments/x.capellafragment"));
        }

        [Test]
        public void Verify_that_relativize_url_encodes_path_segments()
        {
            var relative = HrefReference.Relativize("a.capella", "sub dir/c.capella");

            Assert.That(relative, Is.EqualTo("sub%20dir/c.capella"));
        }

        [Test]
        public void Verify_that_relativize_and_canonicalize_are_inverses()
        {
            const string from = "fragments/SA.capellafragment";
            const string to = "fragments/deep/PA.capellafragment";

            var relative = HrefReference.Relativize(from, to);
            var canonical = HrefReference.Canonicalize(from, relative);

            Assert.That(canonical, Is.EqualTo(to));
        }
    }
}
