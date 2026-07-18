// ------------------------------------------------------------------------------------------------
// <copyright file="DefaultValues.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Helpers
{
    using System;
    using System.Globalization;
    using System.Linq;

    using ECoreNetto;

    /// <summary>
    /// Resolves a scalar feature's Ecore <c>defaultValueLiteral</c> into the C# expression that
    /// initializes the generated property. EMF omits attributes whose value equals the declared
    /// default when serializing, so a generated reader only sees the attribute when it differs —
    /// without the initializer the property silently reads as the CLR default (issue #76: every
    /// <c>EdgeStyle.targetArrow</c> that is the metamodel default <c>InputArrow</c> read as
    /// <c>NoDecoration</c>, the first literal). The generated writers pass the same expression back
    /// as the suppression default, so a value equal to the declared default is omitted on write,
    /// exactly as EMF serializes it.
    /// </summary>
    public static class DefaultValues
    {
        /// <summary>
        /// The C# initializer expression for the feature's <c>defaultValueLiteral</c>, or
        /// <c>null</c> when the feature declares no default, is not a scalar attribute, or the
        /// literal cannot be expressed for the feature's mapped C# type.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the initializer expression, or <c>null</c></returns>
        public static string? Expression(EStructuralFeature feature)
        {
            var literal = feature.DefaultValueLiteral;

            if (literal == null || CSharpType.IsCollection(feature) || CSharpType.IsComputed(feature) || feature is EReference)
            {
                return null;
            }

            if (feature.EType is EEnum eEnum)
            {
                var enumLiteral = eEnum.ELiterals.FirstOrDefault(candidate =>
                    string.Equals(candidate.Name, literal, StringComparison.Ordinal)
                    || string.Equals(candidate.Literal, literal, StringComparison.Ordinal));

                return enumLiteral == null
                    ? null
                    : $"{CSharpNaming.EnumType(eEnum)}.{CSharpNaming.Escape(CSharpNaming.Capitalize(enumLiteral.Name))}";
            }

            return CSharpType.BaseType(feature.EType) switch
            {
                "string" => Quote(literal),
                "bool" => bool.TryParse(literal, out var parsedBool) ? (parsedBool ? "true" : "false") : null,
                "sbyte" => sbyte.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _) ? literal : null,
                "short" => short.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _) ? literal : null,
                "int" => int.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _) ? literal : null,
                "long" => long.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _) ? literal + "L" : null,
                "float" => float.TryParse(literal, NumberStyles.Float, CultureInfo.InvariantCulture, out _) ? literal + "f" : null,
                "double" => double.TryParse(literal, NumberStyles.Float, CultureInfo.InvariantCulture, out _) ? literal + "d" : null,
                "decimal" => decimal.TryParse(literal, NumberStyles.Number, CultureInfo.InvariantCulture, out _) ? literal + "m" : null,
                "char" => literal.Length == 1 ? $"'{Escape(literal[0])}'" : null,
                _ => null,
            };
        }

        /// <summary>
        /// The C# string literal for a default value, with quotes and backslashes escaped.
        /// </summary>
        /// <param name="value">the raw literal</param>
        /// <returns>the quoted C# literal</returns>
        private static string Quote(string value)
        {
            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }

        /// <summary>
        /// The C# character-literal body of a default character, escaped when the character is a
        /// quote or backslash.
        /// </summary>
        /// <param name="value">the character</param>
        /// <returns>the escaped character text</returns>
        private static string Escape(char value)
        {
            return value switch
            {
                '\'' => "\\'",
                '\\' => "\\\\",
                _ => value.ToString(),
            };
        }
    }
}
