// ------------------------------------------------------------------------------------------------
// <copyright file="NamingContext.cs" company="Starion Group S.A.">
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

    using ECoreNetto;

    /// <summary>
    /// The ambient root-namespace configuration for a single generation run. The generators drive two
    /// different metamodels through the same static HandleBars helpers — the Capella model under
    /// <c>Auriga</c> and the Sirius model under <c>Auriga.Sirius</c> — so the root namespace cannot be a
    /// compile-time constant. A generator opens a <see cref="Use"/> scope for the duration of a
    /// <c>Generate</c> call; the helpers read the three roots from here. The value is thread-scoped so
    /// concurrently-executing test fixtures (Capella and Sirius) never see each other's configuration,
    /// and it defaults to the Capella roots so an unconfigured run reproduces the original output
    /// byte-for-byte.
    /// </summary>
    public static class NamingContext
    {
        /// <summary>
        /// The default root namespace of the generated object model (the Capella model).
        /// </summary>
        public const string DefaultModelRoot = "Auriga";

        [ThreadStatic]
        private static string? modelRoot;

        [ThreadStatic]
        private static ISet<EStructuralFeature>? renamedFeatures;

        /// <summary>
        /// Gets the root namespace of the object model currently being generated (e.g. <c>Auriga</c> or
        /// <c>Auriga.Sirius</c>).
        /// </summary>
        public static string ModelRoot => modelRoot ?? DefaultModelRoot;

        /// <summary>
        /// Whether the supplied feature's C# member name must be de-collided (a trailing underscore
        /// appended) because it would otherwise share the name of a concrete class that declares or
        /// inherits it. The set is computed once per run from the whole metamodel so the same feature is
        /// renamed identically in its interface and every implementing class.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>true when the feature's member name must be de-collided</returns>
        public static bool IsRenamed(EStructuralFeature feature)
        {
            return renamedFeatures != null && renamedFeatures.Contains(feature);
        }

        /// <summary>
        /// Gets the root namespace of the generated XMI readers for the model currently being generated,
        /// derived from <see cref="ModelRoot"/> (e.g. <c>Auriga.Xmi.AutoGenXmiReaders</c>).
        /// </summary>
        public static string ReaderRoot => ModelRoot + ".Xmi.AutoGenXmiReaders";

        /// <summary>
        /// Gets the root namespace of the generated XMI writers for the model currently being generated,
        /// derived from <see cref="ModelRoot"/> (e.g. <c>Auriga.Xmi.AutoGenXmiWriters</c>).
        /// </summary>
        public static string WriterRoot => ModelRoot + ".Xmi.AutoGenXmiWriters";

        /// <summary>
        /// Opens a scope in which the supplied root namespace and member-name collision set are used for the
        /// current thread, restoring the previous values when the returned token is disposed.
        /// </summary>
        /// <param name="rootNamespace">the object-model root namespace to use for the duration of the scope</param>
        /// <param name="collidingFeatures">
        /// the features whose member names must be de-collided, or <c>null</c> for none
        /// </param>
        /// <returns>a token that restores the previous configuration when disposed</returns>
        public static IDisposable Use(string rootNamespace, ISet<EStructuralFeature>? collidingFeatures = null)
        {
            return new Scope(rootNamespace, collidingFeatures);
        }

        private sealed class Scope : IDisposable
        {
            private readonly string? previousModelRoot;

            private readonly ISet<EStructuralFeature>? previousRenamedFeatures;

            public Scope(string rootNamespace, ISet<EStructuralFeature>? collidingFeatures)
            {
                this.previousModelRoot = modelRoot;
                this.previousRenamedFeatures = renamedFeatures;
                modelRoot = rootNamespace;
                renamedFeatures = collidingFeatures;
            }

            public void Dispose()
            {
                modelRoot = this.previousModelRoot;
                renamedFeatures = this.previousRenamedFeatures;
            }
        }
    }
}
