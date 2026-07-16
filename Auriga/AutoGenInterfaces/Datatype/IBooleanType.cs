// ------------------------------------------------------------------------------------------------
// <copyright file="IBooleanType.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Datatype
{
    /// <summary>
    /// Definition of the <c>BooleanType</c> interface.
    /// </summary>
    public partial interface IBooleanType : Auriga.Information.Datatype.IDataType
    {
        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractBooleanValue OwnedDefaultValue { get; set; }

        /// <summary>
        /// Gets the owned literals.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.Datavalue.ILiteralBooleanValue> OwnedLiterals { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
