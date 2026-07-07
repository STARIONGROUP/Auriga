// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionOutputPortReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>FunctionOutputPort</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class FunctionOutputPortReader : XmiElementReader<Auriga.Fa.IFunctionOutputPort>, IXmiElementReader<Auriga.Fa.IFunctionOutputPort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionOutputPortReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public FunctionOutputPortReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>FunctionOutputPort</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Fa.IFunctionOutputPort"/></returns>
        public Auriga.Fa.IFunctionOutputPort Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Fa.FunctionOutputPort();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectSingleValueReference(poco, "AbstractType", xmlReader.GetAttribute("abstractType"));
            CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
            CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
            poco.Description = xmlReader.GetAttribute("description");
            CollectMultiValueReferences(poco, "Features", xmlReader.GetAttribute("features"));
            CollectMultiValueReferences(poco, "InState", xmlReader.GetAttribute("inState"));
            { var raw = xmlReader.GetAttribute("isControl"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsControl = parsed; } }
            { var raw = xmlReader.GetAttribute("isControlType"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.IsControlType = parsed; } }
            { if (TryParseEnum<Auriga.Activity.ObjectNodeKind>(xmlReader.GetAttribute("kindOfNode"), out var parsed)) { poco.KindOfNode = parsed; } }
            poco.Name = xmlReader.GetAttribute("name");
            { if (TryParseEnum<Auriga.Activity.ObjectNodeOrderingKind>(xmlReader.GetAttribute("ordering"), out var parsed)) { poco.Ordering = parsed; } }
            CollectMultiValueReferences(poco, "OutgoingExchangeItems", xmlReader.GetAttribute("outgoingExchangeItems"));
            CollectMultiValueReferences(poco, "ProvidedInterfaces", xmlReader.GetAttribute("providedInterfaces"));
            CollectSingleValueReference(poco, "RepresentedComponentPort", xmlReader.GetAttribute("representedComponentPort"));
            CollectMultiValueReferences(poco, "RequiredInterfaces", xmlReader.GetAttribute("requiredInterfaces"));
            poco.Review = xmlReader.GetAttribute("review");
            CollectSingleValueReference(poco, "Selection", xmlReader.GetAttribute("selection"));
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
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMigratedElements":
                        poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPortAllocations":
                        poco.OwnedPortAllocations.Add((Auriga.Information.IPortAllocation)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPortRealizations":
                        poco.OwnedPortRealizations.Add((Auriga.Information.IPortRealization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValueGroups":
                        poco.OwnedPropertyValueGroups.Add((Auriga.Capellacore.IPropertyValueGroup)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPropertyValues":
                        poco.OwnedPropertyValues.Add((Auriga.Capellacore.IAbstractPropertyValue)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedProtocols":
                        poco.OwnedProtocols.Add((Auriga.Capellacommon.IStateMachine)this.Facade.QueryElement(xmlReader));
                        break;
                        case "upperBound":
                    {
                        var contained = (Auriga.Modellingcore.IValueSpecification)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.UpperBound = contained;
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
