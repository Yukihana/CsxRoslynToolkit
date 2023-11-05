using System.Collections.Generic;

namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions.Models;

public interface ISymbolDefinition
{
    string Name { get; }
    DefinitionType DefinitionType { get; }

    // Primary

    string? Type { get; }
    string? Value { get; }
    string? Modifiers { get; }
    IEnumerable<ISymbolDefinition>? Attributes { get; }

    // Properties

    IEnumerable<ISymbolDefinition>? Accessors { get; }

    // Classes and Methods

    string? Parent { get; }

    // Methods

    string? TypeParameters { get; }
    IEnumerable<string>? Constraints { get; }
    IEnumerable<ISymbolDefinition>? Members { get; }
    IEnumerable<ISymbolDefinition>? Parameters { get; }
}