# Capella Metamodel HTML Report

`Auriga.Reporting` renders a browsable HTML report of the Capella metamodel from the vendored `.ecore`
files, using the [ECoreNetto](https://github.com/STARIONGROUP/EcoreNetto)
`ECoreNetto.Reporting.HtmlReportGenerator` — the same report generator used by the sibling projects
(uml4net, SysML2.NET). It produces a single self-contained HTML file (styles embedded, no external
dependency) covering every package, class and enumeration of the metamodel.

## Build and run locally

From the repository root:

```bash
dotnet run --project Auriga.Reporting -- --ecore resources/ecore --output report/index.html
```

Then open `report/index.html` in a browser. Both options have defaults (`resources/ecore` and
`report/index.html`), so `dotnet run --project Auriga.Reporting` alone works from the repository root.

| Option | Default | Meaning |
|---|---|---|
| `--ecore <dir>` | `resources/ecore` | the directory of vendored `.ecore` files |
| `--output <file.html>` | `report/index.html` | the HTML report file to write |

## Build and serve with Docker

A multi-stage [`Dockerfile`](../Dockerfile) renders the report with the .NET SDK and serves it from a
lightweight nginx image (the final image contains only the static report — no .NET runtime):

```bash
docker build -t auriga-report .
docker run --rm -p 8080:80 auriga-report
# then browse http://localhost:8080
```
