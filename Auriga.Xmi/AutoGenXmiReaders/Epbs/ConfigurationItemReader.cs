// ------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationItemReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Epbs
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>ConfigurationItem</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class ConfigurationItemReader : XmiElementReader<Auriga.Epbs.IConfigurationItem>, IXmiElementReader<Auriga.Epbs.IConfigurationItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationItemReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ConfigurationItemReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>ConfigurationItem</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Epbs.IConfigurationItem"/></returns>
        public Auriga.Epbs.IConfigurationItem Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.Epbs.ConfigurationItem();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                {
                    var raw = xmlReader.GetAttribute("abstract");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Abstract = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("actor");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Actor = parsed;
                    }
                }
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
                poco.Description = xmlReader.GetAttribute("description");
                CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
                {
                    var raw = xmlReader.GetAttribute("human");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Human = parsed;
                    }
                }
                CollectMultiValueReferences(poco, "InExchangeLinks", xmlReader.GetAttribute("inExchangeLinks"));
                poco.ItemIdentifier = xmlReader.GetAttribute("itemIdentifier");
                {
                    if (TryParseEnum<Auriga.Epbs.ConfigurationItemKind>(xmlReader.GetAttribute("kind"), out var parsed))
                    {
                        poco.Kind = parsed;
                    }
                }
                poco.Name = xmlReader.GetAttribute("name");
                CollectMultiValueReferences(poco, "OutExchangeLinks", xmlReader.GetAttribute("outExchangeLinks"));
                poco.Review = xmlReader.GetAttribute("review");
                poco.Sid = xmlReader.GetAttribute("sid");
                CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
                poco.Summary = xmlReader.GetAttribute("summary");
                {
                    var raw = xmlReader.GetAttribute("visibleInDoc");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.VisibleInDoc = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("visibleInLM");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.VisibleInLM = parsed;
                    }
                }

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
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "appliedPropertyValues":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "AppliedPropertyValues", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "features":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Features", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "inExchangeLinks":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "InExchangeLinks", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "namingRules":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "NamingRules", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.NamingRules.Add((Auriga.Capellacore.INamingRule)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "outExchangeLinks":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OutExchangeLinks", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "ownedAbstractCapabilityPkg":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedAbstractCapabilityPkg", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    var contained = (Auriga.Capellacommon.IAbstractCapabilityPkg)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedAbstractCapabilityPkg = contained;
                                }

                                break;
                            }
                            case "ownedCommunicationLinks":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedCommunicationLinks", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedCommunicationLinks.Add((Auriga.Information.Communication.ICommunicationLink)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedComponentExchangeCategories":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedComponentExchangeCategories", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedComponentExchangeCategories.Add((Auriga.Fa.IComponentExchangeCategory)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedComponentExchanges":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedComponentExchanges", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedComponentExchanges.Add((Auriga.Fa.IComponentExchange)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedComponentRealizations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedComponentRealizations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedComponentRealizations.Add((Auriga.Cs.IComponentRealization)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedConfigurationItemPkgs":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedConfigurationItemPkgs", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedConfigurationItemPkgs.Add((Auriga.Epbs.IConfigurationItemPkg)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedConfigurationItems":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedConfigurationItems", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedConfigurationItems.Add((Auriga.Epbs.IConfigurationItem)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedConstraints":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedConstraints", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedDataPkg":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedDataPkg", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    var contained = (Auriga.Information.IDataPkg)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedDataPkg = contained;
                                }

                                break;
                            }
                            case "ownedEnumerationPropertyTypes":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedEnumerationPropertyTypes", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedExtensions":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedExtensions", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedFeatures":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedFeatures", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedFeatures.Add((Auriga.Capellacore.IFeature)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedFunctionalAllocation":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedFunctionalAllocation", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedFunctionalAllocation.Add((Auriga.Fa.IComponentFunctionalAllocation)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedGeneralizations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedGeneralizations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedGeneralizations.Add((Auriga.Capellacore.IGeneralization)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedInterfaceAllocations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedInterfaceAllocations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedInterfaceAllocations.Add((Auriga.Cs.IInterfaceAllocation)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedInterfaceImplementations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedInterfaceImplementations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedInterfaceImplementations.Add((Auriga.Cs.IInterfaceImplementation)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedInterfacePkg":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedInterfacePkg", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    var contained = (Auriga.Cs.IInterfacePkg)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedInterfacePkg = contained;
                                }

                                break;
                            }
                            case "ownedInterfaceUses":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedInterfaceUses", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedInterfaceUses.Add((Auriga.Cs.IInterfaceUse)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedMigratedElements":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedMigratedElements", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedPhysicalArtifactRealizations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPhysicalArtifactRealizations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPhysicalArtifactRealizations.Add((Auriga.Epbs.IPhysicalArtifactRealization)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedPhysicalLinkCategories":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPhysicalLinkCategories", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPhysicalLinkCategories.Add((Auriga.Cs.IPhysicalLinkCategory)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedPhysicalLinks":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPhysicalLinks", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPhysicalLinks.Add((Auriga.Cs.IPhysicalLink)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedPhysicalPath":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPhysicalPath", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPhysicalPath.Add((Auriga.Cs.IPhysicalPath)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedPropertyValueGroups":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPropertyValueGroups", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedPropertyValues":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPropertyValues", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedStateMachines":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedStateMachines", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedStateMachines.Add((Auriga.Capellacommon.IStateMachine)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "ownedTraces":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedTraces", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader));
                                }

                                break;
                            }
                            case "status":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Status", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            default:
                                this.Logger.LogTrace("Skipping unmapped element '{Element}' of ConfigurationItem at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read ConfigurationItem but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
