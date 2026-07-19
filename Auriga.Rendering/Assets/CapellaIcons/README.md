# Vendored Capella Diagram Artwork

Pinned copies of the icon artwork Eclipse Capella 7.0 uses to render diagram elements
(actors, missions, capabilities, function ports, states, …). Sirius `WorkspaceImage` styles in a
`.aird` reference these files by plugin path (e.g.
`/org.polarsys.capella.core.sirius.analysis/description/images/Capability.svg`);
`Auriga.Rendering` embeds this set and the `CapellaIconRegistry` resolves such paths to the
embedded copy so exported SVGs can show the same glyphs, self-contained.

## Provenance

| Files | Source | License |
| --- | --- | --- |
| `*.svg` (except `SystemActor.svg`, `LogicalComponent.svg`) | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) tag `v7.0.0`, `core/plugins/org.polarsys.capella.core.sirius.analysis/description/images/` | EPL-2.0 |
| `SystemActor.svg`, `LogicalComponent.svg` | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) tag `v7.0.0`, `core/plugins/org.polarsys.capella.core.ui.resources/icons/full/svg/` | EPL-2.0 |
| `Blank.gif` | [eclipse-capella/capella](https://github.com/eclipse-capella/capella) tag `v7.0.0`, `core/plugins/org.polarsys.capella.core.sirius.analysis/icons/full/obj16/` | EPL-2.0 |

The set is the collection of images the repository's fixture models actually reference; it is not
the complete Capella artwork catalogue.

## Modifications

None — the files are byte-identical to the sources.

## Licensing

Unlike the rest of this repository (Apache-2.0), the image files in this directory are
redistributed under the **Eclipse Public License v. 2.0**: see
[`LICENSE-EPL-2.0.md`](LICENSE-EPL-2.0.md) in this directory and the third-party section of the
repository's [`NOTICE`](../../../NOTICE) file. Capella is a registered trademark of the Eclipse
Foundation.
