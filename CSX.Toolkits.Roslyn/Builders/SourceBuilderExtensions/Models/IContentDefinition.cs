namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions.Models;

public interface IContentDefinition
{
    string? TextContent { get; }
    ISymbolDefinition? SymbolContent { get; }
}