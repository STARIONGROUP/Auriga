# Fragment loading and cross-fragment resolution

Capella models are frequently split across several files: a main `.capella` (formerly
`.melodymodeller`) and one or more `.capellafragment` files, with references crossing the boundaries
as `href="relative/path.capellafragment#uuid"`. This note records how the reference implementation —
[py-capellambse](https://github.com/dbinfrago/py-capellambse) — handles this, and the design Auriga
adopts. No code is ported; these are design notes.

## The Capella fragmentation model

A fragmented project is a set of sibling files with distinct roles:

| File | Role | Element id attribute |
|---|---|---|
| `.aird` | Visual model + **manifest**: lists all sibling semantic files (`semanticResources`) and visual sub-fragments (`referencedAnalysis`). The natural entry point. | `uid` / `xmi:id` |
| `.airdfragment` | Visual fragment (diagram layout for a split-out portion) | `uid` / `xmi:id` |
| `.capella` / `.melodymodeller` | The semantic root model | `id` |
| `.capellafragment` / `.melodyfragment` | A semantic fragment — a contained subtree lifted into its own file. Its **root element** is the element the parent file points at via a containment `href`. | `id` |
| `.afm` | Viewpoint / Capella-version metadata only; carries no element ids | — |

The key structural fact: when a subtree is fragmented out, the parent file keeps only a proxy
`<ownedX href="fragments/F.capellafragment#uuid"/>` where `uuid` is the id of the fragment file's
**root** element. Every semantic fragment is therefore reachable by following containment `href`s from
the main file.

## How py-capellambse does it

Primary source: `capellambse/loader/core.py` (`MelodyLoader`, `ModelFile`) and `capellambse/helpers.py`.

- **Discovery.** The entry point is the `.aird`. `MelodyLoader` reads its `semanticResources` /
  `referencedAnalysis` manifest and recurses into every referenced file (`_find_refs`), building
  `self.trees: dict[PurePosixPath, ModelFile]` — one parsed tree per fragment, keyed by its
  normalized path.
- **href format.** The link grammar (`helpers.CROSS_FRAGMENT_LINK`) is
  `(?:(xtype )?(fragment))?#(uuid)` — an optional `xsi:type`, an optional relative fragment path, then
  the `uuid`. Three shapes occur: `#uuid` (same file), `type path#uuid` (cross-fragment), and
  `type ../main.capella#uuid` (back to root). Relative paths are resolved against the *referring*
  file's directory and **URL-decoded** (`%20` → space); Eclipse `platform:/resource/…` library links
  are rewritten to `../`.
- **Global UUID space.** Although each `ModelFile` has its own id cache, resolution treats UUIDs as
  unique across the whole model — duplicates are rejected as corruption
  (`check_duplicate_uuids`). The fragment path in an href is effectively advisory: `follow_link`
  resolves by UUID alone (`del fragment  # TODO use to disambiguate`) and merely verifies the target's
  `xsi:type` matches the optional `xtype`.
- **Resolution.** `follow_link(uuid)` fans out over every loaded tree's id cache and expects exactly
  one hit (ambiguous ⇒ error). `loader[uuid]` is model-wide lookup.
- **Source tracking.** There is no per-element source field; the owning fragment is found on demand by
  walking to the tree root (`_find_fragment`). This is what routes a *new* element into its parent's
  file (`generate_uuid(parent)`) and lets `create_link` choose a bare `#uuid` vs a `type path#uuid`
  cross-fragment link on write.
- **Round-trip.** `save()` writes each `ModelFile` back to its own path with an EMF-compatible
  serializer (`loader/exs.py`) for byte-level diff fidelity; because new elements were inserted into a
  specific tree, they serialize back to the correct file automatically.

## What Auriga adopts, and where it diverges

Auriga's reader (`Auriga.Xmi.XmiReader`) implements the load + cross-fragment resolution for the
**semantic** graph:

- **Single global UUID cache.** Every element from the main file and all fragments goes into one
  `IXmiElementCache` keyed by the bare `id`. This is the direct analogue of py-capellambse's global
  UUID space, and makes resolution an O(1) dictionary lookup rather than a fan-out over per-file
  caches — a deliberate improvement that is still compatible with the on-disk format.
- **Discovery by following hrefs, not the `.aird`.** `Read(string path)` takes the main
  `.capella`/`.melodymodeller` as the entry point and discovers fragments by scanning the collected
  references for path-qualified `href` tokens (`…​.capellafragment#uuid`), loading each transitively.
  Because every semantic fragment is reachable through a containment `href`, this finds the whole
  semantic graph without parsing the `.aird`. The trade-off: fragments that hold *only* diagrams
  (reachable solely via the `.aird`'s `referencedAnalysis`) are not loaded — out of scope, as Auriga
  is a semantic-model library.
- **href parsing.** A collected token keeps its full `href` verbatim; the resolver takes the substring
  after `#` as the cache key (`ReferenceResolver.ReferenceIdentifier`), so both intra-file `#uuid`
  and cross-file `type path#uuid` resolve against the global cache. Relative paths are URL-decoded
  (`Uri.UnescapeDataString`) and resolved against the main file's directory; discovery is filtered to
  `.capellafragment`, so `hlink://` rich-text links, `platform:/resource` library links, and `.aird`
  diagram references are ignored.
- **Explicit per-element source tracking.** Rather than an on-demand ancestor walk, Auriga records the
  originating document on each element (`IAurigaElement.SourceDocument`, relative to the main file,
  e.g. `sysmodel.capella` or `fragments/SA-Data.capellafragment`). This is simpler to query and is the
  hook a fragment-preserving write (#18) will use to route each element back to its file.
- **Robustness.** The main document's failures propagate; a missing or unparsable fragment is logged
  and skipped. References whose target is absent from every provided file remain in
  `XmiReaderResult.UnresolvedReferences` (see [two-pass resolution](#) / issue #11) rather than
  aborting the load — the vendored `fragmented-sysmodel` fixture is a near-complete export with two
  such genuinely-external targets.

## Known limitations / future work

- **Containment back-pointers.** An href-resolved containment target is added to its owner's
  collection but its `Container` is not set (the resolver cannot distinguish containment from
  non-containment references generically). The graph is navigable forward through containment
  collections; reverse navigation for fragment roots is future work.
- **`.aird` manifest and visual fragments.** Not read; diagram-only fragments are not loaded.
- **Library / cross-project links.** `platform:/resource/…` references to other projects are treated
  as external (reported unresolved), not loaded.
- **Writing.** Fragment-preserving round-trip is issue #18; `SourceDocument` is the groundwork.

## References

- py-capellambse: `capellambse/loader/core.py` (`MelodyLoader`, `ModelFile`, `FragmentType`),
  `capellambse/helpers.py` (`CROSS_FRAGMENT_LINK`, `normalize_pure_path`), `capellambse/loader/exs.py`.
- Auriga: `Auriga.Xmi/XmiReader.cs`, `Auriga.Xmi/ReferenceResolver/ReferenceResolver.cs`,
  `Auriga/IAurigaElement.cs` (`SourceDocument`).
- Depends on #11 (two-pass resolution); related to #4 (fixtures) and #18 (fragment-preserving writes).
