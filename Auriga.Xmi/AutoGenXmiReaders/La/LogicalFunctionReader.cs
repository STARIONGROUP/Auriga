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
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public LogicalFunctionReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>LogicalFunction</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.La.ILogicalFunction"/></returns>
        public Auriga.La.ILogicalFunction Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.La.LogicalFunction();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                CollectSingleValueReference(poco, "AbstractType", xmlReader.GetAttribute("abstractType"));
                { if (TryParseEnum<Auriga.Information.AggregationKind>(xmlReader.GetAttribute("aggregationKind"), out var parsed)) { poco.AggregationKind = parsed; } }
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
                CollectMultiValueReferences(poco, "AvailableInStates", xmlReader.GetAttribute("availableInStates"));
                CollectSingleValueReference(poco, "Behavior", xmlReader.GetAttribute("behavior"));
                poco.Condition = xmlReader.GetAttribute("condition");
                CollectSingleValueReference(poco, "Context", xmlReader.GetAttribute("context"));
                poco.Description = xmlReader.GetAttribute("description");
                CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
                { var raw = xmlReader.GetAttribute("final"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Final = parsed; } }
                { var raw = xmlReader.GetAttribute("isAbstract"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsAbstract = parsed; } }
                { var raw = xmlReader.GetAttribute("isDerived"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsDerived = parsed; } }
                { var raw = xmlReader.GetAttribute("isPartOfKey"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsPartOfKey = parsed; } }
                { var raw = xmlReader.GetAttribute("isReadOnly"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsReadOnly = parsed; } }
                { var raw = xmlReader.GetAttribute("isStatic"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsStatic = parsed; } }
                { if (TryParseEnum<Auriga.Fa.FunctionKind>(xmlReader.GetAttribute("kind"), out var parsed)) { poco.Kind = parsed; } }
                { var raw = xmlReader.GetAttribute("maxInclusive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MaxInclusive = parsed; } }
                { var raw = xmlReader.GetAttribute("minInclusive"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MinInclusive = parsed; } }
                poco.Name = xmlReader.GetAttribute("name");
                { var raw = xmlReader.GetAttribute("ordered"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Ordered = parsed; } }
                poco.Review = xmlReader.GetAttribute("review");
                poco.Sid = xmlReader.GetAttribute("sid");
                CollectSingleValueReference(poco, "Status", xmlReader.GetAttribute("status"));
                poco.Summary = xmlReader.GetAttribute("summary");
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
                            case "arguments":
                        poco.Arguments.Add((Auriga.Activity.IInputPin)this.Facade.QueryElement(xmlReader));
                        break;
                            case "inputs":
                        poco.Inputs.Add((Auriga.Activity.IInputPin)this.Facade.QueryElement(xmlReader));
                        break;
                            case "localPostcondition":
                    {
                        var contained = (Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.LocalPostcondition = contained;
                        break;
                    }
                            case "localPrecondition":
                    {
                        var contained = (Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.LocalPrecondition = contained;
                        break;
                    }
                            case "namingRules":
                        poco.NamingRules.Add((Auriga.Capellacore.INamingRule)this.Facade.QueryElement(xmlReader));
                        break;
                            case "outputs":
                        poco.Outputs.Add((Auriga.Activity.IOutputPin)this.Facade.QueryElement(xmlReader));
                        break;
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
                            case "ownedFunctionRealizations":
                        poco.OwnedFunctionRealizations.Add((Auriga.Fa.IFunctionRealization)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedFunctionalChains":
                        poco.OwnedFunctionalChains.Add((Auriga.Fa.IFunctionalChain)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedFunctionalExchanges":
                        poco.OwnedFunctionalExchanges.Add((Auriga.Fa.IFunctionalExchange)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedFunctions":
                        poco.OwnedFunctions.Add((Auriga.Fa.IAbstractFunction)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedHandlers":
                        poco.OwnedHandlers.Add((Auriga.Activity.IExceptionHandler)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedLogicalFunctionPkgs":
                        poco.OwnedLogicalFunctionPkgs.Add((Auriga.La.ILogicalFunctionPkg)this.Facade.QueryElement(xmlReader));
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
                            case "ownedTraces":
                        poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader));
                        break;
                            case "results":
                        poco.Results.Add((Auriga.Activity.IOutputPin)this.Facade.QueryElement(xmlReader));
                        break;
                            default:
                                this.Logger.LogTrace("Skipping unmapped element '{Element}' of LogicalFunction at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
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
