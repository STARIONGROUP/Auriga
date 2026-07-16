// ------------------------------------------------------------------------------------------------
// <copyright file="CSharpNaming.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ECoreNetto;
    using ECoreNetto.Extensions;

    /// <summary>
    /// C#-specific naming rules for the generated Capella object model: PascalCasing, C# keyword
    /// escaping, interface/enum type names and the <c>Auriga.&lt;PascalPackagePath&gt;</c> namespace
    /// derivation described in <c>docs/codegen-design.md</c> §4/§8.
    /// </summary>
    public static class CSharpNaming
    {
        /// <summary>
        /// The reserved C# keywords that must be escaped with an <c>@</c> prefix when used as identifiers.
        /// </summary>
        private static readonly HashSet<string> Keywords = new(StringComparer.Ordinal)
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
            "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
            "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
            "long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
            "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
            "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true",
            "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual",
            "void", "volatile", "while"
        };

        /// <summary>
        /// The root namespace of the generated object model. Read from the ambient
        /// <see cref="NamingContext"/> so the same helpers can generate the Capella model (<c>Auriga.Model</c>)
        /// and the Sirius model (<c>Auriga.Diagram</c>); defaults to <c>Auriga.Model</c>.
        /// </summary>
        public static string RootNamespace => NamingContext.ModelRoot;

        /// <summary>
        /// Capitalizes the first letter of the supplied name.
        /// </summary>
        /// <param name="name">the name to capitalize</param>
        /// <returns>the name with its first letter upper-cased</returns>
        public static string Capitalize(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("An unnamed model element cannot be turned into a C# identifier.", nameof(name));
            }

            return char.ToUpperInvariant(name[0]) + name.Substring(1);
        }

        /// <summary>
        /// Escapes a C# keyword with an <c>@</c> prefix so it can be used as an identifier.
        /// </summary>
        /// <param name="identifier">the candidate identifier</param>
        /// <returns>the identifier, prefixed with <c>@</c> when it collides with a C# keyword</returns>
        public static string Escape(string identifier)
        {
            return Keywords.Contains(identifier) ? "@" + identifier : identifier;
        }

        /// <summary>
        /// Returns the C# namespace for the supplied classifier, e.g. <c>Auriga.Pa.Deployment</c>.
        /// </summary>
        /// <param name="classifier">the Ecore classifier</param>
        /// <returns>the fully-qualified C# namespace</returns>
        public static string Namespace(EClassifier classifier)
        {
            var segments = new List<string>();
            var package = classifier.EPackage;

            while (package != null)
            {
                segments.Insert(0, Capitalize(package.Name));
                package = package.ESuperPackage;
            }

            segments.Insert(0, RootNamespace);

            return string.Join(".", segments);
        }

        /// <summary>
        /// Returns the fully-qualified interface name of an <see cref="EClass"/>, e.g.
        /// <c>Auriga.Pa.IPhysicalFunction</c>.
        /// </summary>
        /// <param name="eClass">the Ecore class</param>
        /// <returns>the fully-qualified interface name</returns>
        public static string InterfaceType(EClass eClass)
        {
            return $"{Namespace(eClass)}.I{Capitalize(eClass.Name)}";
        }

        /// <summary>
        /// Returns the fully-qualified enum name of an <see cref="EEnum"/>, e.g.
        /// <c>Auriga.Pa.PhysicalComponentNature</c>.
        /// </summary>
        /// <param name="eEnum">the Ecore enumeration</param>
        /// <returns>the fully-qualified enum name</returns>
        public static string EnumType(EEnum eEnum)
        {
            return $"{Namespace(eEnum)}.{Capitalize(eEnum.Name)}";
        }

        /// <summary>
        /// Returns the C# member name for a structural feature: the PascalCased, keyword-escaped feature
        /// name, with a trailing underscore appended when the feature is in the ambient collision set (C#
        /// forbids a member sharing its enclosing type's name, e.g. the GMF <c>notation::View.diagram</c>
        /// feature inherited by the <c>notation::Diagram</c> class). The XML name written/read for the
        /// feature stays the raw Ecore name, so the serialization is unaffected. No Capella feature
        /// collides, so Capella member names are unchanged.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the de-collided C# member name</returns>
        public static string MemberName(EStructuralFeature feature)
        {
            var name = Escape(Capitalize(feature.Name));

            if (NamingContext.IsRenamed(feature))
            {
                name += "_";
            }

            return name;
        }

        /// <summary>
        /// Detects the structural features whose C# member name would collide with the name of a concrete
        /// class that declares or inherits them — which C# forbids, since a member cannot share its
        /// enclosing type's name. Detection is by feature identity over the whole metamodel so a feature
        /// declared in a base type (e.g. GMF <c>View.diagram</c>) is renamed consistently in its interface
        /// and in every concrete subclass that flattens it (e.g. <c>Diagram</c>). The result is supplied to
        /// <see cref="NamingContext.Use"/> so <see cref="MemberName"/> can de-collide those features.
        /// </summary>
        /// <param name="allPackages">every package of the loaded metamodel</param>
        /// <returns>the set of features whose member name must be de-collided</returns>
        public static ISet<EStructuralFeature> DetectMemberCollisions(IEnumerable<EPackage> allPackages)
        {
            var colliding = new HashSet<EStructuralFeature>();

            foreach (var eClass in allPackages.SelectMany(p => p.EClassifiers.OfType<EClass>()))
            {
                if (eClass.Abstract || eClass.Interface)
                {
                    continue;
                }

                var className = Capitalize(eClass.Name);

                foreach (var feature in eClass.AllEStructuralFeatures)
                {
                    if (feature.EType != null && string.Equals(Capitalize(feature.Name), className, StringComparison.Ordinal))
                    {
                        colliding.Add(feature);
                    }
                }
            }

            return colliding;
        }
    }
}
