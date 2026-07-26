// ------------------------------------------------------------------------------------------------
// <copyright file="SimpleAttributeFidelity.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// The scalar-fidelity audit used by the round-trip regression suites (issue #121): it compares the
    /// <em>values</em> a document carries, not only its structure and references, so content that the
    /// reader never captured — and therefore silently dropped on write — is caught rather than passing
    /// unnoticed.
    ///
    /// <para>It targets the multi-valued simple attributes EMF serializes as one child element per value
    /// (e.g. a <c>DAnalysis</c>'s <c>semanticResources</c>, a <c>DDiagramElement</c>'s
    /// <c>arrangeConstraints</c>, a Capella description's <c>bodies</c>). These are exactly the values the
    /// semantic round-trip cannot see: it compares element identities, runtime types, containment and
    /// references, none of which change when a list of strings is lost.</para>
    /// </summary>
    internal static class SimpleAttributeFidelity
    {
        /// <summary>
        /// The multiset of simple-attribute values a document carries, keyed by
        /// <c>elementName=value</c> with the number of occurrences as the value.
        ///
        /// <para>A simple-attribute child element is a leaf: it has no child elements and no attributes.
        /// That excludes an <c>href</c> proxy and an empty containment element (both carry attributes),
        /// leaving the repeated child elements EMF emits for a multi-valued <c>EAttribute</c>.</para>
        /// </summary>
        /// <param name="document">the document to project</param>
        /// <returns>the value multiset</returns>
        public static Dictionary<string, int> Project(XDocument document)
        {
            var values = new Dictionary<string, int>(System.StringComparer.Ordinal);

            foreach (var element in document.Descendants())
            {
                if (element.HasElements || element.HasAttributes)
                {
                    continue;
                }

                var key = element.Name.LocalName + "=" + element.Value;
                values[key] = values.TryGetValue(key, out var count) ? count + 1 : 1;
            }

            return values;
        }

        /// <summary>
        /// The simple-attribute values present in <paramref name="original"/> that the written document
        /// does not carry as often (or at all) — the content a read → write cycle dropped.
        /// </summary>
        /// <param name="original">the original document</param>
        /// <param name="written">the document produced by writing the model back</param>
        /// <returns>a human-readable description of each shortfall, empty when nothing was dropped</returns>
        public static IReadOnlyList<string> Dropped(XDocument original, XDocument written)
        {
            var expected = Project(original);
            var actual = Project(written);

            return expected
                .Where(entry => !actual.TryGetValue(entry.Key, out var count) || count < entry.Value)
                .OrderBy(entry => entry.Key, System.StringComparer.Ordinal)
                .Select(entry =>
                {
                    actual.TryGetValue(entry.Key, out var count);

                    var name = entry.Key.Split('=')[0];
                    var value = entry.Key.Substring(name.Length + 1);

                    // A value that differs only in spelling is far more common than one that vanished, and
                    // is much easier to diagnose alongside what the writer actually produced.
                    var written = actual.Keys
                        .Where(key => key.StartsWith(name + "=", System.StringComparison.Ordinal))
                        .Select(key => key.Substring(name.Length + 1))
                        .OrderBy(candidate => System.Math.Abs(candidate.Length - value.Length))
                        .FirstOrDefault();

                    return $"<{name}> {Escape(value)} — {entry.Value} in original, {count} written"
                           + (written == null ? " (no <" + name + "> written at all)" : $"; nearest written: {Escape(written)}");
                })
                .ToList();
        }

        /// <summary>
        /// Renders a value for a failure message with its line breaks and tabs made visible and its length
        /// bounded, so a multi-line description does not swamp the report and a whitespace-only difference
        /// is legible.
        /// </summary>
        /// <param name="value">the value to render</param>
        /// <returns>the escaped, truncated value</returns>
        private static string Escape(string value)
        {
            var escaped = value
                .Replace("\r", "\\r", System.StringComparison.Ordinal)
                .Replace("\n", "\\n", System.StringComparison.Ordinal)
                .Replace("\t", "\\t", System.StringComparison.Ordinal);

            return escaped.Length <= 120 ? $"'{escaped}'" : $"'{escaped.Substring(0, 120)}…' ({escaped.Length} chars)";
        }
    }
}
