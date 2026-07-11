// ------------------------------------------------------------------------------------------------
// <copyright file="SessionManagerEObject.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Definition of the <c>SessionManagerEObject</c> class.
    /// </summary>
    public partial class SessionManagerEObject : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.ISessionManagerEObject
    {
        /// <summary>
        /// Gets the owned sessions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.IDAnalysisSessionEObject> OwnedSessions => this.backingOwnedSessions ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.IDAnalysisSessionEObject>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSessions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.IDAnalysisSessionEObject> backingOwnedSessions;

        /// <summary>
        /// Gets the elements directly contained by this <c>SessionManagerEObject</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedSessions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
