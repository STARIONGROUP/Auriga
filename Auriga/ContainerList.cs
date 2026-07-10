// ------------------------------------------------------------------------------------------------
// <copyright file="ContainerList.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Default <see cref="IContainerList{T}"/> implementation. Every element added is re-parented to the
    /// <see cref="Owner"/> by setting its <see cref="IAurigaElement.Container"/>; removed elements have
    /// their container reset to <c>null</c>. It derives from <see cref="Collection{T}"/> and maintains the
    /// back-reference in the protected <see cref="Collection{T}.InsertItem"/>, <see cref="Collection{T}.SetItem"/>,
    /// <see cref="Collection{T}.RemoveItem"/> and <see cref="Collection{T}.ClearItems"/> hooks, so every
    /// mutation path — <c>Add</c>, <c>Insert</c>, the indexer, <c>Remove</c>, <c>RemoveAt</c>, <c>Clear</c>,
    /// and the non-generic <see cref="System.Collections.IList"/> members — maintains it, and it cannot be
    /// bypassed through a base-interface reference (unlike a <c>List{T}</c>-with-<c>new</c> design).
    ///
    /// <para><b>Ownership is exclusive (reject, not steal).</b> Containment is a single-parent relationship,
    /// so an element that already has a <see cref="IAurigaElement.Container"/> cannot be added to another
    /// containment list: <see cref="InsertItem"/> and <see cref="SetItem"/> throw an
    /// <see cref="InvalidOperationException"/> rather than silently re-pointing its container (which would
    /// leave the element in two lists). To move an element between containers, remove it from its current
    /// container first, then add it to the new one. This mirrors SysML2.NET's "reject when already owned"
    /// choice — see <c>docs/containment-list.md</c> for the full rationale and the three-way comparison with
    /// uml4net and SysML2.NET.</para>
    /// </summary>
    /// <typeparam name="T">the element type, an <see cref="IAurigaElement"/></typeparam>
    public class ContainerList<T> : Collection<T>, IContainerList<T> where T : class, IAurigaElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerList{T}"/> class.
        /// </summary>
        /// <param name="owner">the element that owns this containment list</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="owner"/> is <c>null</c></exception>
        public ContainerList(IAurigaElement owner)
        {
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerList{T}"/> class from an existing list.
        /// </summary>
        /// <param name="containerList">the list whose elements are copied</param>
        /// <param name="owner">the element that owns this containment list</param>
        /// <param name="updateContaineeContainer">
        /// when <c>true</c>, the <see cref="IAurigaElement.Container"/> of every copied element is set to
        /// <paramref name="owner"/>; the default is <c>false</c>
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="containerList"/> or <paramref name="owner"/> is <c>null</c>
        /// </exception>
        public ContainerList(IContainerList<T> containerList, IAurigaElement owner, bool updateContaineeContainer = false)
            : base(new List<T>(containerList ?? throw new ArgumentNullException(nameof(containerList))))
        {
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));

            if (!updateContaineeContainer)
            {
                return;
            }

            foreach (var element in this)
            {
                element.Container = this.Owner;
            }
        }

        /// <summary>
        /// Gets the element that owns this containment list.
        /// </summary>
        public IAurigaElement Owner { get; }

        /// <summary>
        /// Adds a range of elements, setting each element's <see cref="IAurigaElement.Container"/> to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="elements">the elements to add</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="elements"/> is <c>null</c></exception>
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Removes the first occurrence of an element, resetting its container via the removal hook and
        /// rejecting a <c>null</c> argument. (The container reset itself happens in
        /// <see cref="RemoveItem"/>, so removing through any base interface is equally safe.)
        /// </summary>
        /// <param name="item">the element to remove</param>
        /// <returns><c>true</c> when the element was removed; otherwise <c>false</c></returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="item"/> is <c>null</c></exception>
        public new bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return base.Remove(item);
        }

        /// <summary>
        /// Inserts an element (the target of every <c>Add</c>/<c>Insert</c>) and sets its
        /// <see cref="IAurigaElement.Container"/> to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="index">the zero-based index at which to insert</param>
        /// <param name="item">the element to insert</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="item"/> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        /// thrown when <paramref name="item"/> is the <see cref="Owner"/> itself, is already in the list, or
        /// already belongs to another container (see the ownership-transfer note on the class)
        /// </exception>
        protected override void InsertItem(int index, T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (ReferenceEquals(this.Owner, item))
            {
                throw new InvalidOperationException("The container shall not be added as a contained item to itself.");
            }

            if (this.Contains(item))
            {
                throw new InvalidOperationException($"The item already exists in the list: {item.Id}.");
            }

            if (item.Container != null)
            {
                throw new InvalidOperationException($"The item already belongs to another container: {item.Id}. Remove it from its current container before adding it here.");
            }

            base.InsertItem(index, item);
            item.Container = this.Owner;
        }

        /// <summary>
        /// Replaces the element at the specified index (the indexer set), re-parenting the new value to the
        /// <see cref="Owner"/> and clearing the container of the replaced element.
        /// </summary>
        /// <param name="index">the zero-based index to replace</param>
        /// <param name="item">the replacement element</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="item"/> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        /// thrown when <paramref name="item"/> is the <see cref="Owner"/> itself, is already at a different
        /// index, or already belongs to another container (see the ownership-transfer note on the class)
        /// </exception>
        protected override void SetItem(int index, T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (ReferenceEquals(this.Owner, item))
            {
                throw new InvalidOperationException("The container shall not be added as a contained item to itself.");
            }

            var existingIndex = this.IndexOf(item);
            if (existingIndex >= 0 && existingIndex != index)
            {
                throw new InvalidOperationException($"The item already exists in the list: {item.Id}.");
            }

            if (existingIndex < 0 && item.Container != null)
            {
                throw new InvalidOperationException($"The item already belongs to another container: {item.Id}. Remove it from its current container before adding it here.");
            }

            var replaced = this[index];
            base.SetItem(index, item);

            if (!ReferenceEquals(replaced, item))
            {
                replaced.Container = null;
            }

            item.Container = this.Owner;
        }

        /// <summary>
        /// Removes the element at the specified index (the target of <c>Remove</c>/<c>RemoveAt</c>) and
        /// resets its <see cref="IAurigaElement.Container"/> to <c>null</c>.
        /// </summary>
        /// <param name="index">the zero-based index of the element to remove</param>
        protected override void RemoveItem(int index)
        {
            var element = this[index];
            base.RemoveItem(index);
            element.Container = null;
        }

        /// <summary>
        /// Removes all elements and resets each element's <see cref="IAurigaElement.Container"/> to <c>null</c>.
        /// </summary>
        protected override void ClearItems()
        {
            foreach (var element in this)
            {
                element.Container = null;
            }

            base.ClearItems();
        }
    }
}
