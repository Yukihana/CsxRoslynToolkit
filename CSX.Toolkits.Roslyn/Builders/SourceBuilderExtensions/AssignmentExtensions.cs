using CSX.Toolkits.Roslyn.Helpers;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class AssignmentExtensions
{
    // Class scope assignment (automatically prefix 'this' if required)

    public static string WriteClassScopeAssignment(this string source, string target)
        => $"{(source == target ? "this." : "")}{target} = {source};";

    public static SourceBuilder AddClassScopeAssignment(this SourceBuilder builder, string source, string target)
        => builder.AddLine(source.WriteClassScopeAssignment(target));

    // Ctor Assignment (handles automatic capitalization)

    public static string WriteConstructorAssignment(this string source)
        => WriteClassScopeAssignment(source, source.Capitalize());

    public static SourceBuilder AddConstructorAssignment(this SourceBuilder builder, string source)
        => builder.AddLine(WriteConstructorAssignment(source));

    public static SourceBuilder AddConstructorAssignments(this SourceBuilder builder, params string[] source)
    {
        foreach (var assignment in source)
            builder.AddLine(WriteConstructorAssignment(assignment));
        return builder;
    }
}