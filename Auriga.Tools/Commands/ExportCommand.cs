// ------------------------------------------------------------------------------------------------
// <copyright file="ExportCommand.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Commands
{
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Auriga.Reporting.Drawing;
    using Auriga.Reporting.Generators;
    using Auriga.Tools.Presentation;
    using Auriga.Tools.Services;

    using Spectre.Console;

    using ModelColor = Auriga.Reporting.Model.Color;

    /// <summary>
    /// Writes the diagrams of a Capella model as pictures.
    /// </summary>
    public class ExportCommand : ModelCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportCommand"/> class.
        /// </summary>
        public ExportCommand()
            : base("export", "Exports the diagrams of a Capella model to SVG, PNG, JPEG and Excel")
        {
            var output = new Option<DirectoryInfo>(name: "--output")
            {
                Description = "The directory the pictures are written to; created when it does not exist",
                DefaultValueFactory = _ => new DirectoryInfo("auriga-export"),
                Required = false,
            };

            output.Aliases.Add("-o");
            this.Options.Add(output);

            var format = new Option<string>(name: "--format")
            {
                Description = "A comma-separated list of svg, png, jpeg and xlsx",
                DefaultValueFactory = _ => "svg,png",
                Required = false,
            };

            format.Aliases.Add("-f");
            this.Options.Add(format);

            var scale = new Option<double>(name: "--scale")
            {
                Description = "The factor the diagram's persisted size is multiplied by in the raster formats",
                DefaultValueFactory = _ => 1d,
                Required = false,
            };

            this.Options.Add(scale);

            var dpi = new Option<double>(name: "--dpi")
            {
                Description = "The raster resolution, as an alternative to --scale; 96 dpi is scale 1",
                DefaultValueFactory = _ => 0d,
                Required = false,
            };

            this.Options.Add(dpi);

            var background = new Option<string>(name: "--background")
            {
                Description = "The colour the diagram is drawn on, as #RRGGBB or r,g,b; omit for transparent PNG and white JPEG",
                Required = false,
            };

            this.Options.Add(background);

            var quality = new Option<int>(name: "--quality")
            {
                Description = "The JPEG encoder quality, from 1 to 100",
                DefaultValueFactory = _ => 90,
                Required = false,
            };

            this.Options.Add(quality);

            var open = new Option<bool>(name: "--open")
            {
                Description = "Open the output directory when the export finishes",
                DefaultValueFactory = _ => false,
                Required = false,
            };

            this.Options.Add(open);
        }

        /// <summary>
        /// The handler of the <see cref="ExportCommand"/>.
        /// </summary>
        public class Handler
        {
            /// <summary>
            /// The generator that loads the model and writes the pictures.
            /// </summary>
            private readonly IDiagramReportGenerator generator;

            /// <summary>
            /// The check for a newer release of the tool.
            /// </summary>
            private readonly IVersionChecker versionChecker;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="generator">the generator that loads the model and writes the pictures</param>
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
            /// <returns>zero when the pictures were written, a non-zero code when they were not</returns>
            public async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var model = parseResult.GetValue<FileInfo>("model")!;
                var output = parseResult.GetValue<DirectoryInfo>("--output")!;

                Ui.Logo(parseResult.GetValue<bool>("--no-logo"));

                await this.versionChecker.ExecuteAsync(cancellationToken);

                if (!model.Exists && !Directory.Exists(model.FullName))
                {
                    Ui.Problem("That Capella model does not exist.", model.FullName);

                    return -1;
                }

                DiagramReportOptions options;

                try
                {
                    options = BuildOptions(parseResult);
                }
                catch (ArgumentException exception)
                {
                    Ui.Problem(exception.Message);

                    return -1;
                }

                WriteSettings(model, output, options, parseResult.GetValue<string>("--format")!);

                try
                {
                    var stopwatch = Stopwatch.StartNew();
                    var written = this.Run(model, output, options);
                    stopwatch.Stop();

                    if (written.Count == 0)
                    {
                        Ui.Problem("Nothing matched, so nothing was written.", options.NameFilter);

                        return 0;
                    }

                    WriteSummary(written, output, stopwatch.Elapsed);

                    if (parseResult.GetValue<bool>("--open"))
                    {
                        Open(output);
                    }

                    return 0;
                }
                catch (OperationCanceledException)
                {
                    AnsiConsole.MarkupLine("[yellow]Cancelled — the pictures written so far are in place.[/]");

                    throw;
                }
                catch (Exception exception) when (exception is IOException or InvalidDataException or UnauthorizedAccessException or PlatformNotSupportedException)
                {
                    Ui.Problem("The export could not complete.", exception.Message);

                    return -1;
                }
                catch (Exception exception)
                {
                    Ui.Crash(exception);

                    return -1;
                }
            }

            /// <summary>
            /// Runs the export behind a progress display driven by the generator's own reports.
            /// </summary>
            /// <param name="model">the model to export</param>
            /// <param name="output">the directory the pictures are written to</param>
            /// <param name="options">what to write and how</param>
            /// <returns>the files written</returns>
            private IReadOnlyList<FileInfo> Run(FileInfo model, DirectoryInfo output, DiagramReportOptions options)
            {
                IReadOnlyList<FileInfo> written = Array.Empty<FileInfo>();

                AnsiConsole.Progress()
                    .AutoClear(false)
                    .HideCompleted(false)
                    .Columns(
                        new TaskDescriptionColumn { Alignment = Justify.Left },
                        new ProgressBarColumn(),
                        new PercentageColumn(),
                        new ElapsedTimeColumn(),
                        new SpinnerColumn(Spinner.Known.Dots))
                    .Start(context =>
                    {
                        var reading = context.AddTask($"[green]Reading[/] {Ui.Escape(model.Name)}", maxValue: 1);

                        // Both tasks exist from the start, the writing one unstarted until there is
                        // something to write: how many diagrams there are is only known once the
                        // model has been read, and its maximum is raised then.
                        var writing = context.AddTask("[grey]Waiting to write[/]", autoStart: false, maxValue: 1);

                        // The generator runs on this thread, so the reports arrive here rather than
                        // on a pool thread — a plain Progress<T> would post them elsewhere and the
                        // bar would lag behind the work.
                        var progress = new SynchronousProgress<DiagramReportProgress>(report =>
                        {
                            switch (report.Stage)
                            {
                                case DiagramReportStage.Building:
                                    reading.Description = $"[green]Read[/] {Ui.Escape(model.Name)}, building diagrams";
                                    break;

                                case DiagramReportStage.Writing:
                                    reading.Value = 1;

                                    if (!writing.IsStarted)
                                    {
                                        writing.StartTask();
                                    }

                                    writing.MaxValue = Math.Max(1, report.Total);
                                    writing.Value = report.Completed;
                                    writing.Description = $"[green]Writing[/] {Ui.Escape(Shorten(report.Subject))}";
                                    break;

                                case DiagramReportStage.WritingWorkbook:
                                    context.AddTask("[green]Writing[/] the table workbook", maxValue: 1).Value = 1;
                                    break;
                            }
                        });

                        written = this.generator.Generate(model, output, options, progress);

                        reading.Value = 1;

                        if (writing.IsStarted)
                        {
                            writing.Value = writing.MaxValue;
                            writing.Description = "[green]Wrote[/] every diagram";
                        }
                    });

                return written;
            }

            /// <summary>
            /// The options the command line asks for.
            /// </summary>
            /// <param name="parseResult">the parsed command line</param>
            /// <returns>the options</returns>
            /// <exception cref="ArgumentException">a value names something the tool does not know</exception>
            private static DiagramReportOptions BuildOptions(ParseResult parseResult)
            {
                var dpi = parseResult.GetValue<double>("--dpi");

                var raster = dpi > 0
                    ? RasterOptions.FromDpi(dpi)
                    : new RasterOptions { Scale = parseResult.GetValue<double>("--scale") };

                raster.Quality = parseResult.GetValue<int>("--quality");

                var background = parseResult.GetValue<string>("--background");

                if (!string.IsNullOrEmpty(background))
                {
                    raster.Background = OptionParsing.Colour(background);
                }

                return new DiagramReportOptions
                {
                    Formats = OptionParsing.Formats(parseResult.GetValue<string>("--format")),
                    NameFilter = parseResult.GetValue<string>("--name"),
                    Raster = raster,
                };
            }

            /// <summary>
            /// Writes what the run was asked to do, so the output says what produced it.
            /// </summary>
            /// <param name="model">the model being exported</param>
            /// <param name="output">the directory the pictures go to</param>
            /// <param name="options">the options in force</param>
            /// <param name="formats">the formats as the caller wrote them</param>
            private static void WriteSettings(FileInfo model, DirectoryInfo output, DiagramReportOptions options, string formats)
            {
                var grid = new Grid()
                    .AddColumn(new GridColumn().NoWrap().PadRight(3))
                    .AddColumn();

                grid.AddRow("[grey]model[/]", Ui.Escape(model.FullName));
                grid.AddRow("[grey]output[/]", Ui.Escape(output.FullName));
                grid.AddRow("[grey]formats[/]", Ui.Escape(formats));
                grid.AddRow("[grey]scale[/]", options.Raster.Scale.ToString("0.##", CultureInfo.InvariantCulture));
                grid.AddRow("[grey]background[/]", options.Raster.Background?.ToHex() ?? "[grey]per format[/]");

                if (!string.IsNullOrEmpty(options.NameFilter))
                {
                    grid.AddRow("[grey]filter[/]", Ui.Escape(options.NameFilter));
                }

                AnsiConsole.Write(new Panel(grid).Header("[bold] exporting [/]").RoundedBorder().BorderColor(Color.Grey));
                AnsiConsole.WriteLine();
            }

            /// <summary>
            /// Writes what the run produced: a breakdown per format, and where it went.
            /// </summary>
            /// <param name="written">the files written</param>
            /// <param name="output">the directory they went to</param>
            /// <param name="elapsed">how long the run took</param>
            private static void WriteSummary(IReadOnlyList<FileInfo> written, DirectoryInfo output, TimeSpan elapsed)
            {
                AnsiConsole.WriteLine();
                Ui.Section("result");

                var table = new Table()
                    .SimpleBorder()
                    .BorderColor(Color.Grey)
                    .AddColumn("[bold]format[/]")
                    .AddColumn("[grey]files[/]", column => column.RightAligned())
                    .AddColumn("[grey]size[/]", column => column.RightAligned());

                foreach (var group in written.GroupBy(file => file.Extension.TrimStart('.').ToLowerInvariant()).OrderBy(group => group.Key, StringComparer.Ordinal))
                {
                    table.AddRow(
                        group.Key,
                        group.Count().ToString(CultureInfo.InvariantCulture),
                        Ui.Size(group.Sum(file => file.Length)));
                }

                table.AddEmptyRow();
                table.AddRow(
                    "[bold]total[/]",
                    $"[bold]{written.Count.ToString(CultureInfo.InvariantCulture)}[/]",
                    $"[bold]{Ui.Size(written.Sum(file => file.Length))}[/]");

                AnsiConsole.Write(table);
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine($"[green]Done[/] in {Ui.Duration(elapsed)} — written to [bold]{Ui.Escape(output.FullName)}[/]");
                AnsiConsole.WriteLine();
            }

            /// <summary>
            /// A diagram name short enough to sit on a progress bar without wrapping it.
            /// </summary>
            /// <param name="name">the name</param>
            /// <returns>the shortened name</returns>
            private static string Shorten(string name)
            {
                const int Limit = 46;

                return name.Length <= Limit ? name : name[..(Limit - 1)] + "…";
            }

            /// <summary>
            /// Opens the output directory in the desktop's file manager, on a best-effort basis.
            /// </summary>
            /// <param name="output">the directory to open</param>
            private static void Open(DirectoryInfo output)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(output.FullName) { UseShellExecute = true });
                }
                catch (Exception exception) when (exception is System.ComponentModel.Win32Exception or InvalidOperationException or PlatformNotSupportedException)
                {
                    AnsiConsole.MarkupLine($"[yellow]The output directory could not be opened: {Ui.Escape(exception.Message)}[/]");
                }
            }

            /// <summary>
            /// An <see cref="IProgress{T}"/> that runs its callback where <see cref="IProgress{T}.Report"/>
            /// was called, rather than posting it elsewhere as <see cref="Progress{T}"/> does.
            /// </summary>
            /// <typeparam name="T">the reported value</typeparam>
            private sealed class SynchronousProgress<T> : IProgress<T>
            {
                /// <summary>
                /// What to do with each report.
                /// </summary>
                private readonly Action<T> report;

                /// <summary>
                /// Initializes a new instance of the <see cref="SynchronousProgress{T}"/> class.
                /// </summary>
                /// <param name="report">what to do with each report</param>
                public SynchronousProgress(Action<T> report)
                {
                    this.report = report;
                }

                /// <summary>
                /// Handles a report.
                /// </summary>
                /// <param name="value">the reported value</param>
                public void Report(T value)
                {
                    this.report(value);
                }
            }
        }
    }
}
