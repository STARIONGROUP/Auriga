// ------------------------------------------------------------------------------------------------
// <copyright file="EnumSetLayoutOption.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>EnumSetLayoutOption</c> class.
    /// </summary>
    public partial class EnumSetLayoutOption : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.IEnumSetLayoutOption
    {
        /// <summary>
        /// Gets the choices.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEnumLayoutValue> Choices => this.backingChoices ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IEnumLayoutValue>(this);

        /// <summary>
        /// Backing field for <see cref="Choices"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEnumLayoutValue> backingChoices;

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description => default;

        /// <summary>
        /// Gets the label.
        /// </summary>
        public string Label => default;

        /// <summary>
        /// Gets the targets.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.LayoutOptionTarget> Targets { get; } = new List<Auriga.Diagram.Diagram.Description.LayoutOptionTarget>();

        /// <summary>
        /// Gets the values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEnumLayoutValue> Values => this.backingValues ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IEnumLayoutValue>(this);

        /// <summary>
        /// Backing field for <see cref="Values"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEnumLayoutValue> backingValues;

        /// <summary>
        /// Gets the elements directly contained by this <c>EnumSetLayoutOption</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Choices)
            {
                yield return element;
            }

            foreach (var element in this.Values)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
