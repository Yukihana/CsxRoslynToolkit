using System;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

public static partial class AttributeExtensions
{
    // Attribute Targetting Attribute

    public static string WriteFieldUsageAttribute(bool allowMultiple = true)
        => $"[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = {(allowMultiple ? "true" : "false")})]";

    public static SourceBuilder AddFieldUsageAttribute(this SourceBuilder builder, bool allowMultiple = true)
        => builder.AddLine(WriteFieldUsageAttribute(allowMultiple));

    // Attribute Class Header

    public static string WriteAttributeClassHeader(this string identifier)
    {
        if (!identifier.EndsWith("Attribute"))
            throw new ArgumentException("Attribute classnames should end with 'Attribute'.", nameof(identifier));

        return $"public partial class {identifier} : System.Attribute";
    }

    public static SourceBuilder AddAttributeClassHeader(this SourceBuilder builder, string identifier)
        => builder.AddLine(identifier.WriteAttributeClassHeader());

    // Start field-usage attribute-class block

    public static SourceBuilder StartFieldUsageAttributeClass(this SourceBuilder builder, string identifier, bool allowMultiple = true)
    {
        builder.AddFieldUsageAttribute(allowMultiple);
        builder.AddAttributeClassHeader(identifier);
        return builder.OpenBlockBody();
    }
}