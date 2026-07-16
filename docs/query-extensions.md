# Query Extension Methods (`Auriga.Extensions`)

`Auriga.Extensions` provides LINQ-style extension methods that make the loaded Capella object graph feel
like first-class C#, following the `uml4net.Extensions` pattern. They query functions, components,
ports, exchanges, and the allocation and realization links between the Arcadia layers.

The methods build only on the **containment graph** — each element's `Container` back-pointer and its
`QueryContainedElements()` / `QueryAllContainedElements()` (issue #15) — and on the reference endpoints
the reader actually resolves (`SourceElement` / `TargetElement` on the trace-based links, `Source` /
`Target` on a functional exchange). They deliberately avoid the metamodel's *derived* convenience
accessors (for example `ComponentFunctionalAllocation.Function` or `Component.AllocatedFunctions`), which
the code generator emits as `null`/empty stubs.

## Catalogue

### On `IAurigaElement` — `AurigaElementExtensions`

| Method | Returns |
|---|---|
| `QueryAncestors()` | the containing elements, nearest first, up to the root |
| `QueryRoot()` | the containment root (the `capellamodeller::Project` for a full model) |
| `IsContainedIn(ancestor)` | whether the element is contained, directly or transitively, by `ancestor` |
| `QueryAllFunctions()` | every `Fa.IAbstractFunction` in the element's subtree |
| `QueryAllComponents()` | every `Cs.IComponent` in the element's subtree |

### On `Fa.IAbstractFunction` — `AbstractFunctionExtensions`

| Method | Returns |
|---|---|
| `QueryFunctionPorts()` | the function's input and output ports |
| `QueryAllocatingBlocks()` | the blocks/components the function is allocated to |
| `IsAllocatedTo(block)` | whether the function is allocated to `block` |
| `QueryRealizedFunctions()` | the functions this function realizes (higher-layer) |
| `QueryRealizingFunctions()` | the functions that realize this function (lower-layer) |

### On `Fa.IAbstractFunctionalBlock` — `AbstractFunctionalBlockExtensions`

| Method | Returns |
|---|---|
| `QueryAllocatedFunctions()` | the functions allocated to the block (a component is a block) |

### On `Cs.IComponent` — `ComponentExtensions`

| Method | Returns |
|---|---|
| `QueryComponentPorts()` | the component's ports |
| `QueryRealizedComponents()` | the components this component realizes (higher-layer) |
| `QueryRealizingComponents()` | the components that realize this component (lower-layer) |

### On `Fa.IFunctionalExchange` — `FunctionalExchangeExtensions`

| Method | Returns |
|---|---|
| `QuerySourceFunction()` | the function owning the exchange's source port, or `null` |
| `QueryTargetFunction()` | the function owning the exchange's target port, or `null` |

## Example

```csharp
using Auriga.Extensions;
using Auriga.Xmi;

var project = CapellaProject.Load("coffee-machine-demo.capella");

// every function of the System Analysis layer
var functions = project.SystemAnalysis!.QueryAllFunctions();

// the functions a component is responsible for, and the inverse
foreach (var component in project.SystemAnalysis!.QueryAllComponents())
{
    foreach (var function in component.QueryAllocatedFunctions())
    {
        // function.IsAllocatedTo(component) == true
        // function.QueryAllocatingBlocks() contains component
    }
}

// trace a functional exchange back to the functions it connects
foreach (var exchange in project.Project!.QueryAllContainedElements().OfType<Auriga.Model.Fa.IFunctionalExchange>())
{
    var from = exchange.QuerySourceFunction();
    var to = exchange.QueryTargetFunction();
}
```
