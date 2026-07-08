# Introduction

Auriga is a suite of dotnet libraries and tools that are used to deserialize (read), manipulate, and serialize (write) Eclipse Capella™ models. Capella is an open-source Model-Based Systems Engineering (MBSE) tool implementing the [Arcadia](https://mbse-capella.org/arcadia.html) method; its models are stored as Ecore-based XMI. Auriga makes the Capella semantic model (the five Arcadia architecture layers and the common packages) available as an in-memory .NET object graph, typically to support opinionated template-based code-generation and model transformation, and is a part of `modeltopia`.

Auriga builds on [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) for reading the Capella Ecore metamodel, and is a sibling of [uml4net](https://github.com/STARIONGROUP/uml4net) and [SysML2.NET](https://github.com/STARIONGROUP/SysML2.NET). Auriga provides a number of libraries that are described in the following sections.

> **Scope note.** Version 1 targets the Capella **semantic model** (`.capella` / `.melodymodeller` and `.capellafragment` files). The Sirius diagram/representation files (`.aird`) are out of scope for v1.

## Auriga

The core library that contains the Capella object model: the C# implementation of the Capella metamodel (the Arcadia layers — Operational Analysis, System Analysis, Logical Architecture, Physical Architecture, EPBS — and the common packages), generated from the Capella Ecore metamodel. Together with **Auriga.Xmi** it provides the capability to read and write Capella models and make them available as an in-memory object graph.

## Auriga.Xmi

The **Auriga.Xmi** library provides an XMI reader implementation to read Capella semantic model files (`.capella` / `.melodymodeller`) and an XMI writer implementation to write them back. It resolves intra-file (`xmi:id`) and cross-file (`href`) references, including references that cross `.capellafragment` boundaries, into a fully resolved object graph.

## Auriga.Extensions

The **Auriga.Extensions** library provides LINQ-style query extension methods over the Auriga object graph, following the `uml4net.Extensions` pattern: containment navigation (`QueryAncestors`, `QueryRoot`, `QueryAllFunctions`, `QueryAllComponents`), component-functional allocation (`QueryAllocatedFunctions`, `IsAllocatedTo`, `QueryAllocatingBlocks`), function/component ports and functional exchanges, and cross-layer realization (`QueryRealizedFunctions`/`QueryRealizingFunctions` and the component equivalents). See [Query Extension Methods](docs/query-extensions.md).

## Auriga.CodeGenerator

The **Auriga.CodeGenerator** is an Ecore-to-C# code generator, built on [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) and [ECoreNetto.HandleBars](https://github.com/STARIONGROUP/EcoreNetto), that emits the Auriga object model from the vendored Capella `.ecore` files. It is a development-time tool and is not published as a package.

## Auriga.Reporting

The **Auriga.Reporting** tool renders a browsable HTML report of the Capella metamodel from the vendored `.ecore` files, using the [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) `HtmlReportGenerator` — the same report generator used by the sibling projects (uml4net, SysML2.NET). The [`docker-build-docs-local.sh`](docker-build-docs-local.sh) and [`docker-build-docs-attested.sh`](docker-build-docs-attested.sh) scripts render the report and serve it from an nginx image ([`HtmlDocs/Dockerfile`](HtmlDocs/Dockerfile)). See [Capella Metamodel HTML Report](docs/metamodel-report.md) for build and run instructions. It is a development-time tool and is not published as a package.

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

  - `Auriga` — the Capella object model
  - `Auriga.Xmi` — the `.capella` / `.melodymodeller` reader and writer
  - `Auriga.Extensions` — query extension methods

# Build Status

GitHub Actions are used to build and test the Auriga libraries.

Branch | Build Status
------- | :------------
Master | ![Build Status](https://github.com/STARIONGROUP/Auriga/actions/workflows/CodeQuality.yml/badge.svg?branch=master)
Development | ![Build Status](https://github.com/STARIONGROUP/Auriga/actions/workflows/CodeQuality.yml/badge.svg?branch=development)

# Documentation

Background and design documentation lives in the [`docs`](docs) folder:

  - [Capella Metamodel Inventory](docs/metamodel-inventory.md) — the `.ecore` files, the inter-package dependency graph, and the v1 code-generation scope
  - [Arcadia Semantics Not Visible in Raw Ecore](docs/arcadia-notes.md) — the layer, allocation, realization, and containment conventions the public API must respect
  - [ECoreNetto Validation Against the Capella Metamodel](docs/ecorenetto-validation.md) — proof that ECoreNetto loads the full Capella metamodel with fully resolved references
  - [Capella Metamodel HTML Report](docs/metamodel-report.md) — building and hosting the browsable metamodel report (`Auriga.Reporting`, with Docker build scripts)
  - [Query Extension Methods](docs/query-extensions.md) — the `Auriga.Extensions` LINQ query set for functions, components, ports, exchanges, and cross-layer allocation/realization

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

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitally signed to s.gerene@stariongroup.eu. You can find the CLA's in the CLA folder.

[Contribution guidelines for this project](.github/CONTRIBUTING.md)
