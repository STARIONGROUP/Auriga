// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramExtensionDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DiagramExtensionDescription</c> class.
    /// </summary>
    public partial class DiagramExtensionDescription : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.IDiagramExtensionDescription
    {
        /// <summary>
        /// All concerns of the diagrams to add. A concern is a set of filters, validations and behaviors.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Concern.IConcernSet Concerns
        {
            get => this.backingConcerns;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingConcerns = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Concerns"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Concern.IConcernSet backingConcerns;

        /// <summary>
        /// Gets the layers.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IAdditionalLayer> Layers => this.backingLayers ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.Description.IAdditionalLayer>(this);

        /// <summary>
        /// Backing field for <see cref="Layers"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IAdditionalLayer> backingLayers;

        /// <summary>
        /// You might use this reference to statically bind your representation extension with a set of Ecore
        /// packages. Keep in mind that this is not mandatory.
        /// </summary>
        public List<object> Metamodel { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the Representation you are extending.
        /// </summary>
        public string RepresentationName { get; set; }

        /// <summary>
        /// The validations rules to add
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Validation.IValidationSet ValidationSet
        {
            get => this.backingValidationSet;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingValidationSet = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ValidationSet"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Validation.IValidationSet backingValidationSet;

        /// <summary>
        /// The logical URI of the viewpoint you want to extend, in the form of
        /// viewpoint:/pluginID/ViewpointName
        /// </summary>
        public string ViewpointURI { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DiagramExtensionDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            if (this.Concerns != null)
            {
                yield return this.Concerns;
            }

            foreach (var element in this.Layers)
            {
                yield return element;
            }

            if (this.ValidationSet != null)
            {
                yield return this.ValidationSet;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
