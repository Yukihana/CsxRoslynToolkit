using Microsoft.CodeAnalysis.CSharp;

namespace RoslynToolkitTests;

public class SyntaxFactVerifications
{
    [Fact]
    public void TestIdentifierValidity()
    {
        Assert.False(SyntaxFacts.IsValidIdentifier("$#$@#%%@#%"));
        Assert.False(SyntaxFacts.IsValidIdentifier("abc$#$@#%%@#%"));
        Assert.False(SyntaxFacts.IsValidIdentifier("abc def"));
        Assert.False(SyntaxFacts.IsValidIdentifier("1$#$@#%%@#%"));
        Assert.False(SyntaxFacts.IsValidIdentifier("_$#$@#%%@#%"));
        Assert.False(SyntaxFacts.IsValidIdentifier("4abc"));
        Assert.False(SyntaxFacts.IsValidIdentifier("4間違い"));

        Assert.True(SyntaxFacts.IsValidIdentifier("_"));
        Assert.True(SyntaxFacts.IsValidIdentifier("_423"));
        Assert.True(SyntaxFacts.IsValidIdentifier("____423"));
        Assert.True(SyntaxFacts.IsValidIdentifier("_field"));
        Assert.True(SyntaxFacts.IsValidIdentifier("____field"));

        Assert.True(SyntaxFacts.IsValidIdentifier("Property"));
        Assert.True(SyntaxFacts.IsValidIdentifier("localField"));

        Assert.True(SyntaxFacts.IsValidIdentifier("正解"));
        Assert.True(SyntaxFacts.IsValidIdentifier("_正解"));
    }

    [Fact]
    public void TestStartCharacters()
    {
        Assert.True(SyntaxFacts.IsIdentifierStartCharacter('_'));
        Assert.True(SyntaxFacts.IsIdentifierStartCharacter('a'));
        Assert.True(SyntaxFacts.IsIdentifierStartCharacter('A'));
        Assert.False(SyntaxFacts.IsIdentifierStartCharacter('1'));
    }

    [Fact]
    public void TestEnglishLetters()
    {
        Assert.True(char.IsLetter('a'));
        Assert.False(char.IsLetter('_'));
        Assert.False(char.IsLetter('.'));
        Assert.False(char.IsLetter('1'));
    }

    [Fact]
    public void TestUnicodeLetters()
    {
        Assert.True(char.IsLetter('の'));
        Assert.True(char.IsLetter('一'));    // Is actually a letter, despite being the number 1.
        Assert.True(char.IsLetter('二'));
        Assert.True(char.IsLetter('三'));    // Note: in japanese unicode, numbers are letters.
        Assert.False(char.IsLetter('。'));
    }

    [Fact]
    public void TestUnicodeRecasing()
    {
        char input = 'の';
        Assert.Equal(input, char.ToUpperInvariant(input));
        Assert.Equal(input, char.ToLowerInvariant(input));
    }
}