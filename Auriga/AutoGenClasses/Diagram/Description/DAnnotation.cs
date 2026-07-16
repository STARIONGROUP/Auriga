// ------------------------------------------------------------------------------------------------
// <copyright file="DAnnotation.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Diagram.Viewpoint.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>DAnnotation</c> class.
    /// </summary>
    public partial class DAnnotation : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.IDAnnotation
    {
        /// <summary>
        /// Gets the details.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Core.IAurigaElement> Details => this.backingDetails ??= new Auriga.Core.ContainerList<Auriga.Core.IAurigaElement>(this);

        /// <summary>
        /// Backing field for <see cref="Details"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Core.IAurigaElement> backingDetails;

        /// <summary>
        /// Gets the references.
        /// </summary>
        public List<object> References { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DAnnotation</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Details)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
