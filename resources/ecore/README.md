# Vendored Capella Metamodel (`.ecore`)

Pinned copies of the Eclipse Capella 7.0 semantic metamodel plus its dependencies, used as the input for code generation and validation. See [`docs/metamodel-inventory.md`](../../docs/metamodel-inventory.md) for the full inventory and [`docs/ecorenetto-validation.md`](../../docs/ecorenetto-validation.md) for how these files are validated.

## Provenance

| Files | Source | License |
| --- | --- | --- |
| `Activity`, `Behavior`, `ModellingCore`, `CapellaCommon`, `CapellaCore`, `CapellaModeller`, `CompositeStructure`, `ContextArchitecture`, `EPBSArchitecture`, `FunctionalAnalysis`, `Information`, `Interaction`, `LogicalArchitecture`, `OperationalAnalysis`, `PhysicalArchitecture`, `SharedModel` | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) `m2/plugins/org.polarsys.capella.{common,core}.data.def/model/` | EPL-2.0 |
| `libraries`, `re` | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) `common/plugins/org.polarsys.capella.common.{libraries,re}.gen/model/` | EPL-2.0 |
| `Requirements`, `CapellaRequirements` | [eclipse-capella/capella-requirements-vp](https://github.com/eclipse-capella/capella-requirements-vp) `plugins/org.polarsys.{kitalpha,capella}.vp.requirements/models/` | EPL-2.0 |
| `eMDE` | [eclipse-kitalpha/kitalpha](https://github.com/eclipse-kitalpha/kitalpha) `emde/plugins/org.polarsys.kitalpha.emde/model/` | EPL-2.0 |

## Modifications

The only change relative to the sources: all cross-file reference paths (`platform:/plugin/<plugin>/model/X.ecore#...` and `../../<plugin>/model/X.ecore#...`) were rewritten to same-directory form (`X.ecore#...`) so the set is self-contained. No semantic content was altered.
