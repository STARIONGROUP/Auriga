// ------------------------------------------------------------------------------------------------
// <copyright file="GitHubRelease.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Services
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The part of a GitHub release the <see cref="VersionChecker"/> reads.
    /// </summary>
    public sealed class GitHubRelease
    {
        /// <summary>
        /// Gets or sets the tag the release was cut from, which is the version.
        /// </summary>
        [JsonPropertyName("tag_name")]
        public string? TagName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the release page, for a user who wants to read what changed.
        /// </summary>
        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }
    }
}
