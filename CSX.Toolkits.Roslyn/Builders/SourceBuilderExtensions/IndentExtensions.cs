namespace CSX.Toolkits.Roslyn.Builders;

public static partial class IndentExtensions
{
    public static SourceBuilder IncreaseIndent(this SourceBuilder builder)
    {
        builder.IndentLength += builder.IndentIncrements;
        return builder;
    }

    public static SourceBuilder DecreaseIndent(this SourceBuilder builder)
    {
        builder.IndentLength -= builder.IndentIncrements;
        return builder;
    }

    public static SourceBuilder ResetIndent(this SourceBuilder builder)
    {
        builder.IndentLength = 0;
        return builder;
    }
}