using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

namespace RoslynToolkitTests;

public partial class AttributeTests
{
    [Fact]
    public void FieldUsageHeader()
    {
        string generated = AttributeExtensions.WriteFieldUsageAttribute();
        string expected = "[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void FieldUsageHeaderMuted()
    {
        string generated = AttributeExtensions.WriteFieldUsageAttribute(false);
        string expected = "[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void AttributeClassHeader()
    {
        string generated = "MyTestAttribute".WriteAttributeClassHeader();
        string expected = "public partial class MyTestAttribute : System.Attribute";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void AttributeClassHeaderWithBadName()
    {
        bool argExceptThrown = false;
        try
        {
            string generated = "MyTestAttrib".WriteAttributeClassHeader();
        }
        catch (ArgumentException ex)
        {
            if (ex.ParamName is "identifier" && ex.Message.Contains("'Attribute'"))
                argExceptThrown = true;
        }

        Assert.True(argExceptThrown);
    }
}