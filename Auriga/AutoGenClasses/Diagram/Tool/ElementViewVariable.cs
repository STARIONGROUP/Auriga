// ------------------------------------------------------------------------------------------------
// <copyright file="ElementViewVariable.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Tool
{
    /// <summary>
    /// Definition of the <c>ElementViewVariable</c> class.
    /// </summary>
    public partial class ElementViewVariable : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Tool.IElementViewVariable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the sub variables.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.ISubVariable> SubVariables => this.backingSubVariables ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.ISubVariable>(this);

        /// <summary>
        /// Backing field for <see cref="SubVariables"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.ISubVariable> backingSubVariables;

        /// <summary>
        /// Gets the elements directly contained by this <c>ElementViewVariable</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
