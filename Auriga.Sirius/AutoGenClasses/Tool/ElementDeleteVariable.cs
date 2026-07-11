// ------------------------------------------------------------------------------------------------
// <copyright file="ElementDeleteVariable.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ElementDeleteVariable</c> class.
    /// </summary>
    public partial class ElementDeleteVariable : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IElementDeleteVariable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the sub variables.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.ISubVariable> SubVariables => this.backingSubVariables ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.ISubVariable>(this);

        /// <summary>
        /// Backing field for <see cref="SubVariables"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.ISubVariable> backingSubVariables;

        /// <summary>
        /// Gets the elements directly contained by this <c>ElementDeleteVariable</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.SubVariables)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
