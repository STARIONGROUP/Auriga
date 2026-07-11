// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalFunction.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalFunction</c> interface.
    /// </summary>
    public partial interface IPhysicalFunction : Auriga.Fa.IAbstractFunction
    {
        /// <summary>
        /// Gets the allocating physical components.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalComponent> AllocatingPhysicalComponents { get; }

        /// <summary>
        /// Gets the children physical functions.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalFunction> ChildrenPhysicalFunctions { get; }

        /// <summary>
        /// Gets the contained physical functions.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalFunction> ContainedPhysicalFunctions { get; }

        /// <summary>
        /// Gets the owned physical function pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs { get; }

        /// <summary>
        /// Gets the realized logical functions.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalFunction> RealizedLogicalFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
