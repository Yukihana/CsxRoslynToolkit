using CSX.Toolkits.Roslyn.RoslynToolkitExtensions;

namespace RoslynToolkitTests;

public class CapitalizationTests
{
    // Invalid Identifiers

    [Fact]
    public void CapitalizeJank()
    {
        string input = "#$#%@#%@$!$";
        string expected = string.Empty;
        Assert.Equal(expected, NamingExtensions.GetPropertyNameFromField(input));
        Assert.Equal(expected, NamingExtensions.GetPropertyNameFromParameter(input));
    }

    // Underscored

    [Fact]
    public void UnderscoredField()
    {
        string input = "_myFieldName";
        string expected = "MyFieldName";
        string actual = NamingExtensions.GetPropertyNameFromField(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UnderscoredParameter()
    {
        string input = "_myFieldName";
        string expected = "MyFieldName";
        string actual = NamingExtensions.GetPropertyNameFromParameter(input);

        Assert.Equal(expected, actual);
    }

    // camelCase

    [Fact]
    public void CamelCaseField()
    {
        string input = "myFieldName";
        string expected = "MyFieldName";
        string actual = NamingExtensions.GetPropertyNameFromField(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CamelCaseParameter()
    {
        string input = "myFieldName";
        string expected = "MyFieldName";
        string actual = NamingExtensions.GetPropertyNameFromParameter(input);

        Assert.Equal(expected, actual);
    }

    // Already Capitalized

    [Fact]
    public void CapitalizedField()
    {
        string input = "MyFieldName";
        string expected = "C__MyFieldName";
        string actual = NamingExtensions.GetPropertyNameFromField(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CapitalizedParameter()
    {
        string input = "MyFieldName";
        string expected = "MyFieldName";
        string actual = NamingExtensions.GetPropertyNameFromParameter(input);

        Assert.Equal(expected, actual);
    }

    // Non conforming

    [Fact]
    public void NonconformingField()
    {
        string input = "___myFieldName";
        string expected = "C_____myFieldName";
        string actual = NamingExtensions.GetPropertyNameFromField(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NonconformingParameter()
    {
        string input = "___myFieldName";
        string expected = "C_____myFieldName";
        string actual = NamingExtensions.GetPropertyNameFromParameter(input);

        Assert.Equal(expected, actual);
    }
}