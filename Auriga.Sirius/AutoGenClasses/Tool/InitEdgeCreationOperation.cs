// ------------------------------------------------------------------------------------------------
// <copyright file="InitEdgeCreationOperation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>InitEdgeCreationOperation</c> class.
    /// </summary>
    public partial class InitEdgeCreationOperation : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IInitEdgeCreationOperation
    {
        /// <summary>
        /// Gets or sets the first model operations.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation FirstModelOperations
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
        private Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation backingFirstModelOperations;

        /// <summary>
        /// Gets the elements directly contained by this <c>InitEdgeCreationOperation</c>.
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
