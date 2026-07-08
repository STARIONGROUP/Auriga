// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementWriterFacade.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable enable

namespace Auriga.Xmi.AutoGenXmiWriters
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated registry that maps an element's runtime type to the writer that serializes it, and
    /// writes a contained element by dispatching on that type. The inverse of <c>XmiReaderFacade</c>.
    /// </summary>
    public sealed class XmiElementWriterFacade : IXmiElementWriterFacade
    {
        private readonly Dictionary<Type, IXmiElementWriter> writers;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementWriterFacade"/> class.
        /// </summary>
        /// <param name="loggerFactory">the logger factory shared with every writer, or <c>null</c> to disable logging</param>
        public XmiElementWriterFacade(ILoggerFactory? loggerFactory = null)
        {
            this.writers = new Dictionary<Type, IXmiElementWriter>()
            {
                [typeof(Auriga.CapellaRequirements.CapellaIncomingRelation)] = new Auriga.Xmi.AutoGenXmiWriters.CapellaRequirements.CapellaIncomingRelationWriter(this, loggerFactory),
                [typeof(Auriga.CapellaRequirements.CapellaModule)] = new Auriga.Xmi.AutoGenXmiWriters.CapellaRequirements.CapellaModuleWriter(this, loggerFactory),
                [typeof(Auriga.CapellaRequirements.CapellaOutgoingRelation)] = new Auriga.Xmi.AutoGenXmiWriters.CapellaRequirements.CapellaOutgoingRelationWriter(this, loggerFactory),
                [typeof(Auriga.CapellaRequirements.CapellaTypesFolder)] = new Auriga.Xmi.AutoGenXmiWriters.CapellaRequirements.CapellaTypesFolderWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.AttributeDefinition)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.AttributeDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.AttributeDefinitionEnumeration)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.AttributeDefinitionEnumerationWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.BooleanValueAttribute)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.BooleanValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.DataTypeDefinition)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.DataTypeDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.DateValueAttribute)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.DateValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.EnumValue)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.EnumValueWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.EnumerationDataTypeDefinition)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.EnumerationDataTypeDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.EnumerationValueAttribute)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.EnumerationValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.Folder)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.FolderWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.IntegerValueAttribute)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.IntegerValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.InternalRelation)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.InternalRelationWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.Module)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.ModuleWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.ModuleType)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.ModuleTypeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.RealValueAttribute)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.RealValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.RelationType)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.RelationTypeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.Requirement)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.RequirementWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.RequirementType)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.RequirementTypeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.StringValueAttribute)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.StringValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Requirements.TypesFolder)] = new Auriga.Xmi.AutoGenXmiWriters.Requirements.TypesFolderWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.AbstractStateRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.AbstractStateRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.CapabilityRealizationInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.CapabilityRealizationInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.ChangeEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.ChangeEventWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.ChoicePseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.ChoicePseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.DeepHistoryPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.DeepHistoryPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.EntryPointPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.EntryPointPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.ExitPointPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.ExitPointPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.FinalState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.FinalStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.ForkPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.ForkPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.GenericTrace)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.GenericTraceWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.InitialPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.InitialPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.JoinPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.JoinPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.JustificationLink)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.JustificationLinkWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.Mode)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.ModeWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.Region)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.RegionWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.ShallowHistoryPseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.ShallowHistoryPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.State)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.StateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.StateEventRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.StateEventRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.StateMachine)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.StateMachineWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.StateTransition)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.StateTransitionWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.StateTransitionRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.StateTransitionRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.TerminatePseudoState)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.TerminatePseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.TimeEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.TimeEventWriter(this, loggerFactory),
                [typeof(Auriga.Capellacommon.TransfoLink)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacommon.TransfoLinkWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.BooleanPropertyValue)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.BooleanPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.Constraint)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.ConstraintWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.EnumerationPropertyLiteral)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.EnumerationPropertyLiteralWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.EnumerationPropertyType)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.EnumerationPropertyTypeWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.EnumerationPropertyValue)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.EnumerationPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.FloatPropertyValue)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.FloatPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.Generalization)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.GeneralizationWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.IntegerPropertyValue)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.IntegerPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.KeyValue)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.KeyValueWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.NamingRule)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.NamingRuleWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.PropertyValueGroup)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.PropertyValueGroupWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.PropertyValuePkg)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.PropertyValuePkgWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.ReuseLink)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.ReuseLinkWriter(this, loggerFactory),
                [typeof(Auriga.Capellacore.StringPropertyValue)] = new Auriga.Xmi.AutoGenXmiWriters.Capellacore.StringPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Capellamodeller.Folder)] = new Auriga.Xmi.AutoGenXmiWriters.Capellamodeller.FolderWriter(this, loggerFactory),
                [typeof(Auriga.Capellamodeller.Library)] = new Auriga.Xmi.AutoGenXmiWriters.Capellamodeller.LibraryWriter(this, loggerFactory),
                [typeof(Auriga.Capellamodeller.Project)] = new Auriga.Xmi.AutoGenXmiWriters.Capellamodeller.ProjectWriter(this, loggerFactory),
                [typeof(Auriga.Capellamodeller.SystemEngineering)] = new Auriga.Xmi.AutoGenXmiWriters.Capellamodeller.SystemEngineeringWriter(this, loggerFactory),
                [typeof(Auriga.Capellamodeller.SystemEngineeringPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Capellamodeller.SystemEngineeringPkgWriter(this, loggerFactory),
                [typeof(Auriga.Information.Communication.CommunicationLink)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Communication.CommunicationLinkWriter(this, loggerFactory),
                [typeof(Auriga.Information.Communication.Exception)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Communication.ExceptionWriter(this, loggerFactory),
                [typeof(Auriga.Information.Communication.Message)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Communication.MessageWriter(this, loggerFactory),
                [typeof(Auriga.Information.Communication.MessageReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Communication.MessageReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Communication.Signal)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Communication.SignalWriter(this, loggerFactory),
                [typeof(Auriga.Information.Communication.SignalInstance)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Communication.SignalInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Cs.ComponentRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.ComponentRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Cs.ExchangeItemAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.ExchangeItemAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Cs.Interface)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.InterfaceWriter(this, loggerFactory),
                [typeof(Auriga.Cs.InterfaceImplementation)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.InterfaceImplementationWriter(this, loggerFactory),
                [typeof(Auriga.Cs.InterfacePkg)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.InterfacePkgWriter(this, loggerFactory),
                [typeof(Auriga.Cs.InterfaceUse)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.InterfaceUseWriter(this, loggerFactory),
                [typeof(Auriga.Cs.Part)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PartWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalLink)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalLinkWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalLinkCategory)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalLinkCategoryWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalLinkEnd)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalLinkEndWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalLinkRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalLinkRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalPath)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalPathWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalPathInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalPathInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalPathRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalPathRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalPathReference)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalPathReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalPort)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalPortWriter(this, loggerFactory),
                [typeof(Auriga.Cs.PhysicalPortRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Cs.PhysicalPortRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.Capability)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.CapabilityWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.CapabilityExploitation)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.CapabilityExploitationWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.CapabilityInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.CapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.CapabilityPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.CapabilityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.Mission)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.MissionWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.MissionInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.MissionInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.MissionPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.MissionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.OperationalAnalysisRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.OperationalAnalysisRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemAnalysis)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemAnalysisWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemCommunication)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemCommunicationWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemCommunicationHook)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemCommunicationHookWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemComponent)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemComponentWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemComponentPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemComponentPkgWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemFunction)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Ctx.SystemFunctionPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Ctx.SystemFunctionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datatype.BooleanType)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datatype.BooleanTypeWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datatype.Enumeration)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datatype.EnumerationWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datatype.NumericType)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datatype.NumericTypeWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datatype.PhysicalQuantity)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datatype.PhysicalQuantityWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datatype.StringType)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datatype.StringTypeWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.BinaryExpression)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.BinaryExpressionWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.BooleanReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.BooleanReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.ComplexValue)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.ComplexValueWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.ComplexValueReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.ComplexValueReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.EnumerationLiteral)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.EnumerationLiteralWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.EnumerationReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.EnumerationReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.LiteralBooleanValue)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.LiteralBooleanValueWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.LiteralNumericValue)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.LiteralNumericValueWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.LiteralStringValue)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.LiteralStringValueWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.NumericReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.NumericReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.OpaqueExpression)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.OpaqueExpressionWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.StringReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.StringReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.UnaryExpression)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.UnaryExpressionWriter(this, loggerFactory),
                [typeof(Auriga.Information.Datavalue.ValuePart)] = new Auriga.Xmi.AutoGenXmiWriters.Information.Datavalue.ValuePartWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.ComponentInstance)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.ComponentInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.ConnectionInstance)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.ConnectionInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.DeploymentAspect)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.DeploymentAspectWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.DeploymentConfiguration)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.DeploymentConfigurationWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.InstanceDeploymentLink)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.InstanceDeploymentLinkWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.PartDeploymentLink)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.PartDeploymentLinkWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.PortInstance)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.PortInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Pa.Deployment.TypeDeploymentLink)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment.TypeDeploymentLinkWriter(this, loggerFactory),
                [typeof(Auriga.Epbs.ConfigurationItem)] = new Auriga.Xmi.AutoGenXmiWriters.Epbs.ConfigurationItemWriter(this, loggerFactory),
                [typeof(Auriga.Epbs.ConfigurationItemPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Epbs.ConfigurationItemPkgWriter(this, loggerFactory),
                [typeof(Auriga.Epbs.EPBSArchitecture)] = new Auriga.Xmi.AutoGenXmiWriters.Epbs.EPBSArchitectureWriter(this, loggerFactory),
                [typeof(Auriga.Epbs.EPBSArchitecturePkg)] = new Auriga.Xmi.AutoGenXmiWriters.Epbs.EPBSArchitecturePkgWriter(this, loggerFactory),
                [typeof(Auriga.Epbs.PhysicalArchitectureRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Epbs.PhysicalArchitectureRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Epbs.PhysicalArtifactRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Epbs.PhysicalArtifactRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentExchange)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentExchangeWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentExchangeAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentExchangeAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentExchangeCategory)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentExchangeCategoryWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentExchangeEnd)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentExchangeEndWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentExchangeFunctionalExchangeAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentExchangeFunctionalExchangeAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentExchangeRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentExchangeRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentFunctionalAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentFunctionalAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentPort)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentPortWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentPortAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentPortAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ComponentPortAllocationEnd)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ComponentPortAllocationEndWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ControlNode)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ControlNodeWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ExchangeCategory)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ExchangeCategoryWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ExchangeContainment)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ExchangeContainmentWriter(this, loggerFactory),
                [typeof(Auriga.Fa.ExchangeLink)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.ExchangeLinkWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionInputPort)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionInputPortWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionOutputPort)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionOutputPortWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionSpecification)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionSpecificationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalChain)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalChainWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalChainInvolvementFunction)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalChainInvolvementFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalChainInvolvementLink)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalChainInvolvementLinkWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalChainRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalChainRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalChainReference)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalChainReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalExchange)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalExchangeWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalExchangeRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalExchangeRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.FunctionalExchangeSpecification)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.FunctionalExchangeSpecificationWriter(this, loggerFactory),
                [typeof(Auriga.Fa.SequenceLink)] = new Auriga.Xmi.AutoGenXmiWriters.Fa.SequenceLinkWriter(this, loggerFactory),
                [typeof(Auriga.Information.Association)] = new Auriga.Xmi.AutoGenXmiWriters.Information.AssociationWriter(this, loggerFactory),
                [typeof(Auriga.Information.Class)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ClassWriter(this, loggerFactory),
                [typeof(Auriga.Information.Collection)] = new Auriga.Xmi.AutoGenXmiWriters.Information.CollectionWriter(this, loggerFactory),
                [typeof(Auriga.Information.CollectionValue)] = new Auriga.Xmi.AutoGenXmiWriters.Information.CollectionValueWriter(this, loggerFactory),
                [typeof(Auriga.Information.CollectionValueReference)] = new Auriga.Xmi.AutoGenXmiWriters.Information.CollectionValueReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Information.DataPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Information.DataPkgWriter(this, loggerFactory),
                [typeof(Auriga.Information.DomainElement)] = new Auriga.Xmi.AutoGenXmiWriters.Information.DomainElementWriter(this, loggerFactory),
                [typeof(Auriga.Information.ExchangeItem)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ExchangeItemWriter(this, loggerFactory),
                [typeof(Auriga.Information.ExchangeItemElement)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ExchangeItemElementWriter(this, loggerFactory),
                [typeof(Auriga.Information.ExchangeItemInstance)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ExchangeItemInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Information.ExchangeItemRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ExchangeItemRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Information.InformationRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Information.InformationRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Information.KeyPart)] = new Auriga.Xmi.AutoGenXmiWriters.Information.KeyPartWriter(this, loggerFactory),
                [typeof(Auriga.Information.OperationAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Information.OperationAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Information.Parameter)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ParameterWriter(this, loggerFactory),
                [typeof(Auriga.Information.PortAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Information.PortAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Information.PortRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Information.PortRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Information.Property)] = new Auriga.Xmi.AutoGenXmiWriters.Information.PropertyWriter(this, loggerFactory),
                [typeof(Auriga.Information.Service)] = new Auriga.Xmi.AutoGenXmiWriters.Information.ServiceWriter(this, loggerFactory),
                [typeof(Auriga.Information.Union)] = new Auriga.Xmi.AutoGenXmiWriters.Information.UnionWriter(this, loggerFactory),
                [typeof(Auriga.Information.UnionProperty)] = new Auriga.Xmi.AutoGenXmiWriters.Information.UnionPropertyWriter(this, loggerFactory),
                [typeof(Auriga.Information.Unit)] = new Auriga.Xmi.AutoGenXmiWriters.Information.UnitWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.AbstractCapabilityExtend)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.AbstractCapabilityExtendWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.AbstractCapabilityExtensionPoint)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.AbstractCapabilityExtensionPointWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.AbstractCapabilityGeneralization)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.AbstractCapabilityGeneralizationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.AbstractCapabilityInclude)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.AbstractCapabilityIncludeWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.AbstractCapabilityRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.AbstractCapabilityRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.AbstractFunctionAbstractCapabilityInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.AbstractFunctionAbstractCapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.ArmTimerEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ArmTimerEventWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.CancelTimerEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.CancelTimerEventWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.CombinedFragment)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.CombinedFragmentWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.ConstraintDuration)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ConstraintDurationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.CreationEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.CreationEventWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.DestructionEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.DestructionEventWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.EventReceiptOperation)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.EventReceiptOperationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.EventSentOperation)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.EventSentOperationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.Execution)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ExecutionWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.ExecutionEnd)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ExecutionEndWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.ExecutionEvent)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ExecutionEventWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.FragmentEnd)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.FragmentEndWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.FunctionalChainAbstractCapabilityInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.FunctionalChainAbstractCapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.Gate)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.GateWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.InstanceRole)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.InstanceRoleWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.InteractionOperand)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.InteractionOperandWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.InteractionState)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.InteractionStateWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.InteractionUse)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.InteractionUseWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.MergeLink)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.MergeLinkWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.MessageEnd)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.MessageEndWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.RefinementLink)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.RefinementLinkWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.Scenario)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ScenarioWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.ScenarioRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.ScenarioRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.SequenceMessage)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.SequenceMessageWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.SequenceMessageValuation)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.SequenceMessageValuationWriter(this, loggerFactory),
                [typeof(Auriga.Interaction.StateFragment)] = new Auriga.Xmi.AutoGenXmiWriters.Interaction.StateFragmentWriter(this, loggerFactory),
                [typeof(Auriga.La.CapabilityRealization)] = new Auriga.Xmi.AutoGenXmiWriters.La.CapabilityRealizationWriter(this, loggerFactory),
                [typeof(Auriga.La.CapabilityRealizationPkg)] = new Auriga.Xmi.AutoGenXmiWriters.La.CapabilityRealizationPkgWriter(this, loggerFactory),
                [typeof(Auriga.La.ContextInterfaceRealization)] = new Auriga.Xmi.AutoGenXmiWriters.La.ContextInterfaceRealizationWriter(this, loggerFactory),
                [typeof(Auriga.La.LogicalArchitecture)] = new Auriga.Xmi.AutoGenXmiWriters.La.LogicalArchitectureWriter(this, loggerFactory),
                [typeof(Auriga.La.LogicalArchitecturePkg)] = new Auriga.Xmi.AutoGenXmiWriters.La.LogicalArchitecturePkgWriter(this, loggerFactory),
                [typeof(Auriga.La.LogicalComponent)] = new Auriga.Xmi.AutoGenXmiWriters.La.LogicalComponentWriter(this, loggerFactory),
                [typeof(Auriga.La.LogicalComponentPkg)] = new Auriga.Xmi.AutoGenXmiWriters.La.LogicalComponentPkgWriter(this, loggerFactory),
                [typeof(Auriga.La.LogicalFunction)] = new Auriga.Xmi.AutoGenXmiWriters.La.LogicalFunctionWriter(this, loggerFactory),
                [typeof(Auriga.La.LogicalFunctionPkg)] = new Auriga.Xmi.AutoGenXmiWriters.La.LogicalFunctionPkgWriter(this, loggerFactory),
                [typeof(Auriga.La.SystemAnalysisRealization)] = new Auriga.Xmi.AutoGenXmiWriters.La.SystemAnalysisRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Libraries.LibraryReference)] = new Auriga.Xmi.AutoGenXmiWriters.Libraries.LibraryReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Libraries.ModelInformation)] = new Auriga.Xmi.AutoGenXmiWriters.Libraries.ModelInformationWriter(this, loggerFactory),
                [typeof(Auriga.Libraries.ModelVersion)] = new Auriga.Xmi.AutoGenXmiWriters.Libraries.ModelVersionWriter(this, loggerFactory),
                [typeof(Auriga.Oa.ActivityAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.ActivityAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Oa.CapabilityConfiguration)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.CapabilityConfigurationWriter(this, loggerFactory),
                [typeof(Auriga.Oa.CommunicationMean)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.CommunicationMeanWriter(this, loggerFactory),
                [typeof(Auriga.Oa.CommunityOfInterest)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.CommunityOfInterestWriter(this, loggerFactory),
                [typeof(Auriga.Oa.CommunityOfInterestComposition)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.CommunityOfInterestCompositionWriter(this, loggerFactory),
                [typeof(Auriga.Oa.Concept)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.ConceptWriter(this, loggerFactory),
                [typeof(Auriga.Oa.ConceptCompliance)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.ConceptComplianceWriter(this, loggerFactory),
                [typeof(Auriga.Oa.ConceptPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.ConceptPkgWriter(this, loggerFactory),
                [typeof(Auriga.Oa.Entity)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.EntityWriter(this, loggerFactory),
                [typeof(Auriga.Oa.EntityOperationalCapabilityInvolvement)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.EntityOperationalCapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Oa.EntityPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.EntityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Oa.ItemInConcept)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.ItemInConceptWriter(this, loggerFactory),
                [typeof(Auriga.Oa.Location)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.LocationWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OperationalActivity)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OperationalActivityWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OperationalActivityPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OperationalActivityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OperationalAnalysis)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OperationalAnalysisWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OperationalCapability)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OperationalCapabilityWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OperationalCapabilityPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OperationalCapabilityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OperationalProcess)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OperationalProcessWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OrganisationalUnit)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OrganisationalUnitWriter(this, loggerFactory),
                [typeof(Auriga.Oa.OrganisationalUnitComposition)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.OrganisationalUnitCompositionWriter(this, loggerFactory),
                [typeof(Auriga.Oa.Role)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.RoleWriter(this, loggerFactory),
                [typeof(Auriga.Oa.RoleAllocation)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.RoleAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Oa.RoleAssemblyUsage)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.RoleAssemblyUsageWriter(this, loggerFactory),
                [typeof(Auriga.Oa.RolePkg)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.RolePkgWriter(this, loggerFactory),
                [typeof(Auriga.Oa.Swimlane)] = new Auriga.Xmi.AutoGenXmiWriters.Oa.SwimlaneWriter(this, loggerFactory),
                [typeof(Auriga.Pa.LogicalArchitectureRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.LogicalArchitectureRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Pa.LogicalInterfaceRealization)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.LogicalInterfaceRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalArchitecture)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalArchitectureWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalArchitecturePkg)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalArchitecturePkgWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalComponent)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalComponentWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalComponentPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalComponentPkgWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalFunction)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalFunctionPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalFunctionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Pa.PhysicalNode)] = new Auriga.Xmi.AutoGenXmiWriters.Pa.PhysicalNodeWriter(this, loggerFactory),
                [typeof(Auriga.Re.CatalogElement)] = new Auriga.Xmi.AutoGenXmiWriters.Re.CatalogElementWriter(this, loggerFactory),
                [typeof(Auriga.Re.CatalogElementLink)] = new Auriga.Xmi.AutoGenXmiWriters.Re.CatalogElementLinkWriter(this, loggerFactory),
                [typeof(Auriga.Re.CatalogElementPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Re.CatalogElementPkgWriter(this, loggerFactory),
                [typeof(Auriga.Re.CompliancyDefinition)] = new Auriga.Xmi.AutoGenXmiWriters.Re.CompliancyDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Re.CompliancyDefinitionPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Re.CompliancyDefinitionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Re.GroupingElementPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Re.GroupingElementPkgWriter(this, loggerFactory),
                [typeof(Auriga.Re.RecCatalog)] = new Auriga.Xmi.AutoGenXmiWriters.Re.RecCatalogWriter(this, loggerFactory),
                [typeof(Auriga.Sharedmodel.GenericPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Sharedmodel.GenericPkgWriter(this, loggerFactory),
                [typeof(Auriga.Sharedmodel.SharedPkg)] = new Auriga.Xmi.AutoGenXmiWriters.Sharedmodel.SharedPkgWriter(this, loggerFactory),
            };
        }

        /// <summary>
        /// Writes <paramref name="element"/> as a contained child under <paramref name="roleName"/> by
        /// dispatching to the writer registered for its runtime type.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element to write</param>
        /// <param name="roleName">the containment feature's XML name</param>
        /// <param name="context">the write context</param>
        public void WriteElement(XmlWriter xmlWriter, IAurigaElement element, string roleName, IXmiWriteContext context)
        {
            this.ResolveWriter(element).Write(xmlWriter, element, roleName, context);
        }

        /// <summary>
        /// Resolves the per-type writer registered for <paramref name="element"/>'s runtime type.
        /// </summary>
        /// <param name="element">the element to resolve a writer for</param>
        /// <returns>the writer registered for the element's runtime type</returns>
        /// <exception cref="InvalidOperationException">no writer is registered for the element's type</exception>
        public IXmiElementWriter ResolveWriter(IAurigaElement element)
        {
            if (!this.writers.TryGetValue(element.GetType(), out var writer))
            {
                throw new InvalidOperationException($"No XMI writer is registered for the type '{element.GetType().FullName}'.");
            }

            return writer;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
