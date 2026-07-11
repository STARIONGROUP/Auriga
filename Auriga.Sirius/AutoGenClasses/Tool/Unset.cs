// ------------------------------------------------------------------------------------------------
// <copyright file="Unset.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Unset</c> class.
    /// </summary>
    public partial class Unset : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IUnset
    {
        /// <summary>
        /// Expression returning the elements to unset from the feature.
        /// </summary>
        public string ElementExpression { get; set; }

        /// <summary>
        /// Name of the feature to unset.
        /// </summary>
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets the sub model operations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> SubModelOperations => this.backingSubModelOperations ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation>(this);

        /// <summary>
        /// Backing field for <see cref="SubModelOperations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> backingSubModelOperations;

        /// <summary>
        /// Gets the elements directly contained by this <c>Unset</c>.
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
