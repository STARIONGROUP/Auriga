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

namespace Auriga.Model.Activity
{
    /// <summary>
    /// Definition of the <c>ObjectFlow</c> interface.
    /// </summary>
    public partial interface IObjectFlow : Auriga.Model.Activity.IActivityEdge
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
        Auriga.Model.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the transformation.
        /// </summary>
        Auriga.Model.Behavior.IAbstractBehavior Transformation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
