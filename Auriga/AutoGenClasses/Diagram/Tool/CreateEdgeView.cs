// ------------------------------------------------------------------------------------------------
// <copyright file="CreateEdgeView.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Tool
{
    /// <summary>
    /// Definition of the <c>CreateEdgeView</c> class.
    /// </summary>
    public partial class CreateEdgeView : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Tool.ICreateEdgeView
    {
        /// <summary>
        /// Gets or sets the container view expression.
        /// </summary>
        public string ContainerViewExpression { get; set; } = "";

        /// <summary>
        /// Mapping to create a view from.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.IDiagramElementMapping Mapping { get; set; }

        /// <summary>
        /// Gets or sets the source expression.
        /// </summary>
        public string SourceExpression { get; set; }

        /// <summary>
        /// Gets the sub model operations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation> SubModelOperations => this.backingSubModelOperations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation>(this);

        /// <summary>
        /// Backing field for <see cref="SubModelOperations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation> backingSubModelOperations;

        /// <summary>
        /// Gets or sets the target expression.
        /// </summary>
        public string TargetExpression { get; set; }

        /// <summary>
        /// Once the view is created, a new variable will be bound with the name given here and will be available to any contained operation.
        /// </summary>
        public string VariableName { get; set; } = "createdView";

        /// <summary>
        /// Gets the elements directly contained by this <c>CreateEdgeView</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
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
