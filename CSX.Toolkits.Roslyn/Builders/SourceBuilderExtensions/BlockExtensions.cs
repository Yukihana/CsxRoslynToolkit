namespace CSX.Toolkits.Roslyn.Builders;

public static partial class BlockExtensions
{
    public static SourceBuilder OpenBlockBody(this SourceBuilder builder)
    {
        builder.AddLine("{");
        builder.PushIndentation();
        builder.IndentLength += builder.IndentIncrements;
        return builder;
    }

    public static SourceBuilder CloseBlockBody(this SourceBuilder builder)
    {
        // Not Decrease indent, since it may be inaccurate
        builder.PopIndentation();
        // builder.IndentLength = _blockIndentations.Pop();
        builder.AddLine("}");
        return builder;
    }

    public static SourceBuilder AddEmptyBlockBody(this SourceBuilder builder)
    {
        builder.AddLine("{ }");
        return builder;
    }

    public static SourceBuilder CloseAllBlockBodies(this SourceBuilder builder)
    {
        while (builder.PushedIndentsCount > 0)
        {
            builder.PopIndentation();
            builder.AddLine("}");
        }
        return builder;
    }
}