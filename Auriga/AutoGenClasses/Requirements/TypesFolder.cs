// ------------------------------------------------------------------------------------------------
// <copyright file="TypesFolder.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TypesFolder</c> class.
    /// </summary>
    public partial class TypesFolder : Auriga.AurigaElement, Auriga.Requirements.ITypesFolder
    {
        /// <summary>
        /// Gets the owned definition types.
        /// </summary>
        public Auriga.IContainerList<Auriga.Requirements.IDataTypeDefinition> OwnedDefinitionTypes => this.backingOwnedDefinitionTypes ??= new Auriga.ContainerList<Auriga.Requirements.IDataTypeDefinition>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDefinitionTypes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Requirements.IDataTypeDefinition> backingOwnedDefinitionTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned types.
        /// </summary>
        public Auriga.IContainerList<Auriga.Requirements.IAbstractType> OwnedTypes => this.backingOwnedTypes ??= new Auriga.ContainerList<Auriga.Requirements.IAbstractType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTypes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Requirements.IAbstractType> backingOwnedTypes;

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
        /// Gets the elements directly contained by this <c>TypesFolder</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedDefinitionTypes)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedTypes)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
