using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Text.RegularExpressions;

namespace CSX.Toolkits.Roslyn.RoslynToolkitExtensions;

public static class NamingExtensions
{
    // Property name from field

    public static string GetPropertyNameFromField(string fieldName)
    {
        if (!SyntaxFacts.IsValidIdentifier(fieldName) || fieldName == "_")
            return string.Empty;

        // if the first character is _ and second is a letter.
        // lack of underscore automatically differentiates the new name.
        // hence confirming if ToUpper worked isn't required. (works for unicode)
        if (fieldName[0] == '_' &&
            char.IsLetter(fieldName[1]))
            return $"{char.ToUpperInvariant(fieldName[1])}{fieldName[2..]}";

        // if first character is letter, and ToUpper isn't the same,
        // then it was originally lowercase. hence the new upper can be used as a distinct property name.
        else if (char.IsLetter(fieldName[0]) &&
            char.ToUpperInvariant(fieldName[0]) != fieldName[0])
            return $"{char.ToUpperInvariant(fieldName[0])}{fieldName[1..]}";

        // for all non-conforming cases, just prefix `C__`
        return $"C__{fieldName}";
    }

    // Property name from parameter

    public static string GetPropertyNameFromParameter(string fieldName)
    {
        if (!SyntaxFacts.IsValidIdentifier(fieldName) || fieldName == "_")
            return string.Empty;

        // if the first character is _ and second is a letter.
        // lack of underscore automatically differentiates the new name.
        // hence confirming if ToUpper worked isn't required. (works for unicode)
        if (fieldName[0] == '_' &&
            char.IsLetter(fieldName[1]))
            return $"{char.ToUpperInvariant(fieldName[1])}{fieldName[2..]}";

        // if first character is letter, just uppercase and deploy
        // since we don't need to enforce it to be unique
        else if (char.IsLetter(fieldName[0]))
            return $"{char.ToUpperInvariant(fieldName[0])}{fieldName[1..]}";

        // for all non-conforming cases, just prefix `C__`
        return $"C__{fieldName}";
    }

    // Guid Prefix

    public static Regex HexDecOnly { get; } = new Regex("[^0-9A-Fa-f]+");

    public static string GetBackupPrefix()
    {
        string g = Guid.NewGuid().ToString().ToUpperInvariant();
        return $"C__{HexDecOnly.Replace(g, "")}_";
    }
}