// ------------------------------------------------------------------------------------------------
// <copyright file="ElementTooltip.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System.Net;
    using System.Text.RegularExpressions;

    using NotationModel = Auriga.Diagram.Notation;
    using SiriusDiagramModel = Auriga.Diagram.Diagram;

    /// <summary>
    /// Composes the hover text of a built item from the back-links it carries: what the item
    /// represents, and what the model says about it. The builders resolve it once per item into
    /// <see cref="Box.Tooltip"/> and <see cref="Edge.Tooltip"/>, so an exporter renders the text
    /// (<see cref="SvgExporter"/> as an SVG <c>title</c> element) without reaching into the Capella
    /// or Sirius metamodels itself.
    /// </summary>
    internal static class ElementTooltip
    {
        /// <summary>
        /// Matches an HTML tag, so the markup Capella wraps a description in can be dropped.
        /// </summary>
        private static readonly Regex Tag = new("<[^>]+>", RegexOptions.Compiled);

        /// <summary>
        /// Matches a run of whitespace, so the line breaks and indentation of persisted HTML
        /// collapse into single spaces.
        /// </summary>
        private static readonly Regex WhitespaceRun = new(@"\s+", RegexOptions.Compiled);

        /// <summary>
        /// The hover text of a built item, or <c>null</c> when there is nothing to say about it —
        /// which is what a synthetic render-only artifact (a list container's title rule, a
        /// combined fragment's operand separator) resolves to, since it carries no semantic
        /// element, no Sirius element and no notation type of its own.
        /// </summary>
        /// <remarks>
        /// The heading names what the item represents: the Capella semantic element's type and
        /// name, falling back to the Sirius element's when the semantic target is unresolved (a
        /// diagram-only session) and to the notation type for a pure notation element such as a GMF
        /// note. The detail line carries the model's own words — the semantic element's
        /// <c>description</c> reduced to plain text, or the Sirius element's persisted tooltip when
        /// the semantic element has no description.
        /// </remarks>
        /// <param name="semanticElement">the resolved Capella semantic element, or <c>null</c></param>
        /// <param name="siriusElement">the Sirius representation element, or <c>null</c></param>
        /// <param name="notationView">the GMF notation view the item was built from</param>
        /// <returns>the hover text, or <c>null</c></returns>
        internal static string? For(object? semanticElement, SiriusDiagramModel.IDDiagramElement? siriusElement, NotationModel.IView notationView)
        {
            var heading = SemanticHeading(semanticElement)
                ?? SiriusHeading(siriusElement)
                ?? Trimmed(notationView.Type);

            var detail = PlainText((semanticElement as Auriga.Model.Capellacore.ICapellaElement)?.Description)
                ?? PlainText(siriusElement?.TooltipText);

            if (heading == null)
            {
                return detail;
            }

            return detail == null ? heading : $"{heading}\n{detail}";
        }

        /// <summary>
        /// The heading of a Capella semantic element: its metaclass name qualified by its name when
        /// it has one (e.g. <c>LogicalFunction: Broadcast Audio Video Streams</c>), the metaclass
        /// name alone otherwise.
        /// </summary>
        /// <param name="semanticElement">the resolved Capella semantic element, or <c>null</c></param>
        /// <returns>the heading, or <c>null</c> when there is no semantic element</returns>
        private static string? SemanticHeading(object? semanticElement)
        {
            if (semanticElement == null)
            {
                return null;
            }

            return Qualified(semanticElement.GetType().Name, (semanticElement as Auriga.Model.Modellingcore.IAbstractNamedElement)?.Name);
        }

        /// <summary>
        /// The heading of a Sirius representation element, used when the semantic target is
        /// unresolved: its type qualified by the name the diagram displays.
        /// </summary>
        /// <param name="siriusElement">the Sirius representation element, or <c>null</c></param>
        /// <returns>the heading, or <c>null</c> when there is no Sirius element</returns>
        private static string? SiriusHeading(SiriusDiagramModel.IDDiagramElement? siriusElement)
        {
            return siriusElement == null ? null : Qualified(siriusElement.GetType().Name, siriusElement.Name);
        }

        /// <summary>
        /// A type name qualified by an element name, or the type name alone when the element is
        /// unnamed.
        /// </summary>
        /// <param name="typeName">the type name</param>
        /// <param name="name">the element name, or <c>null</c></param>
        /// <returns>the qualified heading</returns>
        private static string Qualified(string typeName, string? name)
        {
            return Trimmed(name) is { } elementName ? $"{typeName}: {elementName}" : typeName;
        }

        /// <summary>
        /// Reduces the HTML Capella persists a description in to plain text: the markup is dropped,
        /// the entities are decoded and the whitespace is normalized to single spaces, so the
        /// tooltip carries the words and none of the formatting.
        /// </summary>
        /// <param name="html">the persisted description, or <c>null</c></param>
        /// <returns>the plain text, or <c>null</c> when there is none</returns>
        private static string? PlainText(string? html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return null;
            }

            // The tags become spaces rather than nothing, so that text either side of a block
            // element does not run together into one word.
            var text = WebUtility.HtmlDecode(Tag.Replace(html, " "));

            return Trimmed(WhitespaceRun.Replace(text, " "));
        }

        /// <summary>
        /// The trimmed value, or <c>null</c> when it is absent or blank.
        /// </summary>
        /// <param name="value">the value, or <c>null</c></param>
        /// <returns>the trimmed value, or <c>null</c></returns>
        private static string? Trimmed(string? value)
        {
            var trimmed = value?.Trim();
            return string.IsNullOrEmpty(trimmed) ? null : trimmed;
        }
    }
}
