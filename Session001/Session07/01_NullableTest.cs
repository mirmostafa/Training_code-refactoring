using System.Diagnostics.CodeAnalysis;

namespace Refactoring.Session07;

[TestClass]
public class NullableTest
{
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void GetBackTest()
    {
        var a = GetBack(null);
        var a2 = GetBackNullForgiven(null);
    }

    [return: NotNull]
    public static string GetBack(string? name)
    {
        if (name.Trim() == "")
        {

        }
        var notnull_name = name ?? string.Empty;
        //if(name  == null)
        //    name = string.Empty;
        name ??= string.Empty;
        return name;
    }

    public static string GetBackNullForgiven([DisallowNull] string name)
    {
        if (name!.Trim() == "")
        {

        }
        var notnull_name = name ?? string.Empty;
        //if(name  == null)
        //    name = string.Empty;
        name ??= string.Empty;
        return name;
    }

    public static bool IsPrime<TNumber>(TNumber number)
        where TNumber : notnull
    {
        return true;
    }
}