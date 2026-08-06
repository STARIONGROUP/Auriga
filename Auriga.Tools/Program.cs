// ------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools
{
    using System.CommandLine;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Auriga.Reporting.Generators;
    using Auriga.Tools.Commands;
    using Auriga.Tools.Services;

    using Autofac.Extensions.DependencyInjection;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using Serilog;
    using Serilog.Core;
    using Serilog.Events;

    /// <summary>
    /// The entry point of the command line tool.
    /// </summary>
    /// <remarks>
    /// The commands hold no model logic: each resolves an <see cref="IDiagramReportGenerator"/>
    /// and binds the parsed options to it, so what the tool does and what a library consumer does
    /// are the same code path.
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        /// <summary>
        /// The Serilog level the <c>--log-level</c> option adjusts at run time.
        /// </summary>
        private static readonly LoggingLevelSwitch LoggingLevelSwitch = new();

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <param name="args">the command line arguments</param>
        /// <returns>zero when the command succeeded, a non-zero code when it did not</returns>
        public static async Task<int> Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            return await CreateCommandChain(host).Parse(args).InvokeAsync();
        }

        /// <summary>
        /// Builds the host: Serilog to a rolling file, and the services the commands resolve.
        /// </summary>
        /// <param name="args">the command line arguments</param>
        /// <returns>the host builder</returns>
        /// <remarks>
        /// The log goes to a file rather than to the console on purpose: the console belongs to the
        /// progress display, and a log line written into a live Spectre widget corrupts it.
        /// </remarks>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();

                    var logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .MinimumLevel.ControlledBy(LoggingLevelSwitch)
                        .WriteTo.File(
                            "auriga.logs",
                            rollingInterval: RollingInterval.Day,
                            outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] ({SourceContext}) {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();

                    loggingBuilder.AddSerilog(logger, dispose: true);
                    loggingBuilder.SetMinimumLevel(LogLevel.Information);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(services =>
                {
                    services.AddHttpClient();

                    services.AddSingleton<IVersionChecker, VersionChecker>();
                    services.AddSingleton<IDiagramReportGenerator, DiagramReportGenerator>();
                });
        }

        /// <summary>
        /// Builds the root command and its sub-commands.
        /// </summary>
        /// <param name="host">the host the handlers resolve their services from</param>
        /// <returns>the root command</returns>
        private static RootCommand CreateCommandChain(IHost host)
        {
            var root = new RootCommand("Auriga Tools — export the diagrams of an Eclipse Capella model");

            // The scope is awaited inside, not disposed around a returned Task: a non-async lambda
            // ends at the handler's first await, taking the scope — and the logger factory the
            // services hold — down while the command is still running.
            var export = new ExportCommand();

            export.SetAction(async (parseResult, cancellationToken) =>
            {
                ApplyLogLevel(parseResult);

                using var scope = host.Services.CreateScope();

                var handler = new ExportCommand.Handler(
                    scope.ServiceProvider.GetRequiredService<IDiagramReportGenerator>(),
                    scope.ServiceProvider.GetRequiredService<IVersionChecker>());

                return await handler.InvokeAsync(parseResult, cancellationToken);
            });

            root.Add(export);

            var list = new ListCommand();

            list.SetAction(async (parseResult, cancellationToken) =>
            {
                ApplyLogLevel(parseResult);

                using var scope = host.Services.CreateScope();

                var handler = new ListCommand.Handler(
                    scope.ServiceProvider.GetRequiredService<IDiagramReportGenerator>(),
                    scope.ServiceProvider.GetRequiredService<IVersionChecker>());

                return await handler.InvokeAsync(parseResult, cancellationToken);
            });

            root.Add(list);

            return root;
        }

        /// <summary>
        /// Applies the <c>--log-level</c> the command line asked for.
        /// </summary>
        /// <param name="parseResult">the parsed command line</param>
        private static void ApplyLogLevel(ParseResult parseResult)
        {
            LoggingLevelSwitch.MinimumLevel = parseResult.GetValue<LogEventLevel>("--log-level");
        }
    }
}
