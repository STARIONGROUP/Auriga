# XMI Writer

`Auriga.Xmi` serializes a loaded Capella object graph back to XMI with `IXmiWriter`
([`Auriga.Xmi/Writers/`](../Auriga.Xmi/Writers)). It is the exact inverse of the reader: a thin
`XmiElementWriter<T>` base plus one generated `XxxWriter` per concrete class
([`AutoGenXmiWriters/`](../Auriga.Xmi/AutoGenXmiWriters)) and a generated `XmiElementWriterFacade` that
dispatches an element's runtime type to its writer. The writers are produced by the
`XmiWriterGenerator` from the same vendored `.ecore` metamodel as the readers, so the two stay in lock-step.

## Usage

```csharp
using Auriga.Xmi;

var reader = XmiReaderBuilder.Create().Build();
var result = reader.Read("model.capella");

// ... inspect or manipulate result.Root ...

var writer = XmiWriterBuilder.Create().Build();
writer.Write(result.Root, "out/model.capella");   // writes the main file + any fragments
```

`Write(root, mainFilePath)` is fragment-aware: it partitions the graph by each element's
`SourceDocument`, writes the main semantic file to `mainFilePath` and every `.capellafragment` to a
sibling path relative to it, and serializes references between documents as relative `href`s.
`WriteDocument(root, stream, documentName)` writes a single document to a stream.

## How it works

- **Namespaces.** Each generated writer knows its package's `xmlns` prefix, URI and XMI type name
  (from the ecore `nsPrefix`/`nsURI`). Before writing a document's root, the writer walks the document's
  subtree, collects the packages it uses, and declares exactly those `xmlns:` prefixes on the root — the
  same set Capella declares.
- **Elements.** A contained element is written under its containment feature's role name
  (`<ownedFunctions xsi:type="…:PhysicalFunction" …>`); the document root is written with the package
  prefix (`<org.polarsys.capella.core.data.capellamodeller:Project …>`) and no `xsi:type`.
- **Attributes.** Scalars and enumerations are written as attributes (Capella's enum literals are
  upper-case, so the C# member name round-trips verbatim). Non-containment references are written as
  `#id` attributes, multi-valued ones as a whitespace-delimited list.
- **References prefer the collected token.** When an element was read, the reader keeps each reference's
  verbatim token; the writer re-emits that token, so a reference round-trips exactly — including a
  cross-document `path#id` and a genuinely external, unresolved reference. For an element built in memory
  (never read), the writer derives the `#id` (or relative `href`) from the resolved target instead.
- **Fragments.** A containment child that belongs to another document is written as an `href` proxy
  (`<ownedX href="fragments/…capellafragment#id"/>`); the child itself is written, in full, as the root
  of its own document.
- **New-element placement.** An element with no `SourceDocument` — one built in memory rather than read —
  is written into **its container's document**: it is emitted inline wherever its container is written. So
  a new child added to an element that lives in a fragment is written into that fragment, and a new child
  under the main document's tree is written into the main file. (Only an element read from disk carries a
  `SourceDocument`; the reader sets it, and a fragment-preserving write routes it back to that file.)

## Fidelity

The writer targets **semantic** fidelity, not byte-for-byte output: the goal is that reading a model,
writing it, and reading the result again reproduces an equivalent object graph, and that the output
reopens in the Capella tool. The round-trip is proven by
[`XmiWriterTestFixture`](../Auriga.Xmi.Tests/XmiWriterTestFixture.cs) against the minimal fixture and the
fragmented `sysmodel` fixture.

The following differences from Capella's own serialization are **benign** (they do not change meaning and
reopen cleanly). Each is the reason byte-for-byte equality is not attainable, and each is neutralized by
the normalized comparison in the round-trip regression suite (below):

- **Tag wrapping.** EMF wraps long start-tags across several lines (one `xmlns:`/attribute per line); the
  writer relies on `XmlWriter`, which keeps a tag's attributes on one line.
- **Ordering.** Attribute and child ordering is alphabetical by feature name (a stable, deterministic
  order that matches the reader), which does not always match Capella's ordering.
- **Encoding case.** The XML declaration encoding renders as `utf-8` (lower-case) rather than `UTF-8`.
- **Namespace declarations.** The writer declares exactly the packages a document uses; Capella's declared
  set and prefix order can differ.
- **Default values.** Capella omits an attribute whose value equals its Ecore default (e.g. `actor="false"`);
  the writer emits it. The value is identical, so the meaning is unchanged.
- **Multi-valued features as elements.** Capella serializes some multi-valued features as repeated child
  elements (e.g. `bodies`/`languages` of an `OpaqueExpression`, `unsynchronizedFeatures`); the writer emits
  them as a single whitespace-delimited attribute. The values are the same.
- **Typed-reference spelling.** A reference that carries an `xsi:type` hint (e.g. `exchangedItems`,
  `triggers`) and same-/cross-document `#id` / `path#id` tokens are spelled differently but resolve to the
  same target.
- **Inline vs. href proxy.** At a fragment boundary an element may be inlined on one side and written as an
  `href` proxy on the other; both denote the same element in the same document.

Verifying that a written file opens in Capella 7.0.0 is a manual step; the automated proxy is the
round-trip equivalence, well-formedness, and correct namespace declarations.

## Round-trip regression suite

[`RoundTripRegressionTestFixture`](../Auriga.Xmi.Tests/RoundTripRegressionTestFixture.cs) runs read → write
→ compare over **every** fixture under [`TestData/`](../TestData) (issue #19), skipping any model whose
metamodel version the reader does not support (the 6.0.0 coffee-machine fixture). Two complementary checks:

- **Semantic round-trip (CI gate).** Read → write → re-read → compare object graphs (element set, types,
  containment, source document, resolved references, and dangling references). This is the enforced check
  — it runs on every CI build through the normal `dotnet test` and catches any change to what a model
  round-trips to. The reader is the normalizer here: every benign textual difference above is invisible to
  the object graph, so a green run means no *semantic* regression.
- **Normalized text diff (on-demand audit).** An `[Explicit]` test compares the written files against the
  originals after normalizing the benign differences away, and buckets every residual difference into the
  categories above. It is not a CI gate — byte-level fidelity is not a v1 goal — but running it produces the
  auditable list of accepted differences and flags any new, `UNCLASSIFIED` divergence for investigation.
