# ECoreNetto Validation Against the Capella Metamodel

**Issue:** [#2](https://github.com/STARIONGROUP/capella4net/issues/2)
**ECoreNetto version tested:** 7.0.9 (latest on NuGet at the time of writing)
**Input:** the 21 pinned `.ecore` files in [`resources/ecore/`](../resources/ecore) (see below)

## Verdict

ECoreNetto's **parser fully handles the Capella metamodel** — every package, classifier, structural feature, inheritance relation, and annotation loads and resolves correctly. However, its **lazy cross-reference resolution has defects that make the metamodel unloadable out of the box**: loading `resources/ecore` with a plain `ResourceSet` dies with an uncatchable `StackOverflowException`. Six upstream issues were identified and filed (three blockers, three minor). With two mechanical workarounds applied, everything validates:

```
check 1 - load:       21/21 files loaded
check 2 - counts:     25 packages, 430 classes, 35 enums   (matches docs/metamodel-inventory.md exactly)
check 3 - resolution: 558 supertype refs (0 unresolved), 1096 feature types (0 unresolved)
check 4 - inheritance: 8 cross-package chains verified down to emde::ExtensibleElement
check 6 - annotations: 1253 class-level annotations preserved (documentation, semantic, UML2 mapping, ...)
```

## The vendored metamodel: `resources/ecore/`

Per the recommendation in [`metamodel-inventory.md`](metamodel-inventory.md), the v1-scope `.ecore` files are vendored into this repository, pinned at Capella 7.0.0:

- 16 files taken from `capella/m2/plugins/org.polarsys.capella.{common,core}.data.def/model/` (the copies with same-directory reference style)
- `libraries.ecore`, `re.ecore` from the `common/plugins/*.gen/model/` plugins
- `Requirements.ecore`, `CapellaRequirements.ecore` from `capella-requirements-vp`
- `eMDE.ecore` fetched from [eclipse-kitalpha/kitalpha](https://github.com/eclipse-kitalpha/kitalpha) (`emde/plugins/org.polarsys.kitalpha.emde/model/`)

All `platform:/plugin/...` and `../../...` reference paths were rewritten to same-directory form (`CapellaModeller.ecore#//...`); no semantic changes were made. Every cross-file reference resolves within the directory.

## The validation harness: `validation/EcoreValidation`

```
dotnet run --project validation/EcoreValidation -- resources/ecore --workarounds   # passes
dotnet run --project validation/EcoreValidation -- resources/ecore                 # StackOverflowException (upstream defects)
dotnet run --project validation/EcoreValidation -- <dir> --trace                   # verbose ECoreNetto trace logging
```

Checks performed: (1) all files load through one `ResourceSet`; (2) per-package EClass/EEnum/EDataType counts match the metamodel inventory; (3) every `eSuperTypes` entry and feature `eType` resolves to a non-null classifier; (4) cross-package inheritance chains (e.g. `pa::PhysicalFunction → fa::AbstractFunction`, `ctx::SystemFunction → emde::ExtensibleElement`) are reachable; (5) `eOpposite` pairs are mutual and complete; (6) EAnnotations survive loading.

`--workarounds` stages a temporary copy of the input applying exactly two changes, each tied to an upstream defect:

1. **Rename each file to `<rootPackageName>.ecore`** and rewrite all references (17 of 21 files affected — e.g. `CompositeStructure.ecore` → `cs.ecore`). ECoreNetto keys its resolution cache by root package name while Capella's references use file names.
2. **Strip all `eOpposite` attributes** (146 declarations). ECoreNetto's `eOpposite` resolution builds invalid `EStructuralFeature::<file>` fragments that crash or recurse.

## Upstream defects found (STARIONGROUP/EcoreNetto)

| Issue | Severity | Title |
| --- | --- | --- |
| [EcoreNetto#79](https://github.com/STARIONGROUP/EcoreNetto/issues/79) | blocker | Cross-file `.ecore` references cannot resolve when file name differs from root package name |
| [EcoreNetto#80](https://github.com/STARIONGROUP/EcoreNetto/issues/80) | blocker | `Resource.GetEObject` recurses unboundedly on unresolvable fragments (`StackOverflowException`) |
| [EcoreNetto#81](https://github.com/STARIONGROUP/EcoreNetto/issues/81) | blocker | `eOpposite` resolution builds invalid `EStructuralFeature::<file>` fragments; cross-file opposites crash |
| [EcoreNetto#82](https://github.com/STARIONGROUP/EcoreNetto/issues/82) | minor | `Resource.Contents` / `AllContents()` are never populated |
| [EcoreNetto#83](https://github.com/STARIONGROUP/EcoreNetto/issues/83) | minor | Built-in Ecore type lookup uses substring matching; misnamed `EBool` key and ambiguous-match exceptions |
| [EcoreNetto#84](https://github.com/STARIONGROUP/EcoreNetto/issues/84) | minor | `ResourceSet.CreateResource` allows duplicate URIs, corrupting resolution for the whole set |

Defects 79–81 interact: 79 causes the cache misses, 80 turns any miss into a process-killing crash, and 81 injects malformed fragments that trigger 80 even when 79 is worked around. The `development` branch of EcoreNetto already guards direct self-delegation in `GetEObject` (part of 80), but the guard is unreleased and does not cover the remaining paths.

## Consequences for capella4net

- **The code generator (#6, #7) is not blocked.** With `--workarounds`-style staging the full metamodel is available as a resolved ECoreNetto object graph — except `EOpposite` links, which the generator input can carry via a sidecar (parse `eOpposite` pairs directly from the XML) until the upstream fixes land.
- **Prefer waiting for (or contributing) upstream fixes** for defects 1–3 before finalizing the generator input pipeline, so the vendored files can be consumed with their canonical Capella names and full opposite information.
- The `--trace` flag reproduces each defect for upstream debugging.
