namespace Refactoring.Session03;

[TestClass]
public class MyTests
{
    [TestMethod]
    public void TestPersonClass()
    {
        var p = new PersonClass();
        p.Age = 1;
        var expected = 1;
        Assert.AreEqual(expected, p.Age);
    }
}