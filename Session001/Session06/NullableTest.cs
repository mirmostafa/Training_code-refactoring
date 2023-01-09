using System.Diagnostics.CodeAnalysis;

namespace Refactoring.Session06;

[TestClass]
public class NullableTest
{
    [TestMethod]
    public void GetBackTest()
    {
        var a = GetBack(null);
    }

    [return: NotNull]
    public static string GetBack(string? name)
    {
        if(name!.Trim() == "")
        {

        }
        var notnull_name = name ?? string.Empty;
        //if(name  == null)
        //    name = string.Empty;
        name ??= string.Empty;
        return name;
    }
}