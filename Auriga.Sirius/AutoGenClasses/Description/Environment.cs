// ------------------------------------------------------------------------------------------------
// <copyright file="Environment.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Environment</c> class.
    /// </summary>
    public partial class Environment : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.IEnvironment
    {
        /// <summary>
        /// Gets the default tools.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> DefaultTools => this.backingDefaultTools ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry>(this);

        /// <summary>
        /// Backing field for <see cref="DefaultTools"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> backingDefaultTools;

        /// <summary>
        /// Gets or sets the label border styles.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Style.ILabelBorderStyles LabelBorderStyles
        {
            get => this.backingLabelBorderStyles;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingLabelBorderStyles = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="LabelBorderStyles"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Style.ILabelBorderStyles backingLabelBorderStyles;

        /// <summary>
        /// Gets or sets the system colors.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.ISytemColorsPalette SystemColors
        {
            get => this.backingSystemColors;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingSystemColors = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="SystemColors"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.ISytemColorsPalette backingSystemColors;

        /// <summary>
        /// Gets the elements directly contained by this <c>Environment</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.DefaultTools)
            {
                yield return element;
            }

            if (this.LabelBorderStyles != null)
            {
                yield return this.LabelBorderStyles;
            }

            if (this.SystemColors != null)
            {
                yield return this.SystemColors;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
