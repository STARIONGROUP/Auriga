// ------------------------------------------------------------------------------------------------
// <copyright file="ToolGroup.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Tool
{
    /// <summary>
    /// Definition of the <c>ToolGroup</c> class.
    /// </summary>
    public partial class ToolGroup : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Tool.IToolGroup
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; } = "";

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets the tools.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> Tools => this.backingTools ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Tools"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> backingTools;

        /// <summary>
        /// Gets the elements directly contained by this <c>ToolGroup</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Tools)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
