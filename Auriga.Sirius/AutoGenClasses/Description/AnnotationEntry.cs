// ------------------------------------------------------------------------------------------------
// <copyright file="AnnotationEntry.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>AnnotationEntry</c> class.
    /// </summary>
    public partial class AnnotationEntry : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.IAnnotationEntry
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public Auriga.IAurigaElement Data
        {
            get => this.backingData;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingData = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Data"/>.
        /// </summary>
        private Auriga.IAurigaElement backingData;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>AnnotationEntry</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            if (this.Data != null)
            {
                yield return this.Data;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
