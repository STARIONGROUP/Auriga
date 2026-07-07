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

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Namespaces;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated registry that maps a package-qualified type key (<c>package:TypeName</c>) to the
    /// reader that instantiates it, and reads the element at the cursor by resolving its <c>xsi:type</c>.
    /// </summary>
    public sealed class XmiReaderFacade : IXmiReaderFacade
    {
        private const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        private readonly IXmiElementCache cache;

        private readonly INamespaceResolver namespaceResolver;

        private readonly ILoggerFactory loggerFactory;

        private readonly Dictionary<string, string> prefixToNamespace = new Dictionary<string, string>(StringComparer.Ordinal);

        private readonly Dictionary<string, Func<XmlReader, IAurigaElement>> readerFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderFacade"/> class.
        /// </summary>
        /// <param name="cache">the element cache shared with every reader</param>
        /// <param name="namespaceResolver">the namespace-URI-to-package resolver</param>
        /// <param name="loggerFactory">the logger factory shared with every reader, or <c>null</c> to disable logging</param>
        public XmiReaderFacade(IXmiElementCache cache, INamespaceResolver namespaceResolver, ILoggerFactory loggerFactory = null)
        {
            this.cache = cache;
            this.namespaceResolver = namespaceResolver;
            this.loggerFactory = loggerFactory;
            this.readerFactories = new Dictionary<string, Func<XmlReader, IAurigaElement>>(StringComparer.Ordinal)
            {
                ["CapellaRequirements:CapellaIncomingRelation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaIncomingRelationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["CapellaRequirements:CapellaModule"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaModuleReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["CapellaRequirements:CapellaOutgoingRelation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaOutgoingRelationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["CapellaRequirements:CapellaTypesFolder"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements.CapellaTypesFolderReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:AttributeDefinition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.AttributeDefinitionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:AttributeDefinitionEnumeration"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.AttributeDefinitionEnumerationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:BooleanValueAttribute"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.BooleanValueAttributeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:DataTypeDefinition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.DataTypeDefinitionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:DateValueAttribute"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.DateValueAttributeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:EnumValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.EnumValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:EnumerationDataTypeDefinition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.EnumerationDataTypeDefinitionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:EnumerationValueAttribute"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.EnumerationValueAttributeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:Folder"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.FolderReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:IntegerValueAttribute"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.IntegerValueAttributeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:InternalRelation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.InternalRelationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:Module"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.ModuleReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:ModuleType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.ModuleTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:RealValueAttribute"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RealValueAttributeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:RelationType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RelationTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:Requirement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RequirementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:RequirementType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.RequirementTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:StringValueAttribute"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.StringValueAttributeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["Requirements:TypesFolder"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Requirements.TypesFolderReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:AbstractStateRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.AbstractStateRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:CapabilityRealizationInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.CapabilityRealizationInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:ChangeEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ChangeEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:ChoicePseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ChoicePseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:DeepHistoryPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.DeepHistoryPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:EntryPointPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.EntryPointPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:ExitPointPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ExitPointPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:FinalState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.FinalStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:ForkPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ForkPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:GenericTrace"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.GenericTraceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:InitialPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.InitialPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:JoinPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.JoinPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:JustificationLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.JustificationLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:Mode"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ModeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:Region"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.RegionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:ShallowHistoryPseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.ShallowHistoryPseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:State"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:StateEventRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateEventRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:StateMachine"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateMachineReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:StateTransition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateTransitionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:StateTransitionRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.StateTransitionRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:TerminatePseudoState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.TerminatePseudoStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:TimeEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.TimeEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacommon:TransfoLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacommon.TransfoLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:BooleanPropertyValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.BooleanPropertyValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:Constraint"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.ConstraintReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:EnumerationPropertyLiteral"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.EnumerationPropertyLiteralReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:EnumerationPropertyType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.EnumerationPropertyTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:EnumerationPropertyValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.EnumerationPropertyValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:FloatPropertyValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.FloatPropertyValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:Generalization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.GeneralizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:IntegerPropertyValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.IntegerPropertyValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:KeyValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.KeyValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:NamingRule"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.NamingRuleReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:PropertyValueGroup"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.PropertyValueGroupReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:PropertyValuePkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.PropertyValuePkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:ReuseLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.ReuseLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellacore:StringPropertyValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellacore.StringPropertyValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellamodeller:Folder"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.FolderReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellamodeller:Library"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.LibraryReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellamodeller:Project"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.ProjectReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellamodeller:SystemEngineering"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.SystemEngineeringReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["capellamodeller:SystemEngineeringPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Capellamodeller.SystemEngineeringPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["communication:CommunicationLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.CommunicationLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["communication:Exception"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.ExceptionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["communication:Message"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.MessageReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["communication:MessageReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.MessageReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["communication:Signal"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.SignalReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["communication:SignalInstance"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Communication.SignalInstanceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:ComponentRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.ComponentRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:ExchangeItemAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.ExchangeItemAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:Interface"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfaceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:InterfaceImplementation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfaceImplementationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:InterfacePkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfacePkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:InterfaceUse"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.InterfaceUseReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:Part"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PartReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalLinkCategory"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkCategoryReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalLinkEnd"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkEndReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalLinkRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalLinkRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalPath"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalPathInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalPathRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalPathReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPathReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalPort"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPortReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["cs:PhysicalPortRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Cs.PhysicalPortRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:Capability"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:CapabilityExploitation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityExploitationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:CapabilityInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:CapabilityPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.CapabilityPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:Mission"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.MissionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:MissionInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.MissionInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:MissionPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.MissionPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:OperationalAnalysisRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.OperationalAnalysisRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemAnalysis"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemAnalysisReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemCommunication"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemCommunicationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemCommunicationHook"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemCommunicationHookReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemComponent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemComponentReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemComponentPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemComponentPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemFunction"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemFunctionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["ctx:SystemFunctionPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Ctx.SystemFunctionPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datatype:BooleanType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.BooleanTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datatype:Enumeration"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.EnumerationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datatype:NumericType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.NumericTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datatype:PhysicalQuantity"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.PhysicalQuantityReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datatype:StringType"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datatype.StringTypeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:BinaryExpression"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.BinaryExpressionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:BooleanReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.BooleanReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:ComplexValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.ComplexValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:ComplexValueReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.ComplexValueReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:EnumerationLiteral"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.EnumerationLiteralReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:EnumerationReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.EnumerationReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:LiteralBooleanValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.LiteralBooleanValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:LiteralNumericValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.LiteralNumericValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:LiteralStringValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.LiteralStringValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:NumericReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.NumericReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:OpaqueExpression"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.OpaqueExpressionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:StringReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.StringReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:UnaryExpression"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.UnaryExpressionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["datavalue:ValuePart"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.Datavalue.ValuePartReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:ComponentInstance"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.ComponentInstanceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:ConnectionInstance"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.ConnectionInstanceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:DeploymentAspect"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.DeploymentAspectReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:DeploymentConfiguration"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.DeploymentConfigurationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:InstanceDeploymentLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.InstanceDeploymentLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:PartDeploymentLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.PartDeploymentLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:PortInstance"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.PortInstanceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["deployment:TypeDeploymentLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.Deployment.TypeDeploymentLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["epbs:ConfigurationItem"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Epbs.ConfigurationItemReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["epbs:ConfigurationItemPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Epbs.ConfigurationItemPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["epbs:EPBSArchitecture"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Epbs.EPBSArchitectureReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["epbs:EPBSArchitecturePkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Epbs.EPBSArchitecturePkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["epbs:PhysicalArchitectureRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Epbs.PhysicalArchitectureRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["epbs:PhysicalArtifactRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Epbs.PhysicalArtifactRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentExchange"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentExchangeAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentExchangeCategory"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeCategoryReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentExchangeEnd"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeEndReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentExchangeFunctionalExchangeAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeFunctionalExchangeAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentExchangeRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentExchangeRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentFunctionalAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentFunctionalAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentPort"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentPortReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentPortAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentPortAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ComponentPortAllocationEnd"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ComponentPortAllocationEndReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ControlNode"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ControlNodeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ExchangeCategory"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ExchangeCategoryReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ExchangeContainment"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ExchangeContainmentReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:ExchangeLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.ExchangeLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionInputPort"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionInputPortReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionOutputPort"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionOutputPortReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionSpecification"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionSpecificationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalChain"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalChainInvolvementFunction"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainInvolvementFunctionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalChainInvolvementLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainInvolvementLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalChainRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalChainReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalChainReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalExchange"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalExchangeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalExchangeRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalExchangeRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:FunctionalExchangeSpecification"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.FunctionalExchangeSpecificationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["fa:SequenceLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Fa.SequenceLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Association"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.AssociationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Class"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ClassReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Collection"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.CollectionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:CollectionValue"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.CollectionValueReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:CollectionValueReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.CollectionValueReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:DataPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.DataPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:DomainElement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.DomainElementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:ExchangeItem"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:ExchangeItemElement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemElementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:ExchangeItemInstance"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemInstanceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:ExchangeItemRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ExchangeItemRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:InformationRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.InformationRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:KeyPart"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.KeyPartReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:OperationAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.OperationAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Parameter"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ParameterReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:PortAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.PortAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:PortRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.PortRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Property"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.PropertyReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Service"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.ServiceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Union"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.UnionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:UnionProperty"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.UnionPropertyReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["information:Unit"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Information.UnitReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:AbstractCapabilityExtend"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityExtendReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:AbstractCapabilityExtensionPoint"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityExtensionPointReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:AbstractCapabilityGeneralization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityGeneralizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:AbstractCapabilityInclude"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityIncludeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:AbstractCapabilityRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractCapabilityRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:AbstractFunctionAbstractCapabilityInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.AbstractFunctionAbstractCapabilityInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:ArmTimerEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ArmTimerEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:CancelTimerEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.CancelTimerEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:CombinedFragment"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.CombinedFragmentReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:ConstraintDuration"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ConstraintDurationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:CreationEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.CreationEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:DestructionEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.DestructionEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:EventReceiptOperation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.EventReceiptOperationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:EventSentOperation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.EventSentOperationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:Execution"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ExecutionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:ExecutionEnd"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ExecutionEndReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:ExecutionEvent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ExecutionEventReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:FragmentEnd"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.FragmentEndReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:FunctionalChainAbstractCapabilityInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.FunctionalChainAbstractCapabilityInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:Gate"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.GateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:InstanceRole"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InstanceRoleReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:InteractionOperand"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InteractionOperandReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:InteractionState"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InteractionStateReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:InteractionUse"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.InteractionUseReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:MergeLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.MergeLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:MessageEnd"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.MessageEndReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:RefinementLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.RefinementLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:Scenario"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ScenarioReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:ScenarioRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.ScenarioRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:SequenceMessage"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.SequenceMessageReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:SequenceMessageValuation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.SequenceMessageValuationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["interaction:StateFragment"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Interaction.StateFragmentReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:CapabilityRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.CapabilityRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:CapabilityRealizationPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.CapabilityRealizationPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:ContextInterfaceRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.ContextInterfaceRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:LogicalArchitecture"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalArchitectureReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:LogicalArchitecturePkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalArchitecturePkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:LogicalComponent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalComponentReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:LogicalComponentPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalComponentPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:LogicalFunction"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalFunctionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:LogicalFunctionPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.LogicalFunctionPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["la:SystemAnalysisRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.La.SystemAnalysisRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["libraries:LibraryReference"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Libraries.LibraryReferenceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["libraries:ModelInformation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Libraries.ModelInformationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["libraries:ModelVersion"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Libraries.ModelVersionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:ActivityAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.ActivityAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:CapabilityConfiguration"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.CapabilityConfigurationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:CommunicationMean"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.CommunicationMeanReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:CommunityOfInterest"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.CommunityOfInterestReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:CommunityOfInterestComposition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.CommunityOfInterestCompositionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:Concept"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.ConceptReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:ConceptCompliance"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.ConceptComplianceReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:ConceptPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.ConceptPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:Entity"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.EntityReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:EntityOperationalCapabilityInvolvement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.EntityOperationalCapabilityInvolvementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:EntityPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.EntityPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:ItemInConcept"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.ItemInConceptReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:Location"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.LocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OperationalActivity"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalActivityReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OperationalActivityPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalActivityPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OperationalAnalysis"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalAnalysisReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OperationalCapability"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalCapabilityReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OperationalCapabilityPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalCapabilityPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OperationalProcess"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OperationalProcessReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OrganisationalUnit"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OrganisationalUnitReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:OrganisationalUnitComposition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.OrganisationalUnitCompositionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:Role"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.RoleReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:RoleAllocation"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.RoleAllocationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:RoleAssemblyUsage"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.RoleAssemblyUsageReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:RolePkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.RolePkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["oa:Swimlane"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Oa.SwimlaneReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:LogicalArchitectureRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.LogicalArchitectureRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:LogicalInterfaceRealization"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.LogicalInterfaceRealizationReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalArchitecture"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalArchitectureReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalArchitecturePkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalArchitecturePkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalComponent"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalComponentReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalComponentPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalComponentPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalFunction"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalFunctionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalFunctionPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalFunctionPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["pa:PhysicalNode"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Pa.PhysicalNodeReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:CatalogElement"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.CatalogElementReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:CatalogElementLink"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.CatalogElementLinkReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:CatalogElementPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.CatalogElementPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:CompliancyDefinition"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.CompliancyDefinitionReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:CompliancyDefinitionPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.CompliancyDefinitionPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:GroupingElementPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.GroupingElementPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["re:RecCatalog"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Re.RecCatalogReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["sharedmodel:GenericPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Sharedmodel.GenericPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
                ["sharedmodel:SharedPkg"] = xmlReader => new Auriga.Xmi.AutoGenXmiReaders.Sharedmodel.SharedPkgReader(this.cache, this, this.loggerFactory).Read(xmlReader),
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
        /// <param name="explicitTypeKey">
        /// the package-qualified type key (<c>package:TypeName</c>) to use instead of the element's
        /// <c>xsi:type</c>, or <c>null</c> to resolve the type from <c>xsi:type</c>
        /// </param>
        /// <returns>the instantiated, populated element</returns>
        public IAurigaElement QueryElement(XmlReader xmlReader, string explicitTypeKey = null)
        {
            var typeKey = explicitTypeKey ?? this.ResolveTypeKey(xmlReader);

            if (!this.readerFactories.TryGetValue(typeKey, out var factory))
            {
                throw new InvalidOperationException($"No XMI reader is registered for the type '{typeKey}'.");
            }

            using var subReader = xmlReader.ReadSubtree();
            subReader.MoveToContent();
            return factory(subReader);
        }

        /// <summary>
        /// Resolves the package-qualified type key (<c>package:TypeName</c>) of the element at the cursor
        /// from its <c>xsi:type</c> attribute: the prefix is mapped to a namespace URI (via the registered
        /// document namespaces, falling back to <see cref="XmlReader.LookupNamespace"/>) and that URI to
        /// its Ecore package.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the package-qualified type key</returns>
        /// <exception cref="InvalidDataException">
        /// the element carries no <c>xsi:type</c>, or its prefix cannot be resolved to a known Capella package
        /// </exception>
        private string ResolveTypeKey(XmlReader xmlReader)
        {
            var xsiType = xmlReader.GetAttribute("type", XsiNamespace);
            if (string.IsNullOrEmpty(xsiType))
            {
                throw new InvalidDataException("A contained element does not carry an xsi:type attribute.");
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
                throw new InvalidDataException($"Cannot resolve the xsi:type '{xsiType}' to a known Capella package.");
            }

            return $"{package}:{typeName}";
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
