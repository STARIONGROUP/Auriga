# ContainerList: containment collection design

**Issue:** [#32](https://github.com/STARIONGROUP/Auriga/issues/32)

`Auriga.ContainerList<T>` ([`Auriga/ContainerList.cs`](../Auriga/ContainerList.cs)) is the owner-aware
collection behind every **containment** feature of the generated object model. Adding an element sets its
`IAurigaElement.Container` to the list's `Owner`; removing it clears that back-reference again — the
analogue of an EMF containment `EList`. (Non-containment cross-reference features use a plain `List<T>`.)

This note records why `ContainerList<T>` is built the way it is, and the containment-ownership rule it
enforces.

## Why `Collection<T>`, not `List<T>` + `new`

The sibling libraries solve the same problem three ways:

| Aspect | uml4net | SysML2.NET | Auriga |
| --- | --- | --- | --- |
| Base type | `List<T>` | `Collection<T>` | `Collection<T>` |
| Interception | `new`-hidden methods | overrides `InsertItem`/`RemoveItem` | overrides `InsertItem`/`SetItem`/`RemoveItem`/`ClearItems` |
| Bypassable via `IList<T>`/`ICollection<T>`/base reference? | **Yes** | No | No |
| All four mutation paths (insert/set/remove/clear) maintain the back-pointer? | No | **No** (`SetItem`/`ClearItems` not overridden) | **Yes** |
| Already-owned element | steals (re-points `Container`) | rejects if owned by a *different* owner | rejects if owned by *any* other container |

The uml4net design extends `List<T>` and hides the mutating members with `new`. Method hiding is resolved
by the **static** type of the reference, so the container-maintaining logic is silently skipped whenever the
list is touched through a base or interface reference — `((IList<T>)list).Add(x)`, `((ICollection<T>)list).Clear()`,
a `List<T>` reference, or a collection initializer all call the *base* method and never set (or reset)
`x.Container`. Inherited mutators that were not re-hidden (`Insert`, `InsertRange`, `RemoveRange`, `RemoveAll`)
bypass it too.

Extending `System.Collections.ObjectModel.Collection<T>` and overriding its **protected virtuals** fixes
this structurally: every public mutation — `Add`, `Insert`, the indexer set, `Remove`, `RemoveAt`, `Clear`,
`AddRange`, and the non-generic `IList` members — funnels through the same four hooks, so container
maintenance **cannot be bypassed** by the reference type. SysML2.NET pioneered this but overrides only
`InsertItem` and `RemoveItem`, leaving the indexer set (`SetItem`) and `Clear` (`ClearItems`) unmaintained;
Auriga overrides **all four**, closing those two gaps.

## Ownership-transfer semantics: exclusive (reject, not steal)

Containment is a single-parent relationship — in EMF an object has exactly one container. Three policies are
possible when an element that already has a container is added somewhere else:

- **Steal** — re-point `Container` unconditionally. Cheap, but leaves the element in *two* lists with a
  container pointing at only one: a silent inconsistency.
- **EMF move** — remove the element from its previous containment list first, then add it. The most
  convenient, but a `ContainerList<T>` cannot implement it: an element knows its owning *element*
  (`Container`) but not the specific list instance holding it, so it cannot remove itself from there.
- **Reject** — refuse the add and require the caller to remove the element from its current container first.
  Deterministic, and keeps containment provably exclusive.

**Auriga chooses reject.** `InsertItem` and `SetItem` throw an `InvalidOperationException` when the incoming
element already has a non-`null` `Container` (other than the element already occupying the target index on a
self-`SetItem`). This is SysML2.NET's "reject when already owned" choice, tightened from *different owner* to
*any other container* so that adding an element to a second containment feature of the **same** owner is
rejected as well.

To move an element between containers, remove it from its current container, then add it to the new one:

```csharp
oldParent.OwnedThings.Remove(element);   // element.Container -> null
newParent.OwnedThings.Add(element);      // element.Container -> newParent
```

The guards enforced on the insert/set paths, all raising `InvalidOperationException` (except the `null`
check, which raises `ArgumentNullException`):

- the element is not `null`;
- the element is not the `Owner` itself (no self-containment);
- the element is not already in this list (no duplicate);
- the element does not already belong to another container (exclusive ownership).

The copy-constructor (`new ContainerList<T>(source, owner, updateContaineeContainer)`) is the one path that
does not run these hooks — it seeds the base collection directly and, only when asked, re-parents the copied
elements — so copying a list does not disturb the originals unless `updateContaineeContainer` is set.
