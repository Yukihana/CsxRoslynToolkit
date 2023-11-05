using System.Collections.Generic;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions.Models;

public class AttributeManifest : ISymbolDefinition
{
    public string Name { get; } = string.Empty;

    public DefinitionType DefinitionType { get; }

    public string? Type { get; }

    public string? Value { get; }

    public string? Modifiers { get; }

    public IEnumerable<ISymbolDefinition>? Attributes { get; }

    public IEnumerable<ISymbolDefinition>? Accessors { get; }

    public string? Parent { get; }

    public string? TypeParameters { get; }

    public IEnumerable<string>? Constraints { get; }

    public IEnumerable<ISymbolDefinition>? Members { get; }

    public IEnumerable<ISymbolDefinition>? Parameters { get; }
}