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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

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

        // ---- ownership-transfer semantics: containment is exclusive (reject, not steal) -------------

        [Test]
        public void Verify_that_Add_rejects_an_element_already_owned_by_another_container()
        {
            var element = new TestElement { Id = "child" };
            new ContainerList<TestElement>(new TestElement { Id = "other-owner" }).Add(element);

            Assert.That(() => this.list.Add(element), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_Insert_rejects_an_element_already_owned_by_another_container()
        {
            var element = new TestElement { Id = "child" };
            new ContainerList<TestElement>(new TestElement { Id = "other-owner" }).Add(element);

            Assert.That(() => this.list.Insert(0, element), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_adding_to_a_second_list_of_the_same_owner_is_rejected()
        {
            // Exclusivity holds even within one owner: an element already held by one of the owner's
            // containment features may not also be added to another.
            var element = new TestElement { Id = "child" };
            this.list.Add(element);

            var secondList = new ContainerList<TestElement>(this.owner);

            Assert.That(() => secondList.Add(element), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_an_element_can_be_moved_between_containers_after_removal()
        {
            var otherOwner = new TestElement { Id = "other-owner" };
            var otherList = new ContainerList<TestElement>(otherOwner);
            var element = new TestElement { Id = "child" };
            otherList.Add(element);

            // The documented move flow: remove from the current container, then add to the new one.
            otherList.Remove(element);
            this.list.Add(element);

            Assert.Multiple(() =>
            {
                Assert.That(otherList, Is.Empty);
                Assert.That(this.list, Has.Count.EqualTo(1));
                Assert.That(element.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_the_indexer_setter_rejects_an_element_owned_by_another_container()
        {
            this.list.Add(new TestElement { Id = "child" });

            var owned = new TestElement { Id = "owned" };
            new ContainerList<TestElement>(new TestElement { Id = "other-owner" }).Add(owned);

            Assert.That(() => this.list[0] = owned, Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_setting_an_element_onto_its_own_index_is_idempotent()
        {
            var element = new TestElement { Id = "child" };
            this.list.Add(element);

            Assert.Multiple(() =>
            {
                Assert.That(() => this.list[0] = element, Throws.Nothing);
                Assert.That(this.list[0], Is.SameAs(element));
                Assert.That(element.Container, Is.SameAs(this.owner));
            });
        }

        // ---- non-bypassable: mutating through base-class / interface references still maintains it ---

        [Test]
        public void Verify_that_mutating_through_generic_interface_references_maintains_the_container()
        {
            var a = new TestElement { Id = "a" };
            var b = new TestElement { Id = "b" };
            var c = new TestElement { Id = "c" };

            ((ICollection<TestElement>)this.list).Add(a);   // ICollection<T>.Add
            ((IList<TestElement>)this.list).Insert(1, b);   // IList<T>.Insert
            ((IList<TestElement>)this.list)[0] = c;         // IList<T> indexer set, replacing a

            Assert.Multiple(() =>
            {
                Assert.That(a.Container, Is.Null, "the replaced element's container is reset");
                Assert.That(b.Container, Is.SameAs(this.owner));
                Assert.That(c.Container, Is.SameAs(this.owner));
            });

            ((ICollection<TestElement>)this.list).Remove(b);   // ICollection<T>.Remove
            Assert.That(b.Container, Is.Null);

            ((ICollection<TestElement>)this.list).Clear();     // ICollection<T>.Clear
            Assert.That(c.Container, Is.Null);
        }

        [Test]
        public void Verify_that_adding_through_a_base_Collection_reference_sets_the_container()
        {
            var element = new TestElement { Id = "child" };

            ((Collection<TestElement>)this.list).Add(element);

            Assert.That(element.Container, Is.SameAs(this.owner));
        }

        // ---- Move: reorder within the list without changing ownership -------------------------------

        [Test]
        public void Verify_that_Move_reorders_the_element_and_leaves_containers_intact()
        {
            var a = new TestElement { Id = "a" };
            var b = new TestElement { Id = "b" };
            var c = new TestElement { Id = "c" };
            this.list.AddRange(new[] { a, b, c });

            this.list.Move(0, 2);

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Is.EqualTo(new[] { b, c, a }));
                Assert.That(a.Container, Is.SameAs(this.owner));
                Assert.That(b.Container, Is.SameAs(this.owner));
                Assert.That(c.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_Move_backwards_reorders_the_element()
        {
            var a = new TestElement { Id = "a" };
            var b = new TestElement { Id = "b" };
            var c = new TestElement { Id = "c" };
            this.list.AddRange(new[] { a, b, c });

            this.list.Move(2, 0);

            Assert.That(this.list, Is.EqualTo(new[] { c, a, b }));
        }

        [Test]
        public void Verify_that_Move_to_the_same_index_is_a_noop()
        {
            var a = new TestElement { Id = "a" };
            var b = new TestElement { Id = "b" };
            this.list.AddRange(new[] { a, b });

            this.list.Move(1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(this.list, Is.EqualTo(new[] { a, b }));
                Assert.That(b.Container, Is.SameAs(this.owner));
            });
        }

        [Test]
        public void Verify_that_Move_throws_on_an_out_of_range_index()
        {
            this.list.Add(new TestElement { Id = "a" });

            Assert.Multiple(() =>
            {
                Assert.That(() => this.list.Move(-1, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => this.list.Move(3, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => this.list.Move(0, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => this.list.Move(0, 1), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(this.list, Has.Count.EqualTo(1), "a rejected move leaves the list unchanged");
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

            public string? XsiType { get; set; }

            public string? XmiNamespaceUri { get; set; }

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
