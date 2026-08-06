// ------------------------------------------------------------------------------------------------
// <copyright file="Ui.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Presentation
{
    using System;
    using System.Globalization;

    using Auriga.Tools.Resources;

    using Spectre.Console;

    /// <summary>
    /// The console vocabulary the commands share: the splash screen, section rules, the way a
    /// failure is reported, and the byte and duration formats.
    /// </summary>
    /// <remarks>
    /// Everything a model supplies goes through <see cref="Escape"/>. Spectre's markup uses square
    /// brackets, and Capella diagram names are full of them — <c>[SAB] High Level System
    /// Overview</c> — so an unescaped name is at best swallowed and at worst throws while rendering
    /// the very output that was meant to explain what happened.
    /// </remarks>
    public static class Ui
    {
        /// <summary>
        /// Writes the splash screen, unless the caller asked for quiet.
        /// </summary>
        /// <param name="suppress">whether <c>--no-logo</c> was given</param>
        public static void Logo(bool suppress)
        {
            if (suppress)
            {
                return;
            }

            AnsiConsole.Write(new Markup($"[blue]{Escape(ResourceLoader.QueryLogo())}[/]"));
            AnsiConsole.WriteLine();
        }

        /// <summary>
        /// Writes a section heading.
        /// </summary>
        /// <param name="title">the heading</param>
        public static void Section(string title)
        {
            AnsiConsole.Write(new Rule($"[yellow]{Escape(title)}[/]").LeftJustified().RuleStyle("grey"));
        }

        /// <summary>
        /// Text that came from a model or from the file system, safe to put in markup.
        /// </summary>
        /// <param name="text">the text</param>
        /// <returns>the escaped text</returns>
        public static string Escape(string? text)
        {
            return Markup.Escape(text ?? string.Empty);
        }

        /// <summary>
        /// Reports a failure the user can act on, without a stack trace.
        /// </summary>
        /// <param name="message">what went wrong</param>
        /// <param name="detail">the offending value, or <c>null</c></param>
        public static void Problem(string message, string? detail = null)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Panel(new Markup($"[red]{Escape(message)}[/]" + (detail == null ? string.Empty : $"\n[grey]{Escape(detail)}[/]")))
                .Header("[red] problem [/]")
                .BorderColor(Color.Red)
                .RoundedBorder());
            AnsiConsole.WriteLine();
        }

        /// <summary>
        /// Reports an unexpected failure, with the exception rendered and a link to report it.
        /// </summary>
        /// <param name="exception">the failure</param>
        public static void Crash(Exception exception)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[red]Something went wrong that should not have.[/]");
            AnsiConsole.MarkupLine("[grey]Please report it at[/] [link]https://github.com/STARIONGROUP/Auriga/issues[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.WriteException(exception, ExceptionFormats.ShortenPaths | ExceptionFormats.ShortenTypes);
            AnsiConsole.WriteLine();
        }

        /// <summary>
        /// A byte count in the unit a reader wants.
        /// </summary>
        /// <param name="bytes">the count</param>
        /// <returns>the formatted size</returns>
        public static string Size(long bytes)
        {
            string[] units = { "B", "KB", "MB", "GB" };
            double size = bytes;
            var unit = 0;

            while (size >= 1024 && unit < units.Length - 1)
            {
                size /= 1024;
                unit++;
            }

            return string.Format(CultureInfo.InvariantCulture, unit == 0 ? "{0:0} {1}" : "{0:0.#} {1}", size, units[unit]);
        }

        /// <summary>
        /// A duration in the unit a reader wants.
        /// </summary>
        /// <param name="elapsed">the duration</param>
        /// <returns>the formatted duration</returns>
        public static string Duration(TimeSpan elapsed)
        {
            return elapsed.TotalSeconds < 1
                ? string.Format(CultureInfo.InvariantCulture, "{0:0} ms", elapsed.TotalMilliseconds)
                : string.Format(CultureInfo.InvariantCulture, "{0:0.0} s", elapsed.TotalSeconds);
        }
    }
}
