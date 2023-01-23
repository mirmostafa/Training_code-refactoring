namespace Refactoring.Session08;

internal static class Math
{
    /// <summary>
    /// Divides `a` to `b`.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">b.</param>
    /// <returns></returns>
    public static int Div(int a, int b)
        => a / b;

    public static int DivProtected(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (DivideByZeroException)
        {
            return 0;
        }
    }
}

[TestClass]
public class MathTest
{
    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Div_DivisionByZeroTest()
    {
        var a = 1;
        var b = 0;
        var r = Math.Div(a, b);
        Assert.AreEqual(1, r);
    }

    [TestMethod]
    public void Div_FloatTest()
    {
        var a = -10;
        var b = -3;
        _ = Math.Div(a, b);
    }

    [TestMethod]
    public void Div_NegativeTest()
    {
        var a = -10;
        var b = -5;
        var r = Math.Div(a, b);
        Assert.AreEqual(2, r);
    }

    [TestMethod]
    public void Div_PositiveTest()
    {
        var a = 10;
        var b = 5;
        var r = Math.Div(a, b);
        Assert.AreEqual(2, r);
    }
    [TestMethod]
    public void DivProtected_NegativeTest()
    {
        var a = -10;
        var b = -5;
        var r = Math.DivProtected(a, b);
        Assert.AreEqual(2, r);
    }

    [TestMethod]
    public void DivProtected_PositiveTest()
    {
        var a = 10;
        var b = 5;
        var r = Math.DivProtected(a, b);
        Assert.AreEqual(2, r);
    }
    //x[TestMethod]
    //xpublic void DivProtected_DirtyTest()
    //x{
    //x    var a = -10;
    //x    var b = -5;
    //x    var r = Math.DivProtected(a, b);
    //x    Assert.AreEqual(2, r);
      
    //x    b = 5;
    //x    r = Math.DivProtected(a, b);
    //x    Assert.AreEqual(-2, r);
    //x}

    [TestMethod]
    public void DivProtected_ZeroTest()
    {
        var a = 10;
        var b = 0;
        var r = Math.DivProtected(a, b);
        Assert.AreEqual(0, r);
    }
}