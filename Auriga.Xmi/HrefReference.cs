// ------------------------------------------------------------------------------------------------
// <copyright file="HrefReference.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Parses and resolves the reference tokens collected while reading, shared by the reference resolver
    /// (which turns them into document-scoped cache keys) and the reader (which discovers the fragment
    /// documents to load). A token is one of the EMF/Capella cross-reference forms: a bare intra-document
    /// <c>id</c>, a same-document <c>#id</c> (already reduced to <c>id</c> at collection time), a
    /// cross-document <c>path#id</c>, or a typed cross-fragment <c>xsi:type path#id</c>.
    /// </summary>
    internal static class HrefReference
    {
        /// <summary>
        /// Parses a collected reference token into its document path and identifier. The optional leading
        /// <c>xsi:type </c> prefix of the cross-fragment form is stripped: a literal space only ever
        /// separates the type from the path, since real spaces in a path are URL-encoded (<c>%20</c>).
        /// </summary>
        /// <param name="token">the collected reference token</param>
        /// <returns>
        /// the (still URL-encoded) document path — empty for an intra-document reference — and the identifier
        /// </returns>
        public static (string DocumentPath, string Id) Parse(string token)
        {
            var separator = token.IndexOf('#');
            if (separator < 0)
            {
                return (string.Empty, token);
            }

            var id = token.Substring(separator + 1);
            var path = token.Substring(0, separator);

            var space = path.LastIndexOf(' ');
            if (space >= 0)
            {
                path = path.Substring(space + 1);
            }

            return (path, id);
        }

        /// <summary>
        /// Resolves an <c>href</c> document path, relative to the referring document, to the canonical
        /// document name used as the source of the referenced elements: URL-decoded, forward-slashed,
        /// <c>..</c>-collapsed and relative to the model's main file — the same form as
        /// <see cref="IAurigaElement.SourceDocument"/>.
        /// </summary>
        /// <param name="referringDocument">the document the reference is written in</param>
        /// <param name="documentPath">the (URL-encoded) document part of the href</param>
        /// <returns>the canonical target document name</returns>
        public static string Canonicalize(string? referringDocument, string documentPath)
        {
            var segments = new List<string>();

            var referringDirectory = referringDocument ?? string.Empty;
            var lastSlash = referringDirectory.LastIndexOf('/');
            if (lastSlash >= 0)
            {
                segments.AddRange(referringDirectory.Substring(0, lastSlash).Split('/'));
            }

            foreach (var segment in Uri.UnescapeDataString(documentPath).Replace('\\', '/').Split('/'))
            {
                if (segment.Length == 0 || segment == ".")
                {
                    continue;
                }

                if (segment == ".." && segments.Count > 0)
                {
                    segments.RemoveAt(segments.Count - 1);
                }
                else if (segment != "..")
                {
                    segments.Add(segment);
                }
            }

            return string.Join("/", segments);
        }
    }
}
