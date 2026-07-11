// ------------------------------------------------------------------------------------------------
// <copyright file="IExternalJavaActionCall.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// An operation which can be used to call an ExternalJavaAction defined elsewhere.
    /// </summary>
    public partial interface IExternalJavaActionCall : Auriga.Sirius.Viewpoint.Description.Tool.IMenuItemDescriptionWithIcon, Auriga.Sirius.Viewpoint.Description.Tool.IContainerModelOperation, Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenuItem
    {
        /// <summary>
        /// The action to call.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IExternalJavaAction Action { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
