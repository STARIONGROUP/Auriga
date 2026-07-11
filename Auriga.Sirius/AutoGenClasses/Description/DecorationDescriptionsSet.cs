// ------------------------------------------------------------------------------------------------
// <copyright file="DecorationDescriptionsSet.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>DecorationDescriptionsSet</c> class.
    /// </summary>
    public partial class DecorationDescriptionsSet : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.IDecorationDescriptionsSet
    {
        /// <summary>
        /// Gets the decoration descriptions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDecorationDescription> DecorationDescriptions => this.backingDecorationDescriptions ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IDecorationDescription>(this);

        /// <summary>
        /// Backing field for <see cref="DecorationDescriptions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDecorationDescription> backingDecorationDescriptions;

        /// <summary>
        /// Gets the elements directly contained by this <c>DecorationDescriptionsSet</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.DecorationDescriptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
