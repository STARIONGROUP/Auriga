# Vendored Capella Metamodel (`.ecore`)

Pinned copies of the Eclipse Capella 7.0 semantic metamodel plus its dependencies, used as the input for code generation and validation. See the [Metamodel Inventory](https://github.com/STARIONGROUP/Auriga/wiki/Metamodel-Inventory) wiki page for the full inventory and [ECoreNetto Validation](https://github.com/STARIONGROUP/Auriga/wiki/ECoreNetto-Validation) for how these files are validated.

## Provenance

| Files | Source | License |
| --- | --- | --- |
| `Activity`, `Behavior`, `ModellingCore`, `CapellaCommon`, `CapellaCore`, `CapellaModeller`, `CompositeStructure`, `ContextArchitecture`, `EPBSArchitecture`, `FunctionalAnalysis`, `Information`, `Interaction`, `LogicalArchitecture`, `OperationalAnalysis`, `PhysicalArchitecture`, `SharedModel` | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) `m2/plugins/org.polarsys.capella.{common,core}.data.def/model/` | EPL-2.0 |
| `libraries`, `re` | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) `common/plugins/org.polarsys.capella.common.{libraries,re}.gen/model/` | EPL-2.0 |
| `Requirements`, `CapellaRequirements` | [eclipse-capella/capella-requirements-vp](https://github.com/eclipse-capella/capella-requirements-vp) `plugins/org.polarsys.{kitalpha,capella}.vp.requirements/models/` | EPL-2.0 |
| `Mass` | [eclipse-capella/capella-basic-vp](https://github.com/eclipse-capella/capella-basic-vp) `massviewpoint/plugins/org.polarsys.capella.vp.mass/models/mass.ecore` | EPL-2.0 |
| `Requirement` | [eclipse-capella/capella-basic-vp](https://github.com/eclipse-capella/capella-basic-vp) `requirement/plugins/org.polarsys.capella.basic.requirement.model/model/Requirement.ecore` | EPL-2.0 |
| `Cybersecurity` | [eclipse-capella/capella-cybersecurity](https://github.com/eclipse-capella/capella-cybersecurity) `plugins/org.polarsys.capella.cybersecurity.model/models/Cybersecurity.ecore` | EPL-2.0 |
| `eMDE` | [eclipse-kitalpha/kitalpha](https://github.com/eclipse-kitalpha/kitalpha) `emde/plugins/org.polarsys.kitalpha.emde/model/` | EPL-2.0 |

## Modifications

The only change relative to the sources: all cross-file reference paths (`platform:/plugin/<plugin>/model/X.ecore#...` and `../../<plugin>/model/X.ecore#...`) were rewritten to same-directory form (`X.ecore#...`) so the set is self-contained. No semantic content was altered.

## Licensing

Unlike the rest of this repository (Apache-2.0), the `.ecore` files in this directory are redistributed under the **Eclipse Public License v. 2.0**: see [`LICENSE-EPL-2.0.md`](LICENSE-EPL-2.0.md) in this directory and the third-party section of the repository's [`NOTICE`](../../NOTICE) file. Capella is a registered trademark of the Eclipse Foundation.
