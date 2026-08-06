# Sirius `.aird` diagrams

A Capella project keeps its *semantics* — the Arcadia layers, the functions, the components — in
`.capella` / `.melodymodeller` files, and its *diagrams* somewhere else entirely: in a Sirius `.aird`
file beside them. Nothing in the semantic model records that a function appears on a diagram, let
alone where. This document describes what an `.aird` holds, how Auriga reads it, and what the
rendering does and does not promise.

## Two parallel trees

An `.aird` root is an `xmi:XMI` wrapper around one `viewpoint:DAnalysis`, and it carries **two trees
that describe the same picture from different angles**:

- the **Sirius representation tree** — `DSemanticDiagram` holding `DNode`, `DNodeContainer`,
  `DNodeList` and `DEdge` — which says *what is displayed and how it is styled*, and points at the
  semantic element each item stands for through a `target` href into the `.capella`;
- the **GMF notation tree** — `notation:Diagram` holding `Node`, `Edge`, `Bounds`, `Location` and
  bendpoint lists — which says *where everything sits*, in pixels.

The two are linked by uid: a notation `View` carries an `element` reference to the Sirius element it
displays. Neither tree alone is enough. The Sirius tree knows a box means "the Make Coffee function"
but not where it is; the notation tree knows a rectangle is at `x=380 y=237 w=41 h=31` but not what it
represents.

Sub-models are `href`'d out to `.airdfragment` siblings through `referencedAnalysis`, exactly as
semantic content is fragmented into `.capellafragment` files.

Three kinds of representation appear in the fixtures and all three are supported: **graphical
diagrams**, **sequence diagrams** (`sequence` 2.0.0: instance roles, executions, messages) and
**tables** (`table` 1.1.0: lines, columns, cells).

## Reading one

```csharp
using var readers = XmiReaderBuilder.Create();
var session = readers.BuildAirdModelLoader().Load("IFE/IFE.aird");
```

`IAirdModelLoader` resolves the path — the `.aird` file, or a project directory holding exactly one —
and reads it, its `.airdfragment`s **and the Capella semantic documents its representations point
into**, in one session. Co-loading the semantic documents is what makes the cross-metamodel
`target` / `semanticElements` hrefs resolve to real objects instead of dangling; a diagram-only read
is available from the raw reader, but then a box knows its shape and not its meaning.

Tooling references are reported as unresolved rather than failing the load: `platform:/plugin`
`.odesign` viewpoint definitions and `environment:/` colour palettes live inside a Capella
installation, not in the project.

## The intermediate model

`IDiagramBuilder.Build` pairs the two trees into one `Diagram` of `Box`es and `Edge`s. Every item
carries absolute coordinates, its `ResolvedStyle`, the Sirius element that named and styled it, the
Capella element it represents, and a `Tooltip`.

**The layout is read, never computed.** Auriga performs no graph layout: a box is where Capella put
it. That is a deliberate constraint — a re-laid-out diagram would not be the diagram the engineer
drew, and reviewing it against the tool would be impossible. The consequence is that a representation
with no persisted GMF layout is skipped rather than invented, and reported at `Debug`.

Styles resolve in the order Capella itself uses: the Sirius owned style first, then the GMF notation
styles, then the Capella default palette, with a fallback for anything unknown or malformed.

## What comes out

`Auriga.Reporting` writes four things from that one model — SVG and PNG/JPEG through
`ISvgExporter` / `IRasterExporter`, and Excel through `IXlsxTableExporter` for tables, which have no
persisted geometry and are laid out as a grid instead. `IDiagramReportGenerator` does the whole
sequence in one call, and `Auriga.Tools` is that call behind a command line.

The vendored Capella artwork is embedded and inlined into the SVG as `data:` URIs, so an exported
diagram is a single self-contained file with no image sidecars.

## Fidelity is best-effort

Auriga is not Capella, and the exported picture is not pixel-identical to what Capella draws. Text
metrics differ, fonts a model names may be absent, and a handful of Sirius style features have no
equivalent in the intermediate model. **Rendering degrades rather than throws** — a diagram that
renders imperfectly beats one that does not render at all — so an unresolvable image falls back to an
outline, a malformed bendpoint falls back to the view centre, and the export continues.

`ReportingBuilder.WithLogger(ILoggerFactory)` is where every one of those degradations surfaces: at
`Debug`, the images no registry resolved, the representations skipped for want of a layout, and the
bendpoints and anchor ids that did not parse; at `Trace`, each unresolved image path and each style
value that failed to read. A well-formed model is silent at `Information` and above, so turning on
`Debug` is how you explain a difference between what Capella shows and what Auriga exported.

## Writing

Diagrams are **read-only**. The writer emits semantic files only; the `.aird` and its fragments are
left untouched on disk, so writing a model back preserves the layout it had. See
[Validation](validation.md) for the full read/write scope.
