// ------------------------------------------------------------------------------------------------
// <copyright file="Requirement.cs" company="Starion Group S.A.">
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
    using System.Numerics;

    /// <summary>
    /// Definition of the <c>Requirement</c> class.
    /// </summary>
    public partial class Requirement : Auriga.Core.AurigaElement, Auriga.Model.Requirements.IRequirement
    {
        /// <summary>
        /// Gets the owned attributes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Requirements.IAttribute> OwnedAttributes => this.backingOwnedAttributes ??= new Auriga.Core.ContainerList<Auriga.Model.Requirements.IAttribute>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAttributes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Requirements.IAttribute> backingOwnedAttributes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned relations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Requirements.IAbstractRelation> OwnedRelations => this.backingOwnedRelations ??= new Auriga.Core.ContainerList<Auriga.Model.Requirements.IAbstractRelation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRelations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Requirements.IAbstractRelation> backingOwnedRelations;

        /// <summary>
        /// Gets or sets the req i f chapter name.
        /// </summary>
        public string ReqIFChapterName { get; set; }

        /// <summary>
        /// Gets or sets the req i f description.
        /// </summary>
        public string ReqIFDescription { get; set; }

        /// <summary>
        /// Gets or sets the req i f foreign i d.
        /// </summary>
        public BigInteger? ReqIFForeignID { get; set; }

        /// <summary>
        /// Gets or sets the req i f identifier.
        /// </summary>
        public string ReqIFIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the req i f long name.
        /// </summary>
        public string ReqIFLongName { get; set; }

        /// <summary>
        /// Gets or sets the req i f name.
        /// </summary>
        public string ReqIFName { get; set; }

        /// <summary>
        /// Gets or sets the req i f prefix.
        /// </summary>
        public string ReqIFPrefix { get; set; }

        /// <summary>
        /// Gets or sets the req i f text.
        /// </summary>
        public string ReqIFText { get; set; }

        /// <summary>
        /// Gets or sets the requirement type.
        /// </summary>
        public Auriga.Model.Requirements.IRequirementType RequirementType { get; set; }

        /// <summary>
        /// Gets or sets the requirement type proxy.
        /// </summary>
        public string RequirementTypeProxy { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Requirement</c>.
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

            foreach (var element in this.OwnedRelations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
