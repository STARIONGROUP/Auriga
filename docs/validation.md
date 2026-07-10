# Validation Against Real Capella Models

**Issue:** [#20](https://github.com/STARIONGROUP/Auriga/issues/20) (Phase 6)

Phase 6 proves the reader and writer correct against real Capella models rather than toy fixtures. This
document records the validation harness, the models it runs against and their results, the known
limitations, and — the part that matters most for anyone feeding Auriga a model it has never seen — exactly
how the library treats content that is out of v1 scope.

The short version: **every supported real model round-trips**, and the library never silently loses
in-scope data. Content it cannot represent is either rejected up front with a clear error or preserved
verbatim; the one case where meaning changes on write (a model saved by a different Capella version) is
called out below.

## The harness

Validation is not a separate tool — it is a set of NUnit fixtures that run on every CI build through the
normal `dotnet test`, so a regression in the reader or writer fails the build. Two fixtures carry the load:

- [`RoundTripRegressionTestFixture`](../Auriga.Xmi.Tests/RoundTripRegressionTestFixture.cs) — for **every**
  fixture under [`TestData/`](../TestData), read → write → re-read → compare object graphs (the CI gate),
  plus an `[Explicit]` normalized text-diff audit that buckets every residual textual difference into the
  accepted-benign categories and fails on anything new (`UNCLASSIFIED`). See
  [XMI Writer → Round-trip regression suite](xmi-writer.md#round-trip-regression-suite).
- [`RealModelReaderTestFixture`](../Auriga.Xmi.Tests/RealModelReaderTestFixture.cs) — reads the real models
  and asserts that every identified element loads into a typed object and that intra-file and cross-fragment
  references resolve.
- [`UnsupportedContentTestFixture`](../Auriga.Xmi.Tests/UnsupportedContentTestFixture.cs) — pins down the
  out-of-scope-content contract described below (a different-version model still reads; an add-on-viewpoint
  model is rejected with a clear, actionable error).

## Models validated

The fixtures and their provenance are catalogued in [`TestData/README.md`](../TestData/README.md). Their
validation status:

| Model | Version | Round-trips? | Notes |
| --- | --- | --- | --- |
| `minimal` | 7.0.0 | ✅ | Hand-crafted single-file Physical Architecture. |
| In-Flight Entertainment System | 7.0.0 (saved by 7.1.0) | ✅ | Official Capella sample; all five Arcadia layers, ~1.5 MB. |
| `fragmented-sysmodel` | 7.0.0 (saved by 7.1.0) | ✅ | Split across four `.capellafragment` files; exercises cross-fragment `href` resolution. |
| Level Crossing Traffic Control | 7.0.0 | ✅ | Official Capella sample; largest fixture (~1.5 MB semantic, ~37 MB `.aird`). |
| coffee-machine | **6.0.0** | ⚠️ read-only | Reads fully (version-tolerant); **out of round-trip scope** — the writer emits 7.0.0 namespaces (see below). |
| Crowd Surveillance System in DARC | 7.0.0 + **Cybersecurity** add-on | ⛔ rejected on read | Uses an add-on viewpoint outside the vendored metamodel; the reader rejects it with a clear error (see below). |

The other official sample named in the issue, *System of Systems*, is not published in the Capella git
repository (it ships with product downloads); the `fragmented-sysmodel` fixture covers the same
cross-fragment, multi-layer territory, and System of Systems can be added later if a redistributable copy is
obtained.

## Round-trip results

The semantic round-trip (read → write → re-read → compare) passes for all six supported model files (the
four 7.0.0 models above plus the two fragment-bearing files); the two out-of-scope fixtures are skipped with
a documented reason. Byte-for-byte equality with Capella's own serialization is **not** a v1 goal; the
remaining textual differences are all benign and enumerated in
[XMI Writer → Fidelity](xmi-writer.md#fidelity). The `[Explicit]` audit reports the residual counts per
fixture (every one classified, **zero `UNCLASSIFIED`**):

| Fixture | default-value | multivalued-feature-as-element | typed-reference-spelling | inline-vs-proxy |
| --- | --: | --: | --: | --: |
| `minimal.melodymodeller` | 8 | — | — | — |
| In-Flight Entertainment System | 19 | 32 | — | — |
| Level Crossing Traffic Control | 20 | 30 | — | — |
| `fragmented-sysmodel/sysmodel.capella` | 26 | 10 | 11 | 3 |

Each category is a documented, meaning-preserving difference between how Auriga's writer and Capella's own
writer spell the same model — Capella omitting an attribute that equals its Ecore default, serializing a
multi-valued feature as repeated child elements instead of one whitespace-delimited attribute, spelling a
typed reference with an `xsi:type` hint, or choosing inline vs. `href`-proxy at a fragment boundary. The
reader normalizes all of them away, which is why the object-graph round-trip is exact.

## How out-of-scope content is handled

Auriga v1 covers the Capella **semantic** model (core Capella packages + the Requirements viewpoint +
Kitalpha/EMDE) at metamodel version 7.0.0. Anything else is handled by one of four strategies — **reject**,
**preserve**, **skip**, or **normalize** — chosen so that in-scope data is never silently lost:

| Encountered content | Strategy | Behavior |
| --- | --- | --- |
| Diagram/representation files (`.aird`, `.airdfragment`), project sidecars (`.afm`, `.project`), image resources | **preserve** | Never opened. Fragment discovery follows only `.capellafragment` hrefs; `hlink://` rich-text links, `platform:/resource` library links and `.aird` references are ignored. The writer emits only semantic files, so sibling diagram/sidecar files are left on disk untouched. |
| Model saved by a different Capella minor version (e.g. 6.0.0 coffee-machine) | **read: normalize · write: migrate** | The reader resolves packages by a version-stripped namespace match ([`NamespaceResolver`](../Auriga.Xmi/Namespaces/NamespaceResolver.cs)), so a structurally-compatible model of another version loads into a fully resolved graph. **The writer always emits 7.0.0 namespaces**, so writing such a model back silently migrates its version — hence these models are read-only in v1 and excluded from the round-trip suite. |
| Add-on viewpoint / any package outside the vendored metamodel (e.g. the Cybersecurity viewpoint) | **reject** | The whole load fails fast with `InvalidDataException`: *"Cannot resolve the xsi:type '…' to a known Capella package"* (or, for a document root, *"The root namespace '…' … is not a known Capella package"*). Nothing is silently dropped — the model is refused until the viewpoint is vendored. |
| Unknown element **type** within a known package | **reject** | `InvalidOperationException`: *"No XMI reader is registered for the type '…'."* |
| Unrecognized child element (a role not in the metamodel) on an otherwise-known element | **skip** (default) or **reject** (strict) | By default the subtree is consumed and discarded and a `Warning` is logged, so discarded content stays diagnosable — the graceful-degradation path for a stray feature from another version/extension, which does not abort the load. Under **strict reading** (`UseStrictReading`, see below) the reader instead throws `NotSupportedException` naming the reader, element and line/position. |
| Missing or unparseable `.capellafragment` | **skip (warn)** | Logged as a `Warning` and skipped so one bad fragment does not fail the whole model; the rest loads. |
| A reference whose target is absent from every loaded file (dangling) | **preserve** | Kept in [`XmiReaderResult.UnresolvedReferences`](../Auriga.Xmi/Readers/XmiReaderResult.cs) (a `Warning` reports the count), and the verbatim reference token is re-emitted on write, so an intentionally-external `href` round-trips intact. |

### Strict vs. lenient reading

The "skip" row above is the one strategy the caller can switch. By default the reader is **lenient** — an unrecognized child element is skipped with a warning so a model carrying a stray feature still loads. Set `UseStrictReading` to make the reader **strict** — the same element then throws `NotSupportedException`, naming the reader, the offending element and its line/position. Strict reading is the tool for a validation run: it surfaces unexpected content as a hard error instead of dropping it silently.

```csharp
var reader = XmiReaderBuilder.Create()
    .UsingSettings(x => x.UseStrictReading = true)
    .Build();
```

`UseStrictReading` governs only the unrecognized-child-element case. An unknown **package** (add-on viewpoint) and an unknown element **type** are rejected regardless of the setting (the `reject` rows above), because those cannot be represented at all.

## Known limitations

- **No version fidelity on write.** A model read from a Capella version other than 7.0.0 is written back with
  7.0.0 namespaces. The reader is version-tolerant, but the writer is not version-preserving, so
  non-7.0.0 models are read-only in v1. A version-preserving writer (or an explicit up-front rejection of
  non-7.0.0 input) is a candidate for a future release; today the version fallback is best-effort and
  silent.
- **Add-on viewpoints are not supported.** Only the vendored packages are known. A model using an add-on
  viewpoint (Cybersecurity, and any other non-vendored viewpoint) is rejected on read. Supporting one means
  vendoring its `.ecore` and regenerating the readers/writers.
- **Diagrams are out of scope.** `.aird`/`.airdfragment` Sirius representations are neither read nor
  written; they are preserved untouched on disk but their contents are opaque to the library.
- **Byte-for-byte output is not a goal.** The writer targets semantic fidelity; see the benign-difference
  catalogue in [XMI Writer → Fidelity](xmi-writer.md#fidelity). Confirming a written file reopens in the
  Capella 7.0.0 tool is a manual step; the automated proxy is round-trip equivalence plus well-formed,
  correctly-namespaced output.
