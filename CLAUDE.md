# Working in this repository

## Record every user-visible change in CHANGELOG.md

`CHANGELOG.md` is the source of truth for what each package contains. When a change alters what a
consumer of a package can see or do, add a bullet under `## [Unreleased]`, in the
`### <PackageId>` subsection of the package it affects — creating that subsection if the release
does not have one yet:

```markdown
## [Unreleased]

### Auriga.Rendering

- [ADD] hover tooltips on the rendered elements, emitted as the SVG group's title
```

Use `[ADD]` for a new capability, `[FIX]` for corrected behaviour, and `[CHG]` for a changed or
removed API. Write what a consumer gains or must change, not how it was implemented — one bullet per
change, in the same voice as the entries already there.

No entry is needed for a change confined to the development-time tools (`Auriga.CodeGenerator`,
`Auriga.Reporting`, `Auriga.Samples`), to tests, or to documentation.

## Never edit `<PackageReleaseNotes>`

That element is generated. `tools/SyncReleaseNotes.cs`, run by the `Nuget-Release` workflow
(`.github/workflows/nuget-release.yml`), moves the `[Unreleased]` section under the version being
released, writes each package's bullets into that package's `.csproj`, and renders the GitHub
release body from the same section; the workflow commits, packs and publishes what it produced.
Anything written into the element by hand is overwritten at the next release, and it will not appear
in the release notes — put it in `CHANGELOG.md` instead.

The packable projects are `Auriga`, `Auriga.Xmi`, `Auriga.Extensions` and `Auriga.Rendering`; they
are the only ones that carry the element, and the only ones a changelog subsection can name.

`dotnet run tools/SyncReleaseNotes.cs -- --version <semver>` performs the whole rewrite in the
working tree without committing anything, so what a release would say can be read from `git diff`
and undone with `git checkout .`. Use it to check a changelog edit; never commit its output.
