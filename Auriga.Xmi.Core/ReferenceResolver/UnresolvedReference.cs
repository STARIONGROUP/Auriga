// ------------------------------------------------------------------------------------------------
// <copyright file="UnresolvedReference.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.ReferenceResolver
{
    /// <summary>
    /// A single cross-reference that could not be resolved because no element with the referenced
    /// identifier exists in the document — a dangling reference. The second resolution pass collects
    /// these and reports them together, rather than aborting the load on the first one, so a model that
    /// contains a dangling reference still loads and the problem remains diagnosable.
    /// </summary>
    public sealed class UnresolvedReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnresolvedReference"/> class.
        /// </summary>
        /// <param name="owningElementId">the <c>xmi:id</c> of the element that owns the reference</param>
        /// <param name="owningElementType">the type name of the element that owns the reference</param>
        /// <param name="propertyName">the name of the reference property that could not be resolved</param>
        /// <param name="targetIdentifier">the referenced identifier that was not found</param>
        public UnresolvedReference(string owningElementId, string owningElementType, string propertyName, string targetIdentifier)
        {
            this.OwningElementId = owningElementId;
            this.OwningElementType = owningElementType;
            this.PropertyName = propertyName;
            this.TargetIdentifier = targetIdentifier;
        }

        /// <summary>
        /// Gets the <c>xmi:id</c> of the element that owns the dangling reference (empty when the owner
        /// itself carries no identifier).
        /// </summary>
        public string OwningElementId { get; }

        /// <summary>
        /// Gets the type name of the element that owns the dangling reference.
        /// </summary>
        public string OwningElementType { get; }

        /// <summary>
        /// Gets the (PascalCase) name of the reference property that could not be resolved.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the identifier that was referenced but not found in the document.
        /// </summary>
        public string TargetIdentifier { get; }

        /// <summary>
        /// Returns a human-readable description of the dangling reference.
        /// </summary>
        /// <returns>a description of the form <c>Type(id).Property -&gt; 'targetId'</c></returns>
        public override string ToString()
        {
            return $"{this.OwningElementType}({this.OwningElementId}).{this.PropertyName} -> '{this.TargetIdentifier}'";
        }
    }
}
