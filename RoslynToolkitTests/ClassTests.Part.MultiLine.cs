using System.Linq;

namespace RoslynToolkitTests;

public partial class ClassTests
{
    [Fact]
    public void MultiLineClassHeader()
    {
        SourceBuilder src = new();
        string generated = src.AddMultiLineClassHeader(
            identifier: "MyTestClass",
            modifiers: "public static partial",
            parents: new string[] { "MyBaseType", "IMyInterface<T>", "ISomeOtherStuff<X>" },
            constraints: new (string, string)[] { ("T", "IMyConstraint"), ("X", "IMyConstraint2") })
            .ToString();

        string expected = @"public static partial class MyTestClass :
    MyBaseType,
    IMyInterface<T>,
    ISomeOtherStuff<X>
    where T : IMyConstraint
    where X : IMyConstraint2";

        Assert.Equal(expected, generated);
    }
}