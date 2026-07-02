# Capella Metamodel Inventory

**Issue:** [#1](https://github.com/STARIONGROUP/capella4net/issues/1)
**Sources analyzed:**

| Repository | Local clone | Version |
| --- | --- | --- |
| [eclipse-capella/capella](https://github.com/eclipse-capella/capella) | `C:\Users\sgerene\SourceCode\capella` | metamodel nsURIs are `7.0.0` (Capella 7.x line) |
| [eclipse-capella/capella-requirements-vp](https://github.com/eclipse-capella/capella-requirements-vp) | `C:\Users\sgerene\SourceCode\capella-requirements-vp` | requirements viewpoint |

This document is the Phase 1 deliverable of the [project plan](../capella4net-project-context.md): the complete inventory of Capella `.ecore`/`.genmodel` files, the inter-package dependency graph, and the confirmed v1 scope for code generation.

## 1. Where the metamodel actually lives

The project context estimated one `.ecore` per plugin (e.g. `org.polarsys.capella.core.data.oa`). The reality is simpler: **the semantic metamodel is consolidated into a handful of `model/` directories**, and the per-layer plugins contain only generated Java code.

The canonical `.ecore` files (18 total in the capella repo):

### Common packages — one plugin each

| File | Plugin |
| --- | --- |
| `Activity.ecore` | `common/plugins/org.polarsys.capella.common.data.activity.gen/model/` |
| `Behavior.ecore` | `common/plugins/org.polarsys.capella.common.data.behavior.gen/model/` |
| `ModellingCore.ecore` | `common/plugins/org.polarsys.capella.common.data.core.gen/model/` |
| `libraries.ecore` | `common/plugins/org.polarsys.capella.common.libraries.gen/model/` |
| `re.ecore` | `common/plugins/org.polarsys.capella.common.re.gen/model/` |

### Core packages — all in one directory

All 13 in `core/plugins/org.polarsys.capella.core.data.gen/model/`:

`CapellaCommon.ecore`, `CapellaCore.ecore`, `CapellaModeller.ecore`, `CompositeStructure.ecore`, `ContextArchitecture.ecore`, `EPBSArchitecture.ecore`, `FunctionalAnalysis.ecore`, `Information.ecore`, `Interaction.ecore`, `LogicalArchitecture.ecore`, `OperationalAnalysis.ecore`, `PhysicalArchitecture.ecore`, `SharedModel.ecore`

### Requirements viewpoint (separate repo)

| File | Plugin |
| --- | --- |
| `Requirements.ecore` | `capella-requirements-vp/plugins/org.polarsys.kitalpha.vp.requirements/models/` |
| `CapellaRequirements.ecore` | `capella-requirements-vp/plugins/org.polarsys.capella.vp.requirements/models/` |

### Duplicates and non-metamodel `.ecore` files (excluded)

- **`m2/plugins/org.polarsys.capella.common.data.def/model/` and `m2/plugins/org.polarsys.capella.core.data.def/model/`** — a second copy of 16 of the 18 files (all except `libraries.ecore` and `re.ecore`). Verified **semantically identical** to the `gen` copies; the only difference is cross-file reference style (`m2` uses same-directory relative paths like `ModellingCore.ecore#//AbstractType`, the `gen` copies use cross-plugin paths like `../../org.polarsys.capella.common.data.core.gen/model/ModellingCore.ecore#//AbstractType`).
- `tests/plugins/.../layout.ecore`, `Migration.ecore` — test-only models, out of scope.
- `releng/cdo/plugins/**` — CDO-variant genmodels for server deployment, out of scope.

### `.genmodel` files

One genmodel per common plugin plus a single `CapellaModeller.genmodel` covering all 13 core files. Their `basePackage` values (useful as the reference for capella4net's C# namespace mapping, issue #6):

| Genmodel | basePackage |
| --- | --- |
| `Activity`, `Behavior`, `ModellingCore` | `org.polarsys.capella.common.data` |
| `libraries`, `re` | `org.polarsys.capella.common` |
| `CapellaModeller` (all core packages) | `org.polarsys.capella.core.data` (+ `...data.information`, `...data.pa` for subpackages) |

## 2. Package summary

All packages use Ecore primitive types only — **there are no custom EDataTypes anywhere**, which simplifies code generation to EClass + EEnum handling.

| File | EPackage (ns prefix) | nsURI (`http://www.polarsys.org/capella/...`) | EClass | EEnum |
| --- | --- | --- | ---: | ---: |
| ModellingCore.ecore | `modellingcore` | `common/core/7.0.0` | 17 | 2 |
| Activity.ecore | `activity` | `common/activity/7.0.0` | 23 | 2 |
| Behavior.ecore | `behavior` | `common/behavior/7.0.0` | 7 | 0 |
| libraries.ecore | `libraries` | `common/libraries/7.0.0` | 4 | 1 |
| re.ecore | `re` | `common/re/7.0.0` | 11 | 1 |
| CapellaCore.ecore | `capellacore` | `core/core/7.0.0` | 41 | 1 |
| CapellaCommon.ecore | `capellacommon` | `core/common/7.0.0` | 29 | 3 |
| CapellaModeller.ecore | `capellamodeller` | `core/modeller/7.0.0` | 6 | 0 |
| CompositeStructure.ecore | `cs` | `core/cs/7.0.0` | 35 | 0 |
| ContextArchitecture.ecore | `ctx` | `core/ctx/7.0.0` | 15 | 0 |
| OperationalAnalysis.ecore | `oa` | `core/oa/7.0.0` | 28 | 0 |
| LogicalArchitecture.ecore | `la` | `core/la/7.0.0` | 10 | 0 |
| PhysicalArchitecture.ecore | `pa` (+ subpackage `pa.deployment`) | `core/pa/7.0.0` | 9 + 9 | 2 |
| EPBSArchitecture.ecore | `epbs` | `core/epbs/7.0.0` | 6 | 1 |
| FunctionalAnalysis.ecore | `fa` | `core/fa/7.0.0` | 40 | 6 |
| Information.ecore | `information` (+ subpackages `communication`, `datatype`, `datavalue`) | `core/information/7.0.0` | 29 + 9 + 6 + 22 | 8 + 2 + 1 + 2 |
| Interaction.ecore | `interaction` | `core/interaction/7.0.0` | 38 | 3 |
| SharedModel.ecore | `sharedmodel` | `core/sharedmodel/7.0.0` | 2 | 0 |
| **Subtotal (capella repo)** | | | **396** | **35** |
| Requirements.ecore | `Requirements` | `http://www.polarsys.org/kitalpha/requirements` | 26 | 0 |
| CapellaRequirements.ecore | `CapellaRequirements` | `http://www.polarsys.org/capella/requirements` | 5 | 0 |
| **Total** | | | **427** | **35** |

Notes:

- **`ctx` is System Analysis.** The file/package name is `ContextArchitecture`/`ctx`, but it contains `SystemAnalysis`, `SystemFunction`, `SystemComponent`, etc. — the "sa" layer of the project context's estimate.
- Subpackages exist in exactly two files: `Information.ecore` (`information.communication`, `information.datatype`, `information.datavalue`) and `PhysicalArchitecture.ecore` (`pa.deployment`). Each subpackage has its own nsURI and therefore its own XML namespace in `.melodymodeller` files — the reader's namespace registry must include all 24 nsURIs, not 20 (18 + 2 requirement files, +4 subpackage entries).

## 3. Dependency graph

Extracted from every cross-file reference (`eSuperTypes`, `eType`, `eOpposite`) in the canonical files:

| File | Depends on |
| --- | --- |
| ModellingCore | **eMDE (external)** |
| Behavior | ModellingCore |
| Activity | Behavior, ModellingCore |
| libraries | CapellaModeller, **eMDE** |
| re | CapellaModeller, **eMDE** |
| CapellaCore | CapellaCommon, Information, ModellingCore |
| CapellaCommon | Behavior, CapellaCore, FunctionalAnalysis, Interaction, LogicalArchitecture, ModellingCore |
| CapellaModeller | CapellaCore, ContextArchitecture, EPBSArchitecture, LogicalArchitecture, OperationalAnalysis, PhysicalArchitecture, SharedModel |
| CompositeStructure | CapellaCommon, CapellaCore, EPBSArchitecture, FunctionalAnalysis, Information, ModellingCore |
| ContextArchitecture | CapellaCommon, CapellaCore, CompositeStructure, FunctionalAnalysis, Interaction, LogicalArchitecture, OperationalAnalysis |
| EPBSArchitecture | CapellaCommon, CapellaCore, CompositeStructure, LogicalArchitecture, PhysicalArchitecture |
| FunctionalAnalysis | Activity, Behavior, CapellaCommon, CapellaCore, CompositeStructure, ContextArchitecture, Information, LogicalArchitecture, ModellingCore |
| Information | Behavior, CapellaCommon, CapellaCore, CompositeStructure, Interaction, ModellingCore |
| Interaction | Behavior, CapellaCommon, CapellaCore, CompositeStructure, FunctionalAnalysis, Information, ModellingCore |
| LogicalArchitecture | CapellaCommon, CompositeStructure, ContextArchitecture, FunctionalAnalysis, Interaction, PhysicalArchitecture |
| OperationalAnalysis | Activity, CapellaCommon, CapellaCore, CompositeStructure, ContextArchitecture, FunctionalAnalysis, Information, Interaction, ModellingCore |
| PhysicalArchitecture | CapellaCommon, CapellaCore, CompositeStructure, EPBSArchitecture, FunctionalAnalysis, Information, LogicalArchitecture |
| SharedModel | CapellaCore, CapellaModeller, Information |
| Requirements (kitalpha) | **eMDE** |
| CapellaRequirements | CapellaCore, CompositeStructure, **eMDE**, Requirements (kitalpha) |

**The core graph is cyclic, by design.** Examples: `CapellaCore ↔ CapellaCommon`, `Information ↔ Interaction`, `FunctionalAnalysis ↔ ContextArchitecture`, and the architecture layers reference each other bidirectionally through derived allocation/realization features (`la ↔ pa`, `ctx ↔ la`, etc.). Only `ModellingCore`, `Behavior`, and `Activity` form an acyclic bottom layer.

**Consequences for capella4net:**

1. **No per-file generation order exists.** The code generator (issues #6–#8) must load *all* `.ecore` files into one ECoreNetto `ResourceSet` and generate from the complete resolved graph — never file-by-file. This also means the "generate one package (`pa`) first" prototype (#7) still needs the full resource set loaded; it just emits output for one package.
2. Many of the cyclic references are `derived`/`transient`/`volatile` (computed traceability accessors). The generator needs a policy for derived features regardless (issue #6); they are also exactly the features that do not appear in `.melodymodeller` files.

## 4. External dependency: Kitalpha eMDE

`ModellingCore`, `libraries`, `re`, and both requirements files reference **`platform:/plugin/org.polarsys.kitalpha.emde/model/eMDE.ecore`**, using exactly two metaclasses:

- `emde::ExtensibleElement` — the root supertype of `modellingcore::ModelElement`, i.e. of **every** Capella element
- `emde::ElementExtension` — the base class for viewpoint extensions (`ownedExtensions` containment on every element)

`eMDE.ecore` is **not present in the capella repo** (only a CDO genmodel variant) and not in any current local clone. It lives in the [eclipse/kitalpha](https://github.com/eclipse/kitalpha) repository, plugin `org.polarsys.kitalpha.emde`. It is small (a handful of classes) and Apache/EPL-licensed. **Action:** obtain `eMDE.ecore` (single file) before running the generator; without it, the root of the inheritance hierarchy cannot be resolved.

Related observation for the reader (issue #13): every Capella project also contains a `.afm` file holding Kitalpha *AD metadata* (`org.polarsys.kitalpha.ad.metadata`, viewpoint activation state). It is not referenced by the semantic metamodel and can be treated as an opaque sidecar file in v1 (preserve, don't parse).

## 5. Confirmed v1 scope

The project context estimated "~10 packages". The dependency analysis shows the honest unit is **the whole semantic metamodel**: `CapellaModeller` (the model root — `Project`/`SystemEngineering`) pulls in every architecture layer, the layers pull in `cs`/`fa`/`information`/`interaction`/`capellacommon`/`capellacore`, and everything bottoms out in `modellingcore`/`behavior`/`activity` + `emde`. Cutting `Interaction` or `SharedModel` would break type resolution for referenced classes.

**v1 generation scope — all of:**

| Group | Files | EClasses |
| --- | --- | --- |
| Kitalpha stub | `eMDE.ecore` (only `ExtensibleElement`, `ElementExtension` and their features are actually used) | ~5 |
| Common | `ModellingCore`, `Behavior`, `Activity`, `libraries`, `re` | 62 |
| Core | all 13 files in `org.polarsys.capella.core.data.gen/model/` | 334 |
| Requirements | `Requirements` (kitalpha vp), `CapellaRequirements` | 31 |

Total: **~430 EClasses, 35 EEnums, 0 EDataTypes** across 24 EPackages (20 root + 4 subpackages).

Requirements is included in v1 (rather than deferred) because real-world Capella models very commonly use the requirements viewpoint, and its cost is small (31 classes, depends only on `capellacore`, `cs`, `emde`).

**Out of v1 scope** (confirming the project context):

- `.aird` / Sirius representation metamodels (diagrams)
- Kitalpha AD metadata (`.afm` files) beyond opaque preservation
- Other viewpoints (e.g. Basic Mass, Performance) — the `ExtensibleElement`/`ElementExtension` mechanism means unknown viewpoint extensions may appear in models; the reader needs a skip-or-preserve policy for unrecognized extension namespaces (tracked under issue #20)
- Test/releng `.ecore` files (`layout`, `Migration`, CDO variants)

## 6. Recommendations for the next issues

1. **Vendor the input `.ecore` files into this repository** (e.g. `resources/ecore/`), pinned at Capella 7.0.0, with reference paths normalized to same-directory style (as the `m2` copies already are). Rationale: reproducible generation without a multi-gigabyte capella clone; the `m2/.../def/model` copies can be taken as-is for 16 files, `libraries.ecore`/`re.ecore` need their `platform:/plugin/...` and `../../` references rewritten, and `eMDE.ecore` comes from kitalpha. (Feeds issues #2, #6, #7.)
2. **ECoreNetto validation (#2) should target the full 21-file set at once** — cross-file resolution, subpackages, and the `eOpposite`-across-files pattern are precisely what needs proving, and the `platform:/plugin/` URI scheme (if kept) will need a resolution strategy in ECoreNetto's `ResourceSet`.
3. **Namespace registry for the reader (#10):** 24 nsURIs (each subpackage has its own), all version-suffixed `7.0.0`. Reading models saved by older Capella versions (nsURI `1.4.0`, `6.0.0`, …) is a migration problem and stays out of v1; the reader should fail with a clear "unsupported metamodel version" error (issue #13).
4. **C# namespace mapping (#6)** can mirror the genmodel `basePackage` structure, e.g. `Capella4Net.Common.Data.Activity`, `Capella4Net.Core.Data.Pa.Deployment` — decide in the codegen design doc.
