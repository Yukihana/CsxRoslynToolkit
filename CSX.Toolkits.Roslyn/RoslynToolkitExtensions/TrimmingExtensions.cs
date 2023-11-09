using System.Text.RegularExpressions;

namespace CSX.Toolkits.Roslyn.RoslynToolkitExtensions;

public static class TrimmingExtensions
{
    public static Regex SpaceCompressionRegex { get; } = new Regex(@" {2,}", RegexOptions.Compiled);

    public static string CompressAndTrimSpaces(this string text)
        => SpaceCompressionRegex.Replace(text, " ").Trim();
}