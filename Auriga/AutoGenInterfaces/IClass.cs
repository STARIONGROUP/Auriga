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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IClass : Auriga.Capellacore.IGeneralClass
    {
        bool? IsPrimitive { get; set; }

        List<Auriga.Information.IKeyPart> KeyParts { get; }

        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        Auriga.IContainerList<Auriga.Information.Datavalue.IDataValue> OwnedDataValues { get; }

        Auriga.IContainerList<Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        IEnumerable<Auriga.Information.IClass> RealizedClasses { get; }

        IEnumerable<Auriga.Information.IClass> RealizingClasses { get; }

    }
}
