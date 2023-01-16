using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Seesion07;

[TestClass]
public class AlwaysReturnSomething
{
    [TestMethod]
    public void _01_MethodChainest()
    {
        var numbers = Enumerable.Range(0, 10);
        var nums1 = numbers
                        .Where(x => x > 5)
                        .Where(x => x < 8)
                        .Select(x => x.ToString());
        var nums1List = nums1.ToList();
    }
    [TestMethod]
    public void _02_ReturnThis()
    {
        //xvar p1 = new Person();
        var p = Person
                 .Create()
                 .SetAge(25)
                 .SetName("Ali");
    }
}

//! Not Immutated
//! Best practice: Change this to be immutated.
file class Person
{
    public int Age { get; set; }

    public string? Name { get; set; }

    public static Person Create() 
        => new();

    public Person SetAge(int age)
    {
        this.Age = age;
        return this;
    }
}

file static class PersonExtensions
{
    public static Person SetName(this Person person, string name)
    {
        person.Name = name;
        return person;
    }
}