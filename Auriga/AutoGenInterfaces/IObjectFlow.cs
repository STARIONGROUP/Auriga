// ------------------------------------------------------------------------------------------------
// <copyright file="IObjectFlow.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    /// <summary>
    /// Definition of the <c>ObjectFlow</c> interface.
    /// </summary>
    public partial interface IObjectFlow : Auriga.Activity.IActivityEdge
    {
        /// <summary>
        /// Gets or sets the is multicast.
        /// </summary>
        bool? IsMulticast { get; set; }

        /// <summary>
        /// Gets or sets the is multireceive.
        /// </summary>
        bool? IsMultireceive { get; set; }

        /// <summary>
        /// Gets or sets the selection.
        /// </summary>
        Auriga.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the transformation.
        /// </summary>
        Auriga.Behavior.IAbstractBehavior Transformation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
