namespace RoslynToolkitTests;

public partial class AccessorTests
{
    [Fact]
    public void AccessorKeywords()
    {
        Assert.Equal("get", AccessorTypes.Get.ToKeyword());
        Assert.Equal("set", AccessorTypes.Set.ToKeyword());
        Assert.Equal("init", AccessorTypes.Init.ToKeyword());
    }

    // Expressions

    [Fact]
    public void GetExpressionAccessors()
    {
        string expectedA = "get => DoSomething();";
        string generatedA = AccessorTypes.Get.WriteExpressionAccessor(" DoSomething(); ");
        Assert.Equal(expectedA, generatedA);
    }

    [Fact]
    public void GetExpressionAccessorsModified()
    {
        string expectedB = "private get => DoSomething();";
        string generatedB = new SourceBuilder()
            .AddExpressionAccessor(AccessorTypes.Get, " DoSomething(); ", " private ")
            .ToString();
        Assert.Equal(expectedB, generatedB);
    }

    // Blocks

    [Fact]
    public void SetBlockAccessors()
    {
        string expectedA = @"set
{
    _something = value;
}";
        string generatedA = AccessorTypes.Set
            .WriteBlockAccessor(modifiers: string.Empty, "_something = value; ");
        Assert.Equal(expectedA, generatedA);
    }

    [Fact]
    public void SetBlockAccessorsModified()
    {
        string expected = @"private set
{
    _something = value;
    NotifySomething();
}";
        string generated = new SourceBuilder()
            .AddBlockAccessor(type: AccessorTypes.Set, modifiers: " private ", "_something = value; ", "NotifySomething();")
            .ToString();
        Assert.Equal(expected, generated);
    }

    // Automatic

    [Fact]
    public void AccessorAutoformatSingleLine()
    {
        string expected = "private get => DoSomething();";
        string generated = new SourceBuilder()
            .AddAccessor(type: AccessorTypes.Get, modifiers: " private ", " DoSomething(); ")
            .ToString();
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void AccessorAutoformatMultiLine()
    {
        string expected = @"private set
{
    _something = value;
    NotifySomething();
}";
        string generated = new SourceBuilder()
            .AddAccessor(type: AccessorTypes.Set, modifiers: " private ", "_something = value; ", "NotifySomething();")
            .ToString();
        Assert.Equal(expected, generated);
    }
}