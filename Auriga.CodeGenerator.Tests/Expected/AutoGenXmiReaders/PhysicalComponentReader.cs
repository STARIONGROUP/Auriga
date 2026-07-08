// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalComponentReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Pa
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>PhysicalComponent</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class PhysicalComponentReader : XmiElementReader<Auriga.Pa.IPhysicalComponent>, IXmiElementReader<Auriga.Pa.IPhysicalComponent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalComponentReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public PhysicalComponentReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>PhysicalComponent</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Pa.IPhysicalComponent"/></returns>
        public Auriga.Pa.IPhysicalComponent Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException("The document name is required.", nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException("The namespace URI is required.", nameof(namespaceUri));
            }

            var poco = new Auriga.Pa.PhysicalComponent();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading PhysicalComponent at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                // The element's own namespace becomes the in-scope namespace threaded to its children. A
                // document root carries the document namespace; a nested element may narrow it.
                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                // Capture the declared xsi:type verbatim (null on a document root, whose type is fixed by
                // its element tag) as round-trip groundwork. Type-correctness is already guaranteed by the
                // facade's dispatch, so the reader does not re-validate it.
                poco.XsiType = xmlReader.GetAttribute("type", XsiNamespace);
                poco.XmiNamespaceUri = namespaceUri;

                poco.Id = xmlReader.GetAttribute("id");
                poco.SourceDocument = documentName;
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
                {
                    if (TryParseEnum<Auriga.Pa.PhysicalComponentKind>(xmlReader.GetAttribute("kind"), out var parsed))
                    {
                        poco.Kind = parsed;
                    }
                }
                poco.Name = xmlReader.GetAttribute("name");
                {
                    if (TryParseEnum<Auriga.Pa.PhysicalComponentNature>(xmlReader.GetAttribute("nature"), out var parsed))
                    {
                        poco.Nature = parsed;
                    }
                }
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
                                    poco.NamingRules.Add((Auriga.Capellacore.INamingRule)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedAbstractCapabilityPkg = (Auriga.Capellacommon.IAbstractCapabilityPkg)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
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
                                    poco.OwnedCommunicationLinks.Add((Auriga.Information.Communication.ICommunicationLink)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedComponentExchangeCategories.Add((Auriga.Fa.IComponentExchangeCategory)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedComponentExchanges.Add((Auriga.Fa.IComponentExchange)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedComponentRealizations.Add((Auriga.Cs.IComponentRealization)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedDataPkg = (Auriga.Information.IDataPkg)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "ownedDeploymentLinks":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedDeploymentLinks", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedDeploymentLinks.Add((Auriga.Cs.IAbstractDeploymentLink)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedFeatures.Add((Auriga.Capellacore.IFeature)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedFunctionalAllocation.Add((Auriga.Fa.IComponentFunctionalAllocation)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedGeneralizations.Add((Auriga.Capellacore.IGeneralization)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedInterfaceAllocations.Add((Auriga.Cs.IInterfaceAllocation)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedInterfaceImplementations.Add((Auriga.Cs.IInterfaceImplementation)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedInterfacePkg = (Auriga.Cs.IInterfacePkg)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
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
                                    poco.OwnedInterfaceUses.Add((Auriga.Cs.IInterfaceUse)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedPhysicalComponentPkgs":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPhysicalComponentPkgs", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPhysicalComponentPkgs.Add((Auriga.Pa.IPhysicalComponentPkg)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedPhysicalComponents":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedPhysicalComponents", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedPhysicalComponents.Add((Auriga.Pa.IPhysicalComponent)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedPhysicalLinkCategories.Add((Auriga.Cs.IPhysicalLinkCategory)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedPhysicalLinks.Add((Auriga.Cs.IPhysicalLink)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedPhysicalPath.Add((Auriga.Cs.IPhysicalPath)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedStateMachines.Add((Auriga.Capellacommon.IStateMachine)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read PhysicalComponent but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
