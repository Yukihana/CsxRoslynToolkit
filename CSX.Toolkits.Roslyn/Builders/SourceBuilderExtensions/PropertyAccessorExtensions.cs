using CSX.Toolkits.Roslyn.RoslynToolkitExtensions;
using System;
using System.Linq;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class PropertyAccessorExtensions
{
    // Components

    public static string ToKeyword(this AccessorTypes type) => type switch
    {
        AccessorTypes.Get => "get",
        AccessorTypes.Set => "set",
        AccessorTypes.Init => "init",
        _ => throw new ArgumentException($"Unknown input: {nameof(AccessorTypes)}.{type}", nameof(type))
    };

    // Header

    public static string WriteAccessorHeader(this AccessorTypes type, string modifiers = "")
        => $"{modifiers} {type.ToKeyword()}".CompressAndTrimSpaces();

    public static SourceBuilder AddAccessorHeader(
        this SourceBuilder builder,
        AccessorTypes type,
        string modifiers = "")
    {
        string result = type.WriteAccessorHeader(modifiers);
        return builder.AddLine(result);
    }

    public static SourceBuilder StartBlockAccessor(
        this SourceBuilder builder,
        AccessorTypes type,
        string modifiers = "")
    {
        builder.AddAccessorHeader(type: type, modifiers: modifiers);
        return builder.OpenBlockBody();
    }

    // Expression

    public static string WriteExpressionAccessor(this AccessorTypes type, string content, string modifiers = "")
        => $"{type.WriteAccessorHeader(modifiers)} => {content.Trim()}";

    public static SourceBuilder AddExpressionAccessor(
        this SourceBuilder builder,
        AccessorTypes type,
        string content,
        string modifiers = "")
    {
        string result = type.WriteExpressionAccessor(content, modifiers);
        return builder.AddLine(result);
    }

    public static SourceBuilder AddSplitExpressionAccessor(
        this SourceBuilder builder,
        AccessorTypes type,
        string content,
        string modifiers = "")
    {
        builder.AddAccessorHeader(type, modifiers);
        return builder.AddContinuedLine($"=> {content.Trim()}");
    }

    // Block

    public static SourceBuilder AddBlockAccessor(
        this SourceBuilder builder,
        AccessorTypes type,
        string modifiers = "",
        params string[] content)
    {
        builder.StartBlockAccessor(type: type, modifiers: modifiers);
        builder.AddLines(content.TrimEnd().ToArray()); //Start isn't auto-trimmed to compensate for sub-builder indentations
        return builder.CloseBlockBody();
    }

    public static string WriteBlockAccessor(
        this AccessorTypes type,
        string modifiers = "",
        params string[] content)
    {
        return new SourceBuilder()
            .AddBlockAccessor(type: type, modifiers: modifiers, content: content)
            .ToString();
    }

    // Automatic

    public static SourceBuilder AddAccessor(
        this SourceBuilder builder,
        AccessorTypes type,
        string modifiers = "",
        params string[] content)
    {
        return content.Length == 1
            ? builder.AddExpressionAccessor(type: type, content: content[0], modifiers: modifiers)
            : builder.AddBlockAccessor(type: type, modifiers: modifiers, content: content);
    }
}