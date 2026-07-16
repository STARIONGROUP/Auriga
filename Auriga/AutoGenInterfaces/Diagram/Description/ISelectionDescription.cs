// ------------------------------------------------------------------------------------------------
// <copyright file="ISelectionDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SelectionDescription</c> interface.
    /// </summary>
    public partial interface ISelectionDescription : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the candidates expression.
        /// </summary>
        string CandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the children expression.
        /// </summary>
        string ChildrenExpression { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the multiple.
        /// </summary>
        bool Multiple { get; set; }

        /// <summary>
        /// Gets or sets the root expression.
        /// </summary>
        string RootExpression { get; set; }

        /// <summary>
        /// Set to true if you want a tree representation of the selection candidates.
        /// </summary>
        bool Tree { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
