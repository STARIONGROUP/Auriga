// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractAction.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Activity
{
    /// <summary>
    /// Definition of the <c>AbstractAction</c> interface.
    /// </summary>
    public partial interface IAbstractAction : Auriga.Model.Activity.IExecutableNode, Auriga.Model.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        Auriga.Model.Modellingcore.IAbstractType Context { get; set; }

        /// <summary>
        /// Gets the inputs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IInputPin> Inputs { get; }

        /// <summary>
        /// Gets or sets the local postcondition.
        /// </summary>
        Auriga.Model.Modellingcore.IAbstractConstraint LocalPostcondition { get; set; }

        /// <summary>
        /// Gets or sets the local precondition.
        /// </summary>
        Auriga.Model.Modellingcore.IAbstractConstraint LocalPrecondition { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IOutputPin> Outputs { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
