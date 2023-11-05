using CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

namespace RoslynToolkitTests;

public class AssignmentTests
{
    [Fact]
    public void TestClassScopeAssignment()
    {
        string generated = "storagePath".WriteClassScopeAssignment("_storagePath");
        string expected = "_storagePath = storagePath;";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void TestClassScopeAssignmentWithNameConflict()
    {
        string generated = "StoragePath".WriteClassScopeAssignment("StoragePath");
        string expected = "this.StoragePath = StoragePath;";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void TestCtorAssignment()
    {
        string generated = "storagePath".WriteConstructorAssignment();
        string expected = "StoragePath = storagePath;";
        Assert.Equal(expected, generated);
    }

    [Fact]
    public void TestCtorAssignmentWithNameConflict()
    {
        string generated = "StoragePath".WriteConstructorAssignment();
        string expected = "this.StoragePath = StoragePath;";
        Assert.Equal(expected, generated);
    }
}