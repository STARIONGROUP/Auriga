// ------------------------------------------------------------------------------------------------
// <copyright file="Folder.cs" company="Starion Group S.A.">
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
    using System.Numerics;

    /// <summary>
    /// Definition of the <c>Folder</c> class.
    /// </summary>
    public partial class Folder : Auriga.Core.AurigaElement, Auriga.Requirements.IFolder
    {
        /// <summary>
        /// Gets the owned attributes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Requirements.IAttribute> OwnedAttributes => this.backingOwnedAttributes ??= new Auriga.Core.ContainerList<Auriga.Requirements.IAttribute>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAttributes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Requirements.IAttribute> backingOwnedAttributes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned relations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Requirements.IAbstractRelation> OwnedRelations => this.backingOwnedRelations ??= new Auriga.Core.ContainerList<Auriga.Requirements.IAbstractRelation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRelations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Requirements.IAbstractRelation> backingOwnedRelations;

        /// <summary>
        /// Gets the owned requirements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Requirements.IRequirement> OwnedRequirements => this.backingOwnedRequirements ??= new Auriga.Core.ContainerList<Auriga.Requirements.IRequirement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRequirements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Requirements.IRequirement> backingOwnedRequirements;

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
        public Auriga.Requirements.IRequirementType RequirementType { get; set; }

        /// <summary>
        /// Gets or sets the requirement type proxy.
        /// </summary>
        public string RequirementTypeProxy { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Folder</c>.
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

            foreach (var element in this.OwnedRequirements)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
