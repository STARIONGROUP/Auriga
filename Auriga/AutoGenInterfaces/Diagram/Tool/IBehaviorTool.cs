// ------------------------------------------------------------------------------------------------
// <copyright file="IBehaviorTool.cs" company="Starion Group S.A.">
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
    /// A tool that can be launched by the user.
    /// </summary>
    public partial interface IBehaviorTool : Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// The type of elements on which we want to appy the tool.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
