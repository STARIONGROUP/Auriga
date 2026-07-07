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

    /// <summary>
    /// Default <see cref="IContainerList{T}"/> implementation. Every element added is re-parented to the
    /// <see cref="Owner"/> by setting its <see cref="IAurigaElement.Container"/>; removed elements have
    /// their container reset to <c>null</c>. Elements cannot be <c>null</c> and cannot be added twice.
    /// </summary>
    /// <typeparam name="T">the element type, an <see cref="IAurigaElement"/></typeparam>
    public class ContainerList<T> : List<T>, IContainerList<T> where T : class, IAurigaElement
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
            : base(containerList ?? throw new ArgumentNullException(nameof(containerList)))
        {
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));

            if (!updateContaineeContainer)
            {
                return;
            }

            foreach (var element in containerList)
            {
                element.Container = this.Owner;
            }
        }

        /// <summary>
        /// Gets the element that owns this containment list.
        /// </summary>
        public IAurigaElement Owner { get; }

        /// <summary>
        /// Adds an element to the list and sets its <see cref="IAurigaElement.Container"/> to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="element">the element to add</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        /// thrown when <paramref name="element"/> is the <see cref="Owner"/> itself, or already exists in the list
        /// </exception>
        public new void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (ReferenceEquals(this.Owner, element))
            {
                throw new InvalidOperationException("The container shall not be added as a contained item to itself.");
            }

            if (this.Contains(element))
            {
                throw new InvalidOperationException($"The item already exists in the list: {element.Id}.");
            }

            element.Container = this.Owner;
            base.Add(element);
        }

        /// <summary>
        /// Adds a range of elements, setting each element's <see cref="IAurigaElement.Container"/> to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="elements">the elements to add</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="elements"/> is <c>null</c></exception>
        public new void AddRange(IEnumerable<T> elements)
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
        /// Gets or sets the element at the specified index; a set re-parents the value to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="index">the zero-based index</param>
        /// <returns>the element at <paramref name="index"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">thrown when <paramref name="index"/> is out of range</exception>
        /// <exception cref="ArgumentNullException">thrown when the assigned value is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">thrown when the assigned value already exists at a different index</exception>
        public new T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count - 1}");
                }

                return base[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count - 1}");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (this.Contains(value) && !ReferenceEquals(base[index], value))
                {
                    throw new InvalidOperationException($"The item already exists in the list: {value.Id}.");
                }

                value.Container = this.Owner;
                base[index] = value;
            }
        }

        /// <summary>
        /// Removes the first occurrence of an element and resets its <see cref="IAurigaElement.Container"/> to <c>null</c>.
        /// </summary>
        /// <param name="element">the element to remove</param>
        /// <returns><c>true</c> when the element was removed; otherwise <c>false</c></returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> is <c>null</c></exception>
        public new bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (!base.Remove(element))
            {
                return false;
            }

            element.Container = null;
            return true;
        }

        /// <summary>
        /// Removes the element at the specified index and resets its <see cref="IAurigaElement.Container"/> to <c>null</c>.
        /// </summary>
        /// <param name="index">the zero-based index of the element to remove</param>
        /// <exception cref="ArgumentOutOfRangeException">thrown when <paramref name="index"/> is out of range</exception>
        public new void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"index is {index}, valid range is 0 to {this.Count - 1}");
            }

            var element = base[index];
            base.RemoveAt(index);
            element.Container = null;
        }

        /// <summary>
        /// Removes all elements and resets each element's <see cref="IAurigaElement.Container"/> to <c>null</c>.
        /// </summary>
        public new void Clear()
        {
            foreach (var element in this)
            {
                element.Container = null;
            }

            base.Clear();
        }
    }
}
