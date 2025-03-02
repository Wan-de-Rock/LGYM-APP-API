﻿using System.Globalization;
using System.Text;

namespace LgymApp.Domain.Helpers;

public static class StringsHelper
{
    /// <summary>
    /// Converts a given string to underscore case.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <returns>The string converted to underscore case.</returns>
    public static string ToUnderscoreCase(this string str) =>
        string.Concat(
            str.Select((x, i) =>
                i > 0 && char.IsUpper(x) && (char.IsLower(str[i - 1]) || i < str.Length - 1 && char.IsLower(str[i + 1]))
                    ? "_" + x
                    : x.ToString())).ToLowerInvariant();

    /// <summary>
    /// Converts a given string to snake case.
    /// </summary>
    /// <param name="name">The input string.</param>
    /// <returns>The string converted to snake case.</returns>
    public static string ToSnakeCase(this string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        var builder = new StringBuilder(name.Length + Math.Min(2, name.Length / 5));
        var previousCategory = default(UnicodeCategory?);
        const char underScore = '_';
        
        for (var currentIndex = 0; currentIndex < name.Length; currentIndex++)
        {
            var currentChar = name[currentIndex];
            if (currentChar == underScore)
            {
                builder.Append(underScore);
                previousCategory = null;
                continue;
            }

            var currentCategory = char.GetUnicodeCategory(currentChar);
            switch (currentCategory)
            {
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.TitlecaseLetter:
                    if (previousCategory == UnicodeCategory.SpaceSeparator ||
                        previousCategory == UnicodeCategory.LowercaseLetter ||
                        previousCategory != UnicodeCategory.DecimalDigitNumber &&
                        previousCategory != null &&
                        currentIndex > 0 &&
                        currentIndex + 1 < name.Length &&
                        char.IsLower(name[currentIndex + 1]))
                    {
                        builder.Append(underScore);
                    }

                    currentChar = char.ToLower(currentChar);
                    break;

                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.DecimalDigitNumber:
                    if (previousCategory == UnicodeCategory.SpaceSeparator)
                        builder.Append(underScore);
                    break;

                default:
                    if (previousCategory != null)
                        previousCategory = UnicodeCategory.SpaceSeparator;
                    continue;
            }

            builder.Append(currentChar);
            previousCategory = currentCategory;
        }

        return builder.ToString();
    }

    public static string ToSnakeCase2(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        var builder = new System.Text.StringBuilder();
        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]) && i > 0)
            {
                builder.Append('_');
            }

            builder.Append(char.ToLower(name[i]));
        }

        return builder.ToString();
    }
}