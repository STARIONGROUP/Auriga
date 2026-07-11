// ------------------------------------------------------------------------------------------------
// <copyright file="EdgeMappingImport.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Definition of the <c>EdgeMappingImport</c> class.
    /// </summary>
    public partial class EdgeMappingImport : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.IEdgeMappingImport
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription> ConditionnalStyles => this.backingConditionnalStyles ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription>(this);

        /// <summary>
        /// Backing field for <see cref="ConditionnalStyles"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription> backingConditionnalStyles;

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The imported mapping used to define default values for the current mapping.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.IIEdgeMapping ImportedMapping { get; set; }

        /// <summary>
        /// Set to true if you want the filters applying on the imported mappings apply on this one.
        /// </summary>
        public bool? InheritsAncestorFilters { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>EdgeMappingImport</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ConditionnalStyles)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
