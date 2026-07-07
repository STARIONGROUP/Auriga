// ------------------------------------------------------------------------------------------------
// <copyright file="IDataType.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DataType</c> interface.
    /// </summary>
    public partial interface IDataType : Auriga.Capellacore.IGeneralizableElement, Auriga.Information.Datavalue.IDataValueContainer, Auriga.Modellingcore.IFinalizableElement
    {
        /// <summary>
        /// Gets the default value.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue DefaultValue { get; }

        /// <summary>
        /// Gets or sets the discrete.
        /// </summary>
        bool? Discrete { get; set; }

        /// <summary>
        /// Gets or sets the max inclusive.
        /// </summary>
        bool? MaxInclusive { get; set; }

        /// <summary>
        /// Gets or sets the min inclusive.
        /// </summary>
        bool? MinInclusive { get; set; }

        /// <summary>
        /// Gets the null value.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue NullValue { get; }

        /// <summary>
        /// Gets the owned information realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        string Pattern { get; set; }

        /// <summary>
        /// Gets the realized data types.
        /// </summary>
        IEnumerable<Auriga.Information.Datatype.IDataType> RealizedDataTypes { get; }

        /// <summary>
        /// Gets the realizing data types.
        /// </summary>
        IEnumerable<Auriga.Information.Datatype.IDataType> RealizingDataTypes { get; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
