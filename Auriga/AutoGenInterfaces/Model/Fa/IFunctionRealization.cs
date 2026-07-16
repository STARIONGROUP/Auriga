// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Fa
{
    /// <summary>
    /// Definition of the <c>FunctionRealization</c> interface.
    /// </summary>
    public partial interface IFunctionRealization : Auriga.Model.Fa.IAbstractFunctionAllocation
    {
        /// <summary>
        /// Gets the allocated function.
        /// </summary>
        Auriga.Model.Fa.IAbstractFunction AllocatedFunction { get; }

        /// <summary>
        /// Gets the allocating function.
        /// </summary>
        Auriga.Model.Fa.IAbstractFunction AllocatingFunction { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
