using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSX.Toolkits.Roslyn.RoslynToolkitExtensions;

public static partial class StringExtensions
{
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
        => string.IsNullOrWhiteSpace(value);

    public static void ThrowIfNullOrWhiteSpace([NotNullWhen(false)] this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException($"Value cannot be empty or whitespace.", nameof(value));
    }

    // Split

    public static string[] SplitToLines(this string value)
        => value.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

    // Trim

    public static IEnumerable<string> TrimEnd(this IEnumerable<string> source)
    {
        foreach (var item in source)
            yield return item.TrimEnd();
    }
}