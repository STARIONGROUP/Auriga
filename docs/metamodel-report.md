# Capella Metamodel HTML Report

`Auriga.Reporting` renders a browsable, self-contained static HTML site of the Capella metamodel from
the vendored `.ecore` files — one page per package, class/interface and enumeration, fully cross-linked
— mirroring what [sysml2.net](https://sysml2.net) does for the SysML v2 metamodel. It reuses
[ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto) to load the metamodel and HandleBars templates
to render the pages, following the same convention as `Auriga.CodeGenerator`.

## What it produces

A flat set of files, so cross-links are plain relative file names that work from a web server or
straight off the file system:

| File | Contents |
|---|---|
| `index.html` | Landing page: every package with its class and enumeration counts. |
| `package.<pkg>.html` | A package's classes, interfaces and enumerations. |
| `class.<pkg>.<Class>.html` | A class: documentation, super-types and sub-types (linked), and the flattened feature table (name, type — linked, multiplicity, kind — attribute/reference/containment, derived, declaring class). |
| `enum.<pkg>.<Enum>.html` | An enumeration: its literals, values and documentation. |
| `styles.css` | A single bundled stylesheet (light/dark aware). No external CDN dependency. |

The current Capella v1 metamodel renders to **25 packages, 430 classes and 35 enumerations**. Output is
deterministic — a pure function of the `.ecore` files.

## Build and run locally

From the repository root:

```bash
dotnet run --project Auriga.Reporting -- --ecore resources/ecore --output report-output
```

Then open `report-output/index.html` in a browser. Both options have defaults (`resources/ecore` and
`report-output`), so `dotnet run --project Auriga.Reporting` alone works from the repository root.

| Option | Default | Meaning |
|---|---|---|
| `--ecore <dir>` | `resources/ecore` | the directory of vendored `.ecore` files |
| `--output <dir>` | `report-output` | the directory the site is written to |

## Build and serve with Docker

A multi-stage [`Dockerfile`](../Dockerfile) renders the site with the .NET SDK and serves it from a
lightweight nginx image (the final image contains only the static site — no .NET runtime):

```bash
docker build -t auriga-report .
docker run --rm -p 8080:80 auriga-report
# then browse http://localhost:8080
```
