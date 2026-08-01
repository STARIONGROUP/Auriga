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
    using System.Linq;
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
        /// <param name="owner">the enclosing box, which names an item that has no name of its own</param>
        /// <returns>the hover text, or <c>null</c></returns>
        internal static string? ForBox(object? semanticElement, SiriusDiagramModel.IDDiagramElement? siriusElement, NotationModel.IView notationView, Box? owner)
        {
            var heading = Heading(semanticElement, siriusElement, notationView);

            // An execution bar or an interaction state is nameless in the model and on the diagram
            // alike; what identifies it is the lifeline it runs on, so the owner stands in.
            if (heading != null && heading.IndexOf(':') < 0 && OwnerName(owner) is { } ownerName)
            {
                heading = $"{heading} in {ownerName}";
            }

            return Compose(heading, null, Detail(semanticElement, siriusElement));
        }

        /// <summary>
        /// The hover text of a built relationship, which names the elements it connects between its
        /// heading and its detail — a line on a diagram says least about itself, so the ends are
        /// what make its tooltip worth reading. An edge whose own type is unknown still gets a
        /// tooltip when its ends are known.
        /// </summary>
        /// <param name="semanticElement">the resolved Capella semantic element, or <c>null</c></param>
        /// <param name="siriusElement">the Sirius representation element, or <c>null</c></param>
        /// <param name="notationView">the GMF notation view the edge was built from</param>
        /// <param name="source">the box the edge leaves, or <c>null</c> when the end does not resolve to one</param>
        /// <param name="target">the box the edge enters, or <c>null</c> when the end does not resolve to one</param>
        /// <returns>the hover text, or <c>null</c></returns>
        internal static string? ForEdge(object? semanticElement, SiriusDiagramModel.IDDiagramElement? siriusElement, NotationModel.IView notationView, Box? source, Box? target)
        {
            return Compose(Heading(semanticElement, siriusElement, notationView), Ends(source, target), Detail(semanticElement, siriusElement));
        }

        /// <summary>
        /// Joins the lines that are present into the hover text, or <c>null</c> when none is.
        /// </summary>
        /// <param name="heading">the heading line, or <c>null</c></param>
        /// <param name="ends">the connected-ends line, or <c>null</c></param>
        /// <param name="detail">the detail line, or <c>null</c></param>
        /// <returns>the hover text, or <c>null</c></returns>
        private static string? Compose(string? heading, string? ends, string? detail)
        {
            var lines = new[] { heading, ends, detail }.Where(line => line != null);

            var tooltip = string.Join("\n", lines);

            return tooltip.Length == 0 ? null : tooltip;
        }

        /// <summary>
        /// The heading of a built item: the Capella semantic element's metaclass, qualified by its
        /// name — or, when the semantic element is unnamed, by the name the diagram displays for it
        /// (a <c>StateFragment</c> or an <c>Execution</c> has no name of its own, but the Sirius
        /// element that shows it does). It falls back to the Sirius element's own type and name
        /// when the semantic target is unresolved, and to the notation type for a pure notation
        /// element.
        /// </summary>
        /// <param name="semanticElement">the resolved Capella semantic element, or <c>null</c></param>
        /// <param name="siriusElement">the Sirius representation element, or <c>null</c></param>
        /// <param name="notationView">the GMF notation view the item was built from</param>
        /// <returns>the heading, or <c>null</c> when the item represents nothing nameable</returns>
        private static string? Heading(object? semanticElement, SiriusDiagramModel.IDDiagramElement? siriusElement, NotationModel.IView notationView)
        {
            if (semanticElement != null)
            {
                var semanticName = (semanticElement as Auriga.Model.Modellingcore.IAbstractNamedElement)?.Name;

                return Qualified(semanticElement.GetType().Name, Trimmed(semanticName) ?? siriusElement?.Name);
            }

            return siriusElement != null
                ? Qualified(siriusElement.GetType().Name, siriusElement.Name)
                : Trimmed(notationView.Type);
        }

        /// <summary>
        /// The line naming what a relationship connects, or <c>null</c> when neither end resolves
        /// to a box. Each end is named as the diagram labels it, falling back to the heading of its
        /// own tooltip when it carries no label.
        /// </summary>
        /// <param name="source">the box the edge leaves, or <c>null</c></param>
        /// <param name="target">the box the edge enters, or <c>null</c></param>
        /// <returns>the connected-ends line, or <c>null</c></returns>
        private static string? Ends(Box? source, Box? target)
        {
            var from = EndName(source);
            var to = EndName(target);

            if (from != null && to != null)
            {
                return $"{from} → {to}";
            }

            if (from != null)
            {
                return $"from {from}";
            }

            return to == null ? null : $"to {to}";
        }

        /// <summary>
        /// How an edge end is named in the connected-ends line: the label the diagram shows on the
        /// box, or — for an end the diagram leaves unlabelled, which a port always is — the element
        /// that owns it, so a component exchange reads as the components it runs between rather
        /// than as two identically named ports. The heading of the end's own tooltip is the last
        /// resort.
        /// </summary>
        /// <param name="box">the box an edge end attaches to, or <c>null</c></param>
        /// <returns>the end's name, or <c>null</c></returns>
        private static string? EndName(Box? box)
        {
            if (box == null)
            {
                return null;
            }

            return Trimmed(box.Label?.Text) ?? OwnerName(box.Parent) ?? Trimmed(box.Tooltip?.Split('\n')[0]);
        }

        /// <summary>
        /// The label of the nearest enclosing box that carries one, or <c>null</c> when no ancestor
        /// is labelled.
        /// </summary>
        /// <param name="owner">the enclosing box, or <c>null</c></param>
        /// <returns>the owner's name, or <c>null</c></returns>
        private static string? OwnerName(Box? owner)
        {
            for (var ancestor = owner; ancestor != null; ancestor = ancestor.Parent)
            {
                if (Trimmed(ancestor.Label?.Text) is { } name)
                {
                    return name;
                }
            }

            return null;
        }

        /// <summary>
        /// The detail line of a built item: the model's own words about it — the semantic element's
        /// <c>description</c> as plain text, or the Sirius element's persisted tooltip when the
        /// semantic element carries no description.
        /// </summary>
        /// <param name="semanticElement">the resolved Capella semantic element, or <c>null</c></param>
        /// <param name="siriusElement">the Sirius representation element, or <c>null</c></param>
        /// <returns>the detail line, or <c>null</c></returns>
        private static string? Detail(object? semanticElement, SiriusDiagramModel.IDDiagramElement? siriusElement)
        {
            return PlainText((semanticElement as Auriga.Model.Capellacore.ICapellaElement)?.Description)
                ?? PlainText(siriusElement?.TooltipText);
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
