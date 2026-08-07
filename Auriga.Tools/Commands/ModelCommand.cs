// ------------------------------------------------------------------------------------------------
// <copyright file="ModelCommand.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Commands
{
    using System.CommandLine;
    using System.IO;

    using Serilog.Events;

    /// <summary>
    /// The options every command over a Capella model shares: which model, which representations,
    /// and how loud to be.
    /// </summary>
    public abstract class ModelCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCommand"/> class.
        /// </summary>
        /// <param name="name">the command's name on the command line</param>
        /// <param name="description">what the command does, shown in the help</param>
        protected ModelCommand(string name, string description)
            : base(name, description)
        {
            var model = new Argument<FileInfo>("model")
            {
                Description = "The Sirius .aird file of the Capella project, or the project directory holding exactly one",
            };

            this.Arguments.Add(model);

            var nameFilter = new Option<string>(name: "--name")
            {
                Description = "Only representations whose name matches this wildcard pattern, as in \"[SAB]*\". Use * for any run of characters and ? for one",
                Required = false,
            };

            nameFilter.Aliases.Add("-n");
            this.Options.Add(nameFilter);

            var noLogo = new Option<bool>(name: "--no-logo")
            {
                Description = "Suppress the splash screen",
                DefaultValueFactory = _ => false,
                Required = false,
            };

            this.Options.Add(noLogo);

            var logLevel = new Option<LogEventLevel>(name: "--log-level")
            {
                Description = "The level below which nothing is written to the log file",
                DefaultValueFactory = _ => LogEventLevel.Information,
                Required = false,
            };

            this.Options.Add(logLevel);
        }
    }
}
