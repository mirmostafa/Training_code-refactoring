using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Refactoring.Session07;

[TestClass]
public class SwitchStatement
{
    [TestMethod]
    public void _01_IfElseAndSwicth()
    {
        var input = 5;
        switch (input)
        {
            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            default:
                break;
        }
    }

    [TestMethod]
    public void _02_Improvement()
    {
        var input = 5;
        switch (input)
        {
            case < 1:
                break;

            case int.MaxValue:
                break;

            case > 3:
                break;

            //case 5:
            //    break;

            default:
                break;
        }
    }

    [TestMethod]
    public void _03_WhenClause()
    {
        Shape input = new Circle() { Diameter = 5 };

        switch (input)
        {
            case Recatngle:
                break;

            case Circle c when c.Diameter == 1:
                break;

            case Circle c when c.Diameter == 5:
                break;

            default:
                break;
        }
    }

    [TestMethod]
    public void IsNullOrEmptyTest()
    {
        string s = "String";
        Assert.IsFalse(s.IsNullOrEmpty());
    }
}

[DebuggerStepThrough]
[StackTraceHidden]
file static class Extensions
{
    public static bool IsNullOrEmpty(this string s)
        //=> s == null || s.Length== 0 ;
        => s is null or { Length: 0 };
}