// ------------------------------------------------------------------------------------------------
// <copyright file="RasterOptions.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;
    using System.Globalization;

    /// <summary>
    /// How <see cref="IRasterExporter"/> turns a vector document into pixels: how many of them, on
    /// what background, and — for a lossy format — how hard it tries to keep them. The defaults
    /// rasterize at the diagram's persisted size, on transparency, at a quality that shows no
    /// artefacts on a diagram's flat fills.
    /// </summary>
    public sealed class RasterOptions
    {
        /// <summary>
        /// The nominal resolution of the persisted coordinates: Sirius lays a diagram out in
        /// pixels, so <see cref="Scale"/> 1 is 96 dots per inch.
        /// </summary>
        public const double NominalDpi = 96;

        /// <summary>
        /// The backing field of <see cref="Scale"/>.
        /// </summary>
        private double scale = 1;

        /// <summary>
        /// The backing field of <see cref="Quality"/>.
        /// </summary>
        private int quality = 90;

        /// <summary>
        /// Gets or sets the factor the diagram's persisted size is multiplied by, defaulting to 1 —
        /// one pixel per persisted unit. 2 doubles both dimensions, which is what a display of
        /// twice the nominal density wants.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">the scale is not a positive, finite number</exception>
        public double Scale
        {
            get => this.scale;

            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value) || value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "The scale must be a positive, finite number.");
                }

                this.scale = value;
            }
        }

        /// <summary>
        /// Gets or sets the color the diagram is composited onto, or <c>null</c> for the format's
        /// default — transparency for <see cref="RasterFormat.Png"/>, white for
        /// <see cref="RasterFormat.Jpeg"/>, which has no alpha channel and would otherwise
        /// composite onto black.
        /// </summary>
        public Color? Background { get; set; }

        /// <summary>
        /// Gets or sets the encoder quality, from 1 to 100, defaulting to 90. It applies to
        /// <see cref="RasterFormat.Jpeg"/> only; PNG is lossless and ignores it.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">the quality is outside 1 to 100</exception>
        public int Quality
        {
            get => this.quality;

            set
            {
                if (value is < 1 or > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "The quality must be between 1 and 100.");
                }

                this.quality = value;
            }
        }

        /// <summary>
        /// The options that rasterize at the supplied resolution, expressing it as the equivalent
        /// <see cref="Scale"/> — <see cref="NominalDpi"/> is scale 1, so 192 dots per inch is
        /// scale 2. Sugar over <see cref="Scale"/> rather than a second setting, so the two cannot
        /// disagree.
        /// </summary>
        /// <param name="dpi">the target resolution in dots per inch</param>
        /// <returns>the options</returns>
        /// <exception cref="ArgumentOutOfRangeException">the resolution is not a positive, finite number</exception>
        public static RasterOptions FromDpi(double dpi)
        {
            if (double.IsNaN(dpi) || double.IsInfinity(dpi) || dpi <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dpi), dpi, "The resolution must be a positive, finite number.");
            }

            return new RasterOptions { Scale = dpi / NominalDpi };
        }

        /// <summary>
        /// The options as text, for a log message.
        /// </summary>
        /// <returns>the textual representation</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "scale {0}, background {1}, quality {2}",
                this.Scale,
                this.Background?.ToHex() ?? "default",
                this.Quality);
        }
    }
}
