// ------------------------------------------------------------------------------------------------
// <copyright file="ExchangeItemElementReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>ExchangeItemElement</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class ExchangeItemElementReader : XmiElementReader<Auriga.Information.IExchangeItemElement>, IXmiElementReader<Auriga.Information.IExchangeItemElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeItemElementReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ExchangeItemElementReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>ExchangeItemElement</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Information.IExchangeItemElement"/></returns>
        public Auriga.Information.IExchangeItemElement Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.Information.ExchangeItemElement();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                CollectSingleValueReference(poco, "AbstractType", xmlReader.GetAttribute("abstractType"));
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
                { var raw = xmlReader.GetAttribute("composite"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Composite = parsed; } }
                poco.Description = xmlReader.GetAttribute("description");
                { if (TryParseEnum<Auriga.Information.ParameterDirection>(xmlReader.GetAttribute("direction"), out var parsed)) { poco.Direction = parsed; } }
                CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
                { if (TryParseEnum<Auriga.Information.ElementKind>(xmlReader.GetAttribute("kind"), out var parsed)) { poco.Kind = parsed; } }
                { var raw = xmlReader.GetAttribute("maxInclusive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MaxInclusive = parsed; } }
                { var raw = xmlReader.GetAttribute("minInclusive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MinInclusive = parsed; } }
                poco.Name = xmlReader.GetAttribute("name");
                { var raw = xmlReader.GetAttribute("ordered"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Ordered = parsed; } }
                CollectMultiValueReferences(poco, "ReferencedProperties", xmlReader.GetAttribute("referencedProperties"));
                poco.Review = xmlReader.GetAttribute("review");
                poco.Sid = xmlReader.GetAttribute("sid");
                CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
                poco.Summary = xmlReader.GetAttribute("summary");
                { var raw = xmlReader.GetAttribute("unique"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Unique = parsed; } }
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
                            case "abstractType":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "AbstractType", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
                            break;
                        }
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
                            case "ownedConstraints":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedConstraints", href); SkipElement(xmlReader); }
                            else { poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedDefaultValue":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedDefaultValue", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedDefaultValue = contained; }
                            break;
                        }
                            case "ownedEnumerationPropertyTypes":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedEnumerationPropertyTypes", href); SkipElement(xmlReader); }
                            else { poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedExtensions":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedExtensions", href); SkipElement(xmlReader); }
                            else { poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedMaxCard":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedMaxCard", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedMaxCard = contained; }
                            break;
                        }
                            case "ownedMaxLength":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedMaxLength", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedMaxLength = contained; }
                            break;
                        }
                            case "ownedMaxValue":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedMaxValue", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedMaxValue = contained; }
                            break;
                        }
                            case "ownedMigratedElements":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedMigratedElements", href); SkipElement(xmlReader); }
                            else { poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            case "ownedMinCard":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedMinCard", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedMinCard = contained; }
                            break;
                        }
                            case "ownedMinLength":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedMinLength", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedMinLength = contained; }
                            break;
                        }
                            case "ownedMinValue":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedMinValue", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedMinValue = contained; }
                            break;
                        }
                            case "ownedNullValue":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "OwnedNullValue", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.OwnedNullValue = contained; }
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
                            case "referencedProperties":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "ReferencedProperties", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
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
                                this.Logger.LogTrace("Skipping unmapped element '{Element}' of ExchangeItemElement at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read ExchangeItemElement but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
