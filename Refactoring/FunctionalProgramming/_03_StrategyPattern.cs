namespace Refactoring.FunctionalProgramming;

[TestClass]
public class StrategyPatternTest
{
    [TestMethod]
    public void _01_ObjectOriented()
    {
        var result = new ObjectOrientedStrategyPattern().Do(5, 6);
        Assert.AreEqual(11, result);
    }

    [TestMethod]
    public void _02_Functional()
    {
        var action = new FunctionalStrategyPattern().Do();
        var result1 = action(5, 6);
        var result2 = action(10, 15);
        Assert.AreEqual(11, result1);
        Assert.AreEqual(25, result2);
    }

    [TestMethod]
    public void _0201_Functional()
    {
        var action = new FunctionalStrategyPattern().Do(false);
        var result1 = action(5, 6);
        var result2 = action(10, 15);
        Assert.AreEqual(-1, result1);
        Assert.AreEqual(-5, result2);
    }

    [TestMethod]
    public void _03_Functional()
    {
        var result = new FunctionalStrategyPattern().Do()(5, 6);
        Assert.AreEqual(11, result);
    }
}

file class FunctionalStrategyPattern
{
    private readonly Func<int, int, int> _add = (x, y) => x + y;
    private readonly Func<int, int, int> _sub = (x, y) => x - y;

    public Func<int, int, int> Do()
        => this._add;

    public Func<int, int, int> Do(bool useSum)
        => useSum ? this._add : this._sub;
}

file class ObjectOrientedStrategyPattern
{
    private readonly Func<int, int, int> _add = (x, y) => x + y;
    private readonly Func<int, int, int> _sub = (x, y) => x + y;

    public int Do(int x, int y)
        => this._add(x, y);
}