// ------------------------------------------------------------------------------------------------
// <copyright file="Case.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// If the evaluation of the condition returns true then all operations contains by this case statement will be executed, otherwise all operations will be ignored.
    /// </summary>
    public partial class Case : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.ICase
    {
        /// <summary>
        /// Expression representing the condition, if it returns true, every operation contained by this statement will be executed.
        /// </summary>
        public string ConditionExpression { get; set; }

        /// <summary>
        /// Gets the sub model operations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> SubModelOperations => this.backingSubModelOperations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation>(this);

        /// <summary>
        /// Backing field for <see cref="SubModelOperations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> backingSubModelOperations;

        /// <summary>
        /// Gets the elements directly contained by this <c>Case</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.SubModelOperations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
