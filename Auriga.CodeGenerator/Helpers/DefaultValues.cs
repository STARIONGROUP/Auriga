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

            return feature.EType is EEnum eEnum
                ? EnumExpression(eEnum, literal)
                : ScalarExpression(CSharpType.BaseType(feature.EType), literal);
        }

        /// <summary>
        /// The enum-literal expression of a default, or <c>null</c> when the literal names no member
        /// of the enumeration.
        /// </summary>
        /// <param name="eEnum">the enumeration type</param>
        /// <param name="literal">the raw default literal</param>
        /// <returns>the initializer expression, or <c>null</c></returns>
        private static string? EnumExpression(EEnum eEnum, string literal)
        {
            var enumLiteral = eEnum.ELiterals.FirstOrDefault(candidate =>
                string.Equals(candidate.Name, literal, StringComparison.Ordinal)
                || string.Equals(candidate.Literal, literal, StringComparison.Ordinal));

            return enumLiteral == null
                ? null
                : $"{CSharpNaming.EnumType(eEnum)}.{CSharpNaming.Escape(CSharpNaming.Capitalize(enumLiteral.Name))}";
        }

        /// <summary>
        /// The typed literal expression of a scalar default, or <c>null</c> when the literal does not
        /// parse as the feature's mapped C# type.
        /// </summary>
        /// <param name="baseType">the feature's mapped C# base type</param>
        /// <param name="literal">the raw default literal</param>
        /// <returns>the initializer expression, or <c>null</c></returns>
        private static string? ScalarExpression(string baseType, string literal)
        {
            return baseType switch
            {
                "string" => Quote(literal),
                "bool" => BooleanExpression(literal),
                "sbyte" => Validated(sbyte.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _), literal),
                "short" => Validated(short.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _), literal),
                "int" => Validated(int.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _), literal),
                "long" => Validated(long.TryParse(literal, NumberStyles.Integer, CultureInfo.InvariantCulture, out _), literal + "L"),
                "float" => Validated(float.TryParse(literal, NumberStyles.Float, CultureInfo.InvariantCulture, out _), literal + "f"),
                "double" => Validated(double.TryParse(literal, NumberStyles.Float, CultureInfo.InvariantCulture, out _), literal + "d"),
                "decimal" => Validated(decimal.TryParse(literal, NumberStyles.Number, CultureInfo.InvariantCulture, out _), literal + "m"),
                "char" => CharExpression(literal),
                _ => null,
            };
        }

        /// <summary>
        /// The C# character literal of a default, or <c>null</c> when the literal is not a single
        /// character.
        /// </summary>
        /// <param name="literal">the raw default literal</param>
        /// <returns>the initializer expression, or <c>null</c></returns>
        private static string? CharExpression(string literal)
        {
            return literal.Length == 1 ? $"'{Escape(literal[0])}'" : null;
        }

        /// <summary>
        /// The C# boolean literal of a default, or <c>null</c> when the literal is not a boolean.
        /// </summary>
        /// <param name="literal">the raw default literal</param>
        /// <returns>the initializer expression, or <c>null</c></returns>
        private static string? BooleanExpression(string literal)
        {
            if (!bool.TryParse(literal, out var parsed))
            {
                return null;
            }

            return parsed ? "true" : "false";
        }

        /// <summary>
        /// The expression when the literal validated against its type, <c>null</c> otherwise.
        /// </summary>
        /// <param name="isValid">whether the literal parsed as the target type</param>
        /// <param name="expression">the expression to emit when valid</param>
        /// <returns>the expression, or <c>null</c></returns>
        private static string? Validated(bool isValid, string expression)
        {
            return isValid ? expression : null;
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
