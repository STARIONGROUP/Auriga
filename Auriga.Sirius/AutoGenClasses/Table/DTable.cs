// ------------------------------------------------------------------------------------------------
// <copyright file="DTable.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DTable</c> class.
    /// </summary>
    public partial class DTable : Auriga.AurigaElement, Auriga.Sirius.Table.IDTable
    {
        /// <summary>
        /// Gets the columns.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Table.IDColumn> Columns => this.backingColumns ??= new Auriga.ContainerList<Auriga.Sirius.Table.IDColumn>(this);

        /// <summary>
        /// Backing field for <see cref="Columns"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Table.IDColumn> backingColumns;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public Auriga.Sirius.Table.Description.ITableDescription Description { get; set; }

        /// <summary>
        /// Gets the documentation.
        /// </summary>
        public string Documentation => default;

        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation> EAnnotations => this.backingEAnnotations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation>(this);

        /// <summary>
        /// Backing field for <see cref="EAnnotations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation> backingEAnnotations;

        /// <summary>
        /// Gets or sets the header column width.
        /// </summary>
        public int? HeaderColumnWidth { get; set; }

        /// <summary>
        /// Gets the lines.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Table.IDLine> Lines => this.backingLines ??= new Auriga.ContainerList<Auriga.Sirius.Table.IDLine>(this);

        /// <summary>
        /// Backing field for <see cref="Lines"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Table.IDLine> backingLines;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name => default;

        /// <summary>
        /// Gets the owned annotation entries.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry> OwnedAnnotationEntries => this.backingOwnedAnnotationEntries ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAnnotationEntries"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry> backingOwnedAnnotationEntries;

        /// <summary>
        /// The directly contained representation elements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.IDRepresentationElement> OwnedRepresentationElements => Enumerable.Empty<Auriga.Sirius.Viewpoint.IDRepresentationElement>();

        /// <summary>
        /// The directly and indirectly contained representation elements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.IDRepresentationElement> RepresentationElements => Enumerable.Empty<Auriga.Sirius.Viewpoint.IDRepresentationElement>();

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// Gets the ui state.
        /// </summary>
        public Auriga.Sirius.Viewpoint.IUIState UiState => default;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DTable</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Columns)
            {
                yield return element;
            }

            foreach (var element in this.EAnnotations)
            {
                yield return element;
            }

            foreach (var element in this.Lines)
            {
                yield return element;
            }

            foreach (var element in this.OwnedAnnotationEntries)
            {
                yield return element;
            }

            if (this.UiState != null)
            {
                yield return this.UiState;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
