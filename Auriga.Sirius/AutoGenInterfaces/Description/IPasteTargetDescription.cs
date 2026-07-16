// ------------------------------------------------------------------------------------------------
// <copyright file="IPasteTargetDescription.cs" company="Starion Group S.A.">
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
    /// A PasteTargetDescription is a Description or Mapping that can have many PasteTools.
    /// </summary>
    public partial interface IPasteTargetDescription : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the paste descriptions.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IPasteDescription> PasteDescriptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
