// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaOutgoingRelation.cs" company="Starion Group S.A.">
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

namespace Auriga.CapellaRequirements
{
    /// <summary>
    /// Definition of the <c>CapellaOutgoingRelation</c> class.
    /// </summary>
    public partial class CapellaOutgoingRelation : Auriga.AurigaElement, Auriga.CapellaRequirements.ICapellaOutgoingRelation
    {
        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets or sets the relation type.
        /// </summary>
        public Auriga.Requirements.IRelationType RelationType { get; set; }

        /// <summary>
        /// Gets or sets the relation type proxy.
        /// </summary>
        public string RelationTypeProxy { get; set; }

        /// <summary>
        /// Gets or sets the req i f description.
        /// </summary>
        public string ReqIFDescription { get; set; }

        /// <summary>
        /// Gets or sets the req i f identifier.
        /// </summary>
        public string ReqIFIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the req i f long name.
        /// </summary>
        public string ReqIFLongName { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Capellacore.ICapellaElement Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Requirements.IRequirement Target { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>CapellaOutgoingRelation</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
