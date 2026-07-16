// ------------------------------------------------------------------------------------------------
// <copyright file="CSharpType.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Helpers
{
    using System;
    using System.Collections.Generic;

    using ECoreNetto;

    /// <summary>
    /// Resolves an Ecore <see cref="EStructuralFeature"/> to the C# member declarations emitted in
    /// the generated interface and implementation class, per the feature-mapping and type-mapping
    /// rules in <c>docs/codegen-design.md</c> §5/§6. Types are rendered fully-qualified so the
    /// generated code needs no <c>using</c> management.
    /// </summary>
    public static class CSharpType
    {
        /// <summary>
        /// The C# <c>string</c> type name, the mapping target for every textual Ecore datatype.
        /// </summary>
        private const string StringType = "string";

        /// <summary>
        /// The C# <c>object</c> type name, the mapping target for opaque Ecore system datatypes and a
        /// containment of <c>ecore::EObject</c>.
        /// </summary>
        private const string ObjectType = "object";

        /// <summary>
        /// The Ecore built-in datatype name to C# type mapping (design §6).
        /// </summary>
        private static readonly Dictionary<string, string> PrimitiveMap = new(StringComparer.Ordinal)
        {
            ["EString"] = StringType,
            ["EBoolean"] = "bool", ["EBooleanObject"] = "bool",
            ["EByte"] = "sbyte", ["EByteObject"] = "sbyte", ["EByteArray"] = "byte[]",
            ["EChar"] = "char", ["ECharacterObject"] = "char",
            ["EShort"] = "short", ["EShortObject"] = "short",
            ["EInt"] = "int", ["EIntegerObject"] = "int",
            ["ELong"] = "long", ["ELongObject"] = "long",
            ["EFloat"] = "float", ["EFloatObject"] = "float",
            ["EDouble"] = "double", ["EDoubleObject"] = "double",
            ["EBigDecimal"] = "decimal", ["EBigInteger"] = "BigInteger",
            ["EDate"] = "DateTime",
            ["EJavaObject"] = ObjectType, ["EJavaClass"] = "Type",

            // Ecore built-in "system" datatypes reached as feature types in the Sirius/GMF metamodels
            // (e.g. GMF View.diagram's resource plumbing). They are opaque runtime handles carried on
            // transient/volatile features, so they map to object.
            ["EResource"] = ObjectType, ["EResourceSet"] = ObjectType, ["EMap"] = ObjectType,
            ["EFeatureMap"] = ObjectType, ["EFeatureMapEntry"] = ObjectType, ["EDiagnosticChain"] = ObjectType,
            ["EEList"] = ObjectType, ["EInvocationTargetException"] = ObjectType,
            ["ETreeIterator"] = ObjectType, ["EEnumerator"] = ObjectType,

            // Sirius + GMF custom EDataTypes (resources/ecore-sirius). Each serializes to a single XMI
            // lexical token, so the faithful, round-trippable mapping is the raw string; structured
            // interpretation (colors, bendpoint lists, resource descriptors) is left to later phases.
            ["FeatureName"] = StringType, ["FilterKeyList"] = StringType, ["GradientData"] = StringType,
            ["ImagePath"] = StringType, ["InterpretedExpression"] = StringType,
            ["RelativeBendpointList"] = StringType, ["ResourceDescriptor"] = StringType,
            ["RGBValues"] = StringType, ["SortKeyMap"] = StringType, ["TranslatableMessage"] = StringType,
            ["TypeName"] = StringType, ["URI"] = StringType
        };

        /// <summary>
        /// The C# types that are value types (so an optional occurrence renders as <c>T?</c>).
        /// </summary>
        private static readonly HashSet<string> ValueTypes = new(StringComparer.Ordinal)
        {
            "bool", "sbyte", "char", "short", "int", "long", "float", "double", "decimal",
            "BigInteger", "DateTime"
        };

        /// <summary>
        /// Renders the base (non-collection, non-nullable) C# type of a feature's <see cref="EClassifier"/>.
        /// </summary>
        /// <param name="eType">the feature's type</param>
        /// <returns>the fully-qualified base C# type</returns>
        public static string BaseType(EClassifier? eType)
        {
            switch (eType)
            {
                case EEnum eEnum:
                    return CSharpNaming.EnumType(eEnum);
                case EClass eClass when eClass.EPackage != null:
                    return CSharpNaming.InterfaceType(eClass);
                case EClass:
                    // an Ecore built-in reached as a feature type (only ecore::EObject occurs)
                    return ObjectType;
                case EDataType dataType when PrimitiveMap.TryGetValue(dataType.Name, out var cSharp):
                    return cSharp;
                default:
                    throw new NotSupportedException(
                        $"No C# type mapping for Ecore type '{eType?.Name ?? "<null>"}'.");
            }
        }

        /// <summary>
        /// Determines whether a feature is a collection (upper bound unbounded or greater than one).
        /// The EMF-derived <c>Many</c> flag is not serialized reliably, so bounds are used instead.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>true when the feature is a collection</returns>
        public static bool IsCollection(EStructuralFeature feature)
        {
            return feature.UpperBound == -1 || feature.UpperBound > 1;
        }

        /// <summary>
        /// Determines whether a feature is derived, volatile or transient, i.e. not stored and not serialized.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>true when the feature is computed rather than stored</returns>
        public static bool IsComputed(EStructuralFeature feature)
        {
            return feature.Derived || feature.Volatile || feature.Transient;
        }

        /// <summary>
        /// Renders the C# type used for the member (identical in the interface and the implementation
        /// class so the class implicitly implements the interface member).
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the declared C# member type</returns>
        public static string MemberType(EStructuralFeature feature)
        {
            var baseType = BaseType(feature.EType);
            var collection = IsCollection(feature);
            var containment = feature is EReference { IsContainment: true };

            if (IsComputed(feature))
            {
                return collection ? $"IEnumerable<{baseType}>" : ScalarType(feature, baseType);
            }

            if (containment)
            {
                var elementType = ContainmentElementType(feature);
                return collection ? $"Auriga.Core.IContainerList<{elementType}>" : elementType;
            }

            if (collection)
            {
                return $"List<{baseType}>";
            }

            return ScalarType(feature, baseType);
        }

        /// <summary>
        /// Renders the element type of a containment feature. A containment reference always holds model
        /// elements, so a containment of <c>ecore::EObject</c> (whose base type is <c>object</c>) is typed
        /// as <c>Auriga.Core.IAurigaElement</c> — the shared element base — so it satisfies the
        /// <c>IContainerList&lt;T&gt;</c>/<c>ContainerList&lt;T&gt;</c> element constraint. Every other
        /// target keeps its generated interface type. (No Capella containment targets <c>EObject</c>, so
        /// Capella output is unchanged.)
        /// </summary>
        /// <param name="feature">the containment structural feature</param>
        /// <returns>the containment element type</returns>
        public static string ContainmentElementType(EStructuralFeature feature)
        {
            var baseType = BaseType(feature.EType);

            return baseType == ObjectType ? "Auriga.Core.IAurigaElement" : baseType;
        }

        /// <summary>
        /// Returns the BCL namespaces a feature's rendered member requires, so the generated file can
        /// emit exactly the <c>using</c> directives it needs (Auriga model types are fully qualified
        /// and never need a using).
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the required BCL namespaces</returns>
        public static IEnumerable<string> RequiredNamespaces(EStructuralFeature feature)
        {
            var collection = IsCollection(feature);
            var containment = feature is EReference { IsContainment: true };

            if (collection)
            {
                if (IsComputed(feature))
                {
                    yield return "System.Collections.Generic";
                    yield return "System.Linq";
                }
                else if (!containment)
                {
                    yield return "System.Collections.Generic";
                }

                yield break;
            }

            switch (BaseType(feature.EType))
            {
                case "DateTime":
                case "Type":
                    yield return "System";
                    break;
                case "BigInteger":
                    yield return "System.Numerics";
                    break;
            }
        }

        /// <summary>
        /// Renders a scalar member type, appending <c>?</c> for an optional value type.
        /// </summary>
        private static string ScalarType(EStructuralFeature feature, string baseType)
        {
            var optional = feature.LowerBound == 0;
            var isValueType = ValueTypes.Contains(baseType) || feature.EType is EEnum;

            return optional && isValueType ? baseType + "?" : baseType;
        }
    }
}
