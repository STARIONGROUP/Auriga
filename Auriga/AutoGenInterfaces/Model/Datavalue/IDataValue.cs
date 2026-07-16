// ------------------------------------------------------------------------------------------------
// <copyright file="IDataValue.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information.Datavalue
{
    /// <summary>
    /// Definition of the <c>DataValue</c> interface.
    /// </summary>
    public partial interface IDataValue : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Modellingcore.IValueSpecification
    {
        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        bool? Abstract { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        Auriga.Model.Capellacore.IType Type { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
