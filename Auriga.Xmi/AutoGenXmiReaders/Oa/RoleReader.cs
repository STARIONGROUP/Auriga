// ------------------------------------------------------------------------------------------------
// <copyright file="RoleReader.cs" company="Starion Group S.A.">
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
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>Role</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class RoleReader : XmiElementReader<Auriga.Oa.IRole>, IXmiElementReader<Auriga.Oa.IRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public RoleReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>Role</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Oa.IRole"/></returns>
        public Auriga.Oa.IRole Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.Oa.Role();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                CollectSingleValueReference(poco, "AbstractType", xmlReader.GetAttribute("abstractType"));
                {
                    if (TryParseEnum<Auriga.Information.AggregationKind>(xmlReader.GetAttribute("aggregationKind"), out var parsed))
                    {
                        poco.AggregationKind = parsed;
                    }
                }
                CollectMultiValueReferences(poco, "AppliedPropertyValueGroups", xmlReader.GetAttribute("appliedPropertyValueGroups"));
                CollectMultiValueReferences(poco, "AppliedPropertyValues", xmlReader.GetAttribute("appliedPropertyValues"));
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
                            case "ownedActivityAllocations":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedActivityAllocations", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedActivityAllocations.Add((Auriga.Oa.IActivityAllocation)this.Facade.QueryElement(xmlReader));
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
                                    var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedDefaultValue = contained;
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
                                    var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedMaxCard = contained;
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
                                    var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedMaxLength = contained;
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
                                    var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedMaxValue = contained;
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
                                    var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedMinCard = contained;
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
                                    var contained = (Auriga.Information.Datavalue.INumericValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedMinLength = contained;
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
                                    var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedMinValue = contained;
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
                                    var contained = (Auriga.Information.Datavalue.IDataValue)this.Facade.QueryElement(xmlReader);
                                    contained.Container = poco;
                                    poco.OwnedNullValue = contained;
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
                            case "ownedRoleAssemblyUsages":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "OwnedRoleAssemblyUsages", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.OwnedRoleAssemblyUsages.Add((Auriga.Oa.IRoleAssemblyUsage)this.Facade.QueryElement(xmlReader));
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
                this.Logger.LogWarning("Expected an element to read Role but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
