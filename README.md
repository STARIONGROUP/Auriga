<p align="center">
  <img src="https://raw.githubusercontent.com/STARIONGROUP/Auriga/development/assets/auriga-readme-emblem.png" alt="Auriga — Capella models for .NET" width="480">
</p>

# Introduction

Auriga is a suite of dotnet libraries and tools for reading, manipulating and writing Eclipse Capella™ models. Capella is an open-source Model-Based Systems Engineering (MBSE) tool implementing the [Arcadia](https://mbse-capella.org/arcadia.html) method; its models are Ecore-based XMI. Auriga makes the Capella semantic model available as an in-memory .NET object graph, and builds on [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) — it is a sibling of [uml4net](https://github.com/STARIONGROUP/uml4net) and [SysML2.NET](https://github.com/STARIONGROUP/SysML2.NET), and a part of `modeltopia`.

## Auriga

The core library: shared base types (`Auriga.Core`) plus two generated object models — the Capella semantic metamodel (`Auriga.Model.*`, the five Arcadia layers and common packages) and the Sirius/GMF diagramming metamodel (`Auriga.Diagram.*`). Combined with **Auriga.Xmi**, it reads and writes Capella models as an in-memory object graph.

## Auriga.Xmi

XMI readers for Capella semantic files (`.capella` / `.melodymodeller`) and Sirius diagram files (`.aird`), resolving intra-file and cross-file (`.capellafragment`) references into one graph, plus a writer that serializes back to Capella-faithful XMI. See [XMI Writer](https://github.com/STARIONGROUP/Auriga/wiki/Xmi-Writer).

## Auriga.Extensions

LINQ-style query extensions over the object graph — containment navigation, component/function allocation, ports, exchanges, and cross-layer realization. See [Query Extension Methods](https://github.com/STARIONGROUP/Auriga/wiki/Query-Extensions).

## Auriga.Reporting

Renders a model's diagrams and tables to SVG, PNG/JPEG and Excel, over an intermediate `Diagram` model whose layout comes from the persisted Sirius/GMF geometry — never computed. Rendering degrades rather than throws; enable `Debug` logging to see what an export couldn't resolve. See [Sirius `.aird` Diagrams](https://github.com/STARIONGROUP/Auriga/wiki/Aird).

## Auriga.Tools

The `aurigatools` command-line application exports the diagrams of a Capella model without writing any code, published as a [dotnet tool](https://learn.microsoft.com/dotnet/core/tools/global-tools):

```
dotnet tool install --global Auriga.Tools

aurigatools list "In-Flight Entertainment System.aird"
aurigatools export "In-Flight Entertainment System.aird" -o out --format svg,png --scale 2
```

`list` shows the representations a model holds; `export` writes them (`--format svg|png|jpeg|xlsx`, `--scale`/`--dpi`, `--name` to filter by wildcard). Every release also attaches a standalone executable per platform (`aurigatools-<version>-win-x64.zip` etc.) — download, unzip, run, no .NET required.

## Auriga.CodeGenerator

A development-time tool, published as no package, that generates both object models above from the vendored `.ecore` files via [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) and Handlebars templates. The generated code is committed and a CI drift guard regenerates it on every build. See [Auriga.CodeGenerator Design](https://github.com/STARIONGROUP/Auriga/wiki/Codegen-Design) and [Capella Metamodel HTML Report](https://github.com/STARIONGROUP/Auriga/wiki/Metamodel-Report).

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

Render the diagrams of a Sirius `.aird` session to SVG, PNG and Excel:

```csharp
using Auriga.Reporting;
using Auriga.Xmi;

using var reporting = ReportingBuilder.Create();
using var reader = XmiReaderBuilder.Create();
var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");

var svgExporter = reporting.BuildSvgExporter();
var rasterExporter = reporting.BuildRasterExporter();

foreach (var diagram in reporting.BuildDiagramBuilder().BuildAll(session.Elements.Values))
{
    svgExporter.ExportToFile(diagram, $"out/{diagram.Name}.svg");
    rasterExporter.ExportToFile(diagram, $"out/{diagram.Name}.png", new RasterOptions { Scale = 2 });
}

// Tables export to Excel the same way, one worksheet per table.
var xlsxExporter = reporting.BuildXlsxTableExporter();
foreach (var table in session.Elements.Values.OfType<Auriga.Diagram.Table.IDTable>())
{
    xlsxExporter.Export(table, $"out/{table.Uid}.xlsx");
}
```

See [Sirius `.aird` Diagrams](https://github.com/STARIONGROUP/Auriga/wiki/Aird), [ContainerList Design](https://github.com/STARIONGROUP/Auriga/wiki/Containment-List), [Query Extension Methods](https://github.com/STARIONGROUP/Auriga/wiki/Query-Extensions)
and [XMI Writer](https://github.com/STARIONGROUP/Auriga/wiki/Xmi-Writer) for these APIs in depth.

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
  - `Auriga.Tools` — the `aurigatools` command-line application, installed with `dotnet tool install -g Auriga.Tools`

# Build Status

GitHub Actions are used to build and test the Auriga libraries.

Branch | Build Status
------- | :------------
Master | ![Build Status](https://github.com/STARIONGROUP/Auriga/actions/workflows/CodeQuality.yml/badge.svg?branch=master)
Development | ![Build Status](https://github.com/STARIONGROUP/Auriga/actions/workflows/CodeQuality.yml/badge.svg?branch=development)

# Documentation

Background and design documentation lives in the [Auriga wiki](https://github.com/STARIONGROUP/Auriga/wiki):

  - [Capella Metamodel Inventory](https://github.com/STARIONGROUP/Auriga/wiki/Metamodel-Inventory) — the `.ecore` files, the inter-package dependency graph, and the v1 code-generation scope
  - [Sirius Metamodel Inventory](https://github.com/STARIONGROUP/Auriga/wiki/Sirius-Metamodel-Inventory) — the same inventory for the Sirius/GMF diagramming `.ecore` files behind the `.aird` representation model
  - [Arcadia Notes](https://github.com/STARIONGROUP/Auriga/wiki/Arcadia-Notes) — the layer, allocation, realization, and containment conventions the public API must respect
  - [ECoreNetto Validation](https://github.com/STARIONGROUP/Auriga/wiki/ECoreNetto-Validation) — proof that ECoreNetto loads the full Capella metamodel with fully resolved references
  - [Sirius ECoreNetto Validation](https://github.com/STARIONGROUP/Auriga/wiki/Sirius-ECoreNetto-Validation) — the same proof for the Sirius/GMF metamodel
  - [Auriga.CodeGenerator Design](https://github.com/STARIONGROUP/Auriga/wiki/Codegen-Design) — how the vendored `.ecore` files become the committed C# object model: the pipeline, the Handlebars templates, and the naming rules
  - [Fragment Loading](https://github.com/STARIONGROUP/Auriga/wiki/Fragment-Loading) — how a model split across `.capellafragment` files is loaded and its cross-fragment `href`s resolved
  - [Sirius `.aird` Diagrams](https://github.com/STARIONGROUP/Auriga/wiki/Aird) — the two parallel trees an `.aird` carries, how they pair into the intermediate diagram model, and what the rendering does and does not promise
  - [Capella Metamodel HTML Report](https://github.com/STARIONGROUP/Auriga/wiki/Metamodel-Report) — building and hosting the browsable metamodel report (`Auriga.CodeGenerator`, with Docker build scripts)
  - [Query Extension Methods](https://github.com/STARIONGROUP/Auriga/wiki/Query-Extensions) — the `Auriga.Extensions` LINQ query set for functions, components, ports, exchanges, and cross-layer allocation/realization
  - [ContainerList Design](https://github.com/STARIONGROUP/Auriga/wiki/Containment-List) — the non-bypassable `Collection<T>`-based containment collection and its exclusive-ownership (reject-not-steal) semantics
  - [XMI Writer](https://github.com/STARIONGROUP/Auriga/wiki/Xmi-Writer) — serializing the object graph back to Capella-faithful XMI (`Auriga.Xmi`), fragment layout, and the fidelity model
  - [Validation Against Real Capella Models](https://github.com/STARIONGROUP/Auriga/wiki/Validation) — the round-trip validation harness, per-model results, and exactly how out-of-scope content (other versions, add-on viewpoints, diagrams) is handled

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
