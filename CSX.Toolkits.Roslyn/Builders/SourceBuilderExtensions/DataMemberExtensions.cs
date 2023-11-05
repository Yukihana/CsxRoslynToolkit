namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class DataMemberExtensions
{
    public static string WriteDataMemberHeader(string identifier, string type, string modifiers = "private")
        => $"{modifiers} {type} {identifier}";

    public static SourceBuilder AddDataMemberHeader(
        this SourceBuilder builder,
        string identifier,
        string type,
        string modifiers = "private")
    {
        string result = WriteDataMemberHeader(
            identifier: identifier,
            type: type,
            modifiers: modifiers);

        return builder.AddLine(result);
    }
}