// ------------------------------------------------------------------------------------------------
// <copyright file="ConcernSet.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Concern
{
    /// <summary>
    /// A set of many concerns.
    /// </summary>
    public partial class ConcernSet : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Concern.IConcernSet
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// All concerns
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Concern.IConcernDescription> OwnedConcernDescriptions => this.backingOwnedConcernDescriptions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.Concern.IConcernDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConcernDescriptions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Concern.IConcernDescription> backingOwnedConcernDescriptions;

        /// <summary>
        /// Gets the elements directly contained by this <c>ConcernSet</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedConcernDescriptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
