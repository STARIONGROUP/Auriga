// ------------------------------------------------------------------------------------------------
// <copyright file="StrictReadingTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    /// <summary>
    /// Exercises the <see cref="IXmiReaderSettings.UseStrictReading"/> option (issue #46). A document that
    /// carries a child element outside the vendored metamodel reads under the default (lenient) setting —
    /// the element is skipped and a warning is logged — and throws a <see cref="NotSupportedException"/>
    /// under strict reading, naming the reader, the offending element and its line/position.
    /// </summary>
    [TestFixture]
    public class StrictReadingTestFixture
    {
        /// <summary>
        /// A well-formed Project whose one child, <c>unknownAddonFeature</c>, is not a role of Project in
        /// the vendored metamodel — the reader's <c>default:</c> switch branch, which the setting governs.
        /// </summary>
        private const string ProjectWithUnknownChild =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version=\"2.0\" " +
            "xmlns:xmi=\"http://www.omg.org/XMI\" " +
            "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns:org.polarsys.capella.core.data.capellamodeller=\"http://www.polarsys.org/capella/core/modeller/7.0.0\" " +
            "id=\"root-1\" name=\"Strict\">" +
            "<unknownAddonFeature id=\"x-1\"/>" +
            "</org.polarsys.capella.core.data.capellamodeller:Project>";

        [Test]
        public void Verify_that_strict_reading_throws_on_an_unrecognized_element()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.UseStrictReading = true)
                .Build();

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(ProjectWithUnknownChild));

            var exception = Assert.Throws<NotSupportedException>(() => reader.Read(stream, "strict"));

            Assert.That(exception!.Message, Does.Contain("ProjectReader").And.Contain("unknownAddonFeature"));
        }

        [Test]
        public void Verify_that_lenient_reading_skips_an_unrecognized_element_and_warns()
        {
            var loggerFactory = new CapturingLoggerFactory();

            // Lenient is the default; assert it explicitly so the intent is on the record.
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.UseStrictReading = false)
                .WithLogger(loggerFactory)
                .Build();

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(ProjectWithUnknownChild));

            var result = reader.Read(stream, "lenient");

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Has.Count.EqualTo(1), "the unrecognized element is skipped, not instantiated");
                Assert.That(loggerFactory.LoggedLevels, Has.Some.EqualTo(LogLevel.Warning), "the skipped element is reported as a warning");
            });
        }

        [Test]
        public void Verify_that_the_default_setting_is_lenient()
        {
            // No UsingSettings call at all: the out-of-the-box reader must not throw on unknown content.
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(ProjectWithUnknownChild));

            var result = XmiReaderBuilder.Create().Build().Read(stream, "default");

            Assert.That(result.Elements, Has.Count.EqualTo(1));
        }

        [Test]
        public void Verify_that_UsingSettings_returns_the_same_builder_and_rejects_null()
        {
            var builder = XmiReaderBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(builder.UsingSettings(x => x.UseStrictReading = true), Is.SameAs(builder));
                Assert.That(() => builder.UsingSettings(null!), Throws.ArgumentNullException);
            });
        }

        /// <summary>
        /// A minimal <see cref="ILoggerFactory"/> that records the level of every log entry its loggers
        /// emit, so a test can assert that a warning was produced without depending on the message text.
        /// </summary>
        private sealed class CapturingLoggerFactory : ILoggerFactory
        {
            public List<LogLevel> LoggedLevels { get; } = new List<LogLevel>();

            public ILogger CreateLogger(string categoryName)
            {
                return new CapturingLogger(this.LoggedLevels);
            }

            public void AddProvider(ILoggerProvider provider)
            {
            }

            public void Dispose()
            {
            }

            private sealed class CapturingLogger : ILogger
            {
                private readonly List<LogLevel> loggedLevels;

                public CapturingLogger(List<LogLevel> loggedLevels)
                {
                    this.loggedLevels = loggedLevels;
                }

                public IDisposable BeginScope<TState>(TState state)
                    where TState : notnull
                {
                    return NullScope.Instance;
                }

                public bool IsEnabled(LogLevel logLevel)
                {
                    return true;
                }

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
                {
                    this.loggedLevels.Add(logLevel);
                }

                private sealed class NullScope : IDisposable
                {
                    public static readonly NullScope Instance = new NullScope();

                    public void Dispose()
                    {
                    }
                }
            }
        }
    }
}
