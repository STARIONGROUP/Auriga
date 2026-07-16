// ------------------------------------------------------------------------------------------------
// <copyright file="IRepresentationExtensionDescription.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>RepresentationExtensionDescription</c> interface.
    /// </summary>
    public partial interface IRepresentationExtensionDescription : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// You might use this reference to statically bind your representation extension with a set of Ecore packages. Keep in mind that this is not mandatory.
        /// </summary>
        List<object> Metamodel { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The name of the Representation you are extending.
        /// </summary>
        string RepresentationName { get; set; }

        /// <summary>
        /// The logical URI of the viewpoint you want to extend, in the form of viewpoint:/pluginID/ViewpointName
        /// </summary>
        string ViewpointURI { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
