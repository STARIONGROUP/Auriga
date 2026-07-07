// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalArchitectureReader.cs" company="Starion Group S.A.">
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
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>PhysicalArchitecture</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class PhysicalArchitectureReader : XmiElementReader<Auriga.Pa.IPhysicalArchitecture>, IXmiElementReader<Auriga.Pa.IPhysicalArchitecture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalArchitectureReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public PhysicalArchitectureReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>PhysicalArchitecture</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Pa.IPhysicalArchitecture"/></returns>
        public Auriga.Pa.IPhysicalArchitecture Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Pa.PhysicalArchitecture();

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
                        case "ownedComponentExchangeCategories":
                        poco.OwnedComponentExchangeCategories.Add((Auriga.Fa.IComponentExchangeCategory)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedComponentExchangeRealizations":
                        poco.OwnedComponentExchangeRealizations.Add((Auriga.Fa.IComponentExchangeRealization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedComponentExchanges":
                        poco.OwnedComponentExchanges.Add((Auriga.Fa.IComponentExchange)this.Facade.QueryElement(xmlReader));
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
                        case "ownedDeployments":
                        poco.OwnedDeployments.Add((Auriga.Cs.IAbstractDeploymentLink)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedFunctionPkg":
                    {
                        var contained = (Auriga.Fa.IFunctionPkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedFunctionPkg = contained;
                        break;
                    }
                        case "ownedFunctionalAllocations":
                        poco.OwnedFunctionalAllocations.Add((Auriga.Fa.IComponentFunctionalAllocation)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedFunctionalLinks":
                        poco.OwnedFunctionalLinks.Add((Auriga.Fa.IExchangeLink)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedInterfacePkg":
                    {
                        var contained = (Auriga.Cs.IInterfacePkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedInterfacePkg = contained;
                        break;
                    }
                        case "ownedLogicalArchitectureRealizations":
                        poco.OwnedLogicalArchitectureRealizations.Add((Auriga.Pa.ILogicalArchitectureRealization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedMigratedElements":
                        poco.OwnedMigratedElements.Add((Auriga.Modellingcore.IModelElement)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedPhysicalComponentPkg":
                    {
                        var contained = (Auriga.Pa.IPhysicalComponentPkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedPhysicalComponentPkg = contained;
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
