// ------------------------------------------------------------------------------------------------
// <copyright file="CollectionReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>Collection</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class CollectionReader : XmiElementReader<Auriga.Information.ICollection>, IXmiElementReader<Auriga.Information.ICollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public CollectionReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>Collection</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Information.ICollection"/></returns>
        public Auriga.Information.ICollection Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Information.Collection();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            { var raw = xmlReader.GetAttribute("abstract"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Abstract = parsed; } }
            { if (TryParseEnum<Auriga.Information.AggregationKind>(xmlReader.GetAttribute("aggregationKind"), out var parsed)) { poco.AggregationKind = parsed; } }
            CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
            CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
            poco.Description = xmlReader.GetAttribute("description");
            CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
            { var raw = xmlReader.GetAttribute("final"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Final = parsed; } }
            CollectMultiValueReferences(poco, "Index", xmlReader.GetAttribute("index"));
            { var raw = xmlReader.GetAttribute("isPrimitive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsPrimitive = parsed; } }
            { if (TryParseEnum<Auriga.Information.CollectionKind>(xmlReader.GetAttribute("kind"), out var parsed)) { poco.Kind = parsed; } }
            { var raw = xmlReader.GetAttribute("maxInclusive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MaxInclusive = parsed; } }
            { var raw = xmlReader.GetAttribute("minInclusive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MinInclusive = parsed; } }
            poco.Name = xmlReader.GetAttribute("name");
            { var raw = xmlReader.GetAttribute("ordered"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Ordered = parsed; } }
            poco.Review = xmlReader.GetAttribute("review");
            poco.Sid = xmlReader.GetAttribute("sid");
            CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
            poco.Summary = xmlReader.GetAttribute("summary");
            CollectSingleValueReference(poco, "Type", xmlReader.GetAttribute("type"));
            { var raw = xmlReader.GetAttribute("unique"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Unique = parsed; } }
            { if (TryParseEnum<Auriga.Capellacore.VisibilityKind>(xmlReader.GetAttribute("visibility"), out var parsed)) { poco.Visibility = parsed; } }
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
                        case "namingRules":
                        poco.NamingRules.Add((Auriga.Capellacore.INamingRule)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDataValues":
                        poco.OwnedDataValues.Add((Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader));
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
                        case "ownedFeatures":
                        poco.OwnedFeatures.Add((Auriga.Capellacore.IFeature)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedGeneralizations":
                        poco.OwnedGeneralizations.Add((Auriga.Capellacore.IGeneralization)this.Facade.QueryElement(xmlReader));
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
                        case "ownedPropertyValuePkgs":
                        poco.OwnedPropertyValuePkgs.Add((Auriga.Capellacore.IPropertyValuePkg)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValues":
                        poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedTraces":
                        poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader));
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
