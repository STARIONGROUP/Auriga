// ------------------------------------------------------------------------------------------------
// <copyright file="ExpectedClasses.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests.Expected
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The "interesting classes" reported by ECoreNetto's <c>ModelInspector</c> over the Capella
    /// metamodel: the minimal set that, taken together, exercises every variation of value type,
    /// reference type, enum and multiplicity. The code generator is expected to produce an interface
    /// (and, for the concrete ones, an implementation class) that matches the committed golden files
    /// under <c>Expected/</c> for each of these.
    /// </summary>
    public sealed class ExpectedAllClasses : IEnumerable<string>
    {
        /// <summary>
        /// Returns an enumerator that iterates over the class names.
        /// </summary>
        /// <returns>an enumerator over the class names</returns>
        public IEnumerator<string> GetEnumerator()
        {
            yield return "AbstractAction";
            yield return "AbstractActivity";
            yield return "AbstractNamedElement";
            yield return "ActivityEdge";
            yield return "Association";
            yield return "Component";
            yield return "DateValueAttribute";
            yield return "ExceptionHandler";
            yield return "ExchangeItem";
            yield return "FloatPropertyValue";
            yield return "IntegerPropertyValue";
            yield return "InterruptibleActivityRegion";
            yield return "ModelElement";
            yield return "ModelVersion";
            yield return "OpaqueExpression";
            yield return "PhysicalLink";
            yield return "RealValueAttribute";
            yield return "Requirement";
            yield return "SendSignalAction";
            yield return "SystemCommunication";
        }

        /// <summary>
        /// Returns an enumerator that iterates over the class names.
        /// </summary>
        /// <returns>an enumerator over the class names</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    /// <summary>
    /// The concrete subset of the <see cref="ExpectedAllClasses"/> — the interesting classes that are
    /// not abstract and therefore get a generated implementation class.
    /// </summary>
    public sealed class ExpectedConcreteClasses : IEnumerable<string>
    {
        /// <summary>
        /// Returns an enumerator that iterates over the class names.
        /// </summary>
        /// <returns>an enumerator over the class names</returns>
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Association";
            yield return "DateValueAttribute";
            yield return "ExchangeItem";
            yield return "FloatPropertyValue";
            yield return "IntegerPropertyValue";
            yield return "ModelVersion";
            yield return "OpaqueExpression";
            yield return "PhysicalLink";
            yield return "RealValueAttribute";
            yield return "Requirement";
            yield return "SystemCommunication";
        }

        /// <summary>
        /// Returns an enumerator that iterates over the class names.
        /// </summary>
        /// <returns>an enumerator over the class names</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
