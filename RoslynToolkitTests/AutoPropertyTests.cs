namespace RoslynToolkitTests;

public class AutoPropertyTests
{
    [Fact]
    public void GetSet()
    {
        string generated = AutoPropertyExtensions.WriteAutoProperty("Prop0", "string", AutoPropertyAccessors.GetSet, "\"something\"");
        string result = "public string Prop0 { get; set; } = \"something\";";
        Assert.Equal(result, generated);
    }

    [Fact]
    public void GetPrivateSet()
    {
        string generated = AutoPropertyExtensions.WriteAutoProperty("Prop0", "string", AutoPropertyAccessors.GetPrivateSet, "\"something\"");
        string result = "public string Prop0 { get; private set; } = \"something\";";
        Assert.Equal(result, generated);
    }

    [Fact]
    public void GetSetWithoutValue()
    {
        string generated = AutoPropertyExtensions.WriteAutoProperty("Prop0", "string", AutoPropertyAccessors.GetSet);
        string result = "public string Prop0 { get; set; }";
        Assert.Equal(result, generated);
    }
}