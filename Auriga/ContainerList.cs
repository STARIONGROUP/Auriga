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
    using System.Collections.Generic;

    /// <summary>
    /// Default <see cref="IContainerList{T}"/> implementation. Every element added is re-parented to
    /// the <see cref="Owner"/> by setting its <see cref="IAurigaElement.Container"/>.
    /// </summary>
    /// <typeparam name="T">the element type, an <see cref="IAurigaElement"/></typeparam>
    public class ContainerList<T> : List<T>, IContainerList<T> where T : notnull, IAurigaElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerList{T}"/> class.
        /// </summary>
        /// <param name="owner">the element that owns this containment list</param>
        public ContainerList(IAurigaElement owner)
        {
            this.Owner = owner;
        }

        /// <summary>
        /// Gets the element that owns this containment list.
        /// </summary>
        public IAurigaElement Owner { get; }

        /// <summary>
        /// Adds an element to the list and sets its container to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="item">the element to add</param>
        public new void Add(T item)
        {
            item.Container = this.Owner;
            base.Add(item);
        }
    }
}
