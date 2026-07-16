// ------------------------------------------------------------------------------------------------
// <copyright file="IInstanceRoleReorderTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Description.Tool
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>InstanceRoleReorderTool</c> interface.
    /// </summary>
    public partial interface IInstanceRoleReorderTool : Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription, Auriga.Sirius.Sequence.Description.Tool.ISequenceDiagramToolDescription
    {
        /// <summary>
        /// Gets or sets the instance role moved.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InstanceRoleMoved { get; set; }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        List<Auriga.Sirius.Sequence.Description.IInstanceRoleMapping> Mappings { get; }

        /// <summary>
        /// Gets or sets the predecessor after.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable PredecessorAfter { get; set; }

        /// <summary>
        /// Gets or sets the predecessor before.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable PredecessorBefore { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
