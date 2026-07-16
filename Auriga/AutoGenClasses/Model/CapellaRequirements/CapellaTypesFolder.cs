// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaTypesFolder.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.CapellaRequirements
{
    /// <summary>
    /// Definition of the <c>CapellaTypesFolder</c> class.
    /// </summary>
    public partial class CapellaTypesFolder : Auriga.Core.AurigaElement, Auriga.Model.CapellaRequirements.ICapellaTypesFolder
    {
        /// <summary>
        /// Gets the owned definition types.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Requirements.IDataTypeDefinition> OwnedDefinitionTypes => this.backingOwnedDefinitionTypes ??= new Auriga.Core.ContainerList<Auriga.Model.Requirements.IDataTypeDefinition>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDefinitionTypes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Requirements.IDataTypeDefinition> backingOwnedDefinitionTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned types.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Requirements.IAbstractType> OwnedTypes => this.backingOwnedTypes ??= new Auriga.Core.ContainerList<Auriga.Model.Requirements.IAbstractType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTypes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Requirements.IAbstractType> backingOwnedTypes;

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
        /// Gets the elements directly contained by this <c>CapellaTypesFolder</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
