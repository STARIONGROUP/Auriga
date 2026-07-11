// ------------------------------------------------------------------------------------------------
// <copyright file="Switch.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// Swich contains 1 or more Case and 1 Default Case. If no Case condition return true, Default Case is
    /// executed. If there are more Case condition who return true it's the first Condition Case true who is
    /// executed.
    /// </summary>
    public partial class Switch : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.ISwitch
    {
        /// <summary>
        /// Gets the cases.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.ICase> Cases => this.backingCases ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.ICase>(this);

        /// <summary>
        /// Backing field for <see cref="Cases"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.ICase> backingCases;

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IDefault Default
        {
            get => this.backingDefault;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDefault = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Default"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IDefault backingDefault;

        /// <summary>
        /// Gets the elements directly contained by this <c>Switch</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Cases)
            {
                yield return element;
            }

            if (this.Default != null)
            {
                yield return this.Default;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
