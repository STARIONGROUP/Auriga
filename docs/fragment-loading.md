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
**semantic** graph, following the [uml4net](https://github.com/STARIONGROUP/uml4net) XMI-reader
pattern: every `Read` carries the document it is reading (`Read(XmlReader, string documentName,
string namespaceUri)`), references are stored raw at read time and only resolved in a second pass, and
elements are cached under a document-scoped key.

- **Document-scoped cache.** Every element from the main file and all fragments goes into one
  `IXmiElementCache`, but keyed by `documentName#id` (`XmiElementCache.Key`), where `documentName` is
  the reading document's path relative to the main file. This is the faithful uml4net key: it lets the
  same physical file be identified consistently no matter which document referenced it, so a fragment
  that references another fragment — or references back into the main file — resolves to a single,
  stable key. The public `XmiReaderResult.Elements` index is still built by the bare `id` (Capella
  UUIDs are globally unique), so the public API and `Elements[bareId]` lookups are unchanged.
- **Discovery by following hrefs, not the `.aird` manifest.** `Read(string path)` takes the main
  document as the entry point and discovers fragments by scanning the collected references for
  path-qualified `href` tokens, loading each transitively. The followed extensions are derived from
  the main document's family — `.capellafragment` for a `.capella`/`.melodymodeller` session,
  `.airdfragment` for an `.aird` session — and every fragment is reachable through an `href`, so this
  finds the whole graph without parsing the `.aird`'s `semanticResources` manifest. The
  `Read(string, IReadOnlyCollection<string>)` overload accepts an explicit extension set: passing the
  union of both families co-loads the Capella semantic documents an `.aird` hrefs into, which is how
  `AirdModelLoader` resolves the cross-metamodel `target`/`semanticElements` links (issue #54).
- **Referring-document-relative href resolution.** A collected token keeps its full `href` verbatim.
  Both discovery and resolution parse it through `HrefReference` (strip the optional `xsi:type`
  prefix, split on `#`) and canonicalize the document part **relative to the referring element's own
  `SourceDocument`** — URL-decoded (`Uri.UnescapeDataString`), `..`-collapsed, normalized to a path
  relative to the main file. `ReferenceResolver.ResolveKey` then builds the `documentName#id` cache
  key: a bare intra-document `#uuid` is qualified with the owner's own document; a cross-file
  `type path#uuid` is qualified with the resolved target document. Resolving against the *referring*
  document (not the main directory) is what makes fragment→fragment and back-to-main links resolve to
  the same key the target was cached under. Discovery is filtered to the session's extension set, so
  `hlink://` rich-text links, `platform:/resource` library links and `platform:/plugin` tooling
  references are ignored (and reported as unresolved when they are reference tokens).
- **Known Capella namespaces.** `INamespaceResolver.RegisterNamespace` lets the known Capella
  namespace URIs (the generated `AutoGenNamespaceRegistry`) be seeded up front, mirroring uml4net's
  registration, and each document's root namespace URI is threaded through every `Read` as
  `namespaceUri`.
- **Explicit per-element source tracking.** Rather than an on-demand ancestor walk, Auriga records the
  originating document on each element (`IAurigaElement.SourceDocument`, relative to the main file,
  e.g. `sysmodel.capella` or `fragments/SA-Data.capellafragment`) — set by the reader from the
  `documentName` it was read under. This is simpler to query, is the document part of the cache key,
  and is the hook a fragment-preserving write (#18) will use to route each element back to its file.
- **Containment navigation (#15).** Both single- and multi-valued containment re-parent their targets:
  a multi-valued containment collection is a bypass-proof `ContainerList<T>` (built on
  `Collection<T>`, so every mutation path — including the resolver's non-generic `IList.Add` — sets
  `Container`), and a single-valued containment property's setter sets `Container` on assignment. The
  reader and resolver therefore produce a fully navigable graph: `IAurigaElement.Container` walks up to
  the root across fragment boundaries, and generated `QueryContainedElements()` /
  `QueryAllContainedElements()` walk down (`result.Root.QueryAllContainedElements().OfType<…>()`).
- **Robustness.** The main document's failures propagate; a missing or unparsable fragment is logged
  and skipped. References whose target is absent from every provided file remain in
  `XmiReaderResult.UnresolvedReferences` (see [two-pass resolution](#) / issue #11) rather than
  aborting the load — the vendored `fragmented-sysmodel` fixture is a near-complete export with two
  such genuinely-external targets.

## Known limitations / future work

- **`.aird` manifest and visual fragments.** Not read; diagram-only fragments are not loaded.
- **Library / cross-project links.** `platform:/resource/…` references to other projects are treated
  as external (reported unresolved), not loaded.
- **Writing.** Fragment-preserving round-trip is issue #18; `SourceDocument` is the groundwork.

## References

- py-capellambse: `capellambse/loader/core.py` (`MelodyLoader`, `ModelFile`, `FragmentType`),
  `capellambse/helpers.py` (`CROSS_FRAGMENT_LINK`, `normalize_pure_path`), `capellambse/loader/exs.py`.
- Auriga: `Auriga.Xmi/XmiReader.cs`, `Auriga.Xmi/ReferenceResolver/ReferenceResolver.cs`,
  `Auriga.Xmi/HrefReference.cs`, `Auriga.Xmi/Cache/XmiElementCache.cs`,
  `Auriga.Xmi/Namespaces/NamespaceResolver.cs`, `Auriga/IAurigaElement.cs` (`SourceDocument`,
  `QueryContainedElements`), `Auriga/ContainerList.cs`.
- Follows the uml4net XMI-reader pattern (`STARIONGROUP/uml4net`).
- Depends on #11 (two-pass resolution); implements #12 (fragment loading) and #15 (containment
  navigation); related to #4 (fixtures) and #18 (fragment-preserving writes).
