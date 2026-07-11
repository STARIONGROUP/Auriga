// ------------------------------------------------------------------------------------------------
// <copyright file="ExternalJavaActionCall.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// An operation which can be used to call an ExternalJavaAction defined elsewhere.
    /// </summary>
    public partial class ExternalJavaActionCall : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IExternalJavaActionCall
    {
        /// <summary>
        /// The action to call.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IExternalJavaAction Action { get; set; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        public string ElementsToSelect { get; set; }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets the sub model operations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> SubModelOperations => this.backingSubModelOperations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation>(this);

        /// <summary>
        /// Backing field for <see cref="SubModelOperations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> backingSubModelOperations;

        /// <summary>
        /// Gets the elements directly contained by this <c>ExternalJavaActionCall</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            foreach (var element in this.SubModelOperations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
