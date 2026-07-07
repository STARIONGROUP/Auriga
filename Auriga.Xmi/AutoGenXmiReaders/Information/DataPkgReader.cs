// ------------------------------------------------------------------------------------------------
// <copyright file="DataPkgReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>DataPkg</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class DataPkgReader : XmiElementReader<Auriga.Information.IDataPkg>, IXmiElementReader<Auriga.Information.IDataPkg>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataPkgReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public DataPkgReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>DataPkg</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Information.IDataPkg"/></returns>
        public Auriga.Information.IDataPkg Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Information.DataPkg();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
            CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
            poco.Description = xmlReader.GetAttribute("description");
            CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
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
                        case "ownedAssociations":
                        poco.OwnedAssociations.Add((Auriga.Information.IAssociation)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedClasses":
                        poco.OwnedClasses.Add((Auriga.Information.IClass)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedCollections":
                        poco.OwnedCollections.Add((Auriga.Information.ICollection)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDataPkgs":
                        poco.OwnedDataPkgs.Add((Auriga.Information.IDataPkg)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDataTypes":
                        poco.OwnedDataTypes.Add((Auriga.Information.Datatype.IDataType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDataValues":
                        poco.OwnedDataValues.Add((Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExceptions":
                        poco.OwnedExceptions.Add((Auriga.Information.Communication.IException)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExchangeItems":
                        poco.OwnedExchangeItems.Add((Auriga.Information.IExchangeItem)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedKeyParts":
                        poco.OwnedKeyParts.Add((Auriga.Information.IKeyPart)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMessageReferences":
                        poco.OwnedMessageReferences.Add((Auriga.Information.Communication.IMessageReference)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMessages":
                        poco.OwnedMessages.Add((Auriga.Information.Communication.IMessage)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMigratedElements":
                        poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValueGroups":
                        poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValuePkgs":
                        poco.OwnedPropertyValuePkgs.Add((Auriga.Capellacore.IPropertyValuePkg)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValues":
                        poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedSignals":
                        poco.OwnedSignals.Add((Auriga.Information.Communication.ISignal)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedStateEvents":
                        poco.OwnedStateEvents.Add((Auriga.Capellacommon.IStateEvent)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedTraces":
                        poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedUnits":
                        poco.OwnedUnits.Add((Auriga.Information.IUnit)this.Facade.QueryElement(xmlReader));
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
