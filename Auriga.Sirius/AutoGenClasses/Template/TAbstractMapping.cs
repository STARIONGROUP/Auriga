// ------------------------------------------------------------------------------------------------
// <copyright file="TAbstractMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Template
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TAbstractMapping</c> class.
    /// </summary>
    public partial class TAbstractMapping : Auriga.Core.AurigaElement, Auriga.Sirius.Sequence.Template.ITAbstractMapping
    {
        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the view container. The semanticCandidatesExpression is an expression that returns the list of EObject that are candidates of the mapping instead of the candidates of the default case. The context of the expression is the semantic element of the view container.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
