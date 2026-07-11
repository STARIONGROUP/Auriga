// ------------------------------------------------------------------------------------------------
// <copyright file="CreateInstance.cs" company="Starion Group S.A.">
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
    /// This operation allows to create a new instance. The context must be the container of the new
    /// instance.
    /// </summary>
    public partial class CreateInstance : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.ICreateInstance
    {
        /// <summary>
        /// The name of the reference that contained the new instance.
        /// </summary>
        public string ReferenceName { get; set; }

        /// <summary>
        /// Gets the sub model operations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> SubModelOperations => this.backingSubModelOperations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation>(this);

        /// <summary>
        /// Backing field for <see cref="SubModelOperations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation> backingSubModelOperations;

        /// <summary>
        /// The type of the new instance.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Once the instance is created, a new variable will be bound with the name given here and will be
        /// available to any contained operation.
        /// </summary>
        public string VariableName { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>CreateInstance</c>.
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
