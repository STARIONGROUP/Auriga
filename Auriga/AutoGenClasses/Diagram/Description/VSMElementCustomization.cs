// ------------------------------------------------------------------------------------------------
// <copyright file="VSMElementCustomization.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>VSMElementCustomization</c> class.
    /// </summary>
    public partial class VSMElementCustomization : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.IVSMElementCustomization
    {
        /// <summary>
        /// Gets the feature customizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IEStructuralFeatureCustomization> FeatureCustomizations => this.backingFeatureCustomizations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IEStructuralFeatureCustomization>(this);

        /// <summary>
        /// Backing field for <see cref="FeatureCustomizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IEStructuralFeatureCustomization> backingFeatureCustomizations;

        /// <summary>
        /// Gets or sets the predicate expression.
        /// </summary>
        public string PredicateExpression { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>VSMElementCustomization</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.FeatureCustomizations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
