// ------------------------------------------------------------------------------------------------
// <copyright file="SyncReleaseNotes.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// Turns CHANGELOG.md into a release. Run by .github/workflows/nuget-release.yml, and runnable by
// hand on any machine with the .NET SDK:
//
//     dotnet run tools/SyncReleaseNotes.cs -- --version 1.1.0
//
// It reads the '## [Unreleased]' section, writes each package's bullets into that package's
// <PackageReleaseNotes>, moves the section under the version being released, and renders
// RELEASE_NOTES.md for the GitHub release body. Nothing is committed: the caller decides what to do
// with the modified working tree, so a dry run is simply a run that does not commit.
//
// A release must change nothing in a csproj but the notes, so before the value is written the
// untouched document is serialized and compared with the file it was read from. That holds for the
// projects as they stand — the declaration, the blank lines, the indentation, the line endings and
// the empty-element style all survive the round-trip — and the comparison is what keeps it true: a
// document that would come back reformatted fails the release rather than being rewritten wholesale.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

string? version = null;
string? date = null;
var root = Directory.GetCurrentDirectory();
var releaseNotesPath = "RELEASE_NOTES.md";

for (var index = 0; index < args.Length; index++)
{
    switch (args[index])
    {
        case "--version":
            version = ValueOf(args, ref index);
            break;
        case "--date":
            date = ValueOf(args, ref index);
            break;
        case "--root":
            root = ValueOf(args, ref index);
            break;
        case "--release-notes":
            releaseNotesPath = ValueOf(args, ref index);
            break;
        case "--help":
        case "-h":
            Usage();
            return 0;
        default:
            Console.Error.WriteLine($"Unknown argument '{args[index]}'.");
            Usage();
            return 1;
    }
}

if (string.IsNullOrWhiteSpace(version))
{
    Console.Error.WriteLine("--version is required: it is the release the [Unreleased] section becomes.");
    Usage();
    return 1;
}

date ??= DateTime.UtcNow.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
root = Path.GetFullPath(root);

var changelogPath = Path.Combine(root, "CHANGELOG.md");

if (!File.Exists(changelogPath))
{
    Console.Error.WriteLine($"{changelogPath} not found: it is the source of a release's notes.");
    return 1;
}

var changelog = Read(changelogPath);
var unreleased = ExtractUnreleased(changelog.Text);

if (!unreleased.Any(line => line.StartsWith("### ", StringComparison.Ordinal)))
{
    Console.Error.WriteLine("CHANGELOG.md carries no package entries under [Unreleased]; there is nothing to release.");
    return 1;
}

var notes = new StringBuilder("The following items have been fixed in this release:\n\n");
var synced = 0;

foreach (var csproj in Projects(root))
{
    var source = Read(csproj);
    var project = XDocument.Parse(source.Text, LoadOptions.PreserveWhitespace);
    var scope = project.Root!.Name.Namespace;

    var properties = project.Root.Elements(scope + "PropertyGroup").ToList();
    var element = properties.Elements(scope + "PackageReleaseNotes").FirstOrDefault();

    // Only the packable projects carry the generated element; the others are none of our business.
    if (element is null)
    {
        continue;
    }

    if (!Serialize(project, source.Eol, source.Bom).SequenceEqual(source.Bytes))
    {
        Console.Error.WriteLine($"{Relative(root, csproj)} does not survive an XML round-trip unchanged, so writing the release notes would reformat the rest of the file. Release it by hand and report this.");
        return 1;
    }

    var packageId = FirstValue(properties, scope + "PackageId") ?? Path.GetFileNameWithoutExtension(csproj);
    var packageVersion = FirstValue(properties, scope + "Version") ?? version;
    var entries = EntriesFor(unreleased, packageId);

    // A package with no entries this release must not ship the previous release's notes, so the
    // element is rewritten either way — emptied when the package did not change.
    element.ReplaceNodes(new XText(Value(entries, IndentOf(element))));

    File.WriteAllBytes(csproj, Serialize(project, source.Eol, source.Bom));
    synced++;

    Console.WriteLine($"{Relative(root, csproj)}: {packageId} [{packageVersion}], {entries.Count} entr{(entries.Count == 1 ? "y" : "ies")}");

    if (entries.Count == 0)
    {
        continue;
    }

    notes.Append(CultureInfo.InvariantCulture, $"**{packageId} [{packageVersion}]**\n");

    foreach (var entry in entries)
    {
        notes.Append(CultureInfo.InvariantCulture, $"  - {entry}\n");
    }

    notes.Append('\n');
}

if (synced == 0)
{
    Console.Error.WriteLine("No project carries a <PackageReleaseNotes> element; there is nothing to write the notes into.");
    return 1;
}

File.WriteAllText(Path.Combine(root, releaseNotesPath), notes.ToString(), new UTF8Encoding(false));

Write(changelogPath, Roll(changelog.Text, version, date, changelog.Eol), changelog.Bom);

Console.WriteLine($"CHANGELOG.md rolled: [Unreleased] is now [{version}] - {date}, with a fresh [Unreleased] above it.");

return 0;

static void Usage()
{
    Console.Error.WriteLine("usage: dotnet run tools/SyncReleaseNotes.cs -- --version <semver> [--date <yyyy-MM-dd>] [--root <path>] [--release-notes <path>]");
}

static string ValueOf(string[] arguments, ref int index)
{
    if (index + 1 >= arguments.Length)
    {
        throw new ArgumentException($"'{arguments[index]}' expects a value.");
    }

    return arguments[++index];
}

/// The projects, in a stable order. bin/obj and the dot-directories hold no source project.
static IEnumerable<string> Projects(string root)
{
    return Directory.EnumerateFiles(root, "*.csproj", SearchOption.AllDirectories)
        .Where(path => !Relative(root, path)
            .Split('/')
            .Any(segment => segment.StartsWith('.')
                || segment.Equals("bin", StringComparison.OrdinalIgnoreCase)
                || segment.Equals("obj", StringComparison.OrdinalIgnoreCase)))
        .OrderBy(path => path, StringComparer.Ordinal);
}

static string Relative(string root, string path)
{
    return Path.GetRelativePath(root, path).Replace('\\', '/');
}

static string? FirstValue(IEnumerable<XElement> properties, XName name)
{
    var value = properties.Elements(name).FirstOrDefault()?.Value.Trim();

    return string.IsNullOrEmpty(value) ? null : value;
}

/// The body of '## [Unreleased]', up to the next '## ' heading.
static List<string> ExtractUnreleased(string changelog)
{
    var body = new List<string>();
    var inside = false;

    foreach (var line in Lines(changelog))
    {
        if (!inside)
        {
            inside = line.StartsWith("## [Unreleased]", StringComparison.Ordinal);
            continue;
        }

        if (line.StartsWith("## ", StringComparison.Ordinal))
        {
            break;
        }

        body.Add(line);
    }

    return body;
}

/// One package's bullets, from its '### &lt;PackageId&gt;' subsection.
static List<string> EntriesFor(IReadOnlyList<string> unreleased, string packageId)
{
    var heading = $"### {packageId}";
    var entries = new List<string>();
    var inside = false;

    foreach (var line in unreleased)
    {
        if (!inside)
        {
            inside = line.Trim() == heading;
            continue;
        }

        if (line.StartsWith('#'))
        {
            break;
        }

        if (line.StartsWith("- ", StringComparison.Ordinal))
        {
            entries.Add(line[2..].TrimEnd());
        }
    }

    return entries;
}

/// The element's text: one entry per line, indented a level deeper than the element itself, with
/// the closing tag left on its own line. The writer turns the newlines into the file's own.
static string Value(IReadOnlyList<string> entries, string indent)
{
    if (entries.Count == 0)
    {
        return string.Empty;
    }

    var inner = indent + (indent.Contains('\t') ? "\t" : "    ");

    return $"\n{string.Join("\n", entries.Select(entry => inner + entry))}\n{indent}";
}

/// What the element is indented by, read from the whitespace it sits behind.
static string IndentOf(XElement element)
{
    if (element.PreviousNode is XText whitespace && whitespace.Value.Trim().Length == 0)
    {
        var value = whitespace.Value;
        var line = value.LastIndexOf('\n');

        return line < 0 ? value : value[(line + 1)..];
    }

    return "        ";
}

/// Moves '## [Unreleased]' under the version being released and opens a fresh one above it.
static string Roll(string changelog, string version, string date, string eol)
{
    // The heading, not the prose that names it: only an occurrence opening a line is one.
    var heading = -1;

    for (var candidate = changelog.IndexOf("## [Unreleased]", StringComparison.Ordinal);
         candidate >= 0;
         candidate = changelog.IndexOf("## [Unreleased]", candidate + 1, StringComparison.Ordinal))
    {
        if (candidate == 0 || changelog[candidate - 1] == '\n')
        {
            heading = candidate;
            break;
        }
    }

    if (heading < 0)
    {
        throw new InvalidOperationException("CHANGELOG.md carries no '## [Unreleased]' heading to roll.");
    }

    var lineEnd = changelog.IndexOf('\n', heading);
    lineEnd = lineEnd < 0 ? changelog.Length : lineEnd - (eol.Length - 1);

    var rolled = $"## [Unreleased]{eol}{eol}## [{version}] - {date}";

    return string.Concat(changelog.AsSpan(0, heading), rolled, changelog.AsSpan(lineEnd));
}

static IEnumerable<string> Lines(string text)
{
    return text.Replace("\r\n", "\n", StringComparison.Ordinal).Split('\n');
}

/// The document as the file should hold it: the line endings it was read with, the encoding it was
/// read with, and no reformatting of anything the caller did not change.
static byte[] Serialize(XDocument document, string eol, bool bom)
{
    var settings = new XmlWriterSettings
    {
        Indent = false,
        NewLineHandling = NewLineHandling.Replace,
        NewLineChars = eol,
        Encoding = new UTF8Encoding(bom),
        OmitXmlDeclaration = document.Declaration is null,
    };

    using var buffer = new MemoryStream();

    using (var writer = XmlWriter.Create(buffer, settings))
    {
        document.Save(writer);
    }

    return buffer.ToArray();
}

static (byte[] Bytes, string Text, string Eol, bool Bom) Read(string path)
{
    var bytes = File.ReadAllBytes(path);
    var bom = bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF;
    var text = new UTF8Encoding(false).GetString(bytes, bom ? 3 : 0, bytes.Length - (bom ? 3 : 0));

    return (bytes, text, text.Contains("\r\n", StringComparison.Ordinal) ? "\r\n" : "\n", bom);
}

static void Write(string path, string text, bool bom)
{
    File.WriteAllText(path, text, new UTF8Encoding(bom));
}
