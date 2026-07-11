// ------------------------------------------------------------------------------------------------
// <copyright file="IRepresentationDescription.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>RepresentationDescription</c> interface.
    /// </summary>
    public partial interface IRepresentationDescription : Auriga.Sirius.Viewpoint.Description.IDocumentedElement, Auriga.Sirius.Viewpoint.Description.IEndUserDocumentedElement, Auriga.Sirius.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// Set to true if your want your representation to be automatically created when initializing a new
        /// session.
        /// </summary>
        bool Initialisation { get; set; }

        /// <summary>
        /// You might use this reference to statically bind your representation with a set of Ecore packages.
        /// Keep in mind that this is not mandatory.
        /// </summary>
        List<object> Metamodel { get; }

        /// <summary>
        /// Gets or sets the show on startup.
        /// </summary>
        bool? ShowOnStartup { get; set; }

        /// <summary>
        /// The default title of the representation. (new + name if empty)
        /// </summary>
        string TitleExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
