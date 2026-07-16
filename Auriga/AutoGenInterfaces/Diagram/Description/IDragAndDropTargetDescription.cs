// ------------------------------------------------------------------------------------------------
// <copyright file="IDragAndDropTargetDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// A DragAndDropTargetDescription is a Description or Mapping that can have many DropTools
    /// </summary>
    public partial interface IDragAndDropTargetDescription : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the drop descriptions.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Tool.IContainerDropDescription> DropDescriptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
