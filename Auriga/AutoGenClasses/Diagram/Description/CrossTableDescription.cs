// ------------------------------------------------------------------------------------------------
// <copyright file="CrossTableDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table.Description
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CrossTableDescription</c> class.
    /// </summary>
    public partial class CrossTableDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Table.Description.ICrossTableDescription
    {
        /// <summary>
        /// Gets the all create line.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Table.Description.ICreateLineTool> AllCreateLine => Enumerable.Empty<Auriga.Diagram.Table.Description.ICreateLineTool>();

        /// <summary>
        /// Gets the all line mappings.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Table.Description.ILineMapping> AllLineMappings => Enumerable.Empty<Auriga.Diagram.Table.Description.ILineMapping>();

        /// <summary>
        /// All tools of the section.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> AllRepresentationCreationDescriptions => Enumerable.Empty<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// All navigation tools.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> AllRepresentationNavigationDescriptions => Enumerable.Empty<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// Gets the create column.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ICreateCrossColumnTool> CreateColumn => this.backingCreateColumn ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.ICreateCrossColumnTool>(this);

        /// <summary>
        /// Backing field for <see cref="CreateColumn"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ICreateCrossColumnTool> backingCreateColumn;

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the end user documentation.
        /// </summary>
        public string EndUserDocumentation { get; set; }

        /// <summary>
        /// Gets the imported elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Core.IAurigaElement> ImportedElements => this.backingImportedElements ??= new Auriga.Core.ContainerList<Auriga.Core.IAurigaElement>(this);

        /// <summary>
        /// Backing field for <see cref="ImportedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Core.IAurigaElement> backingImportedElements;

        /// <summary>
        /// The initial width of the column header (calculated if not available).
        /// </summary>
        public int? InitialHeaderColumnWidth { get; set; }

        /// <summary>
        /// Set to true if your want your representation to be automatically created when initializing a new session.
        /// </summary>
        public bool Initialisation { get; set; }

        /// <summary>
        /// Gets the intersection.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IIntersectionMapping> Intersection => this.backingIntersection ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.IIntersectionMapping>(this);

        /// <summary>
        /// Backing field for <see cref="Intersection"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IIntersectionMapping> backingIntersection;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// You might use this reference to statically bind your representation with a set of Ecore packages. Keep in mind that this is not mandatory.
        /// </summary>
        public List<object> Metamodel { get; } = new List<object>();

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the owned column mappings.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IElementColumnMapping> OwnedColumnMappings => this.backingOwnedColumnMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.IElementColumnMapping>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedColumnMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IElementColumnMapping> backingOwnedColumnMappings;

        /// <summary>
        /// Gets the owned create line.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ICreateLineTool> OwnedCreateLine => this.backingOwnedCreateLine ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.ICreateLineTool>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedCreateLine"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ICreateLineTool> backingOwnedCreateLine;

        /// <summary>
        /// Gets the owned line mappings.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ILineMapping> OwnedLineMappings => this.backingOwnedLineMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.ILineMapping>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedLineMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ILineMapping> backingOwnedLineMappings;

        /// <summary>
        /// All tools of the section.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> OwnedRepresentationCreationDescriptions => this.backingOwnedRepresentationCreationDescriptions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRepresentationCreationDescriptions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> backingOwnedRepresentationCreationDescriptions;

        /// <summary>
        /// All navigation tools.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> OwnedRepresentationNavigationDescriptions => this.backingOwnedRepresentationNavigationDescriptions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRepresentationNavigationDescriptions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> backingOwnedRepresentationNavigationDescriptions;

        /// <summary>
        /// The precondition (Acceleo Expression).
        /// </summary>
        public string PreconditionExpression { get; set; }

        /// <summary>
        /// Gets the reused create line.
        /// </summary>
        public List<Auriga.Diagram.Table.Description.ICreateLineTool> ReusedCreateLine { get; } = new List<Auriga.Diagram.Table.Description.ICreateLineTool>();

        /// <summary>
        /// Gets the reused line mappings.
        /// </summary>
        public List<Auriga.Diagram.Table.Description.ILineMapping> ReusedLineMappings { get; } = new List<Auriga.Diagram.Table.Description.ILineMapping>();

        /// <summary>
        /// All tools of the section.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> ReusedRepresentationCreationDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// All navigation tools.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> ReusedRepresentationNavigationDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// Gets or sets the show on startup.
        /// </summary>
        public bool? ShowOnStartup { get; set; }

        /// <summary>
        /// The default title of the representation. (new + name if empty)
        /// </summary>
        public string TitleExpression { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>CrossTableDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.CreateColumn)
            {
                yield return element;
            }

            foreach (var element in this.ImportedElements)
            {
                yield return element;
            }

            foreach (var element in this.Intersection)
            {
                yield return element;
            }

            foreach (var element in this.OwnedColumnMappings)
            {
                yield return element;
            }

            foreach (var element in this.OwnedCreateLine)
            {
                yield return element;
            }

            foreach (var element in this.OwnedLineMappings)
            {
                yield return element;
            }

            foreach (var element in this.OwnedRepresentationCreationDescriptions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedRepresentationNavigationDescriptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
