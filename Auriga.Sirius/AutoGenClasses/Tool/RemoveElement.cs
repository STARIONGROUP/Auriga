// ------------------------------------------------------------------------------------------------
// <copyright file="RemoveElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// Remove the element represented by the current context.
    /// </summary>
    public partial class RemoveElement : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IRemoveElement
    {
        /// <summary>
        /// Gets the sub model operations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> SubModelOperations => this.backingSubModelOperations ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation>(this);

        /// <summary>
        /// Backing field for <see cref="SubModelOperations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> backingSubModelOperations;

        /// <summary>
        /// Gets the elements directly contained by this <c>RemoveElement</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.SubModelOperations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
