// ------------------------------------------------------------------------------------------------
// <copyright file="ScenarioReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Interaction
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>Scenario</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class ScenarioReader : XmiElementReader<Auriga.Interaction.IScenario>, IXmiElementReader<Auriga.Interaction.IScenario>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ScenarioReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>Scenario</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Interaction.IScenario"/></returns>
        public Auriga.Interaction.IScenario Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.Interaction.Scenario();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
                poco.Description = xmlReader.GetAttribute("description");
                CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
                { var raw = xmlReader.GetAttribute("isControlOperator"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsControlOperator = parsed; } }
                { if (TryParseEnum<Auriga.Interaction.ScenarioKind>(xmlReader.GetAttribute("kind"), out var parsed)) { poco.Kind = parsed; } }
                { var raw = xmlReader.GetAttribute("merged"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Merged = parsed; } }
                poco.Name = xmlReader.GetAttribute("name");
                CollectMultiValueReferences(poco, "OwnedParameter", xmlReader.GetAttribute("ownedParameter"));
                CollectMultiValueReferences(poco, "OwnedParameterSet", xmlReader.GetAttribute("ownedParameterSet"));
                CollectSingleValueReference(poco, "PostCondition", xmlReader.GetAttribute("postCondition"));
                CollectSingleValueReference(poco, "PreCondition", xmlReader.GetAttribute("preCondition"));
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
                            case "ownedConstraintDurations":
                        poco.OwnedConstraintDurations.Add((Auriga.Interaction.IConstraintDuration)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedEvents":
                        poco.OwnedEvents.Add((Auriga.Interaction.IEvent)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedFormalGates":
                        poco.OwnedFormalGates.Add((Auriga.Interaction.IGate)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedInstanceRoles":
                        poco.OwnedInstanceRoles.Add((Auriga.Interaction.IInstanceRole)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedInteractionFragments":
                        poco.OwnedInteractionFragments.Add((Auriga.Interaction.IInteractionFragment)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedMessages":
                        poco.OwnedMessages.Add((Auriga.Interaction.ISequenceMessage)this.Facade.QueryElement(xmlReader));
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
                            case "ownedScenarioRealization":
                        poco.OwnedScenarioRealization.Add((Auriga.Interaction.IScenarioRealization)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedTimeLapses":
                        poco.OwnedTimeLapses.Add((Auriga.Interaction.ITimeLapse)this.Facade.QueryElement(xmlReader));
                        break;
                            case "ownedTraces":
                        poco.OwnedTraces.Add((Auriga.Capellacore.ITrace)this.Facade.QueryElement(xmlReader));
                        break;
                            default:
                                this.Logger.LogTrace("Skipping unmapped element '{Element}' of Scenario at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read Scenario but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
