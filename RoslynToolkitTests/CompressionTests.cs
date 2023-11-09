using CSX.Toolkits.Roslyn.RoslynToolkitExtensions;

namespace RoslynToolkitTests;

public class CompressionTests
{
    [Fact]
    public void CompressSpaces()
    {
        string input = "    A     B    C  DE F  ";
        string expected = "A B C DE F";
        string actual = input.CompressAndTrimSpaces();
        Assert.Equal(expected, actual);
    }
}