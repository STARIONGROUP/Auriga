// ------------------------------------------------------------------------------------------------
// <copyright file="IModelElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Modellingcore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ModelElement</c> interface.
    /// </summary>
    public partial interface IModelElement : Auriga.Model.Emde.IExtensibleElement
    {
        /// <summary>
        /// Gets the constraints.
        /// </summary>
        IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints { get; }

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> OwnedConstraints { get; }

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> OwnedMigratedElements { get; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        string Sid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
