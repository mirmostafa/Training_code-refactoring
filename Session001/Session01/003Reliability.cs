namespace Session001.Lesson01;

file static class Math
{
    /// <summary>
    /// Divides `a` to `b`.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">b.</param>
    /// <returns></returns>
    public static int Div(int a, int b)
        => a / b;
}

[TestClass]
public class MathTest
{
    [TestMethod]
    public void Test01_PositiveTest()
    {
        var a = 10;
        var b = 5;
        var r = Math.Div(a, b);
        Assert.AreEqual(2, r);
    }

    [TestMethod]
    public void Test02_NegativeTest()
    {
        var a = -10;
        var b = -5;
        var r = Math.Div(a, b);
        Assert.AreEqual(2, r);
    }

    [TestMethod]
    public void Test03_FloatTest()
    {
        var a = -10;
        var b = -3;
        _ = Math.Div(a, b);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Test04_DivisonByZeroTest()
    {
        var a = 1;
        var b = 0;
        _ = Math.Div(a, b);
        Assert.AreEqual(1, 1);
    }
}