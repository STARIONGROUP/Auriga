// ------------------------------------------------------------------------------------------------
// <copyright file="EAttributeCustomization.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>EAttributeCustomization</c> class.
    /// </summary>
    public partial class EAttributeCustomization : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.IEAttributeCustomization
    {
        /// <summary>
        /// Gets the applied on.
        /// </summary>
        public List<object> AppliedOn { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the apply on all.
        /// </summary>
        public bool? ApplyOnAll { get; set; }

        /// <summary>
        /// Gets or sets the attribute name.
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
