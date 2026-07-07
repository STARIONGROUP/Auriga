// ------------------------------------------------------------------------------------------------
// <copyright file="CapabilityConfigurationReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Oa
{
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>CapabilityConfiguration</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class CapabilityConfigurationReader : XmiElementReader<Auriga.Oa.ICapabilityConfiguration>, IXmiElementReader<Auriga.Oa.ICapabilityConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilityConfigurationReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public CapabilityConfigurationReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>CapabilityConfiguration</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Oa.ICapabilityConfiguration"/></returns>
        public Auriga.Oa.ICapabilityConfiguration Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Oa.CapabilityConfiguration();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            { var raw = xmlReader.GetAttribute("abstract"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Abstract = parsed; } }
            { var raw = xmlReader.GetAttribute("actor"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Actor = parsed; } }
            CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
            CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
            CollectMultiValueReferences(poco, "ComposingLinks", xmlReader.GetAttribute("composingLinks"));
            CollectSingleValueReference(poco, "ConfiguredCapability", xmlReader.GetAttribute("configuredCapability"));
            poco.Description = xmlReader.GetAttribute("description");
            CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
            { var raw = xmlReader.GetAttribute("human"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Human = parsed; } }
            CollectMultiValueReferences(poco, "InExchangeLinks", xmlReader.GetAttribute("inExchangeLinks"));
            poco.Name = xmlReader.GetAttribute("name");
            CollectMultiValueReferences(poco, "OutExchangeLinks", xmlReader.GetAttribute("outExchangeLinks"));
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
                        case "namingRules":
                        poco.NamingRules.Add((Auriga.Capellacore.INamingRule)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedAbstractCapabilityPkg":
                    {
                        var contained = (Auriga.Capellacommon.IAbstractCapabilityPkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedAbstractCapabilityPkg = contained;
                        break;
                    }
                        case "ownedCommunicationLinks":
                        poco.OwnedCommunicationLinks.Add((Auriga.Information.Communication.ICommunicationLink)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedComponentExchangeCategories":
                        poco.OwnedComponentExchangeCategories.Add((Auriga.Fa.IComponentExchangeCategory)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedComponentExchanges":
                        poco.OwnedComponentExchanges.Add((Auriga.Fa.IComponentExchange)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedComponentRealizations":
                        poco.OwnedComponentRealizations.Add((Auriga.Cs.IComponentRealization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedDataPkg":
                    {
                        var contained = (Auriga.Information.IDataPkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedDataPkg = contained;
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
                        case "ownedFunctionalAllocation":
                        poco.OwnedFunctionalAllocation.Add((Auriga.Fa.IComponentFunctionalAllocation)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedGeneralizations":
                        poco.OwnedGeneralizations.Add((Auriga.Capellacore.IGeneralization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedInterfaceAllocations":
                        poco.OwnedInterfaceAllocations.Add((Auriga.Cs.IInterfaceAllocation)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedInterfaceImplementations":
                        poco.OwnedInterfaceImplementations.Add((Auriga.Cs.IInterfaceImplementation)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedInterfacePkg":
                    {
                        var contained = (Auriga.Cs.IInterfacePkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedInterfacePkg = contained;
                        break;
                    }
                        case "ownedInterfaceUses":
                        poco.OwnedInterfaceUses.Add((Auriga.Cs.IInterfaceUse)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMigratedElements":
                        poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPhysicalLinkCategories":
                        poco.OwnedPhysicalLinkCategories.Add((Auriga.Cs.IPhysicalLinkCategory)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPhysicalLinks":
                        poco.OwnedPhysicalLinks.Add((Auriga.Cs.IPhysicalLink)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPhysicalPath":
                        poco.OwnedPhysicalPath.Add((Auriga.Cs.IPhysicalPath)this.Facade.QueryElement(xmlReader));
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
