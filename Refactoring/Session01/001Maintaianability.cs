namespace Refactoring.Session01;

// reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor
internal class Person
{
    //! Alternate copy constructor calls the instance constructor.
    public Person(Person previousPerson)
        : this(previousPerson.Name, previousPerson.Age)
    {
    }

    // Instance constructor.
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int Age { get; set; }

    public string Name { get; set; }

    public string Details()
        => Name + " is " + Age.ToString();
}

[TestClass]
public class Tests
{
    [TestMethod]
    public void CopyConstructor()
    {
        // Create a Person object by using the instance constructor.
        var person1 = new Person("George", 40);
        // Create another Person object, copying person1.
        var person2 = new Person(person1);
        // Change each person's age.
        person1.Age = 39;
        person2.Age = 41;
        // Change person2's name.
        person2.Name = "Charles";
        // Show details to verify that the name and age fields are distinct.
        Console.WriteLine(person1.Details());
        Console.WriteLine(person2.Details());
        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        //_ = Console.ReadKey();
    }
}

// Output:
// George is 39
// Charles is 41