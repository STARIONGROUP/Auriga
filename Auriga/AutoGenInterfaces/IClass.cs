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
    public partial interface IClass : global::Auriga.Capellacore.IGeneralClass
    {
        bool? IsPrimitive { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Information.IKeyPart> KeyParts { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        global::Auriga.IContainerList<global::Auriga.Information.Datavalue.IDataValue> OwnedDataValues { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IClass> RealizedClasses { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IClass> RealizingClasses { get; }

    }
}
