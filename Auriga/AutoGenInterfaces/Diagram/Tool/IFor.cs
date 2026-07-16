// ------------------------------------------------------------------------------------------------
// <copyright file="IFor.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Tool
{
    /// <summary>
    /// This operation allows to iterate a list of elements.
    /// </summary>
    public partial interface IFor : Auriga.Diagram.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// Expression returning the elements to iterate on.
        /// </summary>
        string Expression { get; set; }

        /// <summary>
        /// On every iteration, the current element will be binded with the given name.
        /// </summary>
        string IteratorName { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
