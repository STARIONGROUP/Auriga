// ------------------------------------------------------------------------------------------------
// <copyright file="IStyleUpdater.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    /// <summary>
    /// Definition of the <c>StyleUpdater</c> interface.
    /// </summary>
    public partial interface IStyleUpdater : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the background conditional style.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IBackgroundConditionalStyle> BackgroundConditionalStyle { get; }

        /// <summary>
        /// Gets or sets the default background.
        /// </summary>
        Auriga.Sirius.Table.Description.IBackgroundStyleDescription DefaultBackground { get; set; }

        /// <summary>
        /// Gets or sets the default foreground.
        /// </summary>
        Auriga.Sirius.Table.Description.IForegroundStyleDescription DefaultForeground { get; set; }

        /// <summary>
        /// Gets the foreground conditional style.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IForegroundConditionalStyle> ForegroundConditionalStyle { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
