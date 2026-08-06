// ------------------------------------------------------------------------------------------------
// <copyright file="VersionChecker.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;

    using Auriga.Tools.Presentation;
    using Auriga.Tools.Resources;

    using Microsoft.Extensions.Logging;

    using Spectre.Console;

    /// <summary>
    /// The default <see cref="IVersionChecker"/>: asks GitHub for the latest release of the
    /// repository and compares it with the running assembly's version.
    /// </summary>
    public sealed class VersionChecker : IVersionChecker
    {
        /// <summary>
        /// The releases endpoint of the repository.
        /// </summary>
        private const string LatestRelease = "https://api.github.com/repos/STARIONGROUP/Auriga/releases/latest";

        /// <summary>
        /// How long the check may take before the tool gets on with its work.
        /// </summary>
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(3);

        /// <summary>
        /// The factory the check's client comes from.
        /// </summary>
        private readonly IHttpClientFactory clientFactory;

        /// <summary>
        /// The logger recording why a check did not complete.
        /// </summary>
        private readonly ILogger<VersionChecker> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionChecker"/> class.
        /// </summary>
        /// <param name="clientFactory">the factory the check's client comes from</param>
        /// <param name="loggerFactory">the factory the checker creates its logger from</param>
        /// <exception cref="ArgumentNullException">the client factory or the logger factory is null</exception>
        public VersionChecker(IHttpClientFactory clientFactory, ILoggerFactory loggerFactory)
        {
            this.clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.logger = loggerFactory.CreateLogger<VersionChecker>();
        }

        /// <summary>
        /// Checks for a newer release and writes a note when there is one.
        /// </summary>
        /// <param name="cancellationToken">the token cancelling the check</param>
        /// <returns>the running check</returns>
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var client = this.clientFactory.CreateClient();
                client.Timeout = Timeout;
                client.DefaultRequestHeaders.Add("User-Agent", "Auriga.Tools");

                var release = await client.GetFromJsonAsync<GitHubRelease>(LatestRelease, cancellationToken);

                if (release?.TagName == null
                    || !Version.TryParse(release.TagName.TrimStart('v'), out var latest)
                    || !Version.TryParse(ResourceLoader.QueryVersion(), out var running))
                {
                    return;
                }

                if (latest <= running)
                {
                    return;
                }

                AnsiConsole.MarkupLine(
                    $"[yellow]A newer version of Auriga.Tools is available: [bold]{Ui.Escape(release.TagName)}[/] (running {Ui.Escape(running.ToString())})[/]");
                AnsiConsole.MarkupLine("[grey]Update with[/] [bold]dotnet tool update -g Auriga.Tools[/]");
                AnsiConsole.WriteLine();
            }
            catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException or NotSupportedException or InvalidOperationException)
            {
                // Being offline, rate-limited or behind a proxy is not a reason to refuse to work,
                // so the check fails into the log rather than onto the console.
                this.logger.LogDebug(exception, "The check for a newer release did not complete");
            }
        }
    }
}
