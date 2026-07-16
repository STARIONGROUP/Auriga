// ------------------------------------------------------------------------------------------------
// <copyright file="EnumLayoutOption.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>EnumLayoutOption</c> class.
    /// </summary>
    public partial class EnumLayoutOption : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.IEnumLayoutOption
    {
        /// <summary>
        /// Gets the choices.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.IEnumLayoutValue> Choices => this.backingChoices ??= new Auriga.Core.ContainerList<Auriga.Sirius.Diagram.Description.IEnumLayoutValue>(this);

        /// <summary>
        /// Backing field for <see cref="Choices"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.IEnumLayoutValue> backingChoices;

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
        public List<Auriga.Sirius.Diagram.Description.LayoutOptionTarget> Targets { get; } = new List<Auriga.Sirius.Diagram.Description.LayoutOptionTarget>();

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.IEnumLayoutValue Value
        {
            get => this.backingValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Value"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.IEnumLayoutValue backingValue;

        /// <summary>
        /// Gets the elements directly contained by this <c>EnumLayoutOption</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Choices)
            {
                yield return element;
            }

            if (this.Value != null)
            {
                yield return this.Value;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
