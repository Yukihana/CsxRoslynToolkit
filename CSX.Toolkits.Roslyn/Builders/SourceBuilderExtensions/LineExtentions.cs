namespace CSX.Toolkits.Roslyn.Builders;

public static partial class LineExtensions
{
    // Empty lines

    public static SourceBuilder AddEmptyLine(this SourceBuilder builder)
    {
        builder.PushLine(string.Empty);
        return builder;
    }

    public static SourceBuilder AddEmptyLine(this SourceBuilder builder, int count)
    {
        for (int i = 0; i < count; i++)
            builder.PushLine(string.Empty);
        return builder;
    }

    // Content Lines

    public static SourceBuilder AddLine(this SourceBuilder builder, string line)
    {
        builder.PushLine(builder.Indentation + line);
        return builder;
    }

    public static SourceBuilder AddLines(this SourceBuilder builder, params string[] lines)
    {
        foreach (var line in lines)
            builder.PushLine(builder.Indentation + line);
        return builder;
    }

    public static SourceBuilder AddLines(this SourceBuilder builder, SourceBuilder linesSource)
    {
        foreach (var line in linesSource.GetLines())
            builder.PushLine(builder.Indentation + line);
        return builder;
    }

    // Unindented

    public static SourceBuilder AddLinesWithoutIndentation(this SourceBuilder builder, params string[] lines)
    {
        foreach (var line in lines)
            builder.PushLine(line);
        return builder;
    }

    public static SourceBuilder AddLinesWithoutIndentation(this SourceBuilder builder, SourceBuilder linesSource)
    {
        foreach (var line in linesSource.GetLines())
            builder.PushLine(line);
        return builder;
    }

    // Continued

    public static SourceBuilder AddContinuedLine(this SourceBuilder builder, string line)
    {
        builder.IncreaseIndent();
        builder.AddLine(line);
        builder.DecreaseIndent();
        return builder;
    }

    public static SourceBuilder AddContinuedLines(this SourceBuilder builder, params string[] lines)
    {
        builder.IncreaseIndent();
        builder.AddLines(lines);
        builder.DecreaseIndent();
        return builder;
    }

    // Modify existing

    public static SourceBuilder AppendToLast(this SourceBuilder builder, string text)
    {
        string last = builder.PopLine() ?? builder.Indentation;
        builder.PushLine(last + text);
        return builder;
    }
}