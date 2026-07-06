// -------------------------------------------------------------------------------------------------
// Validation harness for GitHub issue #2: prove that ECoreNetto correctly loads the complete
// Capella v1-scope metamodel (resources/ecore) with fully resolved cross-file references.
// Exit code 0 = all checks pass, 1 = at least one check failed.
// -------------------------------------------------------------------------------------------------

using System.Text.RegularExpressions;

using ECoreNetto;
using ECoreNetto.Resource;

using Microsoft.Extensions.Logging;

var trace = args.Contains("--trace");
var ecoreDirectory = args.FirstOrDefault(a => !a.StartsWith("--")) ?? Path.Combine("..", "..", "resources", "ecore");
ecoreDirectory = Path.GetFullPath(ecoreDirectory);

if (!Directory.Exists(ecoreDirectory))
{
    Console.Error.WriteLine($"ecore directory not found: {ecoreDirectory}");
    Console.Error.WriteLine("usage: EcoreValidation [path-to-resources/ecore] [--trace]");
    return 1;
}

var ecoreFiles = Directory.GetFiles(ecoreDirectory, "*.ecore").OrderBy(f => f).ToList();
Console.WriteLine($"validating {ecoreFiles.Count} .ecore files in {ecoreDirectory}");
Console.WriteLine();

var failures = new List<string>();

// ---------------------------------------------------------------------------------------------
// check 1: every file loads through a single ResourceSet without errors
// ---------------------------------------------------------------------------------------------
using var loggerFactory = trace
    ? LoggerFactory.Create(builder => builder.AddSimpleConsole().SetMinimumLevel(LogLevel.Trace))
    : null;

var resourceSet = new ResourceSet(loggerFactory);
var rootPackages = new Dictionary<string, EPackage>();

foreach (var file in ecoreFiles)
{
    var name = Path.GetFileName(file);
    try
    {
        // demand-loading may already have pulled this file in as a dependency of an earlier one;
        // creating a second resource with the same URI corrupts the resource set. For already-loaded
        // resources Contents stays empty (ECoreNetto quirk), so the root package is fetched from the
        // resolution cache via its identifier "<rootPackageName>.ecore#/".
        var uri = new Uri(file);
        var resource = resourceSet.Resources.SingleOrDefault(x => x.URI == uri) ?? resourceSet.CreateResource(uri);
        var root = resource.IsLoaded()
            ? resource.Contents.OfType<EPackage>().FirstOrDefault()
              ?? resource.GetEObject($"{Path.GetFileNameWithoutExtension(file)}.ecore#/") as EPackage
            : resource.Load(null);

        if (root == null)
        {
            failures.Add($"[load] {name}: loaded but the root EPackage could not be retrieved");
            continue;
        }

        rootPackages[name] = root;

        foreach (var error in resource.Errors)
        {
            failures.Add($"[load] {name}: {error}");
        }
    }
    catch (Exception ex)
    {
        var frame = ex.StackTrace?.Split('\n').FirstOrDefault()?.Trim();
        failures.Add($"[load] {name}: {ex.GetType().Name}: {ex.Message} @ {frame}");
        if (trace)
        {
            Console.Error.WriteLine(ex.StackTrace);
        }
    }
}

Console.WriteLine($"check 1 - load: {rootPackages.Count}/{ecoreFiles.Count} files loaded");

// ---------------------------------------------------------------------------------------------
// check 2: classifier counts per package match the metamodel inventory (docs/metamodel-inventory.md)
// ---------------------------------------------------------------------------------------------
var expectedCounts = new Dictionary<string, (int Classes, int Enums)>
{
    ["emde"] = (3, 0),
    ["modellingcore"] = (17, 2),
    ["activity"] = (23, 2),
    ["behavior"] = (7, 0),
    ["libraries"] = (4, 1),
    ["re"] = (11, 1),
    ["capellacore"] = (41, 1),
    ["capellacommon"] = (29, 3),
    ["capellamodeller"] = (6, 0),
    ["cs"] = (35, 0),
    ["ctx"] = (15, 0),
    ["oa"] = (28, 0),
    ["la"] = (10, 0),
    ["pa"] = (9, 2),
    ["pa.deployment"] = (9, 0),
    ["epbs"] = (6, 1),
    ["fa"] = (40, 6),
    ["information"] = (29, 8),
    ["information.communication"] = (9, 2),
    ["information.datatype"] = (6, 1),
    ["information.datavalue"] = (22, 2),
    ["interaction"] = (38, 3),
    ["sharedmodel"] = (2, 0),
    ["Requirements"] = (26, 0),
    ["CapellaRequirements"] = (5, 0),
};

static IEnumerable<EPackage> AllPackages(EPackage package)
{
    yield return package;
    foreach (var sub in package.ESubPackages)
    {
        foreach (var nested in AllPackages(sub))
        {
            yield return nested;
        }
    }
}

static string QualifiedName(EPackage package)
{
    var parts = new List<string>();
    var current = package;
    while (current != null)
    {
        parts.Insert(0, current.Name ?? "?");
        current = current.ESuperPackage;
    }

    return string.Join(".", parts);
}

var allPackages = rootPackages.Values.SelectMany(AllPackages).ToList();
var allClasses = allPackages.SelectMany(p => p.EClassifiers.OfType<EClass>()).ToList();

foreach (var package in allPackages)
{
    var qualifiedName = QualifiedName(package);
    var classes = package.EClassifiers.OfType<EClass>().Count();
    var enums = package.EClassifiers.OfType<EEnum>().Count();
    var dataTypes = package.EClassifiers.OfType<EDataType>().Count() - enums;

    if (!expectedCounts.TryGetValue(qualifiedName, out var expected))
    {
        failures.Add($"[counts] unexpected package: {qualifiedName}");
        continue;
    }

    if (classes != expected.Classes || enums != expected.Enums || dataTypes != 0)
    {
        failures.Add($"[counts] {qualifiedName}: expected {expected.Classes} classes/{expected.Enums} enums, got {classes}/{enums} (+{dataTypes} datatypes)");
    }
}

foreach (var missing in expectedCounts.Keys.Except(allPackages.Select(QualifiedName)))
{
    failures.Add($"[counts] package not found: {missing}");
}

Console.WriteLine($"check 2 - counts: {allPackages.Count} packages, {allClasses.Count} classes, {allPackages.SelectMany(p => p.EClassifiers.OfType<EEnum>()).Count()} enums");

// ---------------------------------------------------------------------------------------------
// check 3: every supertype and every structural-feature/operation type resolves (no null ETypes)
// ---------------------------------------------------------------------------------------------
var nullSuperTypes = 0;
var nullFeatureTypes = 0;

foreach (var eClass in allClasses)
{
    for (var i = 0; i < eClass.ESuperTypes.Count; i++)
    {
        if (eClass.ESuperTypes[i] == null)
        {
            nullSuperTypes++;
            failures.Add($"[resolve] {QualifiedName(eClass.EPackage)}::{eClass.Name}: unresolved supertype at index {i}");
        }
    }

    foreach (var feature in eClass.EStructuralFeatures)
    {
        if (feature.EType == null)
        {
            nullFeatureTypes++;
            failures.Add($"[resolve] {QualifiedName(eClass.EPackage)}::{eClass.Name}.{feature.Name}: unresolved feature type");
        }
    }
}

var totalFeatures = allClasses.Sum(c => c.EStructuralFeatures.Count);
var totalSuperTypes = allClasses.Sum(c => c.ESuperTypes.Count);
Console.WriteLine($"check 3 - resolution: {totalSuperTypes} supertype refs ({nullSuperTypes} unresolved), {totalFeatures} features ({nullFeatureTypes} unresolved types)");

// ---------------------------------------------------------------------------------------------
// check 4: cross-package inheritance chains reach emde::ExtensibleElement
// ---------------------------------------------------------------------------------------------
static IEnumerable<EClass> AllSuperTypes(EClass eClass)
{
    var seen = new HashSet<EClass>();
    var queue = new Queue<EClass>(eClass.ESuperTypes.Where(s => s != null));
    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        if (!seen.Add(current))
        {
            continue;
        }

        yield return current;

        foreach (var super in current.ESuperTypes.Where(s => s != null))
        {
            queue.Enqueue(super);
        }
    }
}

var inheritanceProbes = new (string Package, string Class, string ExpectedAncestorPackage, string ExpectedAncestor)[]
{
    ("pa", "PhysicalFunction", "fa", "AbstractFunction"),
    ("pa", "PhysicalComponent", "cs", "Component"),
    ("la", "LogicalComponent", "modellingcore", "ModelElement"),
    ("ctx", "SystemFunction", "emde", "ExtensibleElement"),
    ("oa", "OperationalActivity", "emde", "ExtensibleElement"),
    ("epbs", "ConfigurationItem", "emde", "ExtensibleElement"),
    ("CapellaRequirements", "CapellaTypesFolder", "emde", "ExtensibleElement"),
    ("interaction", "Scenario", "emde", "ExtensibleElement"),
};

foreach (var probe in inheritanceProbes)
{
    var eClass = allClasses.FirstOrDefault(c => c.Name == probe.Class && QualifiedName(c.EPackage) == probe.Package);
    if (eClass == null)
    {
        failures.Add($"[inheritance] class not found: {probe.Package}::{probe.Class}");
        continue;
    }

    var ancestors = AllSuperTypes(eClass).ToList();
    if (!ancestors.Any(a => a.Name == probe.ExpectedAncestor && QualifiedName(a.EPackage) == probe.ExpectedAncestorPackage))
    {
        failures.Add($"[inheritance] {probe.Package}::{probe.Class} does not reach {probe.ExpectedAncestorPackage}::{probe.ExpectedAncestor} " +
                     $"(found: {string.Join(", ", ancestors.Select(a => a.Name))})");
    }
}

Console.WriteLine($"check 4 - inheritance: {inheritanceProbes.Length} cross-package chains probed");

// ---------------------------------------------------------------------------------------------
// check 5: eOpposite pairs are resolved and mutually consistent; the resolved count matches the
// number of eOpposite declarations in the raw XML
// ---------------------------------------------------------------------------------------------
var allReferences = allClasses.SelectMany(c => c.EStructuralFeatures.OfType<EReference>()).ToList();
var resolvedOpposites = allReferences.Where(r => r.EOpposite != null).ToList();

foreach (var reference in resolvedOpposites)
{
    if (!ReferenceEquals(reference.EOpposite!.EOpposite, reference))
    {
        failures.Add($"[opposite] {reference.EContainingClass.Name}.{reference.Name}: eOpposite is not mutual");
    }
}

var declaredOpposites = ecoreFiles.Sum(f => Regex.Matches(File.ReadAllText(f), "eOpposite=\"").Count);
if (resolvedOpposites.Count != declaredOpposites)
{
    failures.Add($"[opposite] {declaredOpposites} eOpposite declarations in XML but {resolvedOpposites.Count} resolved EOpposite references");
}

Console.WriteLine($"check 5 - opposites: {resolvedOpposites.Count} resolved / {declaredOpposites} declared in XML");

// ---------------------------------------------------------------------------------------------
// check 6: annotations survive loading (Capella carries documentation and emde annotations)
// ---------------------------------------------------------------------------------------------
var annotationSources = allClasses
    .SelectMany(c => c.EAnnotations)
    .Where(a => a.Source != null)
    .GroupBy(a => a.Source!)
    .OrderByDescending(g => g.Count())
    .ToList();

if (annotationSources.Count == 0)
{
    failures.Add("[annotations] no EAnnotations found on any EClass - annotation parsing is broken");
}

Console.WriteLine($"check 6 - annotations: {annotationSources.Sum(g => g.Count())} class-level annotations, top sources:");
foreach (var group in annotationSources.Take(5))
{
    Console.WriteLine($"    {group.Count(),5} x {group.Key}");
}

// ---------------------------------------------------------------------------------------------
// summary
// ---------------------------------------------------------------------------------------------
Console.WriteLine();
if (failures.Count == 0)
{
    Console.WriteLine("PASS: all checks succeeded - ECoreNetto handles the full Capella v1 metamodel");
    return 0;
}

Console.WriteLine($"FAIL: {failures.Count} problem(s) found:");
foreach (var failure in failures)
{
    Console.WriteLine($"  - {failure}");
}

return 1;
