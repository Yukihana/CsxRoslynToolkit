using System;
using System.Collections.Generic;
using System.Linq;

namespace CSX.Toolkits.Roslyn.Builders;

public partial class SourceBuilder
{
    // Only put core features in this class.
    // Everything else can be added as extensions.

    private readonly List<string> _storage = new();

    public override string ToString()
        => string.Join(Environment.NewLine, _storage);

    public string[] GetLines()
        => _storage.ToArray();

    public void Reset()
        => _storage.Clear();

    // Indentation

    public int IndentIncrements { get; set; } = 4;
    public int IndentLength { get; set; } = 0;
    public string Indentation => new(' ', IndentLength);

    // Indentation Stacking

    private readonly Stack<int> _indentations = new();

    public int PushedIndentsCount
        => _indentations.Count;

    public void PushIndentation()
        => _indentations.Push(IndentLength);

    public void PopIndentation()
        => IndentLength = _indentations.Pop();

    // Content

    public void PushLine(string line)
        => _storage.Add(line);

    public string? PopLine()
    {
        if (!_storage.Any())
            return null;
        string popped = _storage.Last();
        _storage.RemoveAt(_storage.Count - 1);
        return popped;
    }
}