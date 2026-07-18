// ------------------------------------------------------------------------------------------------
// <copyright file="ImageStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Notation
{
    /// <summary>
    /// Definition of the <c>ImageStyle</c> class.
    /// </summary>
    public partial class ImageStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IImageStyle
    {
        /// <summary>
        /// Gets or sets the anti alias.
        /// </summary>
        public bool? AntiAlias { get; set; } = true;

        /// <summary>
        /// Gets or sets the crop bound.
        /// </summary>
        public Auriga.Diagram.Notation.IBounds CropBound
        {
            get => this.backingCropBound;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCropBound = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CropBound"/>.
        /// </summary>
        private Auriga.Diagram.Notation.IBounds backingCropBound;

        /// <summary>
        /// Gets or sets the maintain aspect ratio.
        /// </summary>
        public bool? MaintainAspectRatio { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>ImageStyle</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.CropBound != null)
            {
                yield return this.CropBound;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
