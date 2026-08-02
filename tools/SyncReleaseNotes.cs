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
// The element is spliced into the csproj as text rather than written through an XML writer, so the
// rest of the document — its indentation, blank lines, line endings and empty-element style — comes
// out byte-identical. The result is parsed before it is saved, so a bad splice fails the release
// instead of committing a broken project file.

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

foreach (var csproj in Packable(root))
{
    var source = Read(csproj);
    var project = XDocument.Parse(source.Text);
    var scope = project.Root!.Name.Namespace;

    var properties = project.Root.Elements(scope + "PropertyGroup").ToList();

    // Only the packable projects carry the generated element; the others are none of our business.
    if (!properties.Elements(scope + "PackageReleaseNotes").Any())
    {
        continue;
    }

    var packageId = FirstValue(properties, scope + "PackageId") ?? Path.GetFileNameWithoutExtension(csproj);
    var packageVersion = FirstValue(properties, scope + "Version") ?? version;
    var entries = EntriesFor(unreleased, packageId);

    // A package with no entries this release must not ship the previous release's notes, so the
    // element is rewritten either way — emptied when the package did not change.
    var updated = Splice(source.Text, entries, source.Eol);

    try
    {
        XDocument.Parse(updated);
    }
    catch (XmlException exception)
    {
        Console.Error.WriteLine($"{Relative(root, csproj)} would no longer be well-formed XML: {exception.Message}");
        return 1;
    }

    Write(csproj, updated, source.Bom);
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

/// The packable projects, in a stable order. bin/obj and the dot-directories hold no source project.
static IEnumerable<string> Packable(string root)
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

/// Replaces the value of the first &lt;PackageReleaseNotes&gt; element, leaving every other byte of
/// the document as it was found — including the indentation, which is taken from the element itself.
static string Splice(string csproj, IReadOnlyList<string> entries, string eol)
{
    const string Open = "<PackageReleaseNotes";
    const string Close = "</PackageReleaseNotes>";

    var start = csproj.IndexOf(Open, StringComparison.Ordinal);

    if (start < 0)
    {
        throw new InvalidOperationException($"No {Open}> element to write into.");
    }

    var openEnd = csproj.IndexOf('>', start);

    if (openEnd < 0)
    {
        throw new InvalidOperationException($"The {Open}> element is unterminated.");
    }

    int end;

    if (csproj[openEnd - 1] == '/')
    {
        end = openEnd + 1;
    }
    else
    {
        var close = csproj.IndexOf(Close, openEnd, StringComparison.Ordinal);

        if (close < 0)
        {
            throw new InvalidOperationException($"The {Open}> element is never closed.");
        }

        end = close + Close.Length;
    }

    var indentStart = start;

    while (indentStart > 0 && (csproj[indentStart - 1] == ' ' || csproj[indentStart - 1] == '\t'))
    {
        indentStart--;
    }

    var indent = csproj[indentStart..start];
    var inner = indent + (indent.Contains('\t') ? "\t" : "    ");

    var element = new StringBuilder(Open).Append('>');

    if (entries.Count == 0)
    {
        element.Append(Close);
    }
    else
    {
        foreach (var entry in entries)
        {
            element.Append(eol).Append(inner).Append(Escape(entry));
        }

        element.Append(eol).Append(indent).Append(Close);
    }

    return string.Concat(csproj.AsSpan(0, start), element.ToString(), csproj.AsSpan(end));
}

static string Escape(string entry)
{
    return entry
        .Replace("&", "&amp;", StringComparison.Ordinal)
        .Replace("<", "&lt;", StringComparison.Ordinal)
        .Replace(">", "&gt;", StringComparison.Ordinal);
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

static (string Text, string Eol, bool Bom) Read(string path)
{
    var bytes = File.ReadAllBytes(path);
    var bom = bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF;
    var text = new UTF8Encoding(false).GetString(bytes, bom ? 3 : 0, bytes.Length - (bom ? 3 : 0));

    return (text, text.Contains("\r\n", StringComparison.Ordinal) ? "\r\n" : "\n", bom);
}

static void Write(string path, string text, bool bom)
{
    File.WriteAllText(path, text, new UTF8Encoding(bom));
}
