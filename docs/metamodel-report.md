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

The report is served from a lightweight, rootless `nginxinc/nginx-unprivileged:alpine` image
([`HtmlDocs/Dockerfile`](../HtmlDocs/Dockerfile)) that hosts the pre-generated `HtmlDocs/index.html`; the
image contains only the static report — no .NET runtime — and nginx runs as a non-root user, listening on
port `8080` inside the container. Two helper scripts (mirroring the sibling SysML2.NET project) generate
the report and build the image:

- [`docker-build-docs-local.sh`](../docker-build-docs-local.sh) `<version>` — generate the report and build
  the image locally, tagged `stariongroup/auriga.docs:latest` and `:<version>`.
- [`docker-build-docs-attested.sh`](../docker-build-docs-attested.sh) `<version>` — the same, built with
  `docker buildx` and pushed with an SBOM and provenance attestation.

```bash
./docker-build-docs-local.sh 1.0.0
docker run --rm -p 8080:8080 stariongroup/auriga.docs:latest
# then browse http://localhost:8080
```
