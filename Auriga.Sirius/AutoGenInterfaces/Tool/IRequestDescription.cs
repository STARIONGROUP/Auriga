// ------------------------------------------------------------------------------------------------
// <copyright file="IRequestDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>RequestDescription</c> interface.
    /// </summary>
    public partial interface IRequestDescription : Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// An Identifier for your request. This request will be send through GEF and any EditPolicy handling this request will then be able to perform commands.
        /// </summary>
        string Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
