// ------------------------------------------------------------------------------------------------
// <copyright file="ToolFilterDescription.cs" company="Starion Group S.A.">
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
    /// filter to hide a tool in UI based on preconditon evaluated when specified elements to listen are modified
    /// </summary>
    public partial class ToolFilterDescription : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription
    {
        /// <summary>
        /// The elements to listen by the filter.
        /// </summary>
        public string ElementsToListen { get; set; }

        /// <summary>
        /// Gets the listeners.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IFeatureChangeListener> Listeners => this.backingListeners ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IFeatureChangeListener>(this);

        /// <summary>
        /// Backing field for <see cref="Listeners"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IFeatureChangeListener> backingListeners;

        /// <summary>
        /// The precondition of the filter.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ToolFilterDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Listeners)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
