// ------------------------------------------------------------------------------------------------
// <copyright file="DAnalysisCustomData.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Definition of the <c>DAnalysisCustomData</c> class.
    /// </summary>
    public partial class DAnalysisCustomData : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.IDAnalysisCustomData
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public Auriga.Core.IAurigaElement Data
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
        private Auriga.Core.IAurigaElement backingData;

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DAnalysisCustomData</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
