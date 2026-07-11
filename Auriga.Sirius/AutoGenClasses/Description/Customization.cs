// ------------------------------------------------------------------------------------------------
// <copyright file="Customization.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>Customization</c> class.
    /// </summary>
    public partial class Customization : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.ICustomization
    {
        /// <summary>
        /// Gets the vsm element customizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IIVSMElementCustomization> VsmElementCustomizations => this.backingVsmElementCustomizations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IIVSMElementCustomization>(this);

        /// <summary>
        /// Backing field for <see cref="VsmElementCustomizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IIVSMElementCustomization> backingVsmElementCustomizations;

        /// <summary>
        /// Gets the elements directly contained by this <c>Customization</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.VsmElementCustomizations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
