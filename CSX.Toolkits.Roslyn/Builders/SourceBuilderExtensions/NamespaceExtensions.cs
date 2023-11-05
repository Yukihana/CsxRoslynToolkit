namespace CSX.Toolkits.Roslyn.Builders;

public static partial class NamespaceExtensions
{
    public static SourceBuilder SetNamespace(this SourceBuilder builder, string path)
    {
        builder.AddLine($"namespace {path};");
        builder.AddEmptyLine();
        return builder;
    }

    public static SourceBuilder StartNamespace(this SourceBuilder builder, string path)
    {
        builder.AddLine($"namespace {path}");
        builder.OpenBlockBody();
        return builder;
    }
}