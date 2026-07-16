// ------------------------------------------------------------------------------------------------
// <copyright file="EnumerationValueAttribute.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirements
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>EnumerationValueAttribute</c> class.
    /// </summary>
    public partial class EnumerationValueAttribute : Auriga.Core.AurigaElement, Auriga.Model.Requirements.IEnumerationValueAttribute
    {
        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        public Auriga.Model.Requirements.IAttributeDefinition Definition { get; set; }

        /// <summary>
        /// Gets or sets the definition proxy.
        /// </summary>
        public string DefinitionProxy { get; set; }

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the values.
        /// </summary>
        public List<Auriga.Model.Requirements.IEnumValue> Values { get; } = new List<Auriga.Model.Requirements.IEnumValue>();

        /// <summary>
        /// Gets the elements directly contained by this <c>EnumerationValueAttribute</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
