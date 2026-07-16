// ------------------------------------------------------------------------------------------------
// <copyright file="AttributeDefinition.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirements
{
    /// <summary>
    /// Definition of the <c>AttributeDefinition</c> class.
    /// </summary>
    public partial class AttributeDefinition : Auriga.Core.AurigaElement, Auriga.Model.Requirements.IAttributeDefinition
    {
        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        public Auriga.Model.Requirements.IAttribute DefaultValue
        {
            get => this.backingDefaultValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDefaultValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DefaultValue"/>.
        /// </summary>
        private Auriga.Model.Requirements.IAttribute backingDefaultValue;

        /// <summary>
        /// Gets or sets the definition type.
        /// </summary>
        public Auriga.Model.Requirements.IDataTypeDefinition DefinitionType { get; set; }

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets or sets the req i f description.
        /// </summary>
        public string ReqIFDescription { get; set; }

        /// <summary>
        /// Gets or sets the req i f identifier.
        /// </summary>
        public string ReqIFIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the req i f long name.
        /// </summary>
        public string ReqIFLongName { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>AttributeDefinition</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.DefaultValue != null)
            {
                yield return this.DefaultValue;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
