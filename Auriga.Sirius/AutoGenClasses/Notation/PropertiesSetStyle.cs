// ------------------------------------------------------------------------------------------------
// <copyright file="PropertiesSetStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Notation
{
    /// <summary>
    /// Definition of the <c>PropertiesSetStyle</c> class.
    /// </summary>
    public partial class PropertiesSetStyle : Auriga.Core.AurigaElement, Auriga.Sirius.Notation.IPropertiesSetStyle
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the properties map.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Notation.IStringToPropertyValueMapEntry> PropertiesMap => this.backingPropertiesMap ??= new Auriga.Core.ContainerList<Auriga.Sirius.Notation.IStringToPropertyValueMapEntry>(this);

        /// <summary>
        /// Backing field for <see cref="PropertiesMap"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Notation.IStringToPropertyValueMapEntry> backingPropertiesMap;

        /// <summary>
        /// Gets the elements directly contained by this <c>PropertiesSetStyle</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.PropertiesMap)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
