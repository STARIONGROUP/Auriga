// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionalExchangeReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Fa
{
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>FunctionalExchange</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class FunctionalExchangeReader : XmiElementReader<Auriga.Fa.IFunctionalExchange>, IXmiElementReader<Auriga.Fa.IFunctionalExchange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalExchangeReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public FunctionalExchangeReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>FunctionalExchange</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Fa.IFunctionalExchange"/></returns>
        public Auriga.Fa.IFunctionalExchange Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Fa.FunctionalExchange();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
            CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
            poco.Description = xmlReader.GetAttribute("description");
            CollectMultiValueReferences(poco, "ExchangeSpecifications", xmlReader.GetAttribute("exchangeSpecifications"));
            CollectMultiValueReferences(poco, "ExchangedItems", xmlReader.GetAttribute("exchangedItems"));
            CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
            CollectSingleValueReference(poco, "Interrupts", xmlReader.GetAttribute("interrupts"));
            { var raw = xmlReader.GetAttribute("isMulticast"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsMulticast = parsed; } }
            { var raw = xmlReader.GetAttribute("isMultireceive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsMultireceive = parsed; } }
            { if (TryParseEnum<Auriga.Modellingcore.RateKind>(xmlReader.GetAttribute("kindOfRate"), out var parsed)) { poco.KindOfRate = parsed; } }
            poco.Name = xmlReader.GetAttribute("name");
            CollectSingleValueReference(poco, "RealizedFlow", xmlReader.GetAttribute("realizedFlow"));
            poco.Review = xmlReader.GetAttribute("review");
            CollectSingleValueReference(poco, "Selection", xmlReader.GetAttribute("selection"));
            poco.Sid = xmlReader.GetAttribute("sid");
            CollectSingleValueReference(poco, "Source", xmlReader.GetAttribute("source"));
            CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
            poco.Summary = xmlReader.GetAttribute("summary");
            CollectSingleValueReference(poco, "Target", xmlReader.GetAttribute("target"));
            CollectSingleValueReference(poco, "Transformation", xmlReader.GetAttribute("transformation"));
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
                        case "guard":
                    {
                        var contained = (Auriga.Modellingcore.IValueSpecification)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.Guard = contained;
                        break;
                    }
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedFunctionalExchangeRealizations":
                        poco.OwnedFunctionalExchangeRealizations.Add((Auriga.Fa.IFunctionalExchangeRealization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMigratedElements":
                        poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValueGroups":
                        poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValues":
                        poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader));
                        break;
                        case "probability":
                    {
                        var contained = (Auriga.Modellingcore.IValueSpecification)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.Probability = contained;
                        break;
                    }
                        case "rate":
                    {
                        var contained = (Auriga.Modellingcore.IValueSpecification)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.Rate = contained;
                        break;
                    }
                        case "weight":
                    {
                        var contained = (Auriga.Modellingcore.IValueSpecification)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.Weight = contained;
                        break;
                    }
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
