# Vendored Sirius + GMF Metamodels (`.ecore`)

Pinned copies of the Eclipse Sirius diagram/representation metamodels and the Eclipse GMF
`notation` metamodel. These are the metamodels behind the Sirius `.aird` / `.airdfragment`
diagram files, and are the input for the `.aird` object-model code generation and validation.
See [`docs/sirius-metamodel-inventory.md`](../../docs/sirius-metamodel-inventory.md) for the full
inventory and [`docs/sirius-ecorenetto-validation.md`](../../docs/sirius-ecorenetto-validation.md)
for how these files are validated.

These files live in a directory separate from the Capella metamodel (`resources/ecore/`) so the
two metamodels are generated and validated independently.

## Provenance

| File | Source | License |
| --- | --- | --- |
| `viewpoint.ecore` | [eclipse-sirius/sirius-desktop](https://github.com/eclipse-sirius/sirius-desktop) `v7.6.0` — `plugins/org.eclipse.sirius.model/model/` | EPL-2.0 |
| `diagram.ecore` | [eclipse-sirius/sirius-desktop](https://github.com/eclipse-sirius/sirius-desktop) `v7.6.0` — `plugins/org.eclipse.sirius.diagram.model/model/` | EPL-2.0 |
| `sequence.ecore` | [eclipse-sirius/sirius-desktop](https://github.com/eclipse-sirius/sirius-desktop) `v7.6.0` — `plugins/org.eclipse.sirius.diagram.sequence.model/model/` | EPL-2.0 |
| `table.ecore` | [eclipse-sirius/sirius-desktop](https://github.com/eclipse-sirius/sirius-desktop) `v7.6.0` — `plugins/org.eclipse.sirius.table.model/model/` | EPL-2.0 |
| `notation.ecore` | [eclipse-gmf-runtime/gmf-notation](https://github.com/eclipse-gmf-runtime/gmf-notation) `9655137` — `org.eclipse.gmf.runtime.notation/model/` | EPL-2.0 |

The `nsURI` versions declared inside these files (`viewpoint`/`diagram`/`table` `1.1.0`,
`sequence` `2.0.0`, GMF `notation` `1.0.3`) match exactly the namespaces declared by the `.aird`
fixtures under `TestData/`. Each file contains its root `EPackage` plus its subpackages (e.g.
`diagram.ecore` also carries `diagram.description`, `.../style`, `.../filter`, `.../concern`,
`.../tool`).

## Modifications

Two classes of change relative to the sources; no classes, features, or enumerations were altered:

1. **Reference paths rewritten to a self-contained form.** Cross-file references
   (`../../org.eclipse.sirius.model/model/viewpoint.ecore#...` and the equivalent for
   `diagram.ecore`) were rewritten to same-directory form (`viewpoint.ecore#...`,
   `diagram.ecore#...`), and references to the Ecore metamodel
   (`platform:/plugin/org.eclipse.emf.ecore/model/Ecore.ecore#...` and its `../../` relative form)
   were rewritten to the canonical namespace form
   (`http://www.eclipse.org/emf/2002/Ecore#...`), which the reader resolves natively.

2. **Removed 10 dangling `TagValues` annotations in `diagram.ecore`.** These were
   `<eAnnotations source="TagValues" references="viewpoint.ecore#//%Tags%/@details.N"/>` markers
   that tag a class as "deprecated"/"to be renamed" by referencing an `EAnnotation` **detail
   entry** in `viewpoint.ecore`. That `%Tags%/@details.N` fragment form (a cross-file reference
   into annotation details) is not resolvable by ECoreNetto and produced load diagnostics. The
   annotations are pure documentation metadata — removing them leaves every `EClass`, feature,
   supertype and enumeration untouched. The referenced `Tags` annotation itself is retained in
   `viewpoint.ecore`.

## Licensing

Unlike the rest of this repository (Apache-2.0), the `.ecore` files in this directory are
redistributed under the **Eclipse Public License v. 2.0**: see
[`LICENSE-EPL-2.0.md`](LICENSE-EPL-2.0.md) in this directory and the third-party section of the
repository's [`NOTICE`](../../NOTICE) file. Sirius and GMF are projects of the Eclipse Foundation.
