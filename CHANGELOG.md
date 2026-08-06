# Changelog

All notable changes to the Auriga packages are recorded here, newest first.

Record a change under `## [Unreleased]`, in the `### <PackageId>` subsection of the package it
affects, as a `- [ADD]` (new capability), `- [FIX]` (corrected behaviour) or `- [CHG]` (changed or
removed API) bullet. A release names only the packages it changed; a package with no subsection did
not change in that release.

The `Nuget-Release` workflow is what turns this file into a release: it moves `[Unreleased]` under
the version being released, writes each package's bullets into that package's
`<PackageReleaseNotes>` — which is generated, never hand-edited — and builds the GitHub release
body from the same section. `Auriga.CodeGenerator` and `Auriga.Samples` are development-time projects
that ship no package, so they are not recorded here.

## [Unreleased]

### Auriga

- [CHG] merge Auriga.Core and Auriga.Sirius into the Auriga package; the Capella model moves to the Auriga.Model.* namespaces and the Sirius/GMF diagram model ships as Auriga.Diagram.*
- [ADD] Auriga.Core.IEStringToStringMapEntry / EStringToStringMapEntry: the key/value pair an EMap<String, String>-typed feature holds (EMF's inline ecore:EStringToStringMapEntry serialization, e.g. a Sirius DAnnotation's details)
- [FIX] generated properties initialize from the metamodel's defaultValueLiteral, so an attribute EMF omitted (value equal to the declared default) reads as the declared default instead of the CLR default — e.g. an EdgeStyle without targetArrow is an InputArrow, not NoDecoration

### Auriga.Xmi

- [CHG] merge Auriga.Xmi.Core and Auriga.Sirius.Xmi into the Auriga.Xmi package; the Capella readers/writers move to Auriga.Xmi.Model.* and the Sirius readers/writers ship as Auriga.Xmi.Diagram.*
- [CHG] a single XmiReaderBuilder/XmiWriterBuilder now reads and writes both .capella and .aird documents; SiriusXmiReaderBuilder is removed
- [CHG] Autofac-based composition (following uml4net): XmiReaderBuilder/XmiWriterBuilder are fluent entry points over disposable XmiReaderScope/XmiWriterScope containers; CapellaModelLoader.Create and AirdModelLoader.Create are replaced by the BuildCapellaModelLoader/BuildAirdModelLoader scope terminals
- [ADD] AirdModelLoader: load a Sirius .aird (file or project directory) with transitive .airdfragment following
- [ADD] AirdModelLoader co-loads the Capella semantic documents the diagrams reference; the cross-metamodel target/semanticElements links resolve into the Capella graph (IXmiReader gains a Read overload taking the referenced-document extensions)
- [ADD] read inline ecore:EStringToStringMapEntry map entries into key/value pairs on the owning EMap-typed feature; the .aird documents that carry them (DAnnotation details, GMF style property maps) now read
- [ADD] the GMF notation geometry tree reads: the generators honor ExtendedMetaData XML names, so the notation:Diagram children/edges containments (persistedChildren/persistedEdges) load with their Bounds, Location and bendpoint layout data
- [FIX] the generated writers omit attribute values equal to the metamodel's defaultValueLiteral, mirroring EMF, so the new default-initialized properties round-trip without materializing attributes the original file never had
- [FIX] a reader or writer scope no longer disposes the ILoggerFactory or the settings it was handed; they are registered as externally owned, so a caller can build a second scope from the same logger factory instead of meeting ObjectDisposedException

### Auriga.Extensions

- [ADD] LINQ query extension methods for functions, components, ports, exchanges, and cross-layer allocation/realization; fixes #16

### Auriga.Reporting

- [ADD] the intermediate diagram model (Diagram, Box, Edge, Label, Point, Style) and the DiagramBuilder that builds it from a parsed .aird session: persisted GMF geometry paired with the Sirius representation elements and their resolved Capella semantic targets
- [ADD] style resolution (behind the injectable IStyleResolver / ICapellaDefaultPalette): every built item carries a ResolvedStyle (fill/gradient, stroke color-width-pattern, font, arrows, workspace-image path) resolved from the Sirius owned style, the GMF notation styles and the Capella default palette, with sane fallbacks for unknown or malformed styles
- [ADD] SvgExporter (behind the injectable ISvgExporter): serialize a Diagram to plain SVG (string, stream or file) with no external dependency — nested box groups, routed edge paths, wrapped labels, gradients and arrow markers in defs, and a padded viewBox from the persisted geometry
- [ADD] sequence-diagram rendering: the builder honors the persisted AbsoluteBoundsFilter layout (instance roles, executions, states, fragments), turns lifelines into dashed centerlines under their headers, and routes messages horizontally at their execution-anchor heights
- [ADD] per-representation-kind builders (NodeDiagramBuilder, SequenceDiagramBuilder) over a shared DiagramBuilderBase core, dispatched by the constructor-injectable IDiagramBuilder / DiagramBuilder facade
- [FIX] treat Capella's "." placeholder begin/end edge label as empty so it does not render as a stray dot
- [ADD] metaclass label icons: labels are prefixed with the vendored Capella type icon of their semantic element (Class, Property, Association, components, functions, ...), honoring the persisted showIcon and suppressed outside instance-role headers in sequence diagrams
- [FIX] pin a box's title to the top band when it has children (containers, ported functions) so it no longer vertically centers over the content, and center the icon+title as a clamped block clear of border ports
- [ADD] DNodeList container rendering (classes, enumerations, interfaces): sizes synthesized from the content when unpersisted, DNodeListElement rows stacked left-aligned under a title compartment with a separator rule, and association multiplicities rendered as edge begin/end labels
- [FIX] GMF-faithful edge endpoints: the persisted first/last bendpoint entries are stale artifacts — each endpoint is recomputed as the crossing of the anchor-reference line with the node's bounds (GMF slidable-anchor rule), so arrows meet node boundaries instead of stale points inside or beside them
- [ADD] Capella icon rendering: the vendored EPL-2.0 Capella artwork (Assets/CapellaIcons) is embedded in the assembly, the injectable IIconRegistry / CapellaIconRegistry resolves WorkspaceImage paths to it, and the exporter inlines the images as data: URIs sized to the box bounds
- [CHG] Autofac-based composition (following Auriga.Xmi): ReportingBuilder is the fluent entry point over a disposable ReportingScope container declaring every default registration in one place, with UsingPalette/UsingStyleResolver/UsingIconRegistry/WithLogger overrides and BuildDiagramBuilder/BuildTableBuilder/BuildSvgExporter/BuildXlsxTableExporter terminals; the self-wiring parameterless constructors of DiagramBuilder, NodeDiagramBuilder, SequenceDiagramBuilder, StyleResolver and SvgExporter are removed
- [ADD] hover tooltips (behind the injectable ITooltipResolver / TooltipResolver, overridable with ReportingBuilder.UsingTooltipResolver): every built box and edge carries the type and name of what it represents — falling back to the name the diagram displays, to the owning element and to the notation type — what a relationship connects, and the Capella description reduced to plain text; the SVG exporter emits it as the group's title element, the native tooltip of a browser or SVG viewer, keeping the export self-contained and script-free
- [ADD] IProjectImageRegistry and ReportingBuilder.UsingProjectImages(projectRoot): the default icon registry is the vendored Capella artwork chained with a project-image slot of its own, so serving a model's own images takes a path rather than a hand-built CompositeIconRegistry and adds to the vendored set instead of replacing it
- [ADD] logging through the ILoggerFactory registered with ReportingBuilder.WithLogger: the icon registries trace the paths they do not resolve, the SVG exporter reports each image that rendered as a fallback, the diagram builders report the representations they skipped and the persisted bendpoints and anchor ids that did not parse, and the style resolver traces the style values it could not read; the services take the factory as a constructor parameter
- [ADD] INodeDiagramBuilder and ISequenceDiagramBuilder: DiagramBuilder now depends on the per-kind builder interfaces (with ITableBuilder) rather than on the concrete builders, so each kind is substitutable
- [ADD] raster export (behind the injectable IRasterExporter / SkiaRasterExporter, resolved with ReportingBuilder.BuildRasterExporter): rasterize a Diagram or any SVG text to PNG or JPEG (bytes, stream or file, the format taken from the extension) at a scale or DPI, with a choice of background and JPEG quality; the image is the diagram's viewport rounded to whole pixels times the scale. The package consequently carries SkiaSharp and Svg.Skia, and with them a native asset per platform
- [CHG] the package is renamed from Auriga.Rendering to Auriga.Reporting: it writes Excel workbooks as well as SVG and PNG, so it reports rather than renders, matching uml4net.Reporting. The types move into Model, Builders, Drawing, Generators, Styles and Icons namespaces, and RenderingBuilder / RenderingScope / IRenderingScope become ReportingBuilder / ReportingScope / IReportingScope
- [ADD] IDiagramReportGenerator / DiagramReportGenerator: load a .aird and write every representation to SVG, PNG, JPEG and Excel in one call, with a format set, a raster scale or DPI, a background and a wildcard name filter (DiagramReportOptions), reporting what it is doing through an optional IProgress. It resolves a model's own artwork against the model's directory, so UsingProjectImages needs no wiring, and Query lists a model's representations without writing anything
- [FIX] a scope no longer disposes the services it was handed: the ILoggerFactory given to WithLogger, and the palette, style resolver, tooltip resolver and icon registry given to the Using* methods, are registered as externally owned. Disposing one scope previously disposed the caller's logger factory, so a second scope built from the same factory threw ObjectDisposedException

### Auriga.Tools

- [ADD] a command-line tool, published as a dotnet tool: `dotnet tool install -g Auriga.Tools` then `aurigatools export <model.aird> -o out --format svg,png` writes a picture per diagram with no compiler and no code, and `aurigatools list <model.aird>` names what a model holds without writing anything. Formats, raster scale or DPI, background, JPEG quality and a wildcard name filter are options; progress, a per-format summary and errors are rendered with Spectre.Console

## [1.0.0] - 2026-07-10

### Auriga

- Initial Release

### Auriga.Xmi

- Initial Release

### Auriga.Extensions

- Initial Release
