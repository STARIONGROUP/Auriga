// ------------------------------------------------------------------------------------------------
// <copyright file="RelationType.cs" company="Starion Group S.A.">
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

namespace Auriga.Requirements
{
    /// <summary>
    /// Definition of the <c>RelationType</c> class.
    /// </summary>
    public partial class RelationType : Auriga.AurigaElement, Auriga.Requirements.IRelationType
    {
        /// <summary>
        /// Gets the owned attributes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Requirements.IAttributeDefinition> OwnedAttributes => this.backingOwnedAttributes ??= new Auriga.ContainerList<Auriga.Requirements.IAttributeDefinition>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAttributes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Requirements.IAttributeDefinition> backingOwnedAttributes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

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

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
