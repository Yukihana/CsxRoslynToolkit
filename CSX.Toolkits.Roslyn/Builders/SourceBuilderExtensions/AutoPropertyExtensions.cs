using CSX.Toolkits.Roslyn.RoslynToolkitExtensions;
using System;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class AutoPropertyExtensions
{
    public static string WriteAutoProperty(
        string name,
        string type,
        AutoPropertyAccessors accessors = AutoPropertyAccessors.GetSet,
        string? value = null,
        string modifiers = "public")
    {
        modifiers = modifiers.CompressAndTrimSpaces();
        type = type.CompressAndTrimSpaces();
        name = name.CompressAndTrimSpaces();
        string accessorsString = accessors.Write().CompressAndTrimSpaces();

        string suffix = string.Empty;
        if (!value.IsNullOrWhiteSpace())
            suffix = $" = {value.CompressAndTrimSpaces()};";

        return $"{modifiers} {type} {name} {accessorsString}{suffix}";
    }

    public static string Write(this AutoPropertyAccessors accessors)
    {
        string result = accessors switch
        {
            AutoPropertyAccessors.GetSet => "get; set;",
            AutoPropertyAccessors.GetPrivateSet => "get; private set;",
            AutoPropertyAccessors.Get => "get;",
            AutoPropertyAccessors.GetInit => "get; init;",
            _ => throw new NotImplementedException($"Enum option {nameof(AutoPropertyAccessors)}.{accessors} wasn't implemented.")
        };

        return $"{{ {result} }}";
    }

    public static SourceBuilder AddAutoProperty(
        this SourceBuilder builder,
        string name,
        string type,
        AutoPropertyAccessors accessors = AutoPropertyAccessors.GetSet,
        string? value = null,
        string modifiers = "public")
    {
        builder.AddLine(WriteAutoProperty(
            name: name,
            type: type,
            accessors: accessors,
            value: value,
            modifiers: modifiers));
        return builder;
    }
}