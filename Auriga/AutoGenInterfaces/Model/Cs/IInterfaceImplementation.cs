// ------------------------------------------------------------------------------------------------
// <copyright file="IInterfaceImplementation.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cs
{
    /// <summary>
    /// Definition of the <c>InterfaceImplementation</c> interface.
    /// </summary>
    public partial interface IInterfaceImplementation : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the implemented interface.
        /// </summary>
        Auriga.Model.Cs.IInterface ImplementedInterface { get; set; }

        /// <summary>
        /// Gets the interface implementor.
        /// </summary>
        Auriga.Model.Cs.IComponent InterfaceImplementor { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
