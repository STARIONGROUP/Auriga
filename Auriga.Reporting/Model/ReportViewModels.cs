// ------------------------------------------------------------------------------------------------
// <copyright file="ReportViewModels.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The whole metamodel as prepared for rendering: every package with its classifiers, plus the totals
    /// shown on the landing page. Built once by the <see cref="ReportModelBuilder"/> and consumed by the
    /// templates, so the templates hold presentation only and never touch ECoreNetto.
    /// </summary>
    public sealed class ReportModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportModel"/> class.
        /// </summary>
        /// <param name="packages">the packages, ordered by name</param>
        public ReportModel(IReadOnlyList<PackageView> packages)
        {
            this.Packages = packages;
        }

        /// <summary>
        /// Gets the packages, ordered by name.
        /// </summary>
        public IReadOnlyList<PackageView> Packages { get; }

        /// <summary>
        /// Gets the total number of packages.
        /// </summary>
        public int PackageCount => this.Packages.Count;

        /// <summary>
        /// Gets the total number of classes across every package.
        /// </summary>
        public int ClassCount
        {
            get
            {
                var count = 0;
                foreach (var package in this.Packages)
                {
                    count += package.Classes.Count;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets the total number of enumerations across every package.
        /// </summary>
        public int EnumCount
        {
            get
            {
                var count = 0;
                foreach (var package in this.Packages)
                {
                    count += package.Enums.Count;
                }

                return count;
            }
        }
    }

    /// <summary>
    /// A metamodel package: its classes and enumerations, its documentation, and the page it renders to.
    /// </summary>
    public sealed class PackageView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageView"/> class.
        /// </summary>
        /// <param name="name">the Ecore package name</param>
        /// <param name="href">the package page file name</param>
        /// <param name="documentation">the package documentation lines</param>
        /// <param name="classes">the package classes, ordered by name</param>
        /// <param name="enums">the package enumerations, ordered by name</param>
        public PackageView(string name, string href, IReadOnlyList<string> documentation, IReadOnlyList<ClassView> classes, IReadOnlyList<EnumView> enums)
        {
            this.Name = name;
            this.Href = href;
            this.Documentation = documentation;
            this.Classes = classes;
            this.Enums = enums;
        }

        /// <summary>Gets the Ecore package name.</summary>
        public string Name { get; }

        /// <summary>Gets the package page file name.</summary>
        public string Href { get; }

        /// <summary>Gets the package documentation lines (empty when undocumented).</summary>
        public IReadOnlyList<string> Documentation { get; }

        /// <summary>Gets the package classes, ordered by name.</summary>
        public IReadOnlyList<ClassView> Classes { get; }

        /// <summary>Gets the package enumerations, ordered by name.</summary>
        public IReadOnlyList<EnumView> Enums { get; }

        /// <summary>Gets the number of classes in the package.</summary>
        public int ClassCount => this.Classes.Count;

        /// <summary>Gets the number of enumerations in the package.</summary>
        public int EnumCount => this.Enums.Count;
    }

    /// <summary>
    /// A metamodel class or interface: its documentation, super-types and sub-types (as links), and its
    /// flattened feature table.
    /// </summary>
    public sealed class ClassView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassView"/> class.
        /// </summary>
        /// <param name="name">the class name</param>
        /// <param name="packageName">the owning package name</param>
        /// <param name="href">the class page file name</param>
        /// <param name="isAbstract">whether the class is abstract</param>
        /// <param name="isInterface">whether the class is an interface</param>
        /// <param name="documentation">the class documentation lines</param>
        /// <param name="superTypes">the direct super-types, as links</param>
        /// <param name="subTypes">the direct sub-types, as links</param>
        /// <param name="features">the flattened feature table (own and inherited)</param>
        public ClassView(string name, string packageName, string href, bool isAbstract, bool isInterface, IReadOnlyList<string> documentation, IReadOnlyList<TypeLink> superTypes, IReadOnlyList<TypeLink> subTypes, IReadOnlyList<FeatureView> features)
        {
            this.Name = name;
            this.PackageName = packageName;
            this.Href = href;
            this.IsAbstract = isAbstract;
            this.IsInterface = isInterface;
            this.Documentation = documentation;
            this.SuperTypes = superTypes;
            this.SubTypes = subTypes;
            this.Features = features;
        }

        /// <summary>Gets the class name.</summary>
        public string Name { get; }

        /// <summary>Gets the owning package name.</summary>
        public string PackageName { get; }

        /// <summary>Gets the class page file name.</summary>
        public string Href { get; }

        /// <summary>Gets a value indicating whether the class is abstract.</summary>
        public bool IsAbstract { get; }

        /// <summary>Gets a value indicating whether the class is an interface.</summary>
        public bool IsInterface { get; }

        /// <summary>Gets a short kind label ("interface", "abstract class" or "class").</summary>
        public string Kind => this.IsInterface ? "interface" : this.IsAbstract ? "abstract class" : "class";

        /// <summary>Gets the class documentation lines (empty when undocumented).</summary>
        public IReadOnlyList<string> Documentation { get; }

        /// <summary>Gets the direct super-types, as links.</summary>
        public IReadOnlyList<TypeLink> SuperTypes { get; }

        /// <summary>Gets the direct sub-types, as links.</summary>
        public IReadOnlyList<TypeLink> SubTypes { get; }

        /// <summary>Gets the flattened feature table (own and inherited), ordered by name.</summary>
        public IReadOnlyList<FeatureView> Features { get; }

        /// <summary>Gets a value indicating whether the class has any super-types.</summary>
        public bool HasSuperTypes => this.SuperTypes.Count > 0;

        /// <summary>Gets a value indicating whether the class has any sub-types.</summary>
        public bool HasSubTypes => this.SubTypes.Count > 0;

        /// <summary>Gets a value indicating whether the class has any features.</summary>
        public bool HasFeatures => this.Features.Count > 0;
    }

    /// <summary>
    /// A row in a class's flattened feature table.
    /// </summary>
    public sealed class FeatureView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureView"/> class.
        /// </summary>
        /// <param name="name">the feature name</param>
        /// <param name="type">the feature type, as a link</param>
        /// <param name="multiplicity">the multiplicity string (e.g. <c>0..1</c>, <c>0..*</c>)</param>
        /// <param name="kind">the feature kind ("attribute", "reference" or "containment")</param>
        /// <param name="isComputed">whether the feature is derived/volatile/transient</param>
        /// <param name="declaredIn">the class the feature is declared in, as a link, or <c>null</c> when own</param>
        /// <param name="documentation">the feature documentation lines</param>
        public FeatureView(string name, TypeLink type, string multiplicity, string kind, bool isComputed, TypeLink? declaredIn, IReadOnlyList<string> documentation)
        {
            this.Name = name;
            this.Type = type;
            this.Multiplicity = multiplicity;
            this.Kind = kind;
            this.IsComputed = isComputed;
            this.DeclaredIn = declaredIn;
            this.Documentation = documentation;
        }

        /// <summary>Gets the feature name.</summary>
        public string Name { get; }

        /// <summary>Gets the feature type, as a link.</summary>
        public TypeLink Type { get; }

        /// <summary>Gets the multiplicity string.</summary>
        public string Multiplicity { get; }

        /// <summary>Gets the feature kind ("attribute", "reference" or "containment").</summary>
        public string Kind { get; }

        /// <summary>Gets a value indicating whether the feature is derived/volatile/transient (computed).</summary>
        public bool IsComputed { get; }

        /// <summary>Gets the class the feature is declared in (a link), or <c>null</c> when declared on the class itself.</summary>
        public TypeLink? DeclaredIn { get; }

        /// <summary>Gets a value indicating whether the feature is inherited from a super-type.</summary>
        public bool IsInherited => this.DeclaredIn != null;

        /// <summary>Gets the feature documentation lines (empty when undocumented).</summary>
        public IReadOnlyList<string> Documentation { get; }
    }

    /// <summary>
    /// A metamodel enumeration: its documentation and its literals.
    /// </summary>
    public sealed class EnumView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumView"/> class.
        /// </summary>
        /// <param name="name">the enumeration name</param>
        /// <param name="packageName">the owning package name</param>
        /// <param name="href">the enumeration page file name</param>
        /// <param name="documentation">the enumeration documentation lines</param>
        /// <param name="literals">the enumeration literals</param>
        public EnumView(string name, string packageName, string href, IReadOnlyList<string> documentation, IReadOnlyList<LiteralView> literals)
        {
            this.Name = name;
            this.PackageName = packageName;
            this.Href = href;
            this.Documentation = documentation;
            this.Literals = literals;
        }

        /// <summary>Gets the enumeration name.</summary>
        public string Name { get; }

        /// <summary>Gets the owning package name.</summary>
        public string PackageName { get; }

        /// <summary>Gets the enumeration page file name.</summary>
        public string Href { get; }

        /// <summary>Gets the enumeration documentation lines (empty when undocumented).</summary>
        public IReadOnlyList<string> Documentation { get; }

        /// <summary>Gets the enumeration literals, in declaration order.</summary>
        public IReadOnlyList<LiteralView> Literals { get; }
    }

    /// <summary>
    /// A literal of an enumeration.
    /// </summary>
    public sealed class LiteralView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralView"/> class.
        /// </summary>
        /// <param name="name">the literal name</param>
        /// <param name="value">the literal integer value</param>
        /// <param name="documentation">the literal documentation lines</param>
        public LiteralView(string name, int value, IReadOnlyList<string> documentation)
        {
            this.Name = name;
            this.Value = value;
            this.Documentation = documentation;
        }

        /// <summary>Gets the literal name.</summary>
        public string Name { get; }

        /// <summary>Gets the literal integer value.</summary>
        public int Value { get; }

        /// <summary>Gets the literal documentation lines (empty when undocumented).</summary>
        public IReadOnlyList<string> Documentation { get; }
    }

    /// <summary>
    /// A reference to a type: a display label and, for a linkable metamodel type, the page it points at.
    /// A primitive or external type carries a <c>null</c> <see cref="Href"/> and renders as plain text.
    /// </summary>
    public sealed class TypeLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeLink"/> class.
        /// </summary>
        /// <param name="label">the display label</param>
        /// <param name="href">the target page file name, or <c>null</c> for a non-linkable type</param>
        public TypeLink(string label, string? href)
        {
            this.Label = label;
            this.Href = href;
        }

        /// <summary>Gets the display label.</summary>
        public string Label { get; }

        /// <summary>Gets the target page file name, or <c>null</c> for a non-linkable (primitive/external) type.</summary>
        public string? Href { get; }

        /// <summary>Gets a value indicating whether this reference links to a page.</summary>
        public bool HasHref => this.Href != null;
    }
}
