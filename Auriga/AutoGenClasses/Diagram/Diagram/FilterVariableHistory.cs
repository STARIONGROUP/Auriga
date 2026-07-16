// ------------------------------------------------------------------------------------------------
// <copyright file="FilterVariableHistory.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram
{
    /// <summary>
    /// Definition of the <c>FilterVariableHistory</c> class.
    /// </summary>
    public partial class FilterVariableHistory : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IFilterVariableHistory
    {
        /// <summary>
        /// Gets the owned values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IVariableValue> OwnedValues => this.backingOwnedValues ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.IVariableValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IVariableValue> backingOwnedValues;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>FilterVariableHistory</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedValues)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
