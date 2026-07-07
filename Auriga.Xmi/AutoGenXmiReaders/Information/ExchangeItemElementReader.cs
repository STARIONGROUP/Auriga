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
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

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
        public ExchangeItemElementReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>ExchangeItemElement</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Information.IExchangeItemElement"/></returns>
        public Auriga.Information.IExchangeItemElement Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Information.ExchangeItemElement();

            xmlReader.MoveToContent();

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
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDefaultValue":
                    {
                        var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedDefaultValue = contained;
                        break;
                    }
                        case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMaxCard":
                    {
                        var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedMaxCard = contained;
                        break;
                    }
                        case "ownedMaxLength":
                    {
                        var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedMaxLength = contained;
                        break;
                    }
                        case "ownedMaxValue":
                    {
                        var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedMaxValue = contained;
                        break;
                    }
                        case "ownedMigratedElements":
                        poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMinCard":
                    {
                        var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedMinCard = contained;
                        break;
                    }
                        case "ownedMinLength":
                    {
                        var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedMinLength = contained;
                        break;
                    }
                        case "ownedMinValue":
                    {
                        var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedMinValue = contained;
                        break;
                    }
                        case "ownedNullValue":
                    {
                        var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedNullValue = contained;
                        break;
                    }
                        case "ownedPropertyValueGroups":
                        poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValues":
                        poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader));
                        break;
                        default:
                            SkipElement(xmlReader);
                            break;
                    }
                }
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
