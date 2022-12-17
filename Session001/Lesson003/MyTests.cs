namespace Session001.Lesson003;

[TestClass]
public class MyTests
{
    [TestMethod]
    public void TestPersonClass()
    {
        var p = new PersonClass();
        p.Age = 1;
        var expected = 3;
        Assert.AreEqual(expected, p.Age);
    }
}