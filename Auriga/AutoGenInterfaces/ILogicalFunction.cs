// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalFunction.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LogicalFunction</c> interface.
    /// </summary>
    public partial interface ILogicalFunction : Auriga.Fa.IAbstractFunction
    {
        /// <summary>
        /// Gets the allocating logical components.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalComponent> AllocatingLogicalComponents { get; }

        /// <summary>
        /// Gets the children logical functions.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalFunction> ChildrenLogicalFunctions { get; }

        /// <summary>
        /// Gets the contained logical functions.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalFunction> ContainedLogicalFunctions { get; }

        /// <summary>
        /// Gets the owned logical function pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ILogicalFunctionPkg> OwnedLogicalFunctionPkgs { get; }

        /// <summary>
        /// Gets the realized system functions.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemFunction> RealizedSystemFunctions { get; }

        /// <summary>
        /// Gets the realizing physical functions.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalFunction> RealizingPhysicalFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
