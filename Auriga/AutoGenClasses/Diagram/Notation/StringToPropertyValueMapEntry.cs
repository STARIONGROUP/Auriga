// ------------------------------------------------------------------------------------------------
// <copyright file="StringToPropertyValueMapEntry.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Notation
{
    /// <summary>
    /// Definition of the <c>StringToPropertyValueMapEntry</c> class.
    /// </summary>
    public partial class StringToPropertyValueMapEntry : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IStringToPropertyValueMapEntry
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public Auriga.Diagram.Notation.IPropertyValue Value
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
        private Auriga.Diagram.Notation.IPropertyValue backingValue;

        /// <summary>
        /// Gets the elements directly contained by this <c>StringToPropertyValueMapEntry</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
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
