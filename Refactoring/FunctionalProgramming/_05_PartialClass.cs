namespace Refactoring.FunctionalProgramming;

[TestClass]
public class PartialClass
{
    [TestMethod]
    public void _01_PersonPartialClass()
    {
        _ = new Person();
    }
}

internal partial class Person
{
    public Person()
    {
        this.Log();
    }

    partial void Log();
}

internal partial class Person
{
    partial void Log()
    {
        //...
    }
}