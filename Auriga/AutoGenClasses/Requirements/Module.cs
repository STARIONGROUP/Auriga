// ------------------------------------------------------------------------------------------------
// <copyright file="Module.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Module</c> class.
    /// </summary>
    public partial class Module : Auriga.AurigaElement, Auriga.Requirements.IModule
    {
        /// <summary>
        /// Gets or sets the module type.
        /// </summary>
        public Auriga.Requirements.IModuleType ModuleType { get; set; }

        /// <summary>
        /// Gets the owned attributes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Requirements.IAttribute> OwnedAttributes => this.backingOwnedAttributes ??= new Auriga.ContainerList<Auriga.Requirements.IAttribute>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAttributes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Requirements.IAttribute> backingOwnedAttributes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned requirements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Requirements.IRequirement> OwnedRequirements => this.backingOwnedRequirements ??= new Auriga.ContainerList<Auriga.Requirements.IRequirement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRequirements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Requirements.IRequirement> backingOwnedRequirements;

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
        /// Gets or sets the req i f name.
        /// </summary>
        public string ReqIFName { get; set; }

        /// <summary>
        /// Gets or sets the req i f prefix.
        /// </summary>
        public string ReqIFPrefix { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
