// ------------------------------------------------------------------------------------------------
// <copyright file="ExchangeItemReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Xmi.AutoGenXmiReaders.Information
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>ExchangeItem</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class ExchangeItemReader : XmiElementReader<Auriga.Information.IExchangeItem>, IXmiElementReader<Auriga.Information.IExchangeItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeItemReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ExchangeItemReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>ExchangeItem</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Information.IExchangeItem"/></returns>
        public Auriga.Information.IExchangeItem Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.Information.ExchangeItem();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                { var raw = xmlReader.GetAttribute("abstract"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Abstract = parsed; } }
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
                poco.Description = xmlReader.GetAttribute("description");
                { if (TryParseEnum<Auriga.Information.ExchangeMechanism>(xmlReader.GetAttribute("exchangeMechanism"), out var parsed)) { poco.ExchangeMechanism = parsed; } }
                CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
                { var raw = xmlReader.GetAttribute("final"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Final = parsed; } }
                poco.Name = xmlReader.GetAttribute("name");
                poco.Review = xmlReader.GetAttribute("review");
                poco.Sid = xmlReader.GetAttribute("sid");
                CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
                poco.Summary = xmlReader.GetAttribute("summary");
                { var raw = xmlReader.GetAttribute("visibleInDoc"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.VisibleInDoc = parsed; } }
                { var raw = xmlReader.GetAttribute("visibleInLM"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.VisibleInLM = parsed; } }

                this.Cache.TryAdd(poco);

                if (!xmlReader.IsEmptyElement)
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType != XmlNodeType.Element)
                        {
                            continue;
                        }

                        switch (xmlReader.LocalName)
                        {
                            case "appliedPropertyValueGroups":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
                            break;
                        }
                            case "appliedPropertyValues":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "AppliedPropertyValues", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
                            break;
                        }
                            case "features":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "Features", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
                            break;
                        }
                            case "namingRules":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "NamingRules", href); SkipElement(xmlReader); }
                            else { poco.NamingRules.Add((Auriga.Capellacore.INamingRule)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedConstraints":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedConstraints", href); SkipElement(xmlReader); }
                            else { poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedElements":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedElements", href); SkipElement(xmlReader); }
                            else { poco.OwnedElements.Add((Auriga.Information.IExchangeItemElement)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedEnumerationPropertyTypes":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedEnumerationPropertyTypes", href); SkipElement(xmlReader); }
                            else { poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedExchangeItemInstances":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedExchangeItemInstances", href); SkipElement(xmlReader); }
                            else { poco.OwnedExchangeItemInstances.Add((Auriga.Information.IExchangeItemInstance)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedExtensions":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedExtensions", href); SkipElement(xmlReader); }
                            else { poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedGeneralizations":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedGeneralizations", href); SkipElement(xmlReader); }
                            else { poco.OwnedGeneralizations.Add((Auriga.Capellacore.IGeneralization)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedInformationRealizations":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedInformationRealizations", href); SkipElement(xmlReader); }
                            else { poco.OwnedInformationRealizations.Add((Auriga.Information.IInformationRealization)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedMigratedElements":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedMigratedElements", href); SkipElement(xmlReader); }
                            else { poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedPropertyValueGroups":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedPropertyValueGroups", href); SkipElement(xmlReader); }
                            else { poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedPropertyValues":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedPropertyValues", href); SkipElement(xmlReader); }
                            else { poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedTraces":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedTraces", href); SkipElement(xmlReader); }
                            else { poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "status":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "Status", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
                            break;
                        }
                            default:
                                this.Logger.LogTrace("Skipping unmapped element '{Element}' of ExchangeItem at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read ExchangeItem but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
