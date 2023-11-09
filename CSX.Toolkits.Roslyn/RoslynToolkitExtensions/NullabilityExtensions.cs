using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CSX.Toolkits.Roslyn.RoslynToolkitExtensions;

public static class NullabilityExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> e)
    {
        foreach (var item in e)
        {
            if (item is T t)
                yield return t;
        }
    }

    /// <summary>
    /// Only selects items that are not null.
    /// </summary>
    public static IncrementalValuesProvider<T> WhereNotNull<T>(this IncrementalValuesProvider<T?> source)
         => source.SelectMany((item, _) => item is not null ? ImmutableArray.Create(item) : ImmutableArray<T>.Empty);
}