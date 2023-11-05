namespace CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions.Models;

public enum DefinitionType
{
    Field,
    Property,
    Event,

    Accessor,
    Attribute,

    Dependency,
    Namespace,
    Class,          // Types: Class, Record, Struct, Interface, etc.

    Method,
    Constructor,
    Lambda,
    KeywordBlock,

    /* Not included types:
     * Label,
     * Comment,
     * Documentation,
     * Case
     */
}