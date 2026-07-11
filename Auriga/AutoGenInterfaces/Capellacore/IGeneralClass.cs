// ------------------------------------------------------------------------------------------------
// <copyright file="IGeneralClass.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>GeneralClass</c> interface.
    /// </summary>
    public partial interface IGeneralClass : Auriga.Capellacore.IClassifier, Auriga.Modellingcore.IFinalizableElement
    {
        /// <summary>
        /// Gets the contained operations.
        /// </summary>
        IEnumerable<Auriga.Information.IOperation> ContainedOperations { get; }

        /// <summary>
        /// Gets the nested general classes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellacore.IGeneralClass> NestedGeneralClasses { get; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
