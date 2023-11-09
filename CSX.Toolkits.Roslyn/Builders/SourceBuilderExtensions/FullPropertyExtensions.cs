namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class FullPropertyExtensions
{
    public static SourceBuilder StartFullPropertyBlock(this SourceBuilder builder, string identifier, string type, string modifiers = "public")
    {
        builder.AddDataMemberHeader(
            identifier: identifier,
            type: type,
            modifiers: modifiers);

        return builder.OpenBlockBody();
    }
}