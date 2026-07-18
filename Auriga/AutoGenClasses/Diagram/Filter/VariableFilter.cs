// ------------------------------------------------------------------------------------------------
// <copyright file="VariableFilter.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Filter
{
    /// <summary>
    /// A filter that filters viewpoint elements considering an expression and some variables defined by the user.
    /// </summary>
    public partial class VariableFilter : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Filter.IVariableFilter
    {
        /// <summary>
        /// A filter might hide elements or just shrink them. In the case of the shrink, the edges going to this element will be kept.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Filter.FilterKind? FilterKind { get; set; } = Auriga.Diagram.Diagram.Description.Filter.FilterKind.HIDE;

        /// <summary>
        /// Gets the owned variables.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IInteractiveVariableDescription> OwnedVariables => this.backingOwnedVariables ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IInteractiveVariableDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedVariables"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IInteractiveVariableDescription> backingOwnedVariables;

        /// <summary>
        /// The condition to apply on the semantic element.
        /// </summary>
        public string SemanticConditionExpression { get; set; } = "";

        /// <summary>
        /// Gets the elements directly contained by this <c>VariableFilter</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedVariables)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
