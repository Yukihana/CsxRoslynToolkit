namespace RoslynToolkitTests;

public partial class ClassTests
{
    [Fact]
    public void ClassHeader()
    {
        string generated = "MyTestClass".WriteClassHeader(
            modifiers: "public static partial",
            parents: new string[] { "MyBaseType", "IMyInterface<T>", "ISomeOtherStuff<X>" },
            constraints: new (string, string)[] { ("T", "IMyConstraint"), ("X", "IMyConstraint2") });
        string expected = "public static partial class MyTestClass : MyBaseType, IMyInterface<T>, ISomeOtherStuff<X> where T : IMyConstraint where X : IMyConstraint2";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void BasicClassHeader()
    {
        string generated = "MyTestClass".WriteClassHeader();
        string expected = "public partial class MyTestClass";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void BasicStaticClassHeader()
    {
        string generated = "MyTestClass".WriteClassHeader(modifiers: "public static partial");
        string expected = "public static partial class MyTestClass";
        Assert.Equal(expected, generated);
    }
}