# Test Fixtures

**Issue:** [#4](https://github.com/STARIONGROUP/Auriga/issues/4)

Capella model fixtures for reader, writer, and round-trip tests. Layout follows the EcoreNetto/uml4net `TestData` convention: one directory per fixture, each with its license text and the provenance recorded here.

Each obtained fixture is committed as the **complete Capella project set**: semantic files (`.capella`/`.melodymodeller`, `.capellafragment`), the `.aird`/`.airdfragment` representation files, the `.afm`/`.project` sidecars, and any referenced image resources. Parsing `.aird` is out of v1 scope, but the diagram files are kept so the fixtures open unmodified in the Capella tool and so writer tests can verify that sibling files are preserved untouched. Note that the Level Crossing Traffic Control `.aird` is ~37 MB and the In-Flight Entertainment System `.aird` ~20 MB.

| Fixture | Capella version | License | Purpose |
| --- | --- | --- | --- |
| [`minimal/`](minimal) | 7.0.0 nsURIs | Apache-2.0 (this repo) | First reader target: smallest well-formed model |
| [`coffee-machine/`](coffee-machine) | **6.0.0** | Apache-2.0 | py-capellambse demo model; the different-version fixture — reads via version-tolerant resolution, read-only in v1 (out of round-trip scope) |
| [`in-flight-entertainment-system/`](in-flight-entertainment-system) | 7.0.0 nsURIs (saved by 7.1.0) | EPL-2.0 | Official Capella sample; large realistic model, all five Arcadia layers |
| [`fragmented-sysmodel/`](fragmented-sysmodel) | 7.0.0 nsURIs (saved by 7.1.0) | EPL-2.0 | Model split across four `.capellafragment` files; exercises cross-fragment `href` resolution |
| [`Crowd_Surveillance_System_in_DARC/`](Crowd_Surveillance_System_in_DARC) | 7.0.0 nsURIs | EPL-2.0 | Official Capella sample; uses the **Cybersecurity** add-on viewpoint (out of v1 metamodel scope — the round-trip suite skips it) |
| [`Level Crossing Traffic Control/`](Level%20Crossing%20Traffic%20Control) | 7.0.0 nsURIs | EPL-2.0 | Official Capella sample; large model (~1.5 MB semantic, ~37 MB `.aird`) |

## minimal/

`minimal.melodymodeller` — hand-crafted for this repository (Apache-2.0, see the repo [LICENSE](../LICENSE)). A single-file project containing only a Physical Architecture, authored against the serialization idioms of the official 7.x samples:

- `Project → SystemEngineering → PhysicalArchitecture` root chain
- `PhysicalFunctionPkg` with the root-function convention (`Root Physical Function` + two leaf functions), `FunctionInputPort`/`FunctionOutputPort`, and a `FunctionalExchange` owned by the common ancestor function
- `PhysicalComponentPkg` with the root-component convention (one non-actor `PhysicalComponent` + its `Part` as siblings), NODE and BEHAVIOR components, the Component/Part duality (`ownedFeatures` Parts with `abstractType` back-references), `ComponentFunctionalAllocation` of both leaf functions onto the BEHAVIOR component, a `PartDeploymentLink` (nested `pa.deployment` namespace) deploying the software part onto the node part, and a `PhysicalLink` with a multi-valued `linkEnds` attribute between two `PhysicalPort`s
- Deliberately uses the legacy `.melodymodeller` extension (the samples use `.capella`) so both extensions are covered
- Semantic file only — as a hand-crafted fixture it has no `.aird`; a diagram-less model is itself a case the reader must accept

## coffee-machine/

From [DSD-DBS/coffee-machine](https://github.com/DSD-DBS/coffee-machine) (commit `db45166`), the demo model of [py-capellambse](https://github.com/dbinfrago/py-capellambse). Copyright DB Netz AG and contributors, Apache-2.0 ([LICENSE-Apache-2.0.txt](coffee-machine/LICENSE-Apache-2.0.txt)); the `*.license` files are the upstream REUSE sidecars. **Saved by Capella 6.0.0** — its nsURIs are `6.0.0`. The v1 reader is version-tolerant (it resolves packages by a version-stripped namespace match), so this model still **reads** into a fully resolved graph. It is nonetheless **read-only in v1** and excluded from the round-trip suite, because the writer always emits `7.0.0` namespaces — a round-trip would silently migrate the version. It is the different-version fixture; see [`docs/validation.md`](../docs/validation.md).

## in-flight-entertainment-system/

The official Capella sample project, from [eclipse-capella/capella](https://github.com/eclipse-capella/capella) `samples/In-Flight Entertainment System` (commit `3153b93`). EPL-2.0 ([LICENSE-EPL-2.0.md](in-flight-entertainment-system/LICENSE-EPL-2.0.md)). ~1.5 MB semantic model covering all five Arcadia layers, REC/RPL catalogs, state machines, functional chains, and rich HTML descriptions — the main realistic-scale reader/round-trip fixture. Includes the ~20 MB `.aird` and the `images/` folder referenced from element descriptions. The other official sample mentioned in the issue (System of Systems) is not in the capella git repository (it ships with product downloads); it can be added later if needed.

## fragmented-sysmodel/

`FragmentTestModel` from the Capella test suite, [eclipse-capella/capella](https://github.com/eclipse-capella/capella) `tests/plugins/org.polarsys.capella.test.fragmentation/model/FragmentTestModel` (commit `3153b93`). EPL-2.0 ([LICENSE-EPL-2.0.md](fragmented-sysmodel/LICENSE-EPL-2.0.md)). A `sysmodel.capella` root plus four semantic fragments under `fragments/`, referenced via relative hrefs such as:

```
href="fragments/SA-Data.capellafragment#fb7840a4-2ac6-46f2-9547-a3368dd320a0"
href="fragments/LA-Logical%20Functions-RLF-OA2-SysOA2_1.capellafragment#dc08ee20-..."
```

Note the **URL-encoded space (`%20`)** in the fragment file names — the reader's href resolution must URL-decode. The `sysmodel.aird`, the four `.airdfragment` files, and the `ressources/` icons (EPL-2.0, see `ressources/license.txt`) are included, so the fixture is the complete fragmented project as used by the Capella fragmentation test suite.

## Crowd_Surveillance_System_in_DARC/

The official Capella "Crowd Surveillance System in DARC" sample, downloaded from the Capella 7.0.0 sample models at <https://download.eclipse.org/capella/samples/7.0.0/> (`Crowd_Surveillance_System_in_DARC.zip`). EPL-2.0 ([LICENSE-EPL-2.0.md](Crowd_Surveillance_System_in_DARC/LICENSE-EPL-2.0.md)). ~0.5 MB semantic model that exercises Physical Architecture deployment (`PartDeploymentLink`s deploying software parts onto node parts). Includes the ~7.7 MB `.aird` and the `img/` folder referenced from element descriptions. The model also uses the **Cybersecurity** add-on viewpoint (`cybersecurity:CybersecurityConfiguration`), which is not part of the metamodel the v1 reader vendors (core Capella + Requirements VP + Kitalpha); the reader rejects it with a clear "unknown Capella package" error, so the round-trip regression suite skips this fixture — it is retained as the "unsupported add-on viewpoint" case (the counterpart to the version-unsupported coffee-machine).

## Level Crossing Traffic Control/

The official Capella "Level Crossing Traffic Control" sample, downloaded from the Capella 7.0.0 sample models at <https://download.eclipse.org/capella/samples/7.0.0/> (`LevelCrossingTrafficControl.zip`; the French `LevelCrossingTrafficControl_fr` variant was not added). EPL-2.0 ([LICENSE-EPL-2.0.md](Level%20Crossing%20Traffic%20Control/LICENSE-EPL-2.0.md)). ~1.5 MB semantic model across the Arcadia layers, with the ~37 MB `.aird` — the largest fixture in this repository.
