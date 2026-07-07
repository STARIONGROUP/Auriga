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

namespace Auriga.Activity
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ExceptionHandler</c> interface.
    /// </summary>
    public partial interface IExceptionHandler : Auriga.Modellingcore.IModelElement
    {
        /// <summary>
        /// Gets or sets the exception input.
        /// </summary>
        Auriga.Activity.IObjectNode ExceptionInput { get; set; }

        /// <summary>
        /// Gets the exception types.
        /// </summary>
        List<Auriga.Modellingcore.IAbstractType> ExceptionTypes { get; }

        /// <summary>
        /// Gets or sets the handler body.
        /// </summary>
        Auriga.Activity.IExecutableNode HandlerBody { get; set; }

        /// <summary>
        /// Gets or sets the protected node.
        /// </summary>
        Auriga.Activity.IExecutableNode ProtectedNode { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
