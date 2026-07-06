# capella4net: Project Context and Design Discussion

This document captures a design conversation about building **capella4net**, a .NET library for reading, manipulating, and serializing Eclipse Capella models, with an eventual goal of converting Capella models to SysML v2 via **SysML2.NET**.

It is intended as project context for Claude Code (or any successor agent) to continue the design and implementation work. The document preserves the reasoning behind decisions so that later work can revisit or override them with full understanding of the tradeoffs.

## Background and existing assets

The organization (Starion Group) already maintains a family of .NET libraries and tools in the model-based systems engineering (MBSE) space:

- **uml4net**: UML metamodel implementation for .NET, reads UML XMI
- **ecorenetto**: Ecore metamodel implementation for .NET
- **SysML2.NET**: SysML v2 library for .NET
- **reqifsharp**: ReqIF (requirements interchange) library for .NET
- **Hypha**: a Claude plugin acting as a SysML v2 expert agent, part of the Mycelium ecosystem (repo: `mycelium-cmbse/mycelium-hypha`)
- **Mycelium**: next-generation collaborative MBSE platform for concurrent design, built on SysML v2

capella4net will slot into this stack as the Capella reading/writing foundation, and a separate library (working name `capella2sysml2`) will use both capella4net and SysML2.NET to perform the conversion.

## Scope of capella4net

### Two very different sub-problems

Capella models comprise two independent concerns:

**The semantic model.** The actual system-engineering content (Operational Analysis, System Analysis, Logical Architecture, Physical Architecture, EPBS, and common packages). Lives in `.melodymodeller` and `.capellafragment` files. This is Ecore-serialized XMI. Fully within reach.

**The representations / diagrams.** How the model is displayed visually. Lives in `.aird` files, which are Sirius artifacts. Sirius has its own metamodel (viewpoints, representations, diagram elements, styles, layout data) independent from the Capella semantic metamodel. Enormous scope on its own, mostly useful only if you want to render or edit diagrams.

**Decision: scope v1 to semantic model only.** Skip `.aird`. Diagrams matter for humans but rarely for programmatic manipulation. Treating `.aird` as out-of-scope keeps the project achievable in months rather than years. It can be a separate project later if it earns its way in.

### Foundation observations

Capella is Ecore-based. The metamodel is defined by dozens of `.ecore` files in the Eclipse Capella repository. Since ecorenetto already exists and handles Ecore, the hardest part of the foundation is already solved.

The Capella metamodel is structural-UML-based: every Ecore package acts like a UML Package with EClasses and EReferences. It splits by architecture layer (oa, sa, la, pa, epbs) plus common packages (core, activity, behavior, libraries, requirements, information, fa, capellamodeller, re).

Capella file formats:
- `.aird` (Sirius diagram files): the "representations" file, out of v1 scope
- `.melodymodeller`: the actual semantic model content (this is the primary target)
- `.capella`: project descriptor, references model and aird
- `.capellafragment`: fragment files for models split across multiple files

## Prior art

### py-capellambse (primary reference)

Repository: `https://github.com/dbinfrago/py-capellambse`
Documentation: `https://dbinfrago.github.io/py-capellambse/`
License: Apache 2.0
Maintainer: DB InfraGO AG

A Python 3 headless implementation of Capella. Read-write for most of Capella's metamodel. Battle-tested in DB's production pipelines for artifact generation.

Study specifically:
- The core object model in `capellambse/model/`: how they map Capella metaclasses to Python classes, how they handle fragments and cross-file references
- Their examples, particularly `https://github.com/dbinfrago/coffee-machine` (a small Capella model used for demos, ideal as a first capella4net test fixture)

Design lessons transfer even though the language target differs. Do not port code; use it as an architectural reference.

### Eclipse Capella source (metamodel ground truth)

Repository: `https://github.com/eclipse-capella/capella`
Current release: v7.0.1 stable, v7.1.0 in pre-release (mid-2026)
License: EPL-2.0

Heavy repo containing the entire Capella tool. The `.ecore` files are scattered across many plugin subdirectories:
- `common/plugins/org.polarsys.capella.common.data.activity.gen`
- `common/plugins/org.polarsys.capella.common.data.behavior.gen`
- `common/plugins/org.polarsys.capella.common.data.core.gen`
- `common/plugins/org.polarsys.capella.common.libraries.gen`
- `common/plugins/org.polarsys.capella.common.re.gen`
- `core/plugins/org.polarsys.capella.core.data.oa`
- `core/plugins/org.polarsys.capella.core.data.sa`
- `core/plugins/org.polarsys.capella.core.data.la`
- `core/plugins/org.polarsys.capella.core.data.pa`
- `core/plugins/org.polarsys.capella.core.data.epbs`

Related repositories in the same org worth knowing:
- `eclipse-capella/capella-requirements-vp`: the Requirements viewpoint metamodel
- `eclipse-capella/capella-studio`: the SDK for building Capella extensions
- `eclipse-capella/capella-sss-transition`: system-to-subsystem transition, useful as design inspiration for how they express transformation rules

### capella-sysmlv2-bridge (critical prior art)

Repository: `https://github.com/eclipse-capella/capella-sysmlv2-bridge`

**This is an Eclipse-hosted project doing some form of Capella-to-SysML v2 bridging.** It must be evaluated before finalizing the capella2sysml2 design. Possible outcomes of the evaluation:

1. **Mature and canonical**: capella2sysml2 becomes a wrapper or a .NET port of its mapping specification. Big win: inherit spec-adjacent legitimacy without defending every mapping decision from scratch.
2. **Partial or dormant**: base the mapping specification on theirs where it exists, extend where it does not, cite them.
3. **Proof-of-concept only**: proceed with independent design but reference their attempts and gotchas as prior art.


# Official Capella source (heavy, contains all .ecore files)
git clone --depth 1 https://github.com/eclipse-capella/capella.git'
cloned to C:\Users\sgerene\SourceCode\capella

# Requirements viewpoint (separate)
git clone --depth 1 https://github.com/eclipse-capella/capella-requirements-vp.git
cloned to C:\Users\sgerene\SourceCode\capella-requirements-vp

# Prior-art SysML v2 bridge, investigate first
git clone --depth 1 https://github.com/eclipse-capella/capella-sysmlv2-bridge.git
cloned to C:\Users\sgerene\SourceCode\capella-sysmlv2-bridge

# Python reference implementation
git clone --depth 1 https://github.com/dbinfrago/py-capellambse.git
clned to C:\Users\sgerene\SourceCode\py-capellambse
```

Note for downstream agents: these are reference-only. Do not port code directly. py-capellambse informs architectural decisions. The Capella Java sources are the ground truth for the metamodel structure. The bridge repo is prior art to evaluate before publishing a mapping.

## The plan for capella4net

### Phase 1: Ground truth (understand the metamodel)

1. Clone `eclipse-capella/capella` and locate all `.ecore` and `.genmodel` files
2. Map the package structure: common packages plus architecture layers, understand dependencies
3. Identify v1 scope subset: `common.data.core`, `oa`, `sa`, `la`, `pa`, `epbs`, `information`, `fa`, `requirements`, `capellamodeller` (approximately 10 packages, hundreds of EClasses)
4. Load one `.ecore` with ecorenetto as a sanity check: verify Ecore reading handles Capella's Ecore correctly
5. Read the Capella metamodel wiki carefully: Arcadia methodology bakes assumptions into the metamodel that raw Ecore does not reveal

Deliverable: a document mapping the Capella metamodel structure, dependencies, and the v1 subset.

### Phase 2: Code generation from Ecore

This decision determines whether the project ships or drowns. With hundreds of metaclasses across a dozen packages, hand-writing C# classes is not feasible. Generate them from the `.ecore` files, exactly as Eclipse EMF's genmodel step does for Java.

**Recommended approach: extend ecorenetto with a C# code generator.**

Since ecorenetto already reads Ecore into a live object graph, walk that graph and emit C# interfaces and implementations (following the EMF pattern: `IPhysicalFunction` interface, `PhysicalFunction` class, `PaFactory` for instantiation). This makes ecorenetto more valuable as a general-purpose library, not just for Capella. Handles any Ecore-based DSL later (Capella today, KerML, customer DSLs, etc.).

Deliverable: `ecorenetto.CodeGen` (or similar), a tool that takes Capella `.ecore` files and emits a set of C# projects with typed interfaces, implementations, and factories.

### Phase 3: Reader (`.melodymodeller` XMI to typed objects)

Once generated classes exist, the reader is the same problem solved twice already (in uml4net and reqifsharp): XMI in, typed object graph out.

Key elements:

**XMI is namespace-heavy.** Each Capella package has its own XML namespace. The reader must resolve `xsi:type` attributes to concrete EClass instances using those namespaces.

**Cross-references are ID-based.** Elements refer to each other via `xmi:id` (intra-file) and `href` with UUID paths (inter-file). Resolution is a two-pass affair: first pass instantiates everything and captures unresolved references, second pass resolves them once all objects exist. Same pattern as uml4net.

**Fragments are the interesting part.** Capella supports splitting a model across a main `.melodymodeller` and multiple `.capellafragment` files. References cross these boundaries via `href="fragment.capellafragment#uuid"`. The reader must load all fragments and resolve cross-fragment references. This is genuinely harder than uml4net because UML XMI is typically single-file.

Deliverable: `capella4net.Reader` that consumes a `.aird`-referenced `.capella` + `.melodymodeller` (+ fragments) set and returns a fully resolved typed object graph.

### Phase 4: Object model and navigation API

Generated classes give data access; users of the library want an experience, not just a bag of types. Design decisions:

**Navigation from container to contained and back.** Follow EMF's `eContainer()`/`eContents()` pattern, and provide richer typed navigation where useful. Some of both.

**Expose the architecture layers as first-class.** Give users a `CapellaProject` root with clean accessors like `project.OperationalAnalysis`, `project.SystemAnalysis`, `project.LogicalArchitecture`, and so on. This is where the library feels native rather than mechanical.

**Queries via LINQ, not AQL.** Java Capella uses AQL for model queries. Reimplementing AQL in v1 is not the priority. LINQ against the typed object graph is much more natural for C# users and covers 90% of typical needs. AQL can be revisited later if there is demand.

**Extension methods, following the uml4net pattern.** `QueryAllFunctions()`, `QueryContainedIn(component)`, `IsAllocatedTo(target)`, and similar. This makes the object graph feel first-class C#.

Deliverable: a documented, ergonomic public API for reading and navigating Capella models.

### Phase 5: Writing back to disk

Round-tripping is where subtle bugs live and separates a reader from a real library. Concerns:

**XMI ID stability.** Every element has a UUID. When writing back, existing elements must keep their IDs; new elements need generated UUIDs that do not collide.

**Namespace preservation.** The XML output must use the correct namespace prefixes and declarations matching what Capella itself produces, or the file may not open in the Capella tool.

**Formatting fidelity.** Capella's tool is particular about how the XMI is formatted. Aim for byte-identical (or near-identical) output when reading and writing an untouched file, so users can diff their changes cleanly.

**Fragment handling.** If a model was split across fragments on read, the write must preserve that split. Which fragment does a newly-created element belong to is a design decision.

**Cross-references become hrefs.** In-memory object references must serialize as XMI hrefs, using the right path syntax for same-file, cross-fragment, and cross-library references.

Test methodology: read a real Capella model (Capella's own tutorial samples or the coffee-machine demo), write it back untouched, diff. This is the regression suite. Any diff is a bug until proven benign.

Deliverable: `capella4net.Writer` producing round-trippable XMI.

### Phase 6: Validation harness

Once read and write work, prove correctness against real models, not toys. Sources of test fixtures:

- Capella's own sample projects (In-Flight Entertainment System, System of Systems)
- The coffee-machine demo from py-capellambse
- Customer models where IP and permissions allow

Run each through read then serialize then parse then compare cycles. Any divergence is a bug or a genuine ambiguity in the metamodel, worth catching either way.

### Sequencing (not waterfall)

- Weeks 1-2: metamodel study, ecorenetto validation against one Capella `.ecore`
- Weeks 3-4: code generator prototype, hand-coded for one package (pa), then generalized
- Weeks 5-6: reader for that one package's element types against a hand-crafted minimal `.melodymodeller`
- Weeks 7-8: expand to all v1 packages, handle fragments (ship preview: read-only)
- Weeks 9-10: writer, round-trip tests, real-fixture regression
- Weeks 11-12: public API polish, docs, first release

Realistic solo-developer timeline. With a small team: 6-8 weeks.


## The capella2sysml2 conversion (separate project)

### Why the conversion is a hard problem

Capella and SysML v2 are not two dialects of the same thing. They express different worldviews:

- **Capella is methodology-driven.** Arcadia prescribes five architecture layers and specific artifacts. The methodology is baked into the type system.
- **SysML v2 is meta-model-driven.** KerML gives a rich typed foundation; SysML v2 layers domain vocabulary on top. No prescribed architecture layering.

Conversion is not mechanical mapping. It requires deciding what Arcadia's structure means in SysML v2 terms, which is a modeling choice with real consequences.

### Specific tensions to navigate

**Multi-layer traceability.** Arcadia's power comes from explicit traceability between layers (a SystemFunction realizes an OperationalActivity, a LogicalComponent allocates to a PhysicalComponent). SysML v2 has Satisfy, Refine, Trace, and Allocation relationships, but they are semantically weaker and less prescribed. Decide how to preserve Arcadia's layer semantics.

**Functional-vs-structural split.** Arcadia distinguishes functions from components sharply. SysML v2's action/part distinction is similar but shaped differently. Actions in SysML v2 are about behavior; Capella functions carry both behavior and structure connotations.

**Ports and interfaces.** Capella has ComponentPort, FunctionPort, PhysicalPort, ComponentExchange, FunctionalExchange, PhysicalLink. SysML v2 unifies these under a smaller port/interface model. The mapping is many-to-few, and information about which kind of port a thing was is important to preserve for round-tripping.

**Data types and information exchange.** Capella has a specific information subpackage. SysML v2's KerML has its own datatype and feature story. Not one-to-one.

**Requirements.** Capella's requirements integration versus SysML v2's RequirementDefinition/RequirementUsage. Cleaner mapping than most, but semantics of satisfaction and derivation differ subtly.

**States and modes.** Arcadia's Mode/State machines have specific semantics tied to the methodology. SysML v2's state semantics come from KerML. Similar but not identical.

**Allocations.** Arcadia has rich allocation semantics between layers. SysML v2 has AllocationUsage. Shape differs.

None of these are blockers. They are modeling decisions, and there is often more than one defensible answer. Which is why the conversion needs to be opinionated: pick one answer per case, document why, stay consistent.

### Architecture: capella2sysml2 does NOT belong inside capella4net

Recommended repo structure:

```
STARIONGROUP/
  ecorenetto              existing, gains .ecore to C# codegen
  capella4net             new: Capella model library, depends on ecorenetto
  SysML2.NET              existing: SysML v2 library
  capella2sysml2          new: the converter, depends on both
```

### Converter internal architecture (three layers)

**Layer 1: Traversal.** Walk the Capella model, visiting each element type in a defined order. Order matters because the target model has containment and reference constraints. Typically: project structure first, then packages, then types, then elements, then relationships between elements. Capella-specific but target-agnostic.

**Layer 2: Mapping rules.** For each Capella element type, define what SysML v2 element(s) it produces. Every mapping rule is a small, testable, documentable unit. Example: `LogicalComponent -> PartDefinition + PartUsage`. `ComponentPort -> PortUsage`. `LogicalFunction -> ActionDefinition + ActionUsage`. This layer knows about both Capella and SysML v2.

**Layer 3: Correlation.** Every source element gets a stable identifier in the target model, and every reference in the source resolves to a reference in the target. Bookkeeping, but critical for round-tripping and traceability. A `SatisfiedBy` in the source becomes a `SatisfyRequirement` in the target only if both endpoints can be resolved.

### Design decisions

**One-way, not bidirectional.** Capella-to-SysML v2 is the interesting direction. The reverse is a different problem (SysML v2 is more expressive; reverse conversion must lose information intentionally). we do not support sysmlv2 to capella

**Opinionated, not configurable.** For v1, ship a single opinionated mapping. Users cannot make good configuration decisions until they have seen a default mapping work. Add configurability in v2 if demand emerges.

**Preserve traceability to source.** For every generated SysML v2 element, keep a reference (comment, tagged value, or KerML annotation) to its Capella source ID. Makes conversion debuggable, gives users a trail back to the origin, enables "highlight the Capella source of this SysML v2 element" tooling. Small cost, big payoff.

**No diagram conversion in v1.** Capella diagrams are Sirius artifacts with layout, styling, viewpoint semantics. SysML v2's view/notation story is less mature. Trying to convert diagrams is a rabbit hole. Convert the semantic model; let users regenerate views on the SysML v2 side.

### Build order

Do not start with converter code. Start with concrete mapping decisions:

1. Pick a small self-contained Capella example
2. Manually convert it to SysML v2 by hand, documenting each decision as you go
3. This document becomes both the mapping specification and the test oracle
4. Implement mapping rules to reproduce the hand conversion
5. Expand rule by rule, tracking coverage
6. Test against larger real models to surface edge cases
7. Document unmappable cases explicitly; users need to know what got lost

### Milestones

- v0.1: `common.data.core` + `sa` (System Analysis) elements
- v0.2: add oa, la, pa layers with allocation preserved
- v0.3: requirements integration
- v0.4: modes/states, functional exchanges
- v1.0: full v1 metamodel coverage of capella4net, documented mapping specification, tested against multiple real projects

Realistic timeline: three to six months of focused work after capella4net v1 ships.

### Strategic positioning

Zooming out: this whole stack (uml4net, ecorenetto, capella4net, SysML2.NET, reqifsharp, Hypha, the planned UML agent, Mycelium, capella2sysml2) is a coherent .NET-based MBSE stack. capella2sysml2 in particular is a migration path for organizations that have invested in Capella and are looking at SysML v2. That is a real market position as SysML v2 adoption grows.

Two implications:
- **The mapping specification is at least as important as the code.** Publish it prominently: a real document, versioned, with rationale for each decision. This is what the MBSE community will engage with and cite.
- **Consider engaging the SysML v2 Submission Team.** If OMG eventually wants to endorse a Capella-to-SysML v2 mapping, being the reference implementation is valuable. Even informal SST feedback strengthens the mapping and its credibility.

## Immediate next steps for Claude Code

1. **Investigate `capella-sysmlv2-bridge` first.** Read its README, examine its scope, check activity/maintenance. Report back on what it is and how it changes the capella2sysml2 strategy.
2. Explore the Capella metamodel: enumerate `.ecore` files, propose the v1 package subset
3. Validate ecorenetto against one Capella `.ecore` (start with `common.data.core.ecore` since it is foundational)
4. Sketch the design of `ecorenetto.CodeGen` (Phase 2) before writing code
5. Study py-capellambse's approach to fragment handling and cross-reference resolution; document the design patterns worth carrying over

## Open questions to resolve

- Confirm which specific `.ecore` files constitute the v1 scope (the list above is an estimate)
- Decide on capella4net's public API shape: how closely to mirror EMF conventions versus adopting more idiomatic C# patterns
- Determine test fixture strategy: rely on py-capellambse's coffee-machine and Capella's tutorial samples, or curate a dedicated test set