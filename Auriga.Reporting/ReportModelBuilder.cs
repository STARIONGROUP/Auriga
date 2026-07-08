// ------------------------------------------------------------------------------------------------
// <copyright file="ReportModelBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Auriga.CodeGenerator.Helpers;
    using Auriga.Reporting.Model;

    using ECoreNetto;
    using ECoreNetto.Extensions;

    /// <summary>
    /// Transforms the loaded Capella metamodel (ECoreNetto <see cref="EPackage"/>s) into the
    /// presentation-ready <see cref="ReportModel"/> the templates render: cross-link targets, flattened
    /// feature tables, super- and sub-type links, and documentation are all resolved here, so the
    /// templates hold no metamodel logic. Deterministic — every collection is ordered by name.
    /// </summary>
    public static class ReportModelBuilder
    {
        /// <summary>
        /// Builds the report model from the vendored <c>.ecore</c> files in the supplied directory.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        /// <returns>the presentation-ready report model</returns>
        public static ReportModel Build(string ecoreDirectory)
        {
            var packages = MetamodelLoader.Load(ecoreDirectory)
                .SelectMany(MetamodelLoader.AllPackages)
                .OrderBy(p => p.Name, StringComparer.Ordinal)
                .ToList();

            var classes = packages.SelectMany(p => p.EClassifiers.OfType<EClass>()).ToList();
            var enums = packages.SelectMany(p => p.EClassifiers.OfType<EEnum>()).ToList();

            var hrefIndex = BuildHrefIndex(classes, enums);
            var subTypes = BuildSubTypeIndex(classes);
            var declaringClass = BuildDeclaringClassIndex(classes);

            var packageViews = packages
                .Select(package => BuildPackage(package, hrefIndex, subTypes, declaringClass))
                .ToList();

            return new ReportModel(packageViews);
        }

        /// <summary>The file name of the landing page.</summary>
        internal static string IndexHref => "index.html";

        /// <summary>The file name of a package page.</summary>
        internal static string PackageHref(EPackage package) => $"package.{package.Name}.html";

        /// <summary>The file name of a class page.</summary>
        internal static string ClassHref(EClass eClass) => $"class.{eClass.EPackage.Name}.{eClass.Name}.html";

        /// <summary>The file name of an enumeration page.</summary>
        internal static string EnumHref(EEnum eEnum) => $"enum.{eEnum.EPackage.Name}.{eEnum.Name}.html";

        /// <summary>
        /// Indexes every linkable classifier (class and enum) by reference to its page file name.
        /// </summary>
        private static Dictionary<EClassifier, string> BuildHrefIndex(IEnumerable<EClass> classes, IEnumerable<EEnum> enums)
        {
            var index = new Dictionary<EClassifier, string>();

            foreach (var eClass in classes)
            {
                index[eClass] = ClassHref(eClass);
            }

            foreach (var eEnum in enums)
            {
                index[eEnum] = EnumHref(eEnum);
            }

            return index;
        }

        /// <summary>
        /// Builds the reverse super-type index: for every class, the classes that directly extend it.
        /// </summary>
        private static Dictionary<EClass, List<EClass>> BuildSubTypeIndex(IEnumerable<EClass> classes)
        {
            var index = new Dictionary<EClass, List<EClass>>();

            foreach (var eClass in classes)
            {
                foreach (var super in eClass.ESuperTypes)
                {
                    if (!index.TryGetValue(super, out var list))
                    {
                        list = new List<EClass>();
                        index[super] = list;
                    }

                    list.Add(eClass);
                }
            }

            return index;
        }

        /// <summary>
        /// Maps every structural feature to the class that declares it, so a flattened (inherited) feature
        /// can link back to its declaring class.
        /// </summary>
        private static Dictionary<EStructuralFeature, EClass> BuildDeclaringClassIndex(IEnumerable<EClass> classes)
        {
            var index = new Dictionary<EStructuralFeature, EClass>();

            foreach (var eClass in classes)
            {
                foreach (var feature in eClass.EStructuralFeatures)
                {
                    index[feature] = eClass;
                }
            }

            return index;
        }

        private static PackageView BuildPackage(EPackage package, IReadOnlyDictionary<EClassifier, string> hrefIndex, IReadOnlyDictionary<EClass, List<EClass>> subTypes, IReadOnlyDictionary<EStructuralFeature, EClass> declaringClass)
        {
            var classes = package.EClassifiers.OfType<EClass>()
                .OrderBy(c => c.Name, StringComparer.Ordinal)
                .Select(c => BuildClass(c, hrefIndex, subTypes, declaringClass))
                .ToList();

            var enums = package.EClassifiers.OfType<EEnum>()
                .OrderBy(e => e.Name, StringComparer.Ordinal)
                .Select(BuildEnum)
                .ToList();

            return new PackageView(package.Name, PackageHref(package), Documentation(package), classes, enums);
        }

        private static ClassView BuildClass(EClass eClass, IReadOnlyDictionary<EClassifier, string> hrefIndex, IReadOnlyDictionary<EClass, List<EClass>> subTypes, IReadOnlyDictionary<EStructuralFeature, EClass> declaringClass)
        {
            var superLinks = eClass.ESuperTypes
                .OrderBy(s => s.Name, StringComparer.Ordinal)
                .Select(s => LinkTo(s, hrefIndex))
                .ToList();

            var subList = subTypes.TryGetValue(eClass, out var subs) ? subs : new List<EClass>();
            var subLinks = subList
                .OrderBy(s => s.Name, StringComparer.Ordinal)
                .Select(s => LinkTo(s, hrefIndex))
                .ToList();

            var features = eClass.AllEStructuralFeatures
                .Where(f => f.EType != null)
                .OrderBy(f => f.Name, StringComparer.Ordinal)
                .Select(f => BuildFeature(f, eClass, hrefIndex, declaringClass))
                .ToList();

            return new ClassView(
                eClass.Name,
                eClass.EPackage.Name,
                ClassHref(eClass),
                eClass.Abstract,
                eClass.Interface,
                Documentation(eClass),
                superLinks,
                subLinks,
                features);
        }

        private static FeatureView BuildFeature(EStructuralFeature feature, EClass owner, IReadOnlyDictionary<EClassifier, string> hrefIndex, IReadOnlyDictionary<EStructuralFeature, EClass> declaringClass)
        {
            var containment = feature is EReference { IsContainment: true };
            var kind = containment ? "containment" : feature is EReference ? "reference" : "attribute";

            TypeLink? declaredIn = null;
            if (declaringClass.TryGetValue(feature, out var declarer) && !ReferenceEquals(declarer, owner))
            {
                declaredIn = LinkTo(declarer, hrefIndex);
            }

            return new FeatureView(
                feature.Name,
                LinkTo(feature.EType, hrefIndex),
                Multiplicity(feature.LowerBound, feature.UpperBound),
                kind,
                CSharpType.IsComputed(feature),
                declaredIn,
                Documentation(feature));
        }

        private static EnumView BuildEnum(EEnum eEnum)
        {
            var literals = eEnum.ELiterals
                .Select(l => new LiteralView(l.Name, l.Value, Documentation(l)))
                .ToList();

            return new EnumView(eEnum.Name, eEnum.EPackage.Name, EnumHref(eEnum), Documentation(eEnum), literals);
        }

        /// <summary>
        /// Builds a link to a classifier: linked when it is a rendered metamodel type, otherwise plain
        /// text (an Ecore primitive datatype or the built-in <c>EObject</c>).
        /// </summary>
        private static TypeLink LinkTo(EClassifier? classifier, IReadOnlyDictionary<EClassifier, string> hrefIndex)
        {
            if (classifier == null)
            {
                return new TypeLink("?", null);
            }

            return hrefIndex.TryGetValue(classifier, out var href)
                ? new TypeLink(classifier.Name, href)
                : new TypeLink(classifier.Name, null);
        }

        /// <summary>
        /// Renders a multiplicity from its bounds: an unbounded upper renders as <c>*</c>; equal bounds
        /// collapse to a single number (e.g. <c>1</c>); otherwise <c>lower..upper</c>.
        /// </summary>
        private static string Multiplicity(int lowerBound, int upperBound)
        {
            var upper = upperBound == -1 ? "*" : upperBound.ToString(System.Globalization.CultureInfo.InvariantCulture);

            if (upperBound != -1 && lowerBound == upperBound)
            {
                return lowerBound.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            return $"{lowerBound}..{upper}";
        }

        /// <summary>
        /// Returns the documentation lines of a model element, or an empty list when it has none.
        /// </summary>
        private static IReadOnlyList<string> Documentation(EModelElement element)
        {
            try
            {
                return element.QueryDocumentation()
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .ToList();
            }
            catch (Exception)
            {
                return Array.Empty<string>();
            }
        }
    }
}
