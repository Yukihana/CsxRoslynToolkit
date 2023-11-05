using CSX.Toolkits.Roslyn.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class ClassExtensions
{
    public static string WriteClassHeader(
        this string identifier,
        string modifiers = "public partial",
        IEnumerable<string>? parents = null,
        IEnumerable<(string, string)>? constraints = null)
    {
        string result = $"{modifiers} class {identifier}".CompressAndTrimSpaces();

        if (parents is not null && parents.Any())
            result += " : " + string.Join(", ", parents);

        if (constraints is not null && constraints.Any())
        {
            foreach (var constraint in constraints)
                result += $" where {constraint.Item1} : {constraint.Item2}";
        }

        return result;
    }

    public static SourceBuilder AddClassHeader(
        this SourceBuilder builder,
        string identifier,
        string modifiers = "public partial",
        IEnumerable<string>? parents = null,
        IEnumerable<(string, string)>? constraints = null)
    {
        string result = identifier.WriteClassHeader(
            modifiers: modifiers,
            parents: parents,
            constraints: constraints);

        return builder.AddLine(result);
    }

    public static SourceBuilder StartClass(
        this SourceBuilder builder,
        string identifier,
        string modifiers = "public partial",
        IEnumerable<string>? parents = null,
        IEnumerable<(string, string)>? constraints = null)
    {
        string result = identifier.WriteClassHeader(
            modifiers: modifiers,
            parents: parents,
            constraints: constraints);

        builder.AddLine(result);
        return builder.OpenBlockBody();
    }
}