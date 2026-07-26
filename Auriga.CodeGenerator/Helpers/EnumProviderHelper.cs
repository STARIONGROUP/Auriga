// ------------------------------------------------------------------------------------------------
// <copyright file="EnumProviderHelper.cs" company="Starion Group S.A.">
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
    using System.Text;

    using ECoreNetto;

    using HandlebarsDotNet;

    /// <summary>
    /// The HandleBars helpers that render the generated enumeration providers — the per-enum conversion
    /// between an <c>EEnum</c>'s Ecore literal names and the generated C# enumeration members.
    ///
    /// <para>The C# member names are capitalized to be legal, conventional identifiers, so they do not
    /// always reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF
    /// matches literal names case-sensitively, so reading and writing both go through the generated
    /// provider rather than through <c>Enum.TryParse</c> or <c>ToString</c>, which would silently use the
    /// C# spelling. This follows the <c>…Provider</c> pattern used in SysML2.NET and uml4net.</para>
    /// </summary>
    public static class EnumProviderHelper
    {
        /// <summary>
        /// The indentation, in spaces, of the generated <c>TryParse</c> body.
        /// </summary>
        private const int TryParseIndent = 12;

        /// <summary>
        /// The indentation, in spaces, of the generated <c>switch</c> arms.
        /// </summary>
        private const int SwitchArmIndent = 16;

        /// <summary>
        /// Registers the <see cref="EnumProviderHelper"/> helpers with the supplied HandleBars context.
        /// </summary>
        /// <param name="handlebars">the HandleBars context</param>
        public static void RegisterEnumProviderHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("EnumProviderName", (writer, _, arguments) =>
                writer.WriteSafeString(EnumProviderName((EEnum)arguments[0]!)));

            handlebars.RegisterHelper("EnumQualifiedType", (writer, _, arguments) =>
                writer.WriteSafeString(CSharpNaming.EnumType((EEnum)arguments[0]!)));

            handlebars.RegisterHelper("EnumTypeNameRaw", (writer, _, arguments) =>
                writer.WriteSafeString(((EEnum)arguments[0]!).Name));

            handlebars.RegisterHelper("EnumTryParseBody", (writer, _, arguments) =>
                writer.WriteSafeString(EnumTryParseBody((EEnum)arguments[0]!)));

            handlebars.RegisterHelper("EnumToLiteralArms", (writer, _, arguments) =>
                writer.WriteSafeString(EnumToLiteralArms((EEnum)arguments[0]!)));
        }

        /// <summary>
        /// The provider class name of an enumeration (e.g. <c>FontFormatProvider</c>).
        /// </summary>
        /// <param name="eEnum">the enumeration</param>
        /// <returns>the provider class name</returns>
        public static string EnumProviderName(EEnum eEnum)
        {
            return CSharpNaming.Capitalize(eEnum.Name) + "Provider";
        }

        /// <summary>
        /// The body of the generated <c>TryParse</c>: one length-guarded ordinal comparison per literal, in
        /// declaration order. The length test short-circuits the majority of candidates before any
        /// character comparison happens.
        /// </summary>
        /// <param name="eEnum">the enumeration</param>
        /// <returns>the generated body</returns>
        private static string EnumTryParseBody(EEnum eEnum)
        {
            var blocks = new List<string>();
            var indent = new string(' ', TryParseIndent);
            var qualifiedType = CSharpNaming.EnumType(eEnum);

            foreach (var literal in eEnum.ELiterals)
            {
                var block = new StringBuilder();
                block
                    .Append(indent).Append("if (value.Length == ").Append(literal.Name.Length)
                    .Append(" && value.Equals(\"").Append(literal.Name).Append("\".AsSpan(), StringComparison.Ordinal))").AppendLine()
                    .Append(indent).AppendLine("{")
                    .Append(indent).Append("    result = ").Append(qualifiedType).Append('.').Append(LiteralMemberName(literal)).AppendLine(";")
                    .Append(indent).AppendLine("    return true;")
                    .Append(indent).AppendLine("}");

                blocks.Add(block.ToString());
            }

            // Blank line between the blocks but not after the last, so the template's own newline does not
            // leave a double blank before the fall-through.
            return string.Join(Environment.NewLine, blocks);
        }

        /// <summary>
        /// The arms of the generated <c>ToXmlLiteral</c> switch: one per literal, mapping the C# member
        /// back to its Ecore name.
        /// </summary>
        /// <param name="eEnum">the enumeration</param>
        /// <returns>the generated switch arms</returns>
        private static string EnumToLiteralArms(EEnum eEnum)
        {
            var builder = new StringBuilder();
            var indent = new string(' ', SwitchArmIndent);
            var qualifiedType = CSharpNaming.EnumType(eEnum);

            foreach (var literal in eEnum.ELiterals)
            {
                builder
                    .Append(indent).Append(qualifiedType).Append('.').Append(LiteralMemberName(literal))
                    .Append(" => \"").Append(literal.Name).AppendLine("\",");
            }

            return builder.ToString();
        }

        /// <summary>
        /// The C# member name of an enumeration literal, matching what the enumeration template emits.
        /// </summary>
        /// <param name="literal">the enumeration literal</param>
        /// <returns>the C# member name</returns>
        private static string LiteralMemberName(EEnumLiteral literal)
        {
            return CSharpNaming.Escape(CSharpNaming.Capitalize(literal.Name));
        }
    }
}
