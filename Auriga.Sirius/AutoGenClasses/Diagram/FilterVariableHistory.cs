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

namespace Auriga.Sirius.Diagram
{
    /// <summary>
    /// Definition of the <c>FilterVariableHistory</c> class.
    /// </summary>
    public partial class FilterVariableHistory : Auriga.AurigaElement, Auriga.Sirius.Diagram.IFilterVariableHistory
    {
        /// <summary>
        /// Gets the owned values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.IVariableValue> OwnedValues => this.backingOwnedValues ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.IVariableValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedValues"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.IVariableValue> backingOwnedValues;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>FilterVariableHistory</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
