# Auriga.CodeGenerator Design

**Issue:** [#6](https://github.com/STARIONGROUP/Auriga/issues/6)
**Depends on:** [#2](https://github.com/STARIONGROUP/Auriga/issues/2) (ECoreNetto loads the full Capella metamodel — done)
**Feeds:** [#7](https://github.com/STARIONGROUP/Auriga/issues/7) (generator implementation), [#13](https://github.com/STARIONGROUP/Auriga/issues/13) (the reader)
**Reference implementations studied:** [uml4net.CodeGenerator](https://github.com/STARIONGROUP/uml4net), [ECoreNetto + ECoreNetto.HandleBars](https://github.com/STARIONGROUP/EcoreNetto)

This is the Phase 2 design deliverable: how `Auriga.CodeGenerator` turns the vendored Capella `.ecore` files ([`resources/ecore`](../resources/ecore), 21 files / 24 EPackages / ~430 EClasses / 35 EEnums / 0 custom EDataTypes — see the [metamodel inventory](metamodel-inventory.md)) into the committed C# object model in the `Auriga` project. It is written to be implemented as-is in #7; every non-obvious choice is called out as a **Decision** with its rationale, and points that must be confirmed against the real metamodel during implementation are marked **Verify in #7**.

## 1. Reference approach in one paragraph

uml4net.CodeGenerator loads the OMG `UML.xmi` metamodel through `uml4net.xmi` into a typed object graph, then runs one Handlebars template per model element to emit **committed** C# (an `AutoGen*` folder tree of `partial` types), reformatting each file with Roslyn before writing, and gating regeneration with golden-file tests. Auriga mirrors this exactly, with three substitutions: the input graph is the **ECoreNetto** `EPackage → EClass → EStructuralFeature` graph (not UML); the reusable helper layer is **ECoreNetto.Extensions + ECoreNetto.HandleBars** (not `uml4net.Extensions`/`uml4net.HandleBars`); and Auriga supplies the one thing ECoreNetto has no opinion on — an **Ecore-primitive → C# type mapping**. Deserialization dispatch follows uml4net's single `XmiElementReaderFacade` (not a per-package factory), with the lookup key adapted to Capella's `(nsURI, localName)`.

## 2. Pipeline and project layout

The generator is a thin orchestrator, not a transformer chain. `Auriga.CodeGenerator` (already scaffolded, targets `net10.0`, references `ECoreNetto` + `ECoreNetto.HandleBars` 9.0.0) contains:

```
Auriga.CodeGenerator/
  Generators/
    HandleBarsGenerator.cs      // owns the shared IHandlebars env + compiled template registry
    ObjectModelGenerator.cs     // orchestrates: enums -> interfaces -> classes -> factories
    CodeCleanup.cs              // Roslyn reformat (CSharpSyntaxTree.ParseText + Formatter)
  Helpers/
    CSharpTypeHelper.cs         // Ecore->C# type mapping + nullability + collection rendering  (NEW logic)
    CSharpNameHelper.cs         // casing, reserved-word @-escaping, name==type collision        (NEW logic)
    NamespaceHelper.cs          // EPackage -> C# namespace                                       (NEW logic)
  Templates/
    core-enumeration-template.hbs
    core-poco-interface-template.hbs
    core-poco-class-template.hbs
```

(The XMI reader/writer generators — including the single `XmiElementReaderFacade`, §3 — are a related set of generators that emit into `Auriga.Xmi`; they belong to the reader work in #13 but the dispatch decision is recorded here.)

**Decision — reuse ECoreNetto's helper projects rather than create `Auriga.HandleBars`/`Auriga.Extensions`.** uml4net needed its own `uml4net.HandleBars`/`uml4net.Extensions` because nothing upstream understood UML. ECoreNetto already ships `ECoreNetto.Extensions` (multiplicity, containment, documentation, casing, package flattening, specialization queries) and `ECoreNetto.HandleBars` (the block helpers that call them). Auriga registers those, then adds only the C#-specific helpers above. This keeps Auriga.CodeGenerator small and avoids re-implementing the graph-query layer.

Generation flow (in `ObjectModelGenerator`, driven from `Auriga.CodeGenerator.Tests` — see §10, following uml4net which has no CLI and drives generation from NUnit):

1. **Load** the metamodel: one `ResourceSet`, load all 21 `.ecore` files, collect every root `EPackage`, flatten with `PackageExtensions.QueryPackages()` to the 24 packages. (This is exactly the load the #2 validation tests already exercise; the harness code is a working template.)
2. **Bucket** each package's `EClassifiers` into `EEnum`, `EClass` (abstract + concrete), following `HandleBarsReportGenerator.CreateHandlebarsPayload`. There are no custom `EDataType`s to handle (inventory §2), so the datatype bucket is asserted empty — **Verify in #7**.
3. **Emit**, in dependency-safe order (enums, then interfaces, then classes), one file per artifact, each passed through `CodeCleanup` before write.

## 3. Per-EClass generation pattern

**Decision — interface always, implementation class for concrete only; no per-class or per-package factory.** For a metaclass `PhysicalFunction` in package `pa`:

| Artifact | Emitted when | File → committed location | Namespace |
| --- | --- | --- | --- |
| `interface IPhysicalFunction` | always (abstract + concrete) | `AutoGenInterfaces/IPhysicalFunction.cs` | `Auriga.Pa` |
| `class PhysicalFunction` | only when **not** `Abstract` | `AutoGenClasses/PhysicalFunction.cs` | `Auriga.Pa` |
| `enum <Name>` | per `EEnum` | `AutoGenEnumeration/<Name>.cs` | `Auriga.Pa` |

The interface carries the contract and the type lattice; the class carries state. Object construction is plain `new PhysicalFunction()` — the concrete classes are directly instantiable. Type-name → instance dispatch for deserialization is handled by a single generated facade (below), not by factories.

**Decision — flatten the inheritance lattice onto concrete classes; keep true multiple inheritance only on interfaces.** The Capella metamodel uses pervasive multiple inheritance (e.g. `fa::AbstractFunction` has 6+ supertypes; `oa::Entity` is a `cs::Component`; see the [Arcadia notes §6](arcadia-notes.md)). C# has single class inheritance, so — exactly as uml4net does — :

- `interface IPhysicalFunction : IAbstractFunction, IExtensibleElement, …` lists **all direct** supertype interfaces (`EClass.ESuperTypes`), preserving the full lattice.
- `class PhysicalFunction : AurigaElement, IPhysicalFunction` derives from **one** hand-written base (`AurigaElement`, §9) and **re-declares every inherited feature**, obtained from `EClass.AllEStructuralFeatures` (the flattened own+supertypes set). `AllEStructuralFeatures` can contain duplicates across the hierarchy, so **de-duplicate by name** before emitting (ECoreNetto does not dedupe). Order by name for deterministic output.

This makes each concrete class self-contained (no C# base-class chain to walk) and sidesteps the diamond problem entirely, at the cost of member repetition — the same trade uml4net accepts.

**Decision — a single generated `XmiElementReaderFacade` dispatches type → instance, following uml4net; no factories.** The issue's original wording asked for a per-package `PaFactory` (the EMF Java convention), but on review we take the uml4net route instead: one generated dispatcher for the whole model, because a single lookup does everything a per-package factory would, without the ~20 extra factory classes and a registry to wire them together. uml4net's `XmiElementReaderFacade` (`uml4net.xmi/AutoGenXmiReaders/XmiElementReaderFacade.cs`) holds a `Dictionary<string, Func<…>>` keyed by the `xmi:type` string; each value is a lambda that builds the right per-class reader and returns the constructed element; `QueryXmiElement` reads the type attribute and dispatches, throwing on an unknown type. The per-class readers construct with plain `new Foo()`.

Auriga adopts the same single-facade shape with **one Capella-specific change to the key**. uml4net can key on the raw string `"uml:Class"` because UML XMI always uses the fixed `uml:` prefix. Capella's prefix is arbitrary per document (bound to an nsURI via `xmlns:`), and the same local name (e.g. `Component`) exists in several packages, so the facade must key on the **resolved** type — the pair `(nsURI, localName)` — after the reader resolves the element's prefix to its nsURI. Same dictionary-dispatch design, resolved key:

- The facade is keyed by `(nsURI, localName)` → a construction/reader delegate. `nsURI` comes from resolving the element's XML namespace; `localName` is the classifier name. Both are already in hand at the point the reader hits an element.
- An unknown `(nsURI, localName)` throws a clear "no reader for type" error — and, because abstract classes contribute no entry, an `xsi:type` naming an abstract class fails loudly rather than silently.
- The facade and the per-class readers are generated by the XMI reader generator (mirroring uml4net's `XmiReaderGenerator`) into `Auriga.Xmi`; this is coupled to the reader work (#13), but the dispatch decision belongs to the generation design and is recorded here.

Object construction stays plain `new Foo()`; the public "create a model in code" story is simply the instantiable concrete classes, exactly as in uml4net.

Every generated type is `partial` (see §9/§10). File/type naming: `CapitalizeFirstLetter(EClass.Name)` for classes/enums, `"I" + CapitalizeFirstLetter(Name)` for interfaces (`ECoreNetto.Extensions.StringExtensions.CapitalizeFirstLetter` is reused; it throws on empty names — every classifier in the Capella metamodel is named, but assert this).

## 4. Namespace mapping — one C# namespace per Ecore package

**Decision — `Auriga.<PascalCasePackagePath>`, derived purely from the Ecore object graph.** For each package, build the dotted path from the package-name chain (`EClassifier.EPackage` walked up via `ESuperPackage`, or `EPackageTree`), PascalCasing each segment:

| EPackage (ns prefix) | C# namespace |
| --- | --- |
| `modellingcore` | `Auriga.Modellingcore` |
| `capellacore` | `Auriga.Capellacore` |
| `pa` | `Auriga.Pa` |
| `pa.deployment` (sub-package) | `Auriga.Pa.Deployment` |
| `information` | `Auriga.Information` |
| `information.datavalue` (sub-package) | `Auriga.Information.Datavalue` |
| `Requirements` | `Auriga.Requirements` |
| `CapellaRequirements` | `Auriga.CapellaRequirements` |

Root package names are unique across the metamodel (inventory §2), so there are no collisions; sub-packages nest under their parent, matching the four nested EPackages (`pa.deployment`, `information.communication/datatype/datavalue`). This is self-contained (needs only the `.ecore` graph, not the `.genmodel` files) and mirrors uml4net's `uml4net.<Package.Name>` convention.

**Rejected alternative:** mirroring the EMF `.genmodel` `basePackage` values (`Auriga.Common.Data.Activity`, `Auriga.Core.Data.Pa.Deployment`, as the inventory §1 floated). It reads more like the Java packaging, but the `basePackage` lives in the `.genmodel` files, not the `.ecore` files the generator consumes — encoding it would mean a hand-maintained package→basePackage config table. Not worth the coupling; the flat form above is unambiguous. Revisit only if a downstream consumer needs the common/core split.

## 5. Feature mapping

The rules below drive both the interface property signature and the class property. They are computed from ECoreNetto members; **`ETypedElement.Many` and `.Required` are unreliable** (EMF does not serialize the derived `many=`/`required=` attributes, so they read `false` regardless) — always derive from bounds, as `ECoreNetto.Extensions` itself does.

| Feature shape | Detection (ECoreNetto) | C# rendering |
| --- | --- | --- |
| **collection** | `UpperBound == -1 \|\| UpperBound > 1` (`StructuralFeatureExtensions.QueryIsEnumerable`) | see below |
| **required scalar** | `LowerBound >= 1` && not collection | `T` (non-null) |
| **optional scalar** | `LowerBound == 0` && not collection (`QueryIsNullable`) | value type → `T?`; `string`/reference → `T` |
| **containment reference** | `EReference.IsContainment` | scalar → `IFoo`; multi → `IContainerList<IFoo>` (owning) |
| **cross-reference** | `EReference` && !`IsContainment` | scalar → `IFoo`; multi → `List<IFoo>` |
| **attribute, primitive** | `EAttribute`, `EType` is a built-in `EDataType` | mapped C# type (§6) |
| **attribute, enum** | `EAttribute`, `EType is EEnum` (`QueryIsEnum`) | the generated `enum` type |

Collections are never null (initialized: `List<T>` → `= new()`; `IContainerList<T>` → owner-aware backing, §9). Scalars keep `Ordered`/`Unique` only as metadata; C# does not model them structurally.

**Containment vs cross-reference matters twice:** it selects the collection type here, and it tells the reader/writer (#13) whether the target is written inline (containment) or as an `href` (cross-reference). The generator records containment on the property (via the collection type and, if useful, an attribute) so the XMI layer can branch without re-querying the metamodel.

**Derived / volatile / transient features** — the crux for Capella. Per the [Arcadia notes](arcadia-notes.md), essentially all traceability/convenience features (`realizedFunctions`, `allocatedFunctions`, `system`, the `containedX` aliases, …) are `derived volatile transient` and are **not present in `.melodymodeller` XMI**. They are also exactly the cyclic references that make per-file generation impossible (inventory §3).

**Decision — emit derived features as get-only computed properties delegating to a hand-written partial method, and skip them in serialization.** Detected via `EStructuralFeature.Derived` (also treat `Volatile`/`Transient` the same for storage purposes):

```csharp
// in interface: get-only
IEnumerable<IAbstractFunction> RealizedFunctions { get; }
// in class: expression-bodied, delegates to a hand-written partial
public IEnumerable<IAbstractFunction> RealizedFunctions => this.QueryRealizedFunctions();
```

`QueryRealizedFunctions()` is authored by hand in the `Extend/` partial (§9/§10). The XMI reader and writer skip any feature where `Derived || Transient || Volatile`, which both matches the on-disk reality and breaks the reference cycles. Non-derived, non-changeable (`Changeable == false`) features become `{ get; }` without a computed body only if they still carry stored state — **Verify in #7** whether Capella has any read-only-but-stored features (expected: none; derived covers them).

**Redefinition / subsetting.** Ecore expresses these far more weakly than UML (no first-class `redefines`/`subsets` on `EReference`; at most EAnnotations). uml4net's elaborate `[RedefinedProperty]`/`[SubsettedProperty]`/explicit-interface-throw machinery is **not ported** in v1. If a Capella feature name collides with an inherited feature of the same name during the `AllEStructuralFeatures` dedupe, keep the most-derived declaration and drop the ancestor (record the drop in a generation log). **Verify in #7** that dedupe-by-name is sufficient across the real hierarchy (e.g. the `ownedX`/`containedX` alias pairs).

## 6. Ecore → C# type mapping

ECoreNetto ships **no** primitive-type table — `feature.EType.Name` yields the Ecore datatype name string (`"EString"`, `"EInt"`, `"EBoolean"`, …) and that is all. This table is new code Auriga owns (`CSharpTypeHelper`), applied when an attribute's `EType` is a built-in `EDataType` (not an `EEnum`, not an `EClass`):

| Ecore datatype | C# type | | Ecore datatype | C# type |
| --- | --- | --- | --- | --- |
| `EString` | `string` | | `EBoolean` / `EBooleanObject` | `bool` |
| `EInt` / `EIntegerObject` | `int` | | `ELong` / `ELongObject` | `long` |
| `EShort` / `EShortObject` | `short` | | `EByte` / `EByteObject` | `sbyte` |
| `EFloat` / `EFloatObject` | `float` | | `EDouble` / `EDoubleObject` | `double` |
| `EBigDecimal` | `decimal` | | `EBigInteger` | `System.Numerics.BigInteger` |
| `EChar` / `ECharacterObject` | `char` | | `EByteArray` | `byte[]` |
| `EDate` | `System.DateTime` | | `EJavaObject` | `object` |
| `EBooleanObject` etc. (the `*Object` boxed forms) | nullable applies via §5 bounds, not the table | | `EJavaClass` | `System.Type` |

Optionality is applied on top by §5 (a `LowerBound==0` `EInt` becomes `int?`), so the table maps to the non-null base type. **Capella uses only a small subset** — the inventory found only Ecore primitives and enums, in practice `EString`, `EBoolean`, `EInt` dominate — but the full table is cheap and future-proofs against customer DSLs. The mapping is a `Dictionary` seeded with the above and **overridable** (mirroring uml4net's `AddOrOverwriteCSharpTypeMappings`) so a later metamodel can extend it. An unmapped datatype name is a hard generation error (fail loud, do not pass the raw Ecore name through).

## 7. Documentation → XML doc comments

Capella carries rich documentation in `EAnnotation`s (the inventory/Arcadia work found `http://www.polarsys.org/kitalpha/ecore/documentation` as a top annotation source, plus HTML-laden descriptions). Reuse `ECoreNetto.Extensions.ModelElementExtensions.QueryDocumentation()`, which pulls the `documentation` detail key out of an element's `EAnnotations`, strips `<p>/<code>/<em>/<tt>` via HtmlAgilityPack, and rewraps to ~100-char lines — precisely what a `/// <summary>` needs. The template emits:

```csharp
/// <summary>
/// <one line per wrapped documentation line>
/// </summary>
```

on every interface, class, enum, enum literal, and property, via a documentation block helper (reuse `ECoreNetto.HandleBars`' `RawDocumentation`/documentation helper, adapted to emit `///` lines instead of HTML). **Verify in #7** that `QueryDocumentation` actually resolves Capella's kitalpha documentation annotations (ECoreNetto reads the `documentation` key regardless of annotation source, so it should — but confirm against a real class like `pa::PhysicalComponent`, and fall back to a "No documentation" summary when empty rather than emitting an empty `<summary>`).

## 8. Naming, reserved words, nullability, casing

- **Casing:** interface `I` + `CapitalizeFirstLetter(Name)`; class/enum/file `CapitalizeFirstLetter(Name)`; enum literals capitalized. Reuse `ECoreNetto.Extensions.StringExtensions`.
- **Enum literal round-trip:** `EEnumLiteral.Literal` (serialized form) can differ from `Name`. Generate the C# member from the capitalized `Name`, and preserve the original `Literal` (e.g. an `[System.Runtime.Serialization.EnumMember(Value = "…")]` attribute or a generated name↔literal lookup) so the XMI layer (#13) round-trips values that don't match the C# identifier. **Verify in #7** which Capella enums have divergent literals.
- **Reserved words:** replace uml4net's ad-hoc six-word switch with a **complete** C# keyword set; any member (or type) name colliding with a keyword is `@`-escaped. Capella will hit this (e.g. a feature named `abstract`/`object`/`event` is plausible) — **Verify in #7** by scanning feature names against the keyword list.
- **Member name == enclosing type name** (illegal in C#): if the offending feature is a collection, pluralize (`+ "s"`); if scalar, suffix a disambiguator (e.g. `+ "Value"`) rather than uml4net's `throw`. Log every rename.
- **Nullability:** the project is nullable-enabled (solution-wide `<Nullable>enable</Nullable>`). Optional value-typed scalars → `T?`; optional references/strings stay `T` (reference-nullable is not annotated in v1 to avoid churn); collections are non-null and initialized. **Decision:** keep nullable *enabled* (unlike uml4net which disables it) and render value-type optionality explicitly, because the generated model is new code and should be null-correct from the start.

## 9. The hand-written runtime

Generation is only useful on top of a small hand-authored runtime in the `Auriga` project (analogous to uml4net's `XmiElement` and EMF's `EObjectImpl`). These are written once, by hand, not generated:

- **`AurigaElement`** (base of every generated concrete class): identity (`Id`/`xmi:id`), a container back-pointer, and the plumbing the object graph needs. Every `class Foo : AurigaElement, IFoo`.
- **`IContainerList<T>` / `ContainerList<T>`**: an owner-aware collection for containment references that sets the child's container on add/remove (the equivalent of EMF's containment `EList`). Non-containment multi-valued features use plain `List<T>`.
- **`IAurigaElement`** (or reuse the generated `modellingcore::ModelElement` interface as the common root) — decide whether the hand-written base implements a marker interface or the generated `IModelElement`. **Decision:** `AurigaElement` implements a minimal hand-written `IAurigaElement` marker (Id + container); the generated `modellingcore::ModelElement` interface extends it. This keeps the runtime independent of generated code while giving every element the identity contract.
- **Hand-written `Extend/` partials**: the bodies of derived features (`QueryRealizedFunctions()` etc.). These live beside — but separate from — the generated `AutoGen*` files, in the same `partial` type.

There is no factory runtime — object construction is `new Foo()`, and deserialization dispatch is the generated `XmiElementReaderFacade` (§3), which lives in `Auriga.Xmi`, not the object-model runtime.

## 10. Committed-generated-code workflow

**Decision — commit the generated code into the `Auriga` project and gate it with golden-file tests, exactly as uml4net does.**

- **Output location** (committed to git, in the `Auriga` library):
  ```
  Auriga/AutoGenInterfaces/    I*.cs
  Auriga/AutoGenClasses/       <concrete>.cs
  Auriga/AutoGenEnumeration/   <enum>.cs
  Auriga/Extend/               hand-written partials (derived bodies, behavior)
  ```
  (The generated `XmiElementReaderFacade` and per-class readers/writers land in `Auriga.Xmi` — see #13 — not here.)
- **Every generated file** starts with the Starion SPDX copyright header (emitted from the top of each `.hbs` template, `file="{{Name}}.cs"` interpolated — matching CONTRIBUTING) and an auto-generated banner, and every generated type carries `[GeneratedCode("Auriga.CodeGenerator", "<version>")]`. Files are plain `.cs` segregated by `AutoGen*` folder (no `.g.cs`).
- **All generated types are `partial`.** Structure + auto-properties + attributes are generated; derived-property bodies and any behavior live in hand-written `partial`s under `Extend/`. Regeneration never touches `Extend/`.
- **Determinism:** order everything by name (`OrderBy(x => x.Name)`), dedupe flattened features by name, and run every file through Roslyn `CodeCleanup` (`CSharpSyntaxTree.ParseText` + `Formatter.Format` over an `AdhocWorkspace`) so output is byte-stable and templates can be whitespace-sloppy.
- **Regeneration is test-driven** (no CLI, matching uml4net):
  - *Golden-file verification tests* in `Auriga.CodeGenerator.Tests` generate into a throwaway temp dir and assert string-equality against the committed `AutoGen*` files. This is the CI gate: any drift between the templates and the committed output fails the build. (The vendored `.ecore` files are already copied to the test output by the `Auriga.CodeGenerator.Tests.csproj` `Data/ecore` item added in #5.)
  - One `[Explicit("Regenerates production code")]` test walks up to the solution root and writes the `AutoGen*` folders in place. A developer runs it after changing a template, reviews the diff, and commits. CI never runs the explicit test.
- **Input** is `resources/ecore` (the 21 vendored files), loaded exactly as the #2 validation tests do.

## 11. Open items to confirm during implementation (#7)

1. No custom `EDataType`s exist (assert the datatype bucket is empty).
2. `QueryDocumentation` resolves Capella's kitalpha documentation annotations on a real class; empty-doc fallback wording.
3. Dedupe-by-name is sufficient for the flattened `AllEStructuralFeatures` (the `ownedX`/`containedX` alias pairs, redefinition-like collisions).
4. Which enums have `Literal != Name` (round-trip mapping needed).
5. Feature/type names colliding with C# keywords or with their enclosing type (escaping/rename rules exercised).
6. Whether any feature is `Changeable == false` yet stored (expected none — derived covers it).
7. The exact shape of `AurigaElement`/`IContainerList<T>` (the runtime is hand-written and small, but its API is load-bearing for the generated code) and the `(nsURI, localName)` key the `XmiElementReaderFacade` dispatches on (load-bearing for the reader in #13).

## 12. Pointers

- [Metamodel inventory](metamodel-inventory.md) (#1) — packages, counts, dependency cycles, the "generate from the whole resolved graph, never file-by-file" conclusion
- [Arcadia notes](arcadia-notes.md) (#3) — why derived features are transient/volatile and must be skipped in serialization; the multiple-inheritance and containment realities the generator must handle
- [ECoreNetto validation](ecorenetto-validation.md) (#2) — the load that the generator's front-end reuses
- Reference: uml4net.CodeGenerator (`Generators/`, `Templates/`, `Transformers/`) and its committed `uml4net/AutoGen*` output; ECoreNetto.Reporting (`HandleBarsReportGenerator`, `HtmlReportGenerator`) as the closest working ECoreNetto+HandleBars emitter
