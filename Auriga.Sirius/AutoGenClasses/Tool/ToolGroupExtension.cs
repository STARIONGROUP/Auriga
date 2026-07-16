// ------------------------------------------------------------------------------------------------
// <copyright file="ToolGroupExtension.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Tool
{
    /// <summary>
    /// Definition of the <c>ToolGroupExtension</c> class.
    /// </summary>
    public partial class ToolGroupExtension : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.Tool.IToolGroupExtension
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.IToolGroup Group { get; set; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription> Tools => this.backingTools ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Tools"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription> backingTools;

        /// <summary>
        /// Gets the elements directly contained by this <c>ToolGroupExtension</c>.
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
