# Arcadia Semantics Not Visible in Raw Ecore

**Issue:** [#3](https://github.com/STARIONGROUP/Auriga/issues/3)
**Metamodel version:** Capella 7.0.0, the 21 vendored files in [`resources/ecore/`](../resources/ecore) — see the [metamodel inventory](metamodel-inventory.md) (#1)
**Architectural reference:** [py-capellambse](https://github.com/dbinfrago/py-capellambse) (`src/capellambse/model/` + `src/capellambse/metamodel/`), studied as design input only

The Arcadia methodology bakes assumptions into the Capella metamodel that the raw Ecore does not express: what the five layers *mean*, which containment slots are conventions rather than free choices, and how allocation/realization links are supposed to be used. This document records those semantics so that capella4net's public API (architecture-layer accessors, query extensions — Phase 4 of the [project context](../Auriga-project-context.md)) respects them. Facts are labeled **[ecore]** when verifiable in the vendored files and **[convention]** when established by the Capella tool or the Arcadia method but *not* enforced by the metamodel.

## 1. The five perspectives

Arcadia structures a model into five **perspectives** (the method's own term; "layers" colloquially). The first two describe the *need*, the last three the *solution*. The method is explicitly iterative, not waterfall: layers co-evolve, and Capella's transition tooling is designed to be re-run as they change.

| Perspective | Ecore pkg | Engineering question | Main artifacts |
| --- | --- | --- | --- |
| **Operational Analysis (OA)** | `oa` | What do the users need to accomplish? | OperationalActivity, Entity, Role, OperationalCapability, OperationalProcess, CommunicationMean |
| **System Analysis (SA)** | `ctx` | What must the system accomplish for the users? | SystemFunction, SystemComponent (system + actors), Capability, Mission, FunctionalExchange, interfaces |
| **Logical Architecture (LA)** | `la` | How will the system work to fulfil expectations? | LogicalFunction, LogicalComponent, CapabilityRealization, ComponentExchange |
| **Physical Architecture (PA)** | `pa` | How will the system be developed and built? | PhysicalFunction, PhysicalComponent (NODE/BEHAVIOR), PhysicalLink, PhysicalPath, deployment |
| **EPBS** | `epbs` | What is expected from each built or bought component? | ConfigurationItem (HWCI, CSCI, COTS, NDI, Prime Item, System CI, Interface CI) |

Semantics a library must not blur:

- **OA is system-agnostic** [convention]. There is no system element in OA; activities are performed by entities/roles, not allocated to a system. The system boundary first appears in SA.
- **SA is still a black box** [convention]: functions are split between the System component and external actors, but no internal solution structure exists yet.
- **PA adds technology**: `pa::PhysicalComponent.nature` distinguishes **BEHAVIOR** (software/behavioural) from **NODE** (execution resource/hardware) components [ecore: `PhysicalComponentNature` enum].
- **EPBS is not an architecture** but a procurement/configuration-management view over PA artifacts [convention]. In the Ecore it nevertheless *is* a `ComponentArchitecture` and inherits function/data/interface package slots it never uses [ecore].

Authoritative sources: [Arcadia overview](https://mbse-capella.org/arcadia.html), [Arcadia Q&A by the method authors](https://mbse-capella.org/arcadia-qna.html), the Capella Guide sources in [`eclipse-capella/capella/doc/plugins`](https://github.com/eclipse-capella/capella/tree/master/doc/plugins), and J.-L. Voirin, *Model-based System and Architecture Engineering with the Arcadia Method* (ISTE 2017).

## 2. Model root and layer roots

### 2.1 From Project to the layers [ecore]

```
capellamodeller::Project            (or Library, its subclass)
  └ ownedModelRoots : ModelRoot [0..*]                        (containment)
      └ capellamodeller::SystemEngineering
          └ ownedArchitectures : ModellingArchitecture [0..*] (containment, inherited
                                                               from capellacore::AbstractModellingStructure)
              ├ oa::OperationalAnalysis
              ├ ctx::SystemAnalysis
              ├ la::LogicalArchitecture
              ├ pa::PhysicalArchitecture
              └ epbs::EPBSArchitecture
```

**The `ownedArchitectures` slot is untyped and unordered** [ecore]: it holds any `ModellingArchitecture`, in any order, with any multiplicity per layer type. The typed accessors on `SystemEngineering` (`containedOperationalAnalysis`, `containedSystemAnalysis`, `containedLogicalArchitectures`, `containedPhysicalArchitectures`, `containedEPBSArchitectures`) are all **derived** type-filters over `ownedArchitectures` — and all `[0..*]`. A well-formed Capella project has exactly one of each of the five [convention]; py-capellambse locates each layer by type-scan and treats 0 or >1 `Project` roots as an error. capella4net's `project.OperationalAnalysis`-style accessors should do the same type-scan, decide a policy for the multi-instance case (first-wins vs. error), and never rely on ordering.

Note `la::LogicalArchitecturePkg`, `pa::PhysicalArchitecturePkg`, `epbs::EPBSArchitecturePkg` exist for *multiple architectures per layer* (`cs::BlockArchitecturePkg` subtypes); oa and ctx have no such pkg classes [ecore].

### 2.2 Shared layer-root inheritance [ecore]

```
capellacore::Structure
  └ capellacore::ModellingArchitecture
      └ fa::AbstractFunctionalArchitecture     (ownedFunctionPkg, ownedComponentExchanges,
          │                                     ownedFunctionalLinks, ownedFunctionalAllocations,
          │                                     ownedComponentExchangeRealizations, ...)
          └ cs::BlockArchitecture              (ownedAbstractCapabilityPkg, ownedInterfacePkg,
              │                                 ownedDataPkg; derived: system, allocatedArchitectures)
              ├ oa::OperationalAnalysis
              └ cs::ComponentArchitecture
                  ├ ctx::SystemAnalysis
                  ├ la::LogicalArchitecture
                  ├ pa::PhysicalArchitecture
                  └ epbs::EPBSArchitecture
```

This mirrors what makes a generic API possible: `ownedFunctionPkg`, `ownedDataPkg`, `ownedInterfacePkg`, `ownedAbstractCapabilityPkg` and the derived `system` exist **once**, on the abstract bases, for every layer. py-capellambse exploits exactly this by defining `all_functions`, `function_pkg`, `data_pkg` etc. once on its `BlockArchitecture`/`AbstractFunctionalArchitecture` classes.

### 2.3 Per-layer roots: own containment slots [ecore]

| Layer root | Own containment (beyond the inherited slots above) | Layer-vocabulary derived aliases |
| --- | --- | --- |
| `oa::OperationalAnalysis` | `ownedRolePkg`, `ownedEntityPkg`, `ownedConceptPkg` (all `[0..1]`) | `containedOperationalActivityPkg` = `ownedFunctionPkg`; `containedOperationalCapabilityPkg` = `ownedAbstractCapabilityPkg` |
| `ctx::SystemAnalysis` | `ownedSystemComponentPkg [0..1]`, `ownedMissionPkg [0..1]`, `ownedOperationalAnalysisRealizations [0..*]` | `containedSystemFunctionPkg`, `containedCapabilityPkg` |
| `la::LogicalArchitecture` | `ownedLogicalComponentPkg [0..1]`, `ownedSystemAnalysisRealizations [0..*]` | `containedLogicalFunctionPkg`, `containedCapabilityRealizationPkg` |
| `pa::PhysicalArchitecture` | `ownedPhysicalComponentPkg [0..1]`, `ownedDeployments [0..*]`, `ownedLogicalArchitectureRealizations [0..*]` | `containedPhysicalFunctionPkg`, `containedCapabilityRealizationPkg` |
| `epbs::EPBSArchitecture` | `ownedConfigurationItemPkg [0..1]`, `ownedPhysicalArchitectureRealizations [0..*]` | `containedCapabilityRealizationPkg` |

Two cross-layer reuses to know: the OA function machinery *is* the fa machinery under an alias (`OperationalActivityPkg` is a `fa::FunctionPkg`, `OperationalActivity` an `fa::AbstractFunction`); and **`la::CapabilityRealizationPkg` is reused as the capability package of pa and epbs** — a pa layer's capabilities live in an la-package class [ecore].

There is **no requirements package** on the layer roots in 7.0: requirements attach via the eMDE extension mechanism (`CapellaRequirements::CapellaModule` is an `ElementExtension` placeable on any element; `CapellaOutgoingRelation` links a `CapellaElement` to a `Requirements::Requirement`) [ecore].

## 3. Allocation vs. realization

Arcadia distinguishes two orthogonal link families, both invisible as such in raw Ecore (everything is just an EClass with references):

- **Allocation** binds behaviour to structure *within one* perspective: functions onto components, functional exchanges onto component exchanges, component exchanges onto physical links.
- **Realization** is traceability *between* perspectives: each lower-layer element points up to the need element(s) it realizes.

### 3.1 The uniform link-element pattern [ecore]

Every allocation/realization is a **first-class model element** (not a plain reference), inheriting from `modellingcore::AbstractTrace` via `capellacore::Allocation`. The conventions are completely uniform:

- `sourceElement` = the *allocating/realizing* element (lower/later layer); `targetElement` = the *allocated/realized* element (upper/earlier layer).
- The link element is **contained by its source** (e.g. `FunctionRealization` lives in `AbstractFunction.ownedFunctionRealizations` of the realizing function).
- Concrete link classes add derived typed aliases over `sourceElement`/`targetElement` (e.g. `ComponentFunctionalAllocation.block`/`.function`).
- The traversal shortcuts on the endpoints are all **derived**: `realizedX` = via outgoing traces, `realizingX` = via incoming traces, `allocatedX`/`allocatingX` likewise. In `.melodymodeller` files only `sourceElement`/`targetElement` (and the containment) are serialized; every `realized*`/`realizing*`/`allocated*`/`allocating*` feature must be *computed* by capella4net.

### 3.2 The allocation metaclasses (within a layer) [ecore]

| Link class | Source (allocating) | Target (allocated) | Contained by |
| --- | --- | --- | --- |
| `fa::ComponentFunctionalAllocation` | `fa::AbstractFunctionalBlock` (component) | `fa::AbstractFunction` | `AbstractFunctionalBlock.ownedFunctionalAllocation` |
| `oa::RoleAllocation` | `oa::Entity` | `oa::Role` | `Entity.ownedRoleAllocations` |
| `oa::ActivityAllocation` | `oa::Role` | `oa::OperationalActivity` | `Role.ownedActivityAllocations` |
| `fa::ComponentExchangeFunctionalExchangeAllocation` | `fa::ComponentExchange` | `fa::FunctionalExchange` | `ComponentExchange.ownedComponentExchangeFunctionalExchangeAllocations` |
| `fa::ComponentExchangeAllocation` | `fa::ComponentExchangeAllocator` (`cs::PhysicalLink`, `cs::PhysicalPath`) | `fa::ComponentExchange` | `ComponentExchangeAllocator.ownedComponentExchangeAllocations` |
| `information::PortAllocation` | `information::Port` (ComponentPort) | `information::Port` (FunctionPort) | `Port.ownedPortAllocations` |
| `fa::ComponentPortAllocation` | `cs::PhysicalPort` | `fa::ComponentPort` | `PhysicalPort.ownedComponentPortAllocations` |
| `cs::InterfaceAllocation` (abstract) | `cs::InterfaceAllocator` (Component, Interface) | `cs::Interface` | `InterfaceAllocator.ownedInterfaceAllocations` |

Method rules the Ecore does not enforce [convention]:

- **Only leaf functions are allocated** to components; a parent function counts as allocated when all its children are. The tool displays this, the model does not store it.
- **Functions are allocated to BEHAVIOR physical components only**, never to NODE components. NODE components host behaviour components via deployment instead.
- A component exchange is allocated to **at most one** physical link; `cs::PhysicalPath` chains physical links to carry an exchange across intermediate nodes.
- OA has a *two-hop* allocation alternative: `Entity —RoleAllocation→ Role —ActivityAllocation→ OperationalActivity`, alongside direct `ComponentFunctionalAllocation` (Entity is a Component, see §6).

### 3.3 Deployment [ecore + convention]

Deployment is **not** an Allocation subclass: `cs::AbstractDeploymentLink` (← `capellacore::Relationship`) has `deployedElement : DeployableElement` and `location : DeploymentTarget`. Concrete classes (`PartDeploymentLink`, `TypeDeploymentLink`, `InstanceDeploymentLink`) live in the **nested `pa.deployment` EPackage**. The links physically hang off `cs::Part` elements (also `PhysicalComponent`, `PhysicalArchitecture`, `PhysicalComponentPkg`, `DeploymentConfiguration`).

Conventions: behaviour PCs deploy onto node PCs; a NODE cannot be deployed on a BEHAVIOR; and a component must not be both *contained* and *deployed* under the same parent (Capella validation rule DWF_DC_44) — containment (product breakdown) and deployment (execution mapping) are distinct hierarchies. Because deployment links live on Parts, a "deployed components" accessor is a three-hop computed chain: component → representing Parts → deployment links → deployed Part → its Component type. py-capellambse collapses this into `PhysicalComponent.deployed_components`; capella4net should offer the same collapsed accessor.

### 3.4 The realization metaclasses (between layers) [ecore]

| Link class | Realizing (source) → Realized (target) | Contained by |
| --- | --- | --- |
| `fa::FunctionRealization` | `fa::AbstractFunction` → `fa::AbstractFunction` (one layer up) | `AbstractFunction.ownedFunctionRealizations` |
| `cs::ComponentRealization` | `cs::Component` → `cs::Component` | `Component.ownedComponentRealizations` |
| `fa::FunctionalExchangeRealization` | FunctionalExchange → FunctionalExchange | `FunctionalExchange.ownedFunctionalExchangeRealizations` |
| `fa::ComponentExchangeRealization` | ComponentExchange → ComponentExchange | `ComponentExchange.ownedComponentExchangeRealizations` |
| `fa::FunctionalChainRealization` | FunctionalChain → FunctionalChain | `FunctionalChain.ownedFunctionalChainRealizations` |
| `interaction::AbstractCapabilityRealization` | AbstractCapability → AbstractCapability | `AbstractCapability.ownedAbstractCapabilityRealizations` |
| `information::PortRealization`, `cs::PhysicalPortRealization`, `cs::PhysicalLinkRealization`, `cs::PhysicalPathRealization`, `interaction::ScenarioRealization`, `capellacommon::AbstractStateRealization` / `StateTransitionRealization` / `StateEventRealization`, `information::InformationRealization` / `ExchangeItemRealization` | analogous | their source element |
| `epbs::PhysicalArtifactRealization` | `epbs::ConfigurationItem` → `cs::AbstractPhysicalArtifact` (PhysicalComponent, PhysicalLink, PhysicalPort) | `ConfigurationItem.ownedPhysicalArtifactRealizations` |
| **Whole-layer**: `ctx::OperationalAnalysisRealization`, `la::SystemAnalysisRealization`, `pa::LogicalArchitectureRealization`, `epbs::PhysicalArchitectureRealization` (all ← `cs::ArchitectureAllocation`) | layer root → previous layer root | the source layer root |

Pitfalls: there is **no `LogicalComponentRealization` EClass** — component realization at every layer is `cs::ComponentRealization` (some derived-feature annotation text suggests otherwise; do not trust annotation expressions as a feature inventory). And `la::CapabilityRealization` is **not a realization link** despite its name — it is the LA/PA/EPBS capability *element* (an `interaction::AbstractCapability` subclass); the link class is `interaction::AbstractCapabilityRealization`.

### 3.5 The prescribed realization chains [convention]

```
functions:    OperationalActivity ← SystemFunction ← LogicalFunction ← PhysicalFunction
components:   Entity              ← SystemComponent ← LogicalComponent ← PhysicalComponent ← ConfigurationItem*
capabilities: OperationalCapability ← ctx::Capability ← la::CapabilityRealization (LA) ← ... (PA)
exchanges:    Interaction/CommunicationMean ← FunctionalExchange (SA) ← FE (LA) ← FE (PA)
missions:     Mission —CapabilityExploitation→ Capability            (SA only; missions exist nowhere else)
```

\* ConfigurationItem uses `PhysicalArtifactRealization`, not `ComponentRealization`.

Semantic obligations [convention]: realization links assert *coverage and justification* — every solution element should realize a need element, every addressed need element should be realized. Consistency between allocation and realization is expected ("the linked transformed element shall be the transformed linked element": if PF realizes LF, the PC allocating PF should realize the LC allocating LF). Capella's validation checks these; the Ecore does not. Capella's transition tooling (Capella Guide ch. 11, "Iterative Transitions") creates these links conservatively and re-runnably: re-running never deletes targets, deleted targets are recreated, results reconciled via diff/merge.

### 3.6 Derived traceability features per metaclass [ecore]

The derived accessors capella4net must compute (per layer, the pattern is identical — shown for the function chain):

| Metaclass | Down (allocation) | Up (realized, earlier layer) | Down-stream (realizing, later layer) |
| --- | --- | --- | --- |
| `oa::OperationalActivity` | `allocatorEntities`, `allocatingRoles` | — | `realizingSystemFunctions` |
| `ctx::SystemFunction` | `allocatingSystemComponents` | `realizedOperationalActivities` | `realizingLogicalFunctions` |
| `la::LogicalFunction` | `allocatingLogicalComponents` | `realizedSystemFunctions` | `realizingPhysicalFunctions` |
| `pa::PhysicalFunction` | `allocatingPhysicalComponents` | `realizedLogicalFunctions` | — |

Components mirror this (`allocatedSystemFunctions`/`realizedEntities`/`realizingLogicalComponents` on `ctx::SystemComponent`, etc.), plus `pa::PhysicalComponent.deployedPhysicalComponents`/`deployingPhysicalComponents` and `epbs::ConfigurationItem.allocatedPhysicalArtifacts`. Exchanges and ports carry the same triad (`allocatedFunctionalExchanges`/`realizedComponentExchanges`/... on `fa::ComponentExchange`; `allocatedFunctionPorts`/`realizedComponentPorts`/... on `fa::ComponentPort`). Layer roots have `allocatedArchitectures`/`allocatingArchitectures` with per-layer aliases (`allocatedOperationalAnalyses` on SystemAnalysis, ...).

Note the direction trap in the *function* names: `FunctionRealization.allocatingFunction` = source (the realizing, lower-layer function) and `allocatedFunction` = target (the realized, upper-layer function) — "allocat-" naming on a realization link. The derived features (`realizedX`/`realizingX`) are the sane vocabulary; mirror those in the public API, not the raw link-feature names.

## 4. Involvements [ecore + convention]

`capellacore::Involvement` is the third link family: it *illustrates/describes* rather than allocates or traces. Only `involved` is a real reference; `involver` is derived from the owning containment (the involver owns its involvement links).

| Link class | Involver (owner) | Involved |
| --- | --- | --- |
| `ctx::MissionInvolvement` | `ctx::Mission` | `ctx::SystemComponent` |
| `ctx::CapabilityInvolvement` | `ctx::Capability` | `ctx::SystemComponent` |
| `oa::EntityOperationalCapabilityInvolvement` | `oa::OperationalCapability` | `oa::Entity` |
| `interaction::AbstractFunctionAbstractCapabilityInvolvement` | any `AbstractCapability` | `fa::AbstractFunction` |
| `interaction::FunctionalChainAbstractCapabilityInvolvement` | any `AbstractCapability` | `fa::FunctionalChain` |
| `capellacommon::CapabilityRealizationInvolvement` | `la::CapabilityRealization` | LogicalComponent, PhysicalComponent, ConfigurationItem |
| `fa::FunctionalChainInvolvement` (+ `...Function`, `...Link`, `FunctionalChainReference`) | `fa::FunctionalChain` | functions, functional exchanges, nested chains |
| `cs::PhysicalPathInvolvement` (+ `PhysicalPathReference`) | `cs::PhysicalPath` | Part, PhysicalLink, nested paths (chained via `nextInvolvements`) |

Semantics [convention]: a Capability is "the ability of the system to provide a service that supports high-level operational goals"; a Mission "exploits" capabilities (`ctx::CapabilityExploitation`, SA only). Capabilities are *illustrated* by involvement links to functions, chains, components and by `ownedScenarios`; they are the primary structuring device for functional analysis and IVVQ. `fa::FunctionalChainInvolvement` objects carry their own semantics (link source/target, exchanged items) — py-capellambse deliberately does *not* hide these link objects the way it hides plain allocation links; capella4net should keep them visible too.

## 5. Containment conventions

### 5.1 The Pkg pattern [ecore]

Every major element type X follows one pattern:

- an abstract pkg base (`fa::FunctionPkg`, `cs::ComponentPkg`, `capellacommon::AbstractCapabilityPkg`) with layer-specific subtypes (`ctx::SystemFunctionPkg`, `la::LogicalComponentPkg`, ...);
- each pkg owns `owned<X>s [0..*]` and **recursively** `owned<X>Pkgs [0..*]`;
- the element **self-nests**: `ownedSystemComponents` on SystemComponent, `ownedLogicalComponents` on LogicalComponent, `ownedFunctions` on `fa::AbstractFunction` (generic, all layers), `ownedEntities` on Entity, `ownedConfigurationItems` on ConfigurationItem;
- functions and components additionally **own pkgs themselves** (`ownedLogicalFunctionPkgs` on a LogicalFunction, `ownedLogicalComponentPkgs` on a LogicalComponent) — the containment graph is pkg→element→pkg→... arbitrarily deep.

Exceptions: `ctx::Capability`, `ctx::Mission`, `oa::OperationalCapability` live **only** in their pkgs (no self-nesting). FunctionalExchanges live on the **common ancestor function** (`fa::AbstractFunction.ownedFunctionalExchanges`), not in function pkgs. ComponentExchanges live on the layer root, component pkgs, or (for `oa::CommunicationMean`) the EntityPkg. State machines live on classifiers (`cs::Block.ownedStateMachines` — so any component including Entity and ConfigurationItem — plus `ComponentPkg`, `information::Class`, `CommunicationItem`), never on the architecture roots. FunctionalChains live under functions and capabilities (`fa::AbstractFunctionalChainContainer`). `la::LogicalComponent` can even own entire sub-architectures (`ownedLogicalArchitectures`).

The derived `subFunctions`/`containedX`/`childrenX` features union direct children with children found in owned pkgs transitively — another thing capella4net must compute.

### 5.2 What the tool expects inside those slots [convention]

The Ecore allows far more than well-formed Capella models use. The tool establishes, at project creation:

- **One root function per functional layer**, directly inside the layer's `ownedFunctionPkg` ("Root System Function", "Root Logical Function", ...; "Root Operational Activity" in OA). All real functions are its descendants. The root is a tooling artifact, usually hidden in diagrams. Caution from py-capellambse's deprecation record: its OA `root_activity` accessor is being *removed* because real-world OA packages do not reliably contain exactly one root; its SA/LA/PA `root_function` takes `function_pkg.functions[0]` leniently (error only when empty). Recommendation for capella4net: offer `RootFunction` per layer with the same lenient first-child semantics, and never *require* singleton roots when reading.
- **One root component ("the system") per layer plus actors as siblings**: the layer's root component pkg contains exactly one component with `actor=false` (the System / Logical System / Physical System) and the actor components next to it. This one *is* in the metamodel as the derived `cs::BlockArchitecture.system` — defined as exactly that filter [ecore]. py-capellambse enforces uniqueness on access (error on 0 or >1 non-actor components).
- **Pkg plumbing is presentation-hidden**: the Project Explorer hides Parts and FunctionalExchanges by default, and users are not expected to care which nested pkg an element sits in. py-capellambse mitigates via deep-search accessors (`all_functions`, `all_components`, `all_capabilities` — "give me every X below this layer regardless of packaging"). capella4net should expose both: honest containment navigation (`OwnedFunctionPkg`) *and* deep query extensions (`QueryAllFunctions()`), per the Phase 4 plan.

## 6. Metamodel surprises a library author must know

Collected from the Ecore analysis and confirmed against py-capellambse's handling:

1. **There are no Actor classes.** In 7.0, actor-ness is `cs::Component.actor : EBoolean` (plus `human : EBoolean`). "All actors of a layer" is a filter, not a type query. Some derived-feature annotation texts still reference pre-7.0 actor features — ignore them.
2. **Component/Part duality.** `cs::Component` is both a Classifier (type) and an `fa::AbstractFunctionalBlock`; instances are `cs::Part` elements living in `ownedFeatures` (or `ComponentPkg.ownedParts`) and pointing back via `abstractType`. In default ("singleton part") mode Capella auto-creates one Part per Component — py-capellambse does this transparently on element creation, and a Part may even *contain* its own type (`Part.ownedAbstractType`). Derived features like `subLogicalComponents` conceptually traverse parts. Deployment links live on Parts (§3.3).
3. **`oa::Entity` is a `cs::Component`** (via `oa::AbstractConceptItem`), and `EntityPkg` is a `ComponentPkg` — OA reuses the entire component machinery, including the actor flag. `oa::CommunicationMean` extends `fa::ComponentExchange` with derived `sourceEntity`/`targetEntity`.
4. **Exchange ends are indirected.** `FunctionalExchange`/`ComponentExchange` inherit `source`/`target : modellingcore::InformationsExchanger [1..1]` from `AbstractInformationFlow`; the typed accessors (`sourcePort`, `sourcePart`, ...) are derived and must unwrap `fa::ComponentExchangeEnd` (port + part) when present.
5. **`fa::AbstractFunction` is heavily multi-typed** [ecore]: Namespace + InvolvedElement + `information::AbstractInstance` (i.e. a Property/Feature!) + FunctionalChainContainer + `activity::CallBehaviorAction` + `behavior::AbstractEvent`. py-capellambse's need for MRO workarounds on exactly these classes predicts where capella4net's single-inheritance C# will need interface-based design; the generated code (issues #6–#8) must emit interfaces for every EClass.
6. **All the convenience features are `derived volatile transient`** — they are not in the XMI. The reader (issue #13) must not expect them; the generated classes need computed implementations (or the API layer provides them as extension methods). The `derived` features are precisely the cyclic references noted in the [inventory §3](metamodel-inventory.md).
7. **Nested EPackages**: `pa.deployment` and `information.{communication,datatype,datavalue}` are sub-EPackages with their own nsURIs — 24 XML namespaces total (inventory §2).
8. **EPBS inherits unused slots** (function/data/interface pkgs on `EPBSArchitecture`); `ConfigurationItem` is a full `cs::Component` whose real payload is `itemIdentifier` + `kind : ConfigurationItemKind` + the artifact realizations.
9. **Requirements are extensions**, not owned packages (§2.3): the reader must handle `ElementExtension` content on arbitrary elements (`ownedExtensions`, inventory §4).

## 7. API design lessons from py-capellambse

Distilled from `capellambse/model/` + `capellambse/metamodel/` (architectural reference only — no code ported):

1. **Layer accessors are type-scans** over `SystemEngineering.ownedArchitectures`, robust to ordering and missing layers (§2.1). Every element also gets a reverse `Layer` property (walk ancestors to the nearest `BlockArchitecture`) — cheap and very useful.
2. **Hide plain link objects, keep semantic ones.** Their `Allocation` accessor traverses allocation/realization link elements transparently (`component.allocated_functions` yields functions, not `ComponentFunctionalAllocation` objects), and *creates* the intermediate link element on write. Their explicit rule: if a link element carries anything beyond source/target (name, kind, exchanged items — e.g. `FunctionalChainInvolvement`, `cs::ExchangeItemAllocation`), expose it as real containment with a shortcut property instead. Both the raw containment (`FunctionalAllocations`) and the shortcut (`AllocatedFunctions`) are exposed as siblings.
3. **Reverse directions are computed** (`realizing_functions`, `deploying_components`): backed by model-wide reverse-reference search, not stored data. For capella4net this suggests a reverse-reference index built at load time (the reader already does two-pass resolution, issue #13).
4. **Layer vocabulary via aliasing**: define the mechanism once on the fa/cs base (`realized_functions`), give each layer the Arcadia-correct name and narrowed type (`SystemFunction.RealizedOperationalActivities`, `LogicalFunction.RealizedSystemFunctions`). This matches the Ecore's own derived-alias pattern (§2.3) and is directly expressible in C# with `new`-slot typed overrides or extension methods.
5. **Deep-search accessors** (`all_functions`, `all_components`, `all_actors`, backed by a type index) are the primary answer to Pkg plumbing (§5.2). LINQ + `QueryAllFunctions()`-style extensions are the C# equivalent (Phase 4 plan).
6. **Their deprecation log is a free requirements review**: singleton-root assumptions removed (`root_activity`), scalar conveniences over genuinely multi-valued links removed (`ComponentExchange.owner` "only takes into account the first allocation link"), "all recursive" vs "directly contained" naming being disambiguated (`component_exchanges` vs `all_component_exchanges`). capella4net should get these right from the start: prefer explicit `All*`/`Owned*` naming and avoid scalar accessors over multi-valued relations.

## 8. Pointers

- [Metamodel inventory](metamodel-inventory.md) (#1) — packages, counts, dependency cycles, eMDE, v1 scope
- [ECoreNetto validation](ecorenetto-validation.md) (#2) — the vendored files load fully resolved on ECoreNetto ≥ 9.0.0
- Arcadia: [method overview](https://mbse-capella.org/arcadia.html) · [Q&A](https://mbse-capella.org/arcadia-qna.html) · Voirin, *MBSE with the Arcadia Method* (ISTE 2017) · Roques, *Systems Architecture Modeling with the Arcadia Method* (ISTE 2017)
- Capella Guide sources: [doc/plugins](https://github.com/eclipse-capella/capella/tree/master/doc/plugins) — esp. `org.polarsys.capella.transitions.doc` (ch. 11 Iterative Transitions), `org.polarsys.capella.glossary.doc`, `org.polarsys.capella.ui.doc` (Project Explorer, Allocating Functions on Components)
- [Capella metamodel wiki](https://github.com/eclipse-capella/capella/wiki/Metamodel)
- [py-capellambse docs](https://dbinfrago.github.io/py-capellambse/) — esp. "Intro to the API" and "Intro to Physical Architecture API"
