// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderFacade.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using Auriga.Core;
    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Namespaces;
    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated registry that maps a package-qualified type key (<c>package:TypeName</c>) to the
    /// reader that instantiates it, and reads the element at the cursor by resolving its <c>xsi:type</c>.
    /// </summary>
    public sealed class XmiReaderFacade : IXmiReaderFacade
    {
        private const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        private const string XmiNamespace = "http://www.omg.org/XMI";

        private readonly IXmiElementCache cache;

        private readonly INamespaceResolver namespaceResolver;

        private readonly IXmiReaderSettings settings;

        private readonly ILoggerFactory loggerFactory;

        private readonly Dictionary<string, string> prefixToNamespace = new Dictionary<string, string>(StringComparer.Ordinal);

        private readonly Dictionary<string, Func<XmlReader, string, string, IAurigaElement>> readerFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderFacade"/> class.
        /// </summary>
        /// <param name="cache">the element cache shared with every reader</param>
        /// <param name="namespaceResolver">the namespace-URI-to-package resolver</param>
        /// <param name="settings">the reader settings shared with every reader, or <c>null</c> for the lenient defaults</param>
        /// <param name="loggerFactory">the logger factory shared with every reader, or <c>null</c> to disable logging</param>
        public XmiReaderFacade(IXmiElementCache cache, INamespaceResolver namespaceResolver, IXmiReaderSettings settings = null, ILoggerFactory loggerFactory = null)
        {
            this.cache = cache;
            this.namespaceResolver = namespaceResolver;
            this.settings = settings ?? new XmiReaderSettings();
            this.loggerFactory = loggerFactory;
            this.readerFactories = new Dictionary<string, Func<XmlReader, string, string, IAurigaElement>>(StringComparer.Ordinal)
            {
                ["CapellaRequirements:CapellaIncomingRelation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaIncomingRelationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["CapellaRequirements:CapellaModule"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaModuleReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["CapellaRequirements:CapellaOutgoingRelation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaOutgoingRelationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["CapellaRequirements:CapellaTypesFolder"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaTypesFolderReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:AttributeDefinition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.AttributeDefinitionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:AttributeDefinitionEnumeration"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.AttributeDefinitionEnumerationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:BooleanValueAttribute"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.BooleanValueAttributeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:DataTypeDefinition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.DataTypeDefinitionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:DateValueAttribute"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.DateValueAttributeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:EnumValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.EnumValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:EnumerationDataTypeDefinition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.EnumerationDataTypeDefinitionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:EnumerationValueAttribute"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.EnumerationValueAttributeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:Folder"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.FolderReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:IntegerValueAttribute"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.IntegerValueAttributeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:InternalRelation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.InternalRelationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:Module"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.ModuleReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:ModuleType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.ModuleTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:RealValueAttribute"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RealValueAttributeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:RelationType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RelationTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:Requirement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RequirementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:RequirementType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RequirementTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:StringValueAttribute"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.StringValueAttributeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["Requirements:TypesFolder"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Requirements.TypesFolderReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:AbstractStateRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.AbstractStateRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:CapabilityRealizationInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.CapabilityRealizationInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:ChangeEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ChangeEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:ChoicePseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ChoicePseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:DeepHistoryPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.DeepHistoryPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:EntryPointPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.EntryPointPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:ExitPointPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ExitPointPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:FinalState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.FinalStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:ForkPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ForkPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:GenericTrace"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.GenericTraceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:InitialPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.InitialPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:JoinPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.JoinPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:JustificationLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.JustificationLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:Mode"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ModeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:Region"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.RegionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:ShallowHistoryPseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ShallowHistoryPseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:State"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:StateEventRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateEventRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:StateMachine"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateMachineReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:StateTransition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateTransitionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:StateTransitionRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateTransitionRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:TerminatePseudoState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.TerminatePseudoStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:TimeEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.TimeEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacommon:TransfoLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.TransfoLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:BooleanPropertyValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.BooleanPropertyValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:Constraint"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.ConstraintReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:EnumerationPropertyLiteral"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.EnumerationPropertyLiteralReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:EnumerationPropertyType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.EnumerationPropertyTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:EnumerationPropertyValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.EnumerationPropertyValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:FloatPropertyValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.FloatPropertyValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:Generalization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.GeneralizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:IntegerPropertyValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.IntegerPropertyValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:KeyValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.KeyValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:NamingRule"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.NamingRuleReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:PropertyValueGroup"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.PropertyValueGroupReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:PropertyValuePkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.PropertyValuePkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:ReuseLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.ReuseLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellacore:StringPropertyValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.StringPropertyValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellamodeller:Folder"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.FolderReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellamodeller:Library"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.LibraryReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellamodeller:Project"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.ProjectReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellamodeller:SystemEngineering"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.SystemEngineeringReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["capellamodeller:SystemEngineeringPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.SystemEngineeringPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["communication:CommunicationLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.CommunicationLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["communication:Exception"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.ExceptionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["communication:Message"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.MessageReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["communication:MessageReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.MessageReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["communication:Signal"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.SignalReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["communication:SignalInstance"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.SignalInstanceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:ComponentRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.ComponentRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:ExchangeItemAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.ExchangeItemAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:Interface"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfaceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:InterfaceImplementation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfaceImplementationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:InterfacePkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfacePkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:InterfaceUse"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfaceUseReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:Part"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PartReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalLinkCategory"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkCategoryReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalLinkEnd"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkEndReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalLinkRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalPath"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalPathInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalPathRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalPathReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalPort"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPortReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["cs:PhysicalPortRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPortRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:Capability"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:CapabilityExploitation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityExploitationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:CapabilityInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:CapabilityPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:Mission"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.MissionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:MissionInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.MissionInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:MissionPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.MissionPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:OperationalAnalysisRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.OperationalAnalysisRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemAnalysis"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemAnalysisReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemCommunication"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemCommunicationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemCommunicationHook"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemCommunicationHookReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemComponent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemComponentReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemComponentPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemComponentPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemFunction"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemFunctionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["ctx:SystemFunctionPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemFunctionPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datatype:BooleanType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.BooleanTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datatype:Enumeration"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.EnumerationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datatype:NumericType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.NumericTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datatype:PhysicalQuantity"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.PhysicalQuantityReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datatype:StringType"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.StringTypeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:BinaryExpression"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.BinaryExpressionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:BooleanReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.BooleanReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:ComplexValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.ComplexValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:ComplexValueReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.ComplexValueReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:EnumerationLiteral"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.EnumerationLiteralReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:EnumerationReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.EnumerationReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:LiteralBooleanValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.LiteralBooleanValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:LiteralNumericValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.LiteralNumericValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:LiteralStringValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.LiteralStringValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:NumericReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.NumericReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:OpaqueExpression"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.OpaqueExpressionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:StringReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.StringReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:UnaryExpression"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.UnaryExpressionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["datavalue:ValuePart"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.ValuePartReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:ComponentInstance"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.ComponentInstanceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:ConnectionInstance"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.ConnectionInstanceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:DeploymentAspect"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.DeploymentAspectReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:DeploymentConfiguration"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.DeploymentConfigurationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:InstanceDeploymentLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.InstanceDeploymentLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:PartDeploymentLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.PartDeploymentLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:PortInstance"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.PortInstanceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["deployment:TypeDeploymentLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.TypeDeploymentLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["epbs:ConfigurationItem"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Epbs.ConfigurationItemReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["epbs:ConfigurationItemPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Epbs.ConfigurationItemPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["epbs:EPBSArchitecture"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Epbs.EPBSArchitectureReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["epbs:EPBSArchitecturePkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Epbs.EPBSArchitecturePkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["epbs:PhysicalArchitectureRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Epbs.PhysicalArchitectureRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["epbs:PhysicalArtifactRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Epbs.PhysicalArtifactRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentExchange"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentExchangeAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentExchangeCategory"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeCategoryReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentExchangeEnd"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeEndReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentExchangeFunctionalExchangeAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeFunctionalExchangeAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentExchangeRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentFunctionalAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentFunctionalAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentPort"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentPortReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentPortAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentPortAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ComponentPortAllocationEnd"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentPortAllocationEndReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ControlNode"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ControlNodeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ExchangeCategory"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ExchangeCategoryReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ExchangeContainment"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ExchangeContainmentReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:ExchangeLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.ExchangeLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionInputPort"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionInputPortReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionOutputPort"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionOutputPortReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionSpecification"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionSpecificationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalChain"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalChainInvolvementFunction"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainInvolvementFunctionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalChainInvolvementLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainInvolvementLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalChainRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalChainReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalExchange"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalExchangeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalExchangeRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalExchangeRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:FunctionalExchangeSpecification"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalExchangeSpecificationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["fa:SequenceLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Fa.SequenceLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Association"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.AssociationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Class"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ClassReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Collection"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.CollectionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:CollectionValue"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.CollectionValueReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:CollectionValueReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.CollectionValueReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:DataPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.DataPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:DomainElement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.DomainElementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:ExchangeItem"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:ExchangeItemElement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemElementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:ExchangeItemInstance"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemInstanceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:ExchangeItemRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:InformationRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.InformationRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:KeyPart"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.KeyPartReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:OperationAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.OperationAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Parameter"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ParameterReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:PortAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.PortAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:PortRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.PortRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Property"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.PropertyReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Service"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.ServiceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Union"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.UnionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:UnionProperty"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.UnionPropertyReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["information:Unit"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Information.UnitReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:AbstractCapabilityExtend"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityExtendReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:AbstractCapabilityExtensionPoint"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityExtensionPointReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:AbstractCapabilityGeneralization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityGeneralizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:AbstractCapabilityInclude"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityIncludeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:AbstractCapabilityRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:AbstractFunctionAbstractCapabilityInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractFunctionAbstractCapabilityInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:ArmTimerEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ArmTimerEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:CancelTimerEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.CancelTimerEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:CombinedFragment"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.CombinedFragmentReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:ConstraintDuration"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ConstraintDurationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:CreationEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.CreationEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:DestructionEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.DestructionEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:EventReceiptOperation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.EventReceiptOperationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:EventSentOperation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.EventSentOperationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:Execution"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ExecutionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:ExecutionEnd"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ExecutionEndReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:ExecutionEvent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ExecutionEventReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:FragmentEnd"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.FragmentEndReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:FunctionalChainAbstractCapabilityInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.FunctionalChainAbstractCapabilityInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:Gate"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.GateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:InstanceRole"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InstanceRoleReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:InteractionOperand"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InteractionOperandReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:InteractionState"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InteractionStateReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:InteractionUse"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InteractionUseReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:MergeLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.MergeLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:MessageEnd"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.MessageEndReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:RefinementLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.RefinementLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:Scenario"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ScenarioReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:ScenarioRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ScenarioRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:SequenceMessage"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.SequenceMessageReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:SequenceMessageValuation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.SequenceMessageValuationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["interaction:StateFragment"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Interaction.StateFragmentReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:CapabilityRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.CapabilityRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:CapabilityRealizationPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.CapabilityRealizationPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:ContextInterfaceRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.ContextInterfaceRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:LogicalArchitecture"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalArchitectureReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:LogicalArchitecturePkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalArchitecturePkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:LogicalComponent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalComponentReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:LogicalComponentPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalComponentPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:LogicalFunction"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalFunctionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:LogicalFunctionPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalFunctionPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["la:SystemAnalysisRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.La.SystemAnalysisRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["libraries:LibraryReference"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Libraries.LibraryReferenceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["libraries:ModelInformation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Libraries.ModelInformationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["libraries:ModelVersion"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Libraries.ModelVersionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:ActivityAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.ActivityAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:CapabilityConfiguration"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.CapabilityConfigurationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:CommunicationMean"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.CommunicationMeanReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:CommunityOfInterest"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.CommunityOfInterestReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:CommunityOfInterestComposition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.CommunityOfInterestCompositionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:Concept"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.ConceptReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:ConceptCompliance"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.ConceptComplianceReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:ConceptPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.ConceptPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:Entity"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.EntityReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:EntityOperationalCapabilityInvolvement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.EntityOperationalCapabilityInvolvementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:EntityPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.EntityPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:ItemInConcept"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.ItemInConceptReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:Location"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.LocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OperationalActivity"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalActivityReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OperationalActivityPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalActivityPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OperationalAnalysis"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalAnalysisReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OperationalCapability"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalCapabilityReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OperationalCapabilityPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalCapabilityPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OperationalProcess"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalProcessReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OrganisationalUnit"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OrganisationalUnitReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:OrganisationalUnitComposition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.OrganisationalUnitCompositionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:Role"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.RoleReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:RoleAllocation"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.RoleAllocationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:RoleAssemblyUsage"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.RoleAssemblyUsageReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:RolePkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.RolePkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["oa:Swimlane"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Oa.SwimlaneReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:LogicalArchitectureRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.LogicalArchitectureRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:LogicalInterfaceRealization"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.LogicalInterfaceRealizationReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalArchitecture"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalArchitectureReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalArchitecturePkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalArchitecturePkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalComponent"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalComponentReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalComponentPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalComponentPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalFunction"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalFunctionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalFunctionPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalFunctionPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["pa:PhysicalNode"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalNodeReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:CatalogElement"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.CatalogElementReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:CatalogElementLink"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.CatalogElementLinkReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:CatalogElementPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.CatalogElementPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:CompliancyDefinition"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.CompliancyDefinitionReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:CompliancyDefinitionPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.CompliancyDefinitionPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:GroupingElementPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.GroupingElementPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["re:RecCatalog"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Re.RecCatalogReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["sharedmodel:GenericPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Sharedmodel.GenericPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
                ["sharedmodel:SharedPkg"] = (xmlReader, documentName, namespaceUri) => new Auriga.Xmi.AutoGenXmiReaders.Sharedmodel.SharedPkgReader(this.cache, this, this.settings, this.loggerFactory).Read(xmlReader, documentName, namespaceUri),
            };
        }

        /// <summary>
        /// Registers a document-level <c>xmlns</c> prefix-to-URI binding so an <c>xsi:type</c> prefix can
        /// be resolved even deep in the tree, where <see cref="XmlReader.LookupNamespace"/> no longer sees
        /// the root's declarations because of the nested <see cref="XmlReader.ReadSubtree"/> calls.
        /// </summary>
        /// <param name="prefix">the namespace prefix</param>
        /// <param name="namespaceUri">the namespace URI it is bound to</param>
        public void RegisterNamespace(string prefix, string namespaceUri)
        {
            this.prefixToNamespace[prefix] = namespaceUri;
        }

        /// <summary>
        /// Reads the element at the cursor of <paramref name="xmlReader"/> into a typed
        /// <see cref="IAurigaElement"/>, recursing into contained elements.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element to read</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <param name="explicitTypeKey">
        /// the package-qualified type key (<c>package:TypeName</c>) to use instead of the element's
        /// <c>xsi:type</c>, or <c>null</c> to resolve the type from <c>xsi:type</c>
        /// </param>
        /// <returns>the instantiated, populated element</returns>
        public IAurigaElement QueryElement(XmlReader xmlReader, string documentName, string namespaceUri, string explicitTypeKey = null)
        {
            var typeKey = explicitTypeKey ?? this.ResolveTypeKey(xmlReader);

            if (!this.readerFactories.TryGetValue(typeKey, out var factory))
            {
                throw new InvalidOperationException($"No XMI reader is registered for the type '{typeKey}'.");
            }

            using var subReader = xmlReader.ReadSubtree();
            subReader.MoveToContent();
            return factory(subReader, documentName, namespaceUri);
        }

        /// <summary>
        /// Resolves the package-qualified type key (<c>package:TypeName</c>) of the element at the cursor
        /// from its type attribute: the prefix is mapped to a namespace URI (via the registered document
        /// namespaces, falling back to <see cref="XmlReader.LookupNamespace"/>) and that URI to its Ecore
        /// package. The type is read from <c>xsi:type</c> (as Capella serializes it) or, failing that,
        /// <c>xmi:type</c> (as Sirius serializes it) — EMF treats the two as interchangeable.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the package-qualified type key</returns>
        /// <exception cref="InvalidDataException">
        /// the element carries no type attribute, or its prefix cannot be resolved to a known package
        /// </exception>
        private string ResolveTypeKey(XmlReader xmlReader)
        {
            var xsiType = xmlReader.GetAttribute("type", XsiNamespace) ?? xmlReader.GetAttribute("type", XmiNamespace);
            if (string.IsNullOrEmpty(xsiType))
            {
                throw new InvalidDataException("A contained element does not carry an xsi:type or xmi:type attribute.");
            }

            var separator = xsiType.IndexOf(':');
            var prefix = separator >= 0 ? xsiType.Substring(0, separator) : string.Empty;
            var typeName = separator >= 0 ? xsiType.Substring(separator + 1) : xsiType;

            if (!this.prefixToNamespace.TryGetValue(prefix, out var namespaceUri))
            {
                namespaceUri = xmlReader.LookupNamespace(prefix);
            }

            if (namespaceUri == null || !this.namespaceResolver.TryResolvePackage(namespaceUri, out var package))
            {
                throw new InvalidDataException($"Cannot resolve the type '{xsiType}' to a known package.");
            }

            return $"{package}:{typeName}";
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
