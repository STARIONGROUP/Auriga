# ECoreNetto Validation Against the Sirius + GMF Metamodels

## Verdict

ECoreNetto 9.0.0 fully loads the vendored Sirius + GMF metamodel
([`resources/ecore-sirius/`](../resources/ecore-sirius/)) with all cross-file references resolved.
This is the foundation for generating the `.aird` object model (issue
[#52](https://github.com/STARIONGROUP/Auriga/issues/52)).

The checks below are enforced as regression tests in
`Auriga.CodeGenerator.Tests/SiriusMetamodelValidationTestFixture.cs`, mirroring the existing
Capella harness ([`ecorenetto-validation.md`](ecorenetto-validation.md)).

| Check | Result |
| --- | --- |
| All `.ecore` files load through one `ResourceSet` | 5 / 5, 0 load diagnostics |
| Package / classifier counts match the inventory | 20 packages, 454 EClass, 39 EEnum, 12 EDataType |
| Supertype + feature-type references resolve | 520 supertype refs + 959 feature-type refs, 0 unresolved |
| Cross-file inheritance chains resolve | diagram/table/sequence → `viewpoint`; sequence → `diagram` |
| `eOpposite` pairs are mutual and complete | 28 declared = 28 resolved, all mutual |
| Annotations survive loading | 128 class-level annotations preserved |

## The vendored metamodel: `resources/ecore-sirius/`

Five files, five root packages plus subpackages (20 packages total), sourced from
eclipse-sirius/sirius-desktop `v7.6.0` and eclipse-gmf-runtime/gmf-notation `9655137`. See
[`sirius-metamodel-inventory.md`](sirius-metamodel-inventory.md) for the full package/count table
and the dependency graph, and [`resources/ecore-sirius/README.md`](../resources/ecore-sirius/README.md)
for provenance and the exact modifications.

## The validation checks: `Auriga.CodeGenerator.Tests`

`SiriusMetamodelValidationTestFixture` loads all five files into a single ECoreNetto `ResourceSet`
(demand-loading pulls dependencies in as needed) and then asserts:

- **Load** — every file yields a root `EPackage` and reports zero `resource.Errors`.
- **Counts** — each package's `EClass` / `EEnum` / `EDataType` count matches the inventory table
  (the counts are the single source of truth shared by the doc and the test).
- **Resolution** — no `EClass.ESuperTypes[i]` is null and no `EStructuralFeature.EType` is null
  across all 454 classes.
- **Cross-file inheritance** — probe classes reach their expected ancestors in another file, e.g.
  `diagram::DSemanticDiagram` → `viewpoint::DRepresentation`, `table::DTable` →
  `viewpoint::DRepresentation`, `sequence::SequenceDDiagram` → `diagram::DSemanticDiagram`.
- **`eOpposite`** — every resolved opposite is mutual (`a.EOpposite.EOpposite == a`) and the
  resolved count equals the raw `eOpposite="` occurrence count in the files.
- **Annotations** — class-level `EAnnotation`s with a source survive loading.

## Modifications required for a clean load

Two documentation-only issues in the upstream files were addressed while vendoring (details in the
provenance README):

1. **Reference paths** were rewritten from `platform:/plugin/...` and `../../.../X.ecore#...`
   relative forms to same-directory / canonical-Ecore-namespace forms, so the set is
   self-contained — the same rewrite already applied to the Capella metamodel.
2. **Ten `TagValues` annotations** in `diagram.ecore` referenced an `EAnnotation` **detail entry**
   in `viewpoint.ecore` (`viewpoint.ecore#//%Tags%/@details.N`). That cross-file
   annotation-detail fragment form is not resolvable by ECoreNetto and produced 10 load
   diagnostics; the annotations are pure "deprecated"/"to be renamed" documentation markers and
   were removed. No `EClass`, feature, supertype, or enumeration is affected — the counts above are
   unchanged by the removal.

## Consequences

The Sirius/GMF metamodel is a valid ECoreNetto input, so the existing metamodel-agnostic code
generator (`Auriga.CodeGenerator`) can target it to emit the `.aird` object model and per-type
XMI readers/writers, exactly as it does for Capella.
