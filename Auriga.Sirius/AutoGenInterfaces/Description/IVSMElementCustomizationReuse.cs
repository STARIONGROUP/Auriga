// ------------------------------------------------------------------------------------------------
// <copyright file="IVSMElementCustomizationReuse.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>VSMElementCustomizationReuse</c> interface.
    /// </summary>
    public partial interface IVSMElementCustomizationReuse : Auriga.Sirius.Viewpoint.Description.IIVSMElementCustomization
    {
        /// <summary>
        /// Gets the applied on.
        /// </summary>
        List<object> AppliedOn { get; }

        /// <summary>
        /// Gets the reuse.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.IEStructuralFeatureCustomization> Reuse { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
