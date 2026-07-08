// ------------------------------------------------------------------------------------------------
// <copyright file="ContainerListTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="ContainerList{T}"/>, the owner-aware containment collection.
    /// </summary>
    [TestFixture]
    public class ContainerListTestFixture
    {
        private TestElement owner = null!;

        private ContainerList<TestElement> list = null!;

        [SetUp]
        public void SetUp()
        {
            this.owner = new TestElement { Id = "owner" };
            this.list = new ContainerList<TestElement>(this.owner);
        }

        [Test]
        public void Verify_that_the_constructor_throws_on_a_null_owner()
        {
            Assert.That(() => new ContainerList<TestElement>((IAurigaElement)null!), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Owner_is_exposed()
        {
            Assert.That(this.list.Owner, Is.SameAs(this.owner));
        }

        [Test]
        public void Verify_that_Add_sets_the_container_to_the_owner()
        {
            var element = new TestElement { Id = "child" };

            this.list.Add(element);

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Has.Count.EqualTo(1));
                Assert.That(element.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_Add_throws_on_null()
        {
            Assert.That(() => this.list.Add(null!), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Insert_sets_the_container_to_the_owner()
        {
            var element = new TestElement { Id = "child" };

            this.list.Insert(0, element);

            Assert.That(element.Container, Is.SameAs(this.owner));
        }

        [Test]
        public void Verify_that_adding_through_the_non_generic_list_sets_the_container()
        {
            // Adding through System.Collections.IList must still re-parent — this is the path the
            // reference resolver uses for href-resolved (cross-fragment) containment.
            var element = new TestElement { Id = "child" };

            ((System.Collections.IList)this.list).Add(element);

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Has.Count.EqualTo(1));
                Assert.That(element.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_Add_throws_when_adding_the_owner_to_itself()
        {
            Assert.That(() => this.list.Add(this.owner), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_Add_throws_on_a_duplicate()
        {
            var element = new TestElement { Id = "child" };
            this.list.Add(element);

            Assert.That(() => this.list.Add(element), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_AddRange_adds_all_and_sets_their_container()
        {
            var one = new TestElement { Id = "one" };
            var two = new TestElement { Id = "two" };

            this.list.AddRange(new[] { one, two });

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Has.Count.EqualTo(2));
                Assert.That(one.Container, Is.SameAs(this.owner));
                Assert.That(two.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_AddRange_throws_on_null()
        {
            Assert.That(() => this.list.AddRange(null!), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_the_indexer_getter_validates_the_range()
        {
            Assert.That(() => this.list[0], Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Verify_that_the_indexer_setter_reparents_the_value()
        {
            this.list.Add(new TestElement { Id = "child" });
            var replacement = new TestElement { Id = "replacement" };

            this.list[0] = replacement;

            Assert.Multiple(() =>
            {
                Assert.That(this.list[0], Is.SameAs(replacement));
                Assert.That(replacement.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_the_indexer_setter_throws_on_null_and_out_of_range()
        {
            this.list.Add(new TestElement { Id = "child" });

            Assert.Multiple(() =>
            {
                Assert.That(() => this.list[0] = null!, Throws.ArgumentNullException);
                Assert.That(() => this.list[5] = new TestElement(), Throws.TypeOf<ArgumentOutOfRangeException>());
            });
        }

        [Test]
        public void Verify_that_the_indexer_setter_throws_on_a_duplicate_at_another_index()
        {
            var one = new TestElement { Id = "one" };
            var two = new TestElement { Id = "two" };
            this.list.AddRange(new[] { one, two });

            Assert.That(() => this.list[0] = two, Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_Remove_resets_the_container()
        {
            var element = new TestElement { Id = "child" };
            this.list.Add(element);

            Assert.Multiple(() =>
            {
                Assert.That(this.list.Remove(element), Is.True);
                Assert.That(element.Container, Is.Null);
                Assert.That(this.list.Remove(new TestElement { Id = "absent" }), Is.False);
            });
        }

        [Test]
        public void Verify_that_Remove_throws_on_null()
        {
            Assert.That(() => this.list.Remove(null!), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_RemoveAt_resets_the_container()
        {
            var element = new TestElement { Id = "child" };
            this.list.Add(element);

            this.list.RemoveAt(0);

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Is.Empty);
                Assert.That(element.Container, Is.Null);
                Assert.That(() => this.list.RemoveAt(0), Throws.TypeOf<ArgumentOutOfRangeException>());
            });
        }

        [Test]
        public void Verify_that_Clear_resets_every_container()
        {
            var one = new TestElement { Id = "one" };
            var two = new TestElement { Id = "two" };
            this.list.AddRange(new[] { one, two });

            this.list.Clear();

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Is.Empty);
                Assert.That(one.Container, Is.Null);
                Assert.That(two.Container, Is.Null);
            });
        }

        [Test]
        public void Verify_that_the_copy_constructor_can_reparent_the_copied_elements()
        {
            var child = new TestElement { Id = "child" };
            this.list.Add(child);
            var newOwner = new TestElement { Id = "new-owner" };

            var copy = new ContainerList<TestElement>(this.list, newOwner, updateContaineeContainer: true);

            Assert.Multiple(() =>
            {
                Assert.That(copy, Has.Count.EqualTo(1));
                Assert.That(copy.Owner, Is.SameAs(newOwner));
                Assert.That(child.Container, Is.SameAs(newOwner));
            });
        }

        [Test]
        public void Verify_that_the_copy_constructor_leaves_containers_untouched_by_default()
        {
            var child = new TestElement { Id = "child" };
            this.list.Add(child);
            var newOwner = new TestElement { Id = "new-owner" };

            var copy = new ContainerList<TestElement>(this.list, newOwner);

            Assert.Multiple(() =>
            {
                Assert.That(copy, Has.Count.EqualTo(1));
                Assert.That(child.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_the_copy_constructor_throws_on_null_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new ContainerList<TestElement>(null!, this.owner), Throws.ArgumentNullException);
                Assert.That(() => new ContainerList<TestElement>(this.list, null!), Throws.ArgumentNullException);
            });
        }

        /// <summary>
        /// A minimal <see cref="IAurigaElement"/> test double.
        /// </summary>
        private sealed class TestElement : IAurigaElement
        {
            public string? Id { get; set; }

            public IAurigaElement? Container { get; set; }

            public string? SourceDocument { get; set; }

            public System.Collections.Generic.IDictionary<string, string> SingleValueReferencePropertyIdentifiers { get; }
                = new System.Collections.Generic.Dictionary<string, string>();

            public System.Collections.Generic.IDictionary<string, System.Collections.Generic.List<string>> MultiValueReferencePropertyIdentifiers { get; }
                = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>();

            public System.Collections.Generic.IEnumerable<IAurigaElement> QueryContainedElements()
            {
                yield break;
            }

            public System.Collections.Generic.IEnumerable<IAurigaElement> QueryAllContainedElements()
            {
                yield break;
            }
        }
    }
}
