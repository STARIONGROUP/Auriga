// ------------------------------------------------------------------------------------------------
// <copyright file="IClass.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Class</c> interface.
    /// </summary>
    public partial interface IClass : Auriga.Model.Capellacore.IGeneralClass
    {
        /// <summary>
        /// Gets or sets the is primitive.
        /// </summary>
        bool? IsPrimitive { get; set; }

        /// <summary>
        /// Gets the key parts.
        /// </summary>
        List<Auriga.Model.Information.IKeyPart> KeyParts { get; }

        /// <summary>
        /// Gets the owned data values.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Datavalue.IDataValue> OwnedDataValues { get; }

        /// <summary>
        /// Gets the owned information realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IInformationRealization> OwnedInformationRealizations { get; }

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        /// <summary>
        /// Gets the realized classes.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IClass> RealizedClasses { get; }

        /// <summary>
        /// Gets the realizing classes.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IClass> RealizingClasses { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
