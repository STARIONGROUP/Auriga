// ------------------------------------------------------------------------------------------------
// <copyright file="UnionReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>Union</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class UnionReader : XmiElementReader<Auriga.Information.IUnion>, IXmiElementReader<Auriga.Information.IUnion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public UnionReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>Union</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Information.IUnion"/></returns>
        public Auriga.Information.IUnion Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Information.Union();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            { var raw = xmlReader.GetAttribute("abstract"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Abstract = parsed; } }
            CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
            CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
            CollectSingleValueReference(poco, "DefaultProperty", xmlReader.GetAttribute("defaultProperty"));
            poco.Description = xmlReader.GetAttribute("description");
            CollectSingleValueReference(poco, "Discriminant", xmlReader.GetAttribute("discriminant"));
            CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
            { var raw = xmlReader.GetAttribute("final"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Final = parsed; } }
            { var raw = xmlReader.GetAttribute("isPrimitive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsPrimitive = parsed; } }
            CollectMultiValueReferences(poco, "KeyParts", xmlReader.GetAttribute("keyParts"));
            { if (TryParseEnum<Auriga.Information.UnionKind>(xmlReader.GetAttribute("kind"), out var parsed)) { poco.Kind = parsed; } }
            poco.Name = xmlReader.GetAttribute("name");
            poco.Review = xmlReader.GetAttribute("review");
            poco.Sid = xmlReader.GetAttribute("sid");
            CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
            poco.Summary = xmlReader.GetAttribute("summary");
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
                        case "nestedGeneralClasses":
                        poco.NestedGeneralClasses.Add((Auriga.Capellacore.IGeneralClass)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDataValues":
                        poco.OwnedDataValues.Add((Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader));
                        break;
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
                        case "ownedInformationRealizations":
                        poco.OwnedInformationRealizations.Add((Auriga.Information.IInformationRealization)this.Facade.QueryElement(xmlReader));
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
                        case "ownedStateMachines":
                        poco.OwnedStateMachines.Add((Auriga.Capellacommon.IStateMachine)this.Facade.QueryElement(xmlReader));
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
