// ------------------------------------------------------------------------------------------------
// <copyright file="LogicalFunctionReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.La
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>LogicalFunction</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class LogicalFunctionReader : XmiElementReader<Auriga.La.ILogicalFunction>, IXmiElementReader<Auriga.La.ILogicalFunction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalFunctionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public LogicalFunctionReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings settings, ILoggerFactory loggerFactory)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>LogicalFunction</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.La.ILogicalFunction"/></returns>
        public Auriga.La.ILogicalFunction Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.La.LogicalFunction();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading LogicalFunction at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

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

                // The element identity is a bare id (as Capella serializes it), an xmi:id (as GMF notation
                // does) or a uid (as the Sirius representation model does); take the first present so every
                // element is cached and its cross-references resolve regardless of the serialization.
                poco.Id = xmlReader.GetAttribute("id") ?? xmlReader.GetAttribute("id", XmiNamespace) ?? xmlReader.GetAttribute("uid");
                poco.SourceDocument = documentName;
                CollectSingleValueReference(poco, "AbstractType", xmlReader.GetAttribute("abstractType"));
                {
                    if (TryParseEnum<Auriga.Information.AggregationKind>(xmlReader.GetAttribute("aggregationKind"), out var parsed))
                    {
                        poco.AggregationKind = parsed;
                    }
                }
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
                CollectMultiValueReferences(poco, "AvailableInStates", xmlReader.GetAttribute("availableInStates"));
                CollectSingleValueReference(poco, "Behavior", xmlReader.GetAttribute("behavior"));
                poco.Condition = xmlReader.GetAttribute("condition");
                CollectSingleValueReference(poco, "Context", xmlReader.GetAttribute("context"));
                poco.Description = xmlReader.GetAttribute("description");
                CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
                {
                    var raw = xmlReader.GetAttribute("final");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Final = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("isAbstract");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.IsAbstract = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("isDerived");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.IsDerived = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("isPartOfKey");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.IsPartOfKey = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("isReadOnly");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.IsReadOnly = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("isStatic");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.IsStatic = parsed;
                    }
                }
                {
                    if (TryParseEnum<Auriga.Fa.FunctionKind>(xmlReader.GetAttribute("kind"), out var parsed))
                    {
                        poco.Kind = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("maxInclusive");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.MaxInclusive = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("minInclusive");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.MinInclusive = parsed;
                    }
                }
                poco.Name = xmlReader.GetAttribute("name");
                {
                    var raw = xmlReader.GetAttribute("ordered");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Ordered = parsed;
                    }
                }
                poco.Review = xmlReader.GetAttribute("review");
                poco.Sid = xmlReader.GetAttribute("sid");
                CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
                poco.Summary = xmlReader.GetAttribute("summary");
                {
                    var raw = xmlReader.GetAttribute("unique");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Unique = parsed;
                    }
                }
                {
                    if (TryParseEnum<Auriga.Capellacore.VisibilityKind>(xmlReader.GetAttribute("visibility"), out var parsed))
                    {
                        poco.Visibility = parsed;
                    }
                }
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
                            case "abstractType":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "AbstractType", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
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
                            case "arguments":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Arguments", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Arguments.Add((Auriga.Activity.IInputPin)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "availableInStates":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "AvailableInStates", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "behavior":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Behavior", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "context":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Context", href);
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
                            case "inputs":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Inputs", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Inputs.Add((Auriga.Activity.IInputPin)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "localPostcondition":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "LocalPostcondition", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.LocalPostcondition = (Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "localPrecondition":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "LocalPrecondition", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.LocalPrecondition = (Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
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
                            case "outputs":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Outputs", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Outputs.Add((Auriga.Activity.IOutputPin)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                            case "ownedDefaultValue":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedDefaultValue", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedDefaultValue = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
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
                            case "ownedFunctionRealizations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedFunctionRealizations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedFunctionRealizations.Add((Auriga.Fa.IFunctionRealization)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedFunctionalChains":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedFunctionalChains", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedFunctionalChains.Add((Auriga.Fa.IFunctionalChain)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedFunctionalExchanges":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedFunctionalExchanges", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedFunctionalExchanges.Add((Auriga.Fa.IFunctionalExchange)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedFunctions":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedFunctions", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedFunctions.Add((Auriga.Fa.IAbstractFunction)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedHandlers":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedHandlers", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedHandlers.Add((Auriga.Activity.IExceptionHandler)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedLogicalFunctionPkgs":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedLogicalFunctionPkgs", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedLogicalFunctionPkgs.Add((Auriga.La.ILogicalFunctionPkg)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "ownedMaxCard":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedMaxCard", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMaxCard = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "ownedMaxLength":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedMaxLength", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMaxLength = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "ownedMaxValue":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedMaxValue", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMaxValue = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
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
                            case "ownedMinCard":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedMinCard", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMinCard = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "ownedMinLength":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedMinLength", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMinLength = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "ownedMinValue":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedMinValue", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedMinValue = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "ownedNullValue":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "OwnedNullValue", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedNullValue = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
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
                            case "results":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Results", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Results.Add((Auriga.Activity.IOutputPin)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"LogicalFunctionReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by LogicalFunctionReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read LogicalFunction but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
