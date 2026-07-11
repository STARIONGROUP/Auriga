// ------------------------------------------------------------------------------------------------
// <copyright file="DeleteHook.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Tool
{
    /// <summary>
    /// Definition of the <c>DeleteHook</c> class.
    /// </summary>
    public partial class DeleteHook : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.Tool.IDeleteHook
    {
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IDeleteHookParameter> Parameters => this.backingParameters ??= new Auriga.Core.ContainerList<Auriga.Sirius.Diagram.Description.Tool.IDeleteHookParameter>(this);

        /// <summary>
        /// Backing field for <see cref="Parameters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IDeleteHookParameter> backingParameters;

        /// <summary>
        /// Gets the elements directly contained by this <c>DeleteHook</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Parameters)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
