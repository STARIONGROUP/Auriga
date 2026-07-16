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

namespace Auriga.Xmi.Model.AutoGenXmiWriters
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Auriga.Core;
    using Auriga.Xmi.Core.Writers;

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
                [typeof(Auriga.Model.CapellaRequirements.CapellaIncomingRelation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.CapellaRequirements.CapellaIncomingRelationWriter(this, loggerFactory),
                [typeof(Auriga.Model.CapellaRequirements.CapellaModule)] = new Auriga.Xmi.Model.AutoGenXmiWriters.CapellaRequirements.CapellaModuleWriter(this, loggerFactory),
                [typeof(Auriga.Model.CapellaRequirements.CapellaOutgoingRelation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.CapellaRequirements.CapellaOutgoingRelationWriter(this, loggerFactory),
                [typeof(Auriga.Model.CapellaRequirements.CapellaTypesFolder)] = new Auriga.Xmi.Model.AutoGenXmiWriters.CapellaRequirements.CapellaTypesFolderWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.AttributeDefinition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.AttributeDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.AttributeDefinitionEnumeration)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.AttributeDefinitionEnumerationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.BooleanValueAttribute)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.BooleanValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.DataTypeDefinition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.DataTypeDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.DateValueAttribute)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.DateValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.EnumValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.EnumValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.EnumerationDataTypeDefinition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.EnumerationDataTypeDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.EnumerationValueAttribute)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.EnumerationValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.Folder)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.FolderWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.IntegerValueAttribute)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.IntegerValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.InternalRelation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.InternalRelationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.Module)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.ModuleWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.ModuleType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.ModuleTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.RealValueAttribute)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.RealValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.RelationType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.RelationTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.Requirement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.RequirementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.RequirementType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.RequirementTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.StringValueAttribute)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.StringValueAttributeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Requirements.TypesFolder)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Requirements.TypesFolderWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.AbstractStateRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.AbstractStateRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.CapabilityRealizationInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.CapabilityRealizationInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.ChangeEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.ChangeEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.ChoicePseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.ChoicePseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.DeepHistoryPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.DeepHistoryPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.EntryPointPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.EntryPointPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.ExitPointPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.ExitPointPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.FinalState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.FinalStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.ForkPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.ForkPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.GenericTrace)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.GenericTraceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.InitialPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.InitialPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.JoinPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.JoinPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.JustificationLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.JustificationLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.Mode)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.ModeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.Region)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.RegionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.ShallowHistoryPseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.ShallowHistoryPseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.State)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.StateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.StateEventRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.StateEventRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.StateMachine)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.StateMachineWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.StateTransition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.StateTransitionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.StateTransitionRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.StateTransitionRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.TerminatePseudoState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.TerminatePseudoStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.TimeEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.TimeEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacommon.TransfoLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacommon.TransfoLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.BooleanPropertyValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.BooleanPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.Constraint)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.ConstraintWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.EnumerationPropertyLiteral)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.EnumerationPropertyLiteralWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.EnumerationPropertyType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.EnumerationPropertyTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.EnumerationPropertyValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.EnumerationPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.FloatPropertyValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.FloatPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.Generalization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.GeneralizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.IntegerPropertyValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.IntegerPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.KeyValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.KeyValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.NamingRule)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.NamingRuleWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.PropertyValueGroup)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.PropertyValueGroupWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.PropertyValuePkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.PropertyValuePkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.ReuseLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.ReuseLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellacore.StringPropertyValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellacore.StringPropertyValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellamodeller.Folder)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellamodeller.FolderWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellamodeller.Library)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellamodeller.LibraryWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellamodeller.Project)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellamodeller.ProjectWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellamodeller.SystemEngineering)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellamodeller.SystemEngineeringWriter(this, loggerFactory),
                [typeof(Auriga.Model.Capellamodeller.SystemEngineeringPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Capellamodeller.SystemEngineeringPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Communication.CommunicationLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Communication.CommunicationLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Communication.Exception)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Communication.ExceptionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Communication.Message)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Communication.MessageWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Communication.MessageReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Communication.MessageReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Communication.Signal)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Communication.SignalWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Communication.SignalInstance)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Communication.SignalInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.ComponentRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.ComponentRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.ExchangeItemAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.ExchangeItemAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.Interface)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.InterfaceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.InterfaceImplementation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.InterfaceImplementationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.InterfacePkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.InterfacePkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.InterfaceUse)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.InterfaceUseWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.Part)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PartWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalLinkCategory)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalLinkCategoryWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalLinkEnd)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalLinkEndWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalLinkRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalLinkRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalPath)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalPathWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalPathInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalPathInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalPathRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalPathRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalPathReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalPathReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalPort)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalPortWriter(this, loggerFactory),
                [typeof(Auriga.Model.Cs.PhysicalPortRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Cs.PhysicalPortRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.Capability)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.CapabilityWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.CapabilityExploitation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.CapabilityExploitationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.CapabilityInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.CapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.CapabilityPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.CapabilityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.Mission)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.MissionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.MissionInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.MissionInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.MissionPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.MissionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.OperationalAnalysisRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.OperationalAnalysisRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemAnalysis)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemAnalysisWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemCommunication)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemCommunicationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemCommunicationHook)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemCommunicationHookWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemComponent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemComponentWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemComponentPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemComponentPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemFunction)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Ctx.SystemFunctionPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Ctx.SystemFunctionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datatype.BooleanType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datatype.BooleanTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datatype.Enumeration)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datatype.EnumerationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datatype.NumericType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datatype.NumericTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datatype.PhysicalQuantity)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datatype.PhysicalQuantityWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datatype.StringType)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datatype.StringTypeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.BinaryExpression)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.BinaryExpressionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.BooleanReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.BooleanReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.ComplexValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.ComplexValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.ComplexValueReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.ComplexValueReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.EnumerationLiteral)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.EnumerationLiteralWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.EnumerationReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.EnumerationReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.LiteralBooleanValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.LiteralBooleanValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.LiteralNumericValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.LiteralNumericValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.LiteralStringValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.LiteralStringValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.NumericReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.NumericReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.OpaqueExpression)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.OpaqueExpressionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.StringReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.StringReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.UnaryExpression)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.UnaryExpressionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Datavalue.ValuePart)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue.ValuePartWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.ComponentInstance)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.ComponentInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.ConnectionInstance)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.ConnectionInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.DeploymentAspect)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.DeploymentAspectWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.DeploymentConfiguration)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.DeploymentConfigurationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.InstanceDeploymentLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.InstanceDeploymentLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.PartDeploymentLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.PartDeploymentLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.PortInstance)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.PortInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.Deployment.TypeDeploymentLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.Deployment.TypeDeploymentLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Epbs.ConfigurationItem)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Epbs.ConfigurationItemWriter(this, loggerFactory),
                [typeof(Auriga.Model.Epbs.ConfigurationItemPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Epbs.ConfigurationItemPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Epbs.EPBSArchitecture)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Epbs.EPBSArchitectureWriter(this, loggerFactory),
                [typeof(Auriga.Model.Epbs.EPBSArchitecturePkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Epbs.EPBSArchitecturePkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Epbs.PhysicalArchitectureRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Epbs.PhysicalArchitectureRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Epbs.PhysicalArtifactRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Epbs.PhysicalArtifactRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentExchange)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentExchangeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentExchangeAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentExchangeAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentExchangeCategory)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentExchangeCategoryWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentExchangeEnd)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentExchangeEndWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentExchangeFunctionalExchangeAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentExchangeFunctionalExchangeAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentExchangeRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentExchangeRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentFunctionalAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentFunctionalAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentPort)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentPortWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentPortAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentPortAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ComponentPortAllocationEnd)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ComponentPortAllocationEndWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ControlNode)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ControlNodeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ExchangeCategory)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ExchangeCategoryWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ExchangeContainment)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ExchangeContainmentWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.ExchangeLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.ExchangeLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionInputPort)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionInputPortWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionOutputPort)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionOutputPortWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionSpecification)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionSpecificationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalChain)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalChainWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalChainInvolvementFunction)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalChainInvolvementFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalChainInvolvementLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalChainInvolvementLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalChainRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalChainRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalChainReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalChainReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalExchange)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalExchangeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalExchangeRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalExchangeRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.FunctionalExchangeSpecification)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.FunctionalExchangeSpecificationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Fa.SequenceLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Fa.SequenceLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Association)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.AssociationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Class)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ClassWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Collection)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.CollectionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.CollectionValue)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.CollectionValueWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.CollectionValueReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.CollectionValueReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.DataPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.DataPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.DomainElement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.DomainElementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.ExchangeItem)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ExchangeItemWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.ExchangeItemElement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ExchangeItemElementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.ExchangeItemInstance)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ExchangeItemInstanceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.ExchangeItemRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ExchangeItemRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.InformationRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.InformationRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.KeyPart)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.KeyPartWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.OperationAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.OperationAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Parameter)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ParameterWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.PortAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.PortAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.PortRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.PortRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Property)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.PropertyWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Service)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.ServiceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Union)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.UnionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.UnionProperty)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.UnionPropertyWriter(this, loggerFactory),
                [typeof(Auriga.Model.Information.Unit)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Information.UnitWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.AbstractCapabilityExtend)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.AbstractCapabilityExtendWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.AbstractCapabilityExtensionPoint)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.AbstractCapabilityExtensionPointWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.AbstractCapabilityGeneralization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.AbstractCapabilityGeneralizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.AbstractCapabilityInclude)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.AbstractCapabilityIncludeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.AbstractCapabilityRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.AbstractCapabilityRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.AbstractFunctionAbstractCapabilityInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.AbstractFunctionAbstractCapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.ArmTimerEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ArmTimerEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.CancelTimerEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.CancelTimerEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.CombinedFragment)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.CombinedFragmentWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.ConstraintDuration)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ConstraintDurationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.CreationEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.CreationEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.DestructionEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.DestructionEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.EventReceiptOperation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.EventReceiptOperationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.EventSentOperation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.EventSentOperationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.Execution)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ExecutionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.ExecutionEnd)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ExecutionEndWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.ExecutionEvent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ExecutionEventWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.FragmentEnd)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.FragmentEndWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.FunctionalChainAbstractCapabilityInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.FunctionalChainAbstractCapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.Gate)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.GateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.InstanceRole)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.InstanceRoleWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.InteractionOperand)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.InteractionOperandWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.InteractionState)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.InteractionStateWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.InteractionUse)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.InteractionUseWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.MergeLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.MergeLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.MessageEnd)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.MessageEndWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.RefinementLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.RefinementLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.Scenario)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ScenarioWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.ScenarioRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.ScenarioRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.SequenceMessage)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.SequenceMessageWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.SequenceMessageValuation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.SequenceMessageValuationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Interaction.StateFragment)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Interaction.StateFragmentWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.CapabilityRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.CapabilityRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.CapabilityRealizationPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.CapabilityRealizationPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.ContextInterfaceRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.ContextInterfaceRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.LogicalArchitecture)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.LogicalArchitectureWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.LogicalArchitecturePkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.LogicalArchitecturePkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.LogicalComponent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.LogicalComponentWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.LogicalComponentPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.LogicalComponentPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.LogicalFunction)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.LogicalFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.LogicalFunctionPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.LogicalFunctionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.La.SystemAnalysisRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.La.SystemAnalysisRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Libraries.LibraryReference)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Libraries.LibraryReferenceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Libraries.ModelInformation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Libraries.ModelInformationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Libraries.ModelVersion)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Libraries.ModelVersionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.ActivityAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.ActivityAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.CapabilityConfiguration)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.CapabilityConfigurationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.CommunicationMean)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.CommunicationMeanWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.CommunityOfInterest)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.CommunityOfInterestWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.CommunityOfInterestComposition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.CommunityOfInterestCompositionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.Concept)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.ConceptWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.ConceptCompliance)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.ConceptComplianceWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.ConceptPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.ConceptPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.Entity)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.EntityWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.EntityOperationalCapabilityInvolvement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.EntityOperationalCapabilityInvolvementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.EntityPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.EntityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.ItemInConcept)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.ItemInConceptWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.Location)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.LocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OperationalActivity)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OperationalActivityWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OperationalActivityPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OperationalActivityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OperationalAnalysis)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OperationalAnalysisWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OperationalCapability)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OperationalCapabilityWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OperationalCapabilityPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OperationalCapabilityPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OperationalProcess)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OperationalProcessWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OrganisationalUnit)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OrganisationalUnitWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.OrganisationalUnitComposition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.OrganisationalUnitCompositionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.Role)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.RoleWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.RoleAllocation)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.RoleAllocationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.RoleAssemblyUsage)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.RoleAssemblyUsageWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.RolePkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.RolePkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Oa.Swimlane)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Oa.SwimlaneWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.LogicalArchitectureRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.LogicalArchitectureRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.LogicalInterfaceRealization)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.LogicalInterfaceRealizationWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalArchitecture)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalArchitectureWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalArchitecturePkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalArchitecturePkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalComponent)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalComponentWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalComponentPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalComponentPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalFunction)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalFunctionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalFunctionPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalFunctionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Pa.PhysicalNode)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Pa.PhysicalNodeWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.CatalogElement)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.CatalogElementWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.CatalogElementLink)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.CatalogElementLinkWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.CatalogElementPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.CatalogElementPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.CompliancyDefinition)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.CompliancyDefinitionWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.CompliancyDefinitionPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.CompliancyDefinitionPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.GroupingElementPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.GroupingElementPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Re.RecCatalog)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Re.RecCatalogWriter(this, loggerFactory),
                [typeof(Auriga.Model.Sharedmodel.GenericPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Sharedmodel.GenericPkgWriter(this, loggerFactory),
                [typeof(Auriga.Model.Sharedmodel.SharedPkg)] = new Auriga.Xmi.Model.AutoGenXmiWriters.Sharedmodel.SharedPkgWriter(this, loggerFactory),
            };
        }

        /// <summary>
        /// Whether a writer is registered for the supplied element's runtime type — used by a composite
        /// facade to route an element to the metamodel facade that owns its type.
        /// </summary>
        /// <param name="element">the element to test</param>
        /// <returns>true when this facade can write the element</returns>
        public bool CanWrite(IAurigaElement element)
        {
            return this.writers.ContainsKey(element.GetType());
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
