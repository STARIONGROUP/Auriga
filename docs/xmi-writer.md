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

## Fidelity

The writer targets **semantic** fidelity, not byte-for-byte output: the goal is that reading a model,
writing it, and reading the result again reproduces an equivalent object graph, and that the output
reopens in the Capella tool. The round-trip is proven by
[`XmiWriterTestFixture`](../Auriga.Xmi.Tests/XmiWriterTestFixture.cs) against the minimal fixture and the
fragmented `sysmodel` fixture.

The following differences from Capella's own serialization are **benign** (they do not change meaning and
reopen cleanly):

- EMF wraps long start-tags across several lines (one `xmlns:`/attribute per line); the writer relies on
  `XmlWriter`, which keeps a tag's attributes on one line.
- Attribute and child ordering follows the Ecore feature declaration order, which approaches but does not
  always match Capella's ordering.
- The XML declaration encoding renders as `utf-8` (lower-case) rather than `UTF-8`.

Verifying that a written file opens in Capella 7.0.0 is a manual step; the automated proxy is the
round-trip equivalence, well-formedness, and correct namespace declarations.
