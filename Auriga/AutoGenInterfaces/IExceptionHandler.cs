// ------------------------------------------------------------------------------------------------
// <copyright file="IExceptionHandler.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    using System.Collections.Generic;

    public partial interface IExceptionHandler : Auriga.Modellingcore.IModelElement
    {
        Auriga.Activity.IExecutableNode ProtectedNode { get; set; }

        Auriga.Activity.IExecutableNode HandlerBody { get; set; }

        Auriga.Activity.IObjectNode ExceptionInput { get; set; }

        List<Auriga.Modellingcore.IAbstractType> ExceptionTypes { get; }

    }
}
