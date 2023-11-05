using CSX.Toolkits.Roslyn.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class ClassExtensions
{
    public static SourceBuilder AddMultiLineClassHeader(
        this SourceBuilder builder,
        string identifier,
        string modifiers = "public partial",
        IEnumerable<string>? parents = null,
        IEnumerable<(string, string)>? constraints = null)
    {
        SourceBuilder src = new();
        src.AddLine($"{modifiers} class {identifier}".CompressAndTrimSpaces());

        if (parents is not null && parents.Any())
        {
            src.AppendToLast(" :");
            string parentsString = string.Join("," + Environment.NewLine, parents);
            src.AddContinuedLines(parentsString.SplitToLines());
        }

        if (constraints is not null && constraints.Any())
        {
            foreach (var constraint in constraints)
                src.AddContinuedLine($"where {constraint.Item1} : {constraint.Item2}");
        }

        return builder.AddLines(src);
    }

    public static SourceBuilder StartClassWithMultiLineHeader(
        this SourceBuilder builder,
        string identifier,
        string modifiers = "public partial",
        IEnumerable<string>? parents = null,
        IEnumerable<(string, string)>? constraints = null)
    {
        builder.AddMultiLineClassHeader(
            identifier: identifier,
            modifiers: modifiers,
            parents: parents,
            constraints: constraints);

        return builder.OpenBlockBody();
    }
}