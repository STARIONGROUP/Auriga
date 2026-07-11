// ------------------------------------------------------------------------------------------------
// <copyright file="ITConditionalMessageStyle.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>TConditionalMessageStyle</c> interface.
    /// </summary>
    public partial interface ITConditionalMessageStyle : Auriga.Sirius.Sequence.Template.ITTransformer
    {
        /// <summary>
        /// This expression will get evaluated and if it returns true the contained style will be choosen.
        /// </summary>
        string PredicateExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Sirius.Sequence.Template.ITMessageStyle Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
