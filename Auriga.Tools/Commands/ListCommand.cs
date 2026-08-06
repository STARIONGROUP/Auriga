// ------------------------------------------------------------------------------------------------
// <copyright file="ListCommand.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Commands
{
    using System;
    using System.CommandLine;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Auriga.Reporting.Generators;
    using Auriga.Tools.Presentation;
    using Auriga.Tools.Services;

    using Spectre.Console;

    // Auriga.Reporting.Model carries a Color and a Style of its own, and so does Spectre; only the
    // diagram is wanted here, so it comes in by name rather than by namespace.
    using Diagram = Auriga.Reporting.Model.Diagram;

    /// <summary>
    /// Names what a Capella project holds, without writing anything — what to run before choosing
    /// what to export.
    /// </summary>
    public class ListCommand : ModelCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCommand"/> class.
        /// </summary>
        public ListCommand()
            : base("list", "Lists the diagrams a Capella model holds, without exporting anything")
        {
        }

        /// <summary>
        /// The handler of the <see cref="ListCommand"/>.
        /// </summary>
        public class Handler
        {
            /// <summary>
            /// The generator that reads the model.
            /// </summary>
            private readonly IDiagramReportGenerator generator;

            /// <summary>
            /// The check for a newer release of the tool.
            /// </summary>
            private readonly IVersionChecker versionChecker;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="generator">the generator that reads the model</param>
            /// <param name="versionChecker">the check for a newer release of the tool</param>
            /// <exception cref="ArgumentNullException">the generator or the version checker is null</exception>
            public Handler(IDiagramReportGenerator generator, IVersionChecker versionChecker)
            {
                this.generator = generator ?? throw new ArgumentNullException(nameof(generator));
                this.versionChecker = versionChecker ?? throw new ArgumentNullException(nameof(versionChecker));
            }

            /// <summary>
            /// Runs the command.
            /// </summary>
            /// <param name="parseResult">the parsed command line</param>
            /// <param name="cancellationToken">the token cancelling the run</param>
            /// <returns>zero when the model was listed, a non-zero code when it was not</returns>
            public async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var model = parseResult.GetValue<FileInfo>("model")!;
                var filter = parseResult.GetValue<string>("--name");

                Ui.Logo(parseResult.GetValue<bool>("--no-logo"));

                await this.versionChecker.ExecuteAsync(cancellationToken);

                if (!model.Exists && !Directory.Exists(model.FullName))
                {
                    Ui.Problem("That Capella model does not exist.", model.FullName);

                    return -1;
                }

                try
                {
                    var stopwatch = Stopwatch.StartNew();

                    var diagrams = AnsiConsole.Status()
                        .Spinner(Spinner.Known.Dots)
                        .SpinnerStyle(Style.Parse("green"))
                        .Start($"Reading {Ui.Escape(model.Name)}…", _ =>
                            this.generator.Query(model, new DiagramReportOptions { NameFilter = filter }));

                    stopwatch.Stop();

                    if (diagrams.Count == 0)
                    {
                        Ui.Problem(
                            filter == null
                                ? "That model holds no representation this tool can render."
                                : "No representation of that model matches the filter.",
                            filter);

                        return 0;
                    }

                    Render(diagrams, model, filter, stopwatch.Elapsed);

                    return 0;
                }
                catch (OperationCanceledException)
                {
                    AnsiConsole.MarkupLine("[yellow]Cancelled.[/]");

                    throw;
                }
                catch (Exception exception) when (exception is IOException or InvalidDataException or UnauthorizedAccessException)
                {
                    Ui.Problem("That model could not be read.", exception.Message);

                    return -1;
                }
                catch (Exception exception)
                {
                    Ui.Crash(exception);

                    return -1;
                }
            }

            /// <summary>
            /// Writes the representations as a table.
            /// </summary>
            /// <param name="diagrams">the representations</param>
            /// <param name="model">the model they came from</param>
            /// <param name="filter">the filter that narrowed them, or <c>null</c></param>
            /// <param name="elapsed">how long reading took</param>
            private static void Render(System.Collections.Generic.IReadOnlyList<Diagram> diagrams, FileInfo model, string? filter, TimeSpan elapsed)
            {
                var table = new Table()
                    .RoundedBorder()
                    .BorderColor(Color.Grey)
                    .Title($"[bold]{Ui.Escape(model.Name)}[/]")
                    .AddColumn("[grey]#[/]", column => column.RightAligned())
                    .AddColumn("[bold]diagram[/]")
                    .AddColumn("[grey]boxes[/]", column => column.RightAligned())
                    .AddColumn("[grey]edges[/]", column => column.RightAligned())
                    .AddColumn("[grey]identifier[/]");

                var index = 1;

                foreach (var diagram in diagrams)
                {
                    table.AddRow(
                        $"[grey]{index++}[/]",
                        Ui.Escape(string.IsNullOrEmpty(diagram.Name) ? "(unnamed)" : diagram.Name),
                        diagram.QueryAllBoxes().Count().ToString(CultureInfo.InvariantCulture),
                        diagram.Edges.Count.ToString(CultureInfo.InvariantCulture),
                        $"[grey]{Ui.Escape(diagram.Identifier.TrimStart('_'))}[/]");
                }

                table.Caption($"[grey]{diagrams.Count} representation(s){(filter == null ? string.Empty : $", filtered by {Ui.Escape(filter)}")}, read in {Ui.Duration(elapsed)}[/]");

                AnsiConsole.WriteLine();
                AnsiConsole.Write(table);
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine("[grey]Export them with[/] [bold]aurigatools export[/] [grey]— see[/] [bold]aurigatools export --help[/]");
                AnsiConsole.WriteLine();
            }
        }
    }
}
