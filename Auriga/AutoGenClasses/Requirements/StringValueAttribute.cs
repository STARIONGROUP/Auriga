// ------------------------------------------------------------------------------------------------
// <copyright file="StringValueAttribute.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>StringValueAttribute</c> class.
    /// </summary>
    public partial class StringValueAttribute : Auriga.AurigaElement, Auriga.Requirements.IStringValueAttribute
    {
        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        public Auriga.Requirements.IAttributeDefinition Definition { get; set; }

        /// <summary>
        /// Gets or sets the definition proxy.
        /// </summary>
        public string DefinitionProxy { get; set; }

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
