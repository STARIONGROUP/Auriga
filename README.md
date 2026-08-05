# Introduction

Auriga is a suite of dotnet libraries and tools that are used to deserialize (read), manipulate, and serialize (write) Eclipse Capella™ models. Capella is an open-source Model-Based Systems Engineering (MBSE) tool implementing the [Arcadia](https://mbse-capella.org/arcadia.html) method; its models are stored as Ecore-based XMI. Auriga makes the Capella semantic model (the five Arcadia architecture layers and the common packages) available as an in-memory .NET object graph, typically to support opinionated template-based code-generation and model transformation, and is a part of `modeltopia`.

Auriga builds on [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) for reading the Capella Ecore metamodel, and is a sibling of [uml4net](https://github.com/STARIONGROUP/uml4net) and [SysML2.NET](https://github.com/STARIONGROUP/SysML2.NET). Auriga provides a number of libraries that are described in the following sections.

## Auriga

The core library that contains the shared base types (the `Auriga.Core` namespace) and two generated object models: the Capella semantic metamodel (the Arcadia layers — Operational Analysis, System Analysis, Logical Architecture, Physical Architecture, EPBS — and the common packages) under the `Auriga.Model.*` namespaces, and the Sirius/GMF diagramming metamodel (the `.aird` representation model) under the `Auriga.Diagram.*` namespaces. Together with **Auriga.Xmi** it provides the capability to read and write Capella models and make them available as an in-memory object graph.

## Auriga.Xmi

The **Auriga.Xmi** library provides XMI reader implementations to read Capella semantic model files (`.capella` / `.melodymodeller`, the `Auriga.Xmi.Model.*` namespaces) and Sirius diagram files (`.aird`, the `Auriga.Xmi.Diagram.*` namespaces), and an XMI writer implementation to write them back, all built on a metamodel-agnostic XMI runtime (the `Auriga.Xmi.Core.*` namespaces). It resolves intra-file (`xmi:id`) and cross-file (`href`) references, including references that cross `.capellafragment` boundaries, into a fully resolved object graph. The writer serializes the graph back to Capella-faithful XMI, preserving the fragment layout — see [XMI Writer](docs/xmi-writer.md).

## Auriga.Extensions

The **Auriga.Extensions** library provides LINQ-style query extension methods over the Auriga object graph, following the `uml4net.Extensions` pattern: containment navigation (`QueryAncestors`, `QueryRoot`, `QueryAllFunctions`, `QueryAllComponents`), component-functional allocation (`QueryAllocatedFunctions`, `IsAllocatedTo`, `QueryAllocatingBlocks`), function/component ports and functional exchanges, and cross-layer realization (`QueryRealizedFunctions`/`QueryRealizingFunctions` and the component equivalents). See [Query Extension Methods](docs/query-extensions.md).

## Auriga.Reporting

The **Auriga.Reporting** library turns a model's diagrams into the artifacts a reader consumes — SVG, PNG, JPEG and Excel — over a renderer-agnostic intermediate diagram model: `IDiagramBuilder.Build` turns a parsed Sirius representation into a `Diagram` of `Box`es and `Edge`s whose coordinates are absolute and taken from the persisted GMF layout (never computed), pairing every notation view with the Sirius element that names and styles it and with its resolved Capella semantic element. Every item carries a `ResolvedStyle` (colors, fonts, line patterns, arrows) resolved from the persisted Sirius/GMF styles with Capella-default fallbacks, and `ISvgExporter` serializes a diagram to plain SVG (string, stream or file) — the SVG writer itself is dependency-free, built on `System.Xml.Linq` alone. Every item also carries a `Tooltip`, resolved by the injectable `ITooltipResolver` — the type and name of what it represents, what a relationship connects, and the Capella `description` reduced to plain text — which the exporter emits as the group's SVG `title`, so hovering a rendered element in a browser explains it without any scripting.

`IRasterExporter` is the bitmap counterpart, for the consumers that cannot take a vector document — a thumbnail, a Word or PowerPoint report, an issue-tracker attachment. It rasterizes a diagram (or any SVG text) to PNG or JPEG at a requested scale or DPI, by way of the very SVG the exporter produces, so the bitmap carries the same palette, styles and artwork. The image measures the diagram's viewport rounded to whole pixels, multiplied by `RasterOptions.Scale`; PNG keeps transparency, JPEG composites onto white unless a background is given. Rasterization is done with [SkiaSharp](https://github.com/mono/SkiaSharp) and [Svg.Skia](https://github.com/wieslawsoltes/Svg.Skia), which is why this package — unlike the rest of Auriga — carries native assets, one set per platform; the SVG *writer* itself remains `System.Xml.Linq` alone.

Sirius table representations are covered as well. Unlike a diagram, a table persists no layout, so `ITableBuilder` synthesizes the grid: it lays a `DTable` out as the same `Diagram` of boxes, which makes the SVG exporter the table's visual export. `IXlsxTableExporter` is the editable counterpart, writing one or more tables to an Excel workbook (a worksheet each) via [ClosedXML](https://github.com/ClosedXML/ClosedXML).

The services are composed through `RenderingBuilder.Create()`, the same fluent-scope pattern as `XmiReaderBuilder`, so any of them — the icon registry, the palette, the style resolver, the tooltip resolver, the exporters — can be substituted in one place. `UsingProjectImages(projectRoot)` adds the artwork a model carries itself (a `WorkspaceImage` pointing inside the project rather than at a Capella plugin) to the vendored Capella icon set rather than replacing it.

Rendering degrades rather than throws — a diagram that renders imperfectly beats one that does not render at all — and `WithLogger(ILoggerFactory)` is where those degradations surface: at Debug, the images no registry resolved, the representations skipped for want of a persisted layout, and the malformed bendpoints and anchor ids that fell back to view centres; at Trace, each unresolved image path and each style value that did not parse. A well-formed model stays silent at Information and above, so turning on Debug is what explains a difference between what Capella shows and what Auriga exported.

## Auriga.CodeGenerator

The **Auriga.CodeGenerator** tool is everything the repository does with the vendored `.ecore` files, and is a development-time tool published as no package.

It generates both object models described above, using [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) to load the metamodel and Handlebars templates to emit the code — the POCOs and interfaces in **Auriga**, and the per-type XMI readers and writers in **Auriga.Xmi**. The generated code is committed, and a CI drift guard regenerates it on every build and fails if the result differs from what is committed, so the templates and the checked-in code cannot fall out of step. Generation itself is driven from `[Explicit]` tests rather than a CLI, following the same convention as uml4net. See [Auriga.CodeGenerator Design](docs/codegen-design.md).

Its command-line entry point renders a browsable HTML report of the Capella metamodel from the same `.ecore` files, using the ECoreNetto `HtmlReportGenerator` — the same report generator used by the sibling projects (uml4net, SysML2.NET). The [`docker-build-docs-local.sh`](docker-build-docs-local.sh) and [`docker-build-docs-attested.sh`](docker-build-docs-attested.sh) scripts render the report and serve it from an nginx image ([`HtmlDocs/Dockerfile`](HtmlDocs/Dockerfile)). See [Capella Metamodel HTML Report](docs/metamodel-report.md) for build and run instructions.

# Getting Started

Install the packages from NuGet (once published):

```
dotnet add package Auriga
dotnet add package Auriga.Xmi
dotnet add package Auriga.Extensions
dotnet add package Auriga.Reporting
```

Load a Capella project, navigate the Arcadia layers, query it, and write it back:

```csharp
using Auriga.Xmi;
using Auriga.Extensions;

// 1) Load a project — pass the .capella / .melodymodeller file or the project directory.
//    Referenced .capellafragment files are discovered and resolved into one object graph.
var project = CapellaProject.Load("In-Flight Entertainment System/In-Flight Entertainment System.capella");

// 2) Navigate the Arcadia layers as first-class properties (null when a layer is absent).
var logical = project.LogicalArchitecture;
var physical = project.PhysicalArchitecture;

// 3) Query with LINQ and the Auriga.Extensions methods.
foreach (var component in logical!.QueryAllComponents())
{
    foreach (var function in component.QueryAllocatedFunctions())
    {
        // function.IsAllocatedTo(component) == true
    }
}

// Any element can walk its own subtree; combine with LINQ for ad-hoc queries.
var exchanges = project.Project!
    .QueryAllContainedElements()
    .OfType<Auriga.Model.Fa.IFunctionalExchange>();

// 4) Write the (possibly modified) model back to disk — the fragment layout is preserved.
var writer = XmiWriterBuilder.Create().Build();
writer.Write(project.Project!, "out/In-Flight Entertainment System.capella");
```

Render the diagrams of a Sirius `.aird` session to SVG:

```csharp
using Auriga.Reporting;
using Auriga.Xmi;
using Microsoft.Extensions.Logging;

// The rendering services compose the same way the readers do: a disposable scope with
// fluent overrides for the parts you want to replace. UsingProjectImages serves the
// artwork the model carries itself, chained onto the vendored Capella icons; your own
// logger factory reports what the renderer degraded — an image no registry resolved, a
// representation with no persisted layout, geometry that did not parse — at Debug.
using var rendering = RenderingBuilder.Create()
    .UsingProjectImages("In-Flight Entertainment System")
    .WithLogger(loggerFactory);

using var reader = XmiReaderBuilder.Create();
var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");

var svgExporter = rendering.BuildSvgExporter();

foreach (var diagram in rendering.BuildDiagramBuilder().BuildAll(session.Elements.Values))
{
    svgExporter.ExportToFile(diagram, $"out/{diagram.Name}.svg");
}
```

Rasterize the same diagrams to PNG or JPEG, for the consumers that cannot take a vector document:

```csharp
using Auriga.Reporting;
using Auriga.Xmi;

using var rendering = RenderingBuilder.Create();
using var reader = XmiReaderBuilder.Create();

var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");

// The raster exporter draws the very SVG the SVG exporter produces, so the bitmap
// carries the same palette, styles and artwork. The format comes from the extension.
var rasterExporter = rendering.BuildRasterExporter();

foreach (var diagram in rendering.BuildDiagramBuilder().BuildAll(session.Elements.Values))
{
    // Twice the persisted size, on a white background instead of PNG's transparency.
    rasterExporter.ExportToFile(
        diagram,
        $"out/{diagram.Name}.png",
        new RasterOptions { Scale = 2, Background = new Color(255, 255, 255) });

    // Or hand the bytes to whatever wanted the picture, at print resolution.
    var jpeg = rasterExporter.Export(diagram, RasterFormat.Jpeg, RasterOptions.FromDpi(300));
}
```

Export the table representations of the same session to Excel:

```csharp
using Auriga.Reporting;
using Auriga.Xmi;

using var rendering = RenderingBuilder.Create();
using var reader = XmiReaderBuilder.Create();

var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");
var tables = session.Elements.Values.OfType<Auriga.Diagram.Table.IDTable>().ToList();

var xlsxExporter = rendering.BuildXlsxTableExporter();

// One workbook per table, or pass a name-to-table sequence to get one workbook of many sheets.
foreach (var table in tables)
{
    xlsxExporter.Export(table, $"out/{table.Uid}.xlsx");
}

// The same table also lays out as a grid of boxes, which the SVG exporter renders.
var grid = rendering.BuildTableBuilder().Build(tables.First());
```

See [ContainerList Design](docs/containment-list.md), [Query Extension Methods](docs/query-extensions.md)
and [XMI Writer](docs/xmi-writer.md) for the containment, query and write-back APIs in depth.

# Code Quality

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=coverage)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_Auriga&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=STARIONGROUP_Auriga)

# Installation

Auriga is in early development and has not yet had its first release. Once published, the packages will be available on NuGet:

  - `Auriga` — the Capella object model (`Auriga.Model.*`) and the Sirius/GMF diagram object model (`Auriga.Diagram.*`)
  - `Auriga.Xmi` — the `.capella` / `.melodymodeller` / `.aird` readers and writers
  - `Auriga.Extensions` — query extension methods
  - `Auriga.Reporting` — the intermediate diagram model built from the persisted `.aird` layout, with SVG, PNG/JPEG and Excel exports

# Build Status

GitHub Actions are used to build and test the Auriga libraries.

Branch | Build Status
------- | :------------
Master | ![Build Status](https://github.com/STARIONGROUP/Auriga/actions/workflows/CodeQuality.yml/badge.svg?branch=master)
Development | ![Build Status](https://github.com/STARIONGROUP/Auriga/actions/workflows/CodeQuality.yml/badge.svg?branch=development)

# Documentation

Background and design documentation lives in the [`docs`](docs) folder:

  - [Capella Metamodel Inventory](docs/metamodel-inventory.md) — the `.ecore` files, the inter-package dependency graph, and the v1 code-generation scope
  - [Sirius Metamodel Inventory](docs/sirius-metamodel-inventory.md) — the same inventory for the Sirius/GMF diagramming `.ecore` files behind the `.aird` representation model
  - [Arcadia Semantics Not Visible in Raw Ecore](docs/arcadia-notes.md) — the layer, allocation, realization, and containment conventions the public API must respect
  - [ECoreNetto Validation Against the Capella Metamodel](docs/ecorenetto-validation.md) — proof that ECoreNetto loads the full Capella metamodel with fully resolved references
  - [ECoreNetto Validation Against the Sirius Metamodel](docs/sirius-ecorenetto-validation.md) — the same proof for the Sirius/GMF metamodel
  - [Auriga.CodeGenerator Design](docs/codegen-design.md) — how the vendored `.ecore` files become the committed C# object model: the pipeline, the Handlebars templates, and the naming rules
  - [Fragment Loading](docs/fragment-loading.md) — how a model split across `.capellafragment` files is loaded and its cross-fragment `href`s resolved
  - [Capella Metamodel HTML Report](docs/metamodel-report.md) — building and hosting the browsable metamodel report (`Auriga.CodeGenerator`, with Docker build scripts)
  - [Query Extension Methods](docs/query-extensions.md) — the `Auriga.Extensions` LINQ query set for functions, components, ports, exchanges, and cross-layer allocation/realization
  - [ContainerList Design](docs/containment-list.md) — the non-bypassable `Collection<T>`-based containment collection and its exclusive-ownership (reject-not-steal) semantics
  - [XMI Writer](docs/xmi-writer.md) — serializing the object graph back to Capella-faithful XMI (`Auriga.Xmi`), fragment layout, and the fidelity model
  - [Validation Against Real Capella Models](docs/validation.md) — the round-trip validation harness, per-model results, and exactly how out-of-scope content (other versions, add-on viewpoints, diagrams) is handled

# Capella and Arcadia Documentation

Eclipse Capella™ is an open-source MBSE tool hosted by the Eclipse Foundation. It implements the Arcadia method, a structured engineering method for the definition and validation of complex systems architecture. Learn more at https://mbse-capella.org and https://eclipse.dev/capella/.

# Software Bill of Materials (SBOM)

As part of our commitment to security and transparency, this project includes a Software Bill of Materials (SBOM) in the associated NuGet packages. The SBOM provides a detailed inventory of the components and dependencies included in the package, allowing you to track and verify the software components, their licenses, and versions.

**Why SBOM?**

- **Improved Transparency**: Gain insight into the open-source and third-party components included in this package.
- **Security Assurance**: By providing an SBOM, we enable users to more easily track vulnerabilities associated with the included components.
- **Compliance**: SBOMs help ensure compliance with licensing requirements and make it easier to audit the project's dependencies.

You can find the SBOM in the NuGet package itself, which is automatically generated and embedded during the build process.

# License

The Auriga libraries are provided to the community under the Apache License 2.0.

Eclipse Capella™ is a trademark of the Eclipse Foundation. Auriga is an independent project and is not affiliated with or endorsed by the Eclipse Foundation.

# Changelog

Notable changes are recorded in [CHANGELOG.md](CHANGELOG.md), under `## [Unreleased]`, in the `### <PackageId>` subsection of the package they affect, as a `- [ADD]` (new capability), `- [FIX]` (corrected behaviour) or `- [CHG]` (changed or removed API) bullet. A change confined to the development-time tools (`Auriga.CodeGenerator`), to tests or to documentation needs no entry.

The `<PackageReleaseNotes>` in each `.csproj` is **generated, not written**: the `Nuget-Release` workflow moves the `[Unreleased]` section under the version being released, writes each package's bullets into that package's `.csproj`, and builds the GitHub release body from the same section — so a published package carries exactly the notes of the release it belongs to. Editing those elements by hand has no lasting effect, since the next release overwrites them. The workflow takes a `dry_run` input that renders the release notes and stops, without committing, packing or publishing anything.

That rendering is done by [`tools/SyncReleaseNotes.cs`](tools/SyncReleaseNotes.cs), which the workflow invokes and which runs anywhere the .NET SDK does, so what a release will say can be checked before dispatching one:

```bash
dotnet run tools/SyncReleaseNotes.cs -- --version 1.1.0
```

It rewrites `CHANGELOG.md`, the four packable `.csproj` files and `RELEASE_NOTES.md` in the working tree and commits nothing, so `git diff` shows the whole of what a release would change, and `git checkout .` undoes it.

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitally signed to s.gerene@stariongroup.eu. You can find the CLA's in the CLA folder.

[Contribution guidelines for this project](.github/CONTRIBUTING.md)
