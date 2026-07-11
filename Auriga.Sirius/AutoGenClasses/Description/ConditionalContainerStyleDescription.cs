// ------------------------------------------------------------------------------------------------
// <copyright file="ConditionalContainerStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Definition of the <c>ConditionalContainerStyleDescription</c> class.
    /// </summary>
    public partial class ConditionalContainerStyleDescription : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.IConditionalContainerStyleDescription
    {
        /// <summary>
        /// This expression will get evaluated and if it returns true the contained style will be choosen.
        /// </summary>
        public string PredicateExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Style.IContainerStyleDescription Style
        {
            get => this.backingStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Style"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Style.IContainerStyleDescription backingStyle;

        /// <summary>
        /// Gets the elements directly contained by this <c>ConditionalContainerStyleDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.Style != null)
            {
                yield return this.Style;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
