// ------------------------------------------------------------------------------------------------
// <copyright file="InitialContainerDropOperation.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Tool
{
    /// <summary>
    /// Definition of the <c>InitialContainerDropOperation</c> class.
    /// </summary>
    public partial class InitialContainerDropOperation : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Tool.IInitialContainerDropOperation
    {
        /// <summary>
        /// Gets or sets the first model operations.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation FirstModelOperations
        {
            get => this.backingFirstModelOperations;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingFirstModelOperations = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FirstModelOperations"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation backingFirstModelOperations;

        /// <summary>
        /// Gets the elements directly contained by this <c>InitialContainerDropOperation</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.FirstModelOperations != null)
            {
                yield return this.FirstModelOperations;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
