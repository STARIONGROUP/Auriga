// ------------------------------------------------------------------------------------------------
// <copyright file="RenderingLoggingTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.Reporting;
    using Auriga.Reporting.Icons;
    using Auriga.Reporting.Model;

    using Auriga.Xmi;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Notation = Auriga.Diagram.Notation;
    using SiriusDescription = Auriga.Diagram.Viewpoint.Description;
    using SiriusDiagram = Auriga.Diagram.Diagram;

    /// <summary>
    /// Tests that the rendering services report their silent degradations through the
    /// <see cref="ILoggerFactory"/> registered with <see cref="RenderingBuilder.WithLogger"/>: an
    /// image no registry resolved, a representation skipped for want of a persisted layout,
    /// persisted geometry that did not parse, and a style value that did not read. Every assertion
    /// runs through the composed scope rather than a hand-constructed service, so it proves the
    /// factory actually reaches the service that logs — and each case also asserts the fallback
    /// itself is unchanged, since the point of the logging is to explain a degradation, not to
    /// alter it.
    /// </summary>
    [TestFixture]
    public class RenderingLoggingTestFixture
    {
        /// <summary>
        /// A workspace-image path no registry resolves.
        /// </summary>
        private const string MissingImage = "Some Project/images/NotVendored.svg";

        /// <summary>
        /// The factory capturing what the composed services log, replaced per test.
        /// </summary>
        private CapturingLoggerFactory loggerFactory = null!;

        /// <summary>
        /// The scope composing the services under test over <see cref="loggerFactory"/>.
        /// </summary>
        private RenderingScope scope = null!;

        /// <summary>
        /// Composes a scope whose services log into a fresh capturing factory.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = new CapturingLoggerFactory();
            this.scope = RenderingBuilder.Create().WithLogger(this.loggerFactory);
        }

        /// <summary>
        /// Disposes the scope, and with it every service it composed.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.scope.Dispose();
        }

        [Test]
        public void Verify_that_an_unresolved_workspace_image_is_reported_once_per_path()
        {
            var nodes = Enumerable.Range(0, 3).Select(index => ImageNode($"n-image-{index}", MissingImage, index * 60)).ToArray();

            var diagram = this.scope.BuildDiagramBuilder().Build(Representation(nodes));
            var svg = this.scope.BuildSvgExporter().Export(diagram);

            Assert.Multiple(() =>
            {
                Assert.That(svg, Does.Not.Contain("<image"), "the unresolved image still degrades to the outline fallback");
                Assert.That(
                    this.loggerFactory.Entries.Count(entry => entry.Level == LogLevel.Debug && entry.Message.Contains(MissingImage)),
                    Is.EqualTo(1),
                    "the three boxes sharing the path are reported once, not three times");
            });
        }

        [Test]
        public void Verify_that_a_representation_without_a_notation_diagram_is_reported_as_skipped()
        {
            var built = Representation(Node("n-built", "built"));
            var skipped = new SiriusDiagram.DSemanticDiagram { Id = "rep-skipped" };
            var descriptor = new Auriga.Diagram.Viewpoint.DRepresentationDescriptor { RepPath = "#rep-skipped", Name = "Skipped Diagram" };

            var diagrams = this.scope.BuildDiagramBuilder().BuildAll(new Auriga.Core.IAurigaElement[] { built, skipped, descriptor });

            var skipEntry = this.loggerFactory.Entries.SingleOrDefault(entry => entry.Message.Contains("rep-skipped"));

            Assert.Multiple(() =>
            {
                Assert.That(diagrams, Has.Count.EqualTo(1), "the representation without a notation diagram is still skipped");
                Assert.That(skipEntry, Is.Not.Null, "the skipped representation is reported");
                Assert.That(skipEntry!.Level, Is.EqualTo(LogLevel.Debug));
                Assert.That(skipEntry.Message, Does.Contain("Skipped Diagram").And.Contain("no GMF notation diagram"), "with its name and the reason");
                Assert.That(this.loggerFactory.Entries.Select(entry => entry.Message), Has.Some.Contains("Built 1 of 2"), "and the built count is reported");
            });
        }

        [Test]
        public void Verify_that_malformed_bendpoints_and_anchors_are_reported_and_still_fall_back()
        {
            var sourceNode = Node("n-src-malformed", "source");
            sourceNode.LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 100, Height = 100 };
            var targetNode = Node("n-tgt-malformed", "target");
            targetNode.LayoutConstraint = new Notation.Bounds { X = 200, Y = 0, Width = 100, Height = 100 };

            var notationEdge = new Notation.Edge
            {
                Id = "n-edge-malformed",
                Source = sourceNode,
                Target = targetNode,
                SourceAnchor = new Notation.IdentityAnchor { Id = "(left,middle)" },
                Bendpoints = new Notation.RelativeBendpoints { Points = "[0, 0, -100, 0]$[not a bendpoint]$[0, 0, 0, 0]" },
            };

            var diagram = this.scope.BuildDiagramBuilder().Build(Representation(new[] { sourceNode, targetNode }, new[] { notationEdge }));

            var messages = this.loggerFactory.Entries.Where(entry => entry.Level == LogLevel.Debug).Select(entry => entry.Message).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(
                    diagram.Edges.Single().Route,
                    Is.EqualTo(new[] { new Point(100, 50), new Point(200, 50) }),
                    "both ends still fall back to the view centres");
                Assert.That(messages, Has.Some.Contains("malformed bendpoint entries").And.Some.Contains("not a bendpoint"), "the discarded bendpoint entry is reported");
                Assert.That(messages, Has.Some.Contains("(left,middle)"), "the anchor id that is not a fraction is reported");
                Assert.That(messages, Has.Some.Contains(diagram.Identifier), "both naming the representation they came from");
            });
        }

        [Test]
        public void Verify_that_a_malformed_style_value_is_traced_and_an_absent_one_is_not()
        {
            var malformed = Node("n-style-malformed", "malformed");
            ((SiriusDiagram.DNode)malformed.Element!).OwnedStyle = new SiriusDiagram.Square { Color = "not,a,color" };

            // The metamodel seeds every colour of a Square with a well-formed default, so an
            // unpersisted colour has to be cleared to model the absent case.
            var absent = Node("n-style-absent", "absent");
            ((SiriusDiagram.DNode)absent.Element!).OwnedStyle = new SiriusDiagram.Square { Color = null! };

            var diagram = this.scope.BuildDiagramBuilder().Build(Representation(new[] { malformed, absent }));

            var traces = this.loggerFactory.Entries.Where(entry => entry.Level == LogLevel.Trace).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(
                    diagram.Boxes.Select(box => box.Style.Resolved.FillColor),
                    Is.All.Null,
                    "both boxes still keep the palette default in place");
                Assert.That(traces, Has.Count.EqualTo(1), "an absent value is not a degradation and is not traced");
                Assert.That(traces[0].Message, Does.Contain("not,a,color").And.Contain("fill"));
            });
        }

        [Test]
        public void Verify_that_the_icon_registries_trace_once_per_unresolved_path()
        {
            var capellaIcons = new CapellaIconRegistry(this.loggerFactory);
            var workspaceImages = new WorkspaceImageRegistry(TestContext.CurrentContext.TestDirectory, this.loggerFactory);

            capellaIcons.Resolve(MissingImage);
            capellaIcons.Resolve(MissingImage);
            workspaceImages.Resolve(MissingImage);
            workspaceImages.Resolve(MissingImage);

            Assert.Multiple(() =>
            {
                Assert.That(this.loggerFactory.Entries, Is.All.Matches<LogEntry>(entry => entry.Level == LogLevel.Trace));
                Assert.That(
                    this.loggerFactory.Entries.Count(entry => entry.Category == typeof(CapellaIconRegistry).FullName),
                    Is.EqualTo(1),
                    "the vendored registry traces the file name once, its cache absorbing the repeat");
                Assert.That(
                    this.loggerFactory.Entries.Count(entry => entry.Category == typeof(WorkspaceImageRegistry).FullName),
                    Is.EqualTo(1),
                    "and so does the workspace registry");
            });
        }

        [Test]
        public void Verify_that_a_real_model_reports_at_debug_and_stays_silent_at_information_and_above()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird");
            using var readerScope = XmiReaderBuilder.Create();
            var result = readerScope.BuildAirdModelLoader().Load(path);

            var exporter = this.scope.BuildSvgExporter();
            var diagrams = this.scope.BuildDiagramBuilder().BuildAll(result.Elements.Values);
            foreach (var diagram in diagrams)
            {
                exporter.Export(diagram);
            }

            Assert.Multiple(() =>
            {
                Assert.That(
                    this.loggerFactory.Entries.Select(entry => entry.Message),
                    Has.Some.Contains($"Built {diagrams.Count} of"),
                    "a whole-model build reports what it built");
                Assert.That(
                    this.loggerFactory.Entries.Where(entry => entry.Level >= LogLevel.Information),
                    Is.Empty,
                    "and rendering a well-formed model reports nothing a consumer has to act on");
            });
        }

        /// <summary>
        /// Builds a top-level notation node displaying a named Sirius node.
        /// </summary>
        /// <param name="identifier">the notation identifier</param>
        /// <param name="name">the Sirius element name</param>
        /// <returns>the notation node</returns>
        private static Notation.Node Node(string identifier, string name)
        {
            return new Notation.Node
            {
                Id = identifier,
                Element = new SiriusDiagram.DNode { Id = $"sirius-{identifier}", Name = name },
                LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 40, Height = 20 },
            };
        }

        /// <summary>
        /// Builds a top-level notation node whose Sirius style is a workspace image.
        /// </summary>
        /// <param name="identifier">the notation identifier</param>
        /// <param name="workspacePath">the persisted workspace-image path</param>
        /// <param name="x">the persisted x coordinate, so the boxes do not overlap</param>
        /// <returns>the notation node</returns>
        private static Notation.Node ImageNode(string identifier, string workspacePath, double x)
        {
            return new Notation.Node
            {
                Id = identifier,
                Element = new SiriusDiagram.DNode
                {
                    Id = $"sirius-{identifier}",
                    OwnedStyle = new SiriusDiagram.WorkspaceImage { WorkspacePath = workspacePath },
                },
                LayoutConstraint = new Notation.Bounds { X = (int)x, Y = 0, Width = 40, Height = 40 },
            };
        }

        /// <summary>
        /// Wraps the supplied top-level notation nodes in a representation carrying their GMF
        /// notation diagram, the shape the builder consumes.
        /// </summary>
        /// <param name="nodes">the top-level notation nodes</param>
        /// <param name="edges">the notation edges, if any</param>
        /// <returns>the Sirius representation</returns>
        private static SiriusDiagram.DSemanticDiagram Representation(IEnumerable<Notation.INode> nodes, IEnumerable<Notation.IEdge>? edges = null)
        {
            var notationDiagram = new Notation.Diagram { Id = "notation-logging" };

            foreach (var node in nodes)
            {
                notationDiagram.PersistedChildren.Add(node);
            }

            foreach (var edge in edges ?? Array.Empty<Notation.IEdge>())
            {
                notationDiagram.PersistedEdges.Add(edge);
            }

            var representation = new SiriusDiagram.DSemanticDiagram { Id = "rep-logging" };
            representation.OwnedAnnotationEntries.Add(new SiriusDescription.AnnotationEntry
            {
                Source = "GMF_DIAGRAMS",
                Data = notationDiagram,
            });

            return representation;
        }

        /// <summary>
        /// Wraps a single top-level notation node in a representation.
        /// </summary>
        /// <param name="node">the top-level notation node</param>
        /// <returns>the Sirius representation</returns>
        private static SiriusDiagram.DSemanticDiagram Representation(Notation.INode node)
        {
            return Representation(new[] { node });
        }

        /// <summary>
        /// One captured log entry: the level it was written at, the category of the logger that
        /// wrote it, and the formatted message.
        /// </summary>
        private sealed class LogEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="LogEntry"/> class.
            /// </summary>
            /// <param name="level">the level the entry was written at</param>
            /// <param name="category">the category of the logger that wrote it</param>
            /// <param name="message">the formatted message</param>
            internal LogEntry(LogLevel level, string category, string message)
            {
                this.Level = level;
                this.Category = category;
                this.Message = message;
            }

            /// <summary>
            /// Gets the level the entry was written at.
            /// </summary>
            internal LogLevel Level { get; }

            /// <summary>
            /// Gets the category of the logger that wrote the entry.
            /// </summary>
            internal string Category { get; }

            /// <summary>
            /// Gets the formatted message.
            /// </summary>
            internal string Message { get; }
        }

        /// <summary>
        /// An <see cref="ILoggerFactory"/> that records every entry its loggers emit — level,
        /// category and formatted message — so a test can assert what a service reported and at
        /// which level. Every level is enabled, so the level-guarded paths run.
        /// </summary>
        private sealed class CapturingLoggerFactory : ILoggerFactory
        {
            /// <summary>
            /// Gets the entries the composed services emitted, in order.
            /// </summary>
            internal List<LogEntry> Entries { get; } = new List<LogEntry>();

            /// <summary>
            /// Creates a logger writing into <see cref="Entries"/> under the supplied category.
            /// </summary>
            /// <param name="categoryName">the logger's category</param>
            /// <returns>the capturing logger</returns>
            public ILogger CreateLogger(string categoryName)
            {
                return new CapturingLogger(this.Entries, categoryName);
            }

            /// <summary>
            /// Ignores the provider: this factory is the sink itself.
            /// </summary>
            /// <param name="provider">the provider to add</param>
            public void AddProvider(ILoggerProvider provider)
            {
            }

            /// <summary>
            /// Releases nothing: the captured entries stay readable after the scope is disposed.
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// The logger recording into the factory's entry list.
            /// </summary>
            private sealed class CapturingLogger : ILogger
            {
                /// <summary>
                /// The list the entries are recorded in.
                /// </summary>
                private readonly List<LogEntry> entries;

                /// <summary>
                /// The category this logger was created under.
                /// </summary>
                private readonly string category;

                /// <summary>
                /// Initializes a new instance of the <see cref="CapturingLogger"/> class.
                /// </summary>
                /// <param name="entries">the list the entries are recorded in</param>
                /// <param name="category">the category this logger was created under</param>
                internal CapturingLogger(List<LogEntry> entries, string category)
                {
                    this.entries = entries;
                    this.category = category;
                }

                /// <summary>
                /// Begins a no-op scope.
                /// </summary>
                /// <typeparam name="TState">the scope state type</typeparam>
                /// <param name="state">the scope state</param>
                /// <returns>the no-op scope</returns>
                public IDisposable BeginScope<TState>(TState state)
                {
                    return NullScope.Instance;
                }

                /// <summary>
                /// Enables every level, so the services' level guards do not suppress what a test
                /// is asserting.
                /// </summary>
                /// <param name="logLevel">the level being tested</param>
                /// <returns>true</returns>
                public bool IsEnabled(LogLevel logLevel)
                {
                    return true;
                }

                /// <summary>
                /// Records the formatted entry.
                /// </summary>
                /// <typeparam name="TState">the entry state type</typeparam>
                /// <param name="logLevel">the level the entry was written at</param>
                /// <param name="eventId">the event id</param>
                /// <param name="state">the entry state</param>
                /// <param name="exception">the exception, or null</param>
                /// <param name="formatter">the message formatter</param>
                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
                {
                    this.entries.Add(new LogEntry(logLevel, this.category, formatter(state, exception)));
                }

                /// <summary>
                /// The scope a capturing logger hands out.
                /// </summary>
                private sealed class NullScope : IDisposable
                {
                    /// <summary>
                    /// The single instance.
                    /// </summary>
                    internal static readonly NullScope Instance = new NullScope();

                    /// <summary>
                    /// Releases nothing.
                    /// </summary>
                    public void Dispose()
                    {
                    }
                }
            }
        }
    }
}
