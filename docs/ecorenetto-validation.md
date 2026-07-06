# ECoreNetto Validation Against the Capella Metamodel

**Issue:** [#2](https://github.com/STARIONGROUP/capella4net/issues/2)
**ECoreNetto version tested:** 9.0.0 (7.0.9 originally; see history below)
**Input:** the 21 pinned `.ecore` files in [`resources/ecore/`](../resources/ecore) (see below)

## Verdict

ECoreNetto 9.0.0 **fully handles the Capella metamodel out of the box** — every package, classifier, structural feature, inheritance relation, `eOpposite` pair, and annotation loads and resolves correctly from the vendored files with their canonical names, no workarounds needed:

```
check 1 - load:       21/21 files loaded
check 2 - counts:     25 packages, 430 classes, 35 enums   (matches docs/metamodel-inventory.md exactly)
check 3 - resolution: 558 supertype refs (0 unresolved), 1096 feature types (0 unresolved)
check 4 - inheritance: 8 cross-package chains verified down to emde::ExtensibleElement
check 5 - opposites:  146 eOpposite pairs resolved and mutual / 146 declared in XML
check 6 - annotations: 1253 class-level annotations preserved (documentation, semantic, UML2 mapping, ...)
```

The original validation against 7.0.9 found six upstream defects (three blockers) that made the metamodel unloadable without workarounds; the blockers were fixed in ECoreNetto 9.0.0 and the workaround staging code has been removed from the harness.

## The vendored metamodel: `resources/ecore/`

Per the recommendation in [`metamodel-inventory.md`](metamodel-inventory.md), the v1-scope `.ecore` files are vendored into this repository, pinned at Capella 7.0.0:

- 16 files taken from `capella/m2/plugins/org.polarsys.capella.{common,core}.data.def/model/` (the copies with same-directory reference style)
- `libraries.ecore`, `re.ecore` from the `common/plugins/*.gen/model/` plugins
- `Requirements.ecore`, `CapellaRequirements.ecore` from `capella-requirements-vp`
- `eMDE.ecore` fetched from [eclipse-kitalpha/kitalpha](https://github.com/eclipse-kitalpha/kitalpha) (`emde/plugins/org.polarsys.kitalpha.emde/model/`)

All `platform:/plugin/...` and `../../...` reference paths were rewritten to same-directory form (`CapellaModeller.ecore#//...`); no semantic changes were made. Every cross-file reference resolves within the directory.

## The validation harness: `validation/EcoreValidation`

```
dotnet run --project validation/EcoreValidation -- resources/ecore                 # passes
dotnet run --project validation/EcoreValidation -- <dir> --trace                   # verbose ECoreNetto trace logging
```

Checks performed: (1) all files load through one `ResourceSet`; (2) per-package EClass/EEnum/EDataType counts match the metamodel inventory; (3) every `eSuperTypes` entry and feature `eType` resolves to a non-null classifier; (4) cross-package inheritance chains (e.g. `pa::PhysicalFunction → fa::AbstractFunction`, `ctx::SystemFunction → emde::ExtensibleElement`) are reachable; (5) `eOpposite` pairs are mutual and complete; (6) EAnnotations survive loading.

## Upstream defects found in 7.0.9 (STARIONGROUP/EcoreNetto)

The original run against 7.0.9 died with an uncatchable `StackOverflowException` and required a `--workarounds` mode that staged a modified copy of the input (files renamed to their root package name, all `eOpposite` attributes stripped). The three blockers were fixed in ECoreNetto 9.0.0, after which the workaround code was removed.

| Issue | Severity | Title |
| --- | --- | --- |
| [EcoreNetto#79](https://github.com/STARIONGROUP/EcoreNetto/issues/79) | blocker | Cross-file `.ecore` references cannot resolve when file name differs from root package name |
| [EcoreNetto#80](https://github.com/STARIONGROUP/EcoreNetto/issues/80) | blocker | `Resource.GetEObject` recurses unboundedly on unresolvable fragments (`StackOverflowException`) |
| [EcoreNetto#81](https://github.com/STARIONGROUP/EcoreNetto/issues/81) | blocker | `eOpposite` resolution builds invalid `EStructuralFeature::<file>` fragments; cross-file opposites crash |
| [EcoreNetto#82](https://github.com/STARIONGROUP/EcoreNetto/issues/82) | minor | `Resource.Contents` / `AllContents()` are never populated |
| [EcoreNetto#83](https://github.com/STARIONGROUP/EcoreNetto/issues/83) | minor | Built-in Ecore type lookup uses substring matching; misnamed `EBool` key and ambiguous-match exceptions |
| [EcoreNetto#84](https://github.com/STARIONGROUP/EcoreNetto/issues/84) | minor | `ResourceSet.CreateResource` allows duplicate URIs, corrupting resolution for the whole set |

Defects 79–81 interacted: 79 caused the cache misses, 80 turned any miss into a process-killing crash, and 81 injected malformed fragments that triggered 80 even when 79 was worked around. The blocker fixes shipped in **ECoreNetto 9.0.0**; the harness verifies all three against the unmodified vendored files (checks 1, 3 and 5 above).

## Consequences for capella4net

- **The code generator (#6, #7) is not blocked.** On ECoreNetto 9.0.0 the full metamodel — including all 146 mutual `EOpposite` links — is available as a resolved object graph directly from the vendored files with their canonical Capella names. No staging or sidecar is needed.
- The `--trace` flag remains available for verbose ECoreNetto load logging.
