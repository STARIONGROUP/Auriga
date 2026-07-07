// ------------------------------------------------------------------------------------------------
// <copyright file="SystemFunctionPkgReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Ctx
{
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>SystemFunctionPkg</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class SystemFunctionPkgReader : XmiElementReader<Auriga.Ctx.ISystemFunctionPkg>, IXmiElementReader<Auriga.Ctx.ISystemFunctionPkg>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionPkgReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public SystemFunctionPkgReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>SystemFunctionPkg</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Ctx.ISystemFunctionPkg"/></returns>
        public Auriga.Ctx.ISystemFunctionPkg Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Ctx.SystemFunctionPkg();

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
                        case "ownedCategories":
                        poco.OwnedCategories.Add((Auriga.Fa.IExchangeCategory)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedConstraints":
                        poco.OwnedConstraints.Add((Auriga.Modellingcore.IAbstractConstraint)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedEnumerationPropertyTypes":
                        poco.OwnedEnumerationPropertyTypes.Add((Auriga.Capellacore.IEnumerationPropertyType)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExchangeSpecificationRealizations":
                        poco.OwnedExchangeSpecificationRealizations.Add((Auriga.Fa.IExchangeSpecificationRealization)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExchanges":
                        poco.OwnedExchanges.Add((Auriga.Fa.IFunctionalExchangeSpecification)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedFunctionSpecifications":
                        poco.OwnedFunctionSpecifications.Add((Auriga.Fa.IFunctionSpecification)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedFunctionalLinks":
                        poco.OwnedFunctionalLinks.Add((Auriga.Fa.IExchangeLink)this.Facade.QueryElement(xmlReader));
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
                        case "ownedSystemFunctionPkgs":
                        poco.OwnedSystemFunctionPkgs.Add((Auriga.Ctx.ISystemFunctionPkg)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedSystemFunctions":
                        poco.OwnedSystemFunctions.Add((Auriga.Ctx.ISystemFunction)this.Facade.QueryElement(xmlReader));
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
