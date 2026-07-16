// ------------------------------------------------------------------------------------------------
// <copyright file="ICollectionValue.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information
{
    /// <summary>
    /// Definition of the <c>CollectionValue</c> interface.
    /// </summary>
    public partial interface ICollectionValue : Auriga.Model.Information.IAbstractCollectionValue
    {
        /// <summary>
        /// Gets or sets the owned default element.
        /// </summary>
        Auriga.Model.Information.Datavalue.IDataValue OwnedDefaultElement { get; set; }

        /// <summary>
        /// Gets the owned elements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Datavalue.IDataValue> OwnedElements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
