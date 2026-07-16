// ------------------------------------------------------------------------------------------------
// <copyright file="TypedVariable.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TypedVariable</c> class.
    /// </summary>
    public partial class TypedVariable : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.ITypedVariable
    {
        /// <summary>
        /// An expression used to define the default variable value.
        /// </summary>
        public string DefaultValueExpression { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A documentation that is displayed to the user.
        /// </summary>
        public string UserDocumentation { get; set; }

        /// <summary>
        /// The type of the variable value.
        /// </summary>
        public object ValueType { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
