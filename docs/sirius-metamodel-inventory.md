# Sirius + GMF Metamodel Inventory

**Issue:** [#51](https://github.com/STARIONGROUP/Auriga/issues/51) (part of the `.aird` support epic [#50](https://github.com/STARIONGROUP/Auriga/issues/50))
**Sources analyzed:**

| Repository | Ref | Notes |
| --- | --- | --- |
| [eclipse-sirius/sirius-desktop](https://github.com/eclipse-sirius/sirius-desktop) | tag `v7.6.0` | Sirius viewpoint / diagram / sequence / table metamodels |
| [eclipse-gmf-runtime/gmf-notation](https://github.com/eclipse-gmf-runtime/gmf-notation) | commit `9655137` | GMF runtime `notation` metamodel |

This is the deliverable of issue #51: the complete inventory of the `.ecore` files behind the
Sirius `.aird` diagram/representation format, the inter-file dependency graph, and the confirmed
scope. The vendored copies live in [`resources/ecore-sirius/`](../resources/ecore-sirius/); their
provenance and modifications are in that directory's [`README.md`](../resources/ecore-sirius/README.md).

## 1. Where the metamodel actually lives

A Sirius `.aird` file is EMF/GMF XMI carrying two parallel trees: the Sirius **representation**
tree (viewpoint / diagram / sequence / table) and the GMF **notation** tree (pixel geometry). The
metamodels for both are consolidated into five `.ecore` files, each holding a root `EPackage` plus
its subpackages:

| Vendored file | Upstream `model/` directory |
| --- | --- |
| `viewpoint.ecore` | `org.eclipse.sirius.model` (Sirius core: viewpoint + description) |
| `diagram.ecore` | `org.eclipse.sirius.diagram.model` (diagram + description/style/filter/concern/tool) |
| `sequence.ecore` | `org.eclipse.sirius.diagram.sequence.model` (sequence + description/tool/ordering/template) |
| `table.ecore` | `org.eclipse.sirius.table.model` (table + description) |
| `notation.ecore` | `org.eclipse.gmf.runtime.notation` (GMF notation) |

All five `nsURI` version strings match exactly the namespaces the `TestData/**/*.aird` fixtures
declare. The many other `.ecore` files in the Sirius repo (properties, formatdata, samples, test
fixtures) are out of scope — none are referenced by the `.aird` fixtures.

## 2. Package summary

The single source of truth for the validation test's expected counts
(`SiriusMetamodelValidationTestFixture`). Subpackages are shown indented under their file's root
package.

| File | Package (qualified) | nsURI | EClass | EEnum | EDataType |
| --- | --- | --- | ---: | ---: | ---: |
| `viewpoint.ecore` | `viewpoint` | `.../sirius/1.1.0` | 30 | 3 | 2 |
| | `viewpoint.description` | `.../sirius/description/1.1.0` | 49 | 3 | 6 |
| | `viewpoint.description.style` | `.../sirius/description/style/1.1.0` | 6 | 0 | 0 |
| | `viewpoint.description.tool` | `.../sirius/description/tool/1.1.0` | 57 | 1 | 0 |
| | `viewpoint.description.validation` | `.../sirius/description/validation/1.1.0` | 6 | 1 | 0 |
| | `viewpoint.description.audit` | `.../sirius/description/audit/1.1.0` | 2 | 0 | 0 |
| `diagram.ecore` | `diagram` | `.../sirius/diagram/1.1.0` | 47 | 11 | 0 |
| | `diagram.description` | `.../sirius/diagram/description/1.1.0` | 32 | 4 | 0 |
| | `diagram.description.style` | `.../sirius/diagram/description/style/1.1.0` | 23 | 1 | 0 |
| | `diagram.description.tool` | `.../sirius/diagram/description/tool/1.1.0` | 26 | 1 | 0 |
| | `diagram.description.filter` | `.../sirius/diagram/description/filter/1.1.0` | 5 | 1 | 0 |
| | `diagram.description.concern` | `.../sirius/diagram/description/concern/1.1.0` | 2 | 0 | 0 |
| `sequence.ecore` | `sequence` | `.../sirius/diagram/sequence/2.0.0` | 1 | 0 | 0 |
| | `sequence.description` | `.../sirius/diagram/sequence/description/2.0.0` | 21 | 0 | 0 |
| | `sequence.description.tool` | `.../sirius/diagram/sequence/description/tool/2.0.0` | 15 | 0 | 0 |
| | `sequence.ordering` | `.../sirius/diagram/sequence/ordering/2.0.0` | 5 | 0 | 0 |
| | `sequence.template` | `.../sirius/diagram/sequence/template/2.0.0` | 18 | 0 | 0 |
| `table.ecore` | `table` | `.../sirius/table/1.1.0` | 10 | 0 | 0 |
| | `table.description` | `.../sirius/table/description/1.1.0` | 29 | 0 | 0 |
| `notation.ecore` | `notation` | `.../gmf/runtime/1.0.3/notation` | 70 | 13 | 4 |
| **Total** | **20 packages** | | **454** | **39** | **12** |

## 3. Dependency graph

Extracted from every cross-file `eSuperTypes` / `eType` reference (all now rewritten to
same-directory form — see the provenance README):

| File | Depends on |
| --- | --- |
| `viewpoint.ecore` | (Ecore only) |
| `notation.ecore` | (Ecore only) |
| `diagram.ecore` | `viewpoint.ecore` |
| `table.ecore` | `viewpoint.ecore` |
| `sequence.ecore` | `diagram.ecore`, `viewpoint.ecore` |

`viewpoint.ecore` is the root of the Sirius side; `diagram` and `table` build on it, and
`sequence` builds on `diagram`. `notation.ecore` (GMF) is independent of the Sirius packages — the
two trees are linked only at the `.aird` instance level (via `element` uids), not at the metamodel
level. All five files must be loaded into one `ResourceSet` for the cross-file references to
resolve; there is no per-file generation order.

## 4. Relationship to the Capella semantic metamodel

At the metamodel level the Sirius/GMF set is **independent** of the Capella `.ecore` set in
`resources/ecore/`. The coupling is only at the instance level: an `.aird` element's `target` /
`semanticElements` are `href`s into a `.capella` file (Capella metaclasses). Resolving those
cross-metamodel links is the subject of issue [#54](https://github.com/STARIONGROUP/Auriga/issues/54),
not this inventory.

## 5. Confirmed scope

All 20 packages across the 5 files are in scope — the `.aird` fixtures exercise graphical
diagrams (`diagram`), sequence diagrams (`sequence`, referencing Capella `interaction`), and
tables (`table`), all over the GMF `notation` geometry tree. No `tree`-representation metamodel is
needed (no fixture contains one).

## 6. Recommendations / next steps

- The files are vendored into `resources/ecore-sirius/` and validated (issue #51,
  [`docs/sirius-ecorenetto-validation.md`](sirius-ecorenetto-validation.md)).
- Generate the object model + XMI readers/writers from these files into the `Auriga.Diagram.*` /
  `Auriga.Xmi.Diagram.*` namespaces of the shared `Auriga` / `Auriga.Xmi` libraries (issue
  [#52](https://github.com/STARIONGROUP/Auriga/issues/52)) — the per-metamodel namespace root avoids
  type collisions with the Capella object model (e.g. `Folder`, `DModelElement`), which lives under
  `Auriga.Model.*`.
