using System.Text.RegularExpressions;

namespace CSX.Toolkits.Roslyn.Helpers;

public static class TrimmingExtensions
{
    public static string CompressAndTrimSpaces(this string text)
        => Regex.Replace(text, @" {2,}", " ").Trim();
}