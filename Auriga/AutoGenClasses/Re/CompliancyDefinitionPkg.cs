// ------------------------------------------------------------------------------------------------
// <copyright file="CompliancyDefinitionPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Re
{
    /// <summary>
    /// Definition of the <c>CompliancyDefinitionPkg</c> class.
    /// </summary>
    public partial class CompliancyDefinitionPkg : Auriga.AurigaElement, Auriga.Re.ICompliancyDefinitionPkg
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the owned definitions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Re.ICompliancyDefinition> OwnedDefinitions => this.backingOwnedDefinitions ??= new Auriga.ContainerList<Auriga.Re.ICompliancyDefinition>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDefinitions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Re.ICompliancyDefinition> backingOwnedDefinitions;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the elements directly contained by this <c>CompliancyDefinitionPkg</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedDefinitions)
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
