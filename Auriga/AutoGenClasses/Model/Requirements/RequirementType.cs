// ------------------------------------------------------------------------------------------------
// <copyright file="RequirementType.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>RequirementType</c> class.
    /// </summary>
    public partial class RequirementType : Auriga.Core.AurigaElement, Auriga.Model.Requirements.IRequirementType
    {
        /// <summary>
        /// Gets the owned attributes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Requirements.IAttributeDefinition> OwnedAttributes => this.backingOwnedAttributes ??= new Auriga.Core.ContainerList<Auriga.Model.Requirements.IAttributeDefinition>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAttributes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Requirements.IAttributeDefinition> backingOwnedAttributes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

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
        /// Gets the elements directly contained by this <c>RequirementType</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedAttributes)
            {
                yield return element;
            }

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
