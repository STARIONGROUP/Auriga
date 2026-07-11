// ------------------------------------------------------------------------------------------------
// <copyright file="IIdentifiedElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// All elements which are identified by its name (id) and which have a label to display it to the end-user.
    /// </summary>
    public partial interface IIdentifiedElement : Auriga.IAurigaElement
    {
        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        string Name { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
