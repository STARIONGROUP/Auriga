// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalActivityPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    /// <summary>
    /// Definition of the <c>OperationalActivityPkg</c> interface.
    /// </summary>
    public partial interface IOperationalActivityPkg : Auriga.Fa.IFunctionPkg
    {
        /// <summary>
        /// Gets the owned operational activities.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IOperationalActivity> OwnedOperationalActivities { get; }

        /// <summary>
        /// Gets the owned operational activity pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
