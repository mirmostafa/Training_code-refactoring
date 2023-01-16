
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Refactoring.Session08;

public record Person(string Name, int Age);

public class PersonService
{
    private readonly List<Person> _people = new();

    public IEnumerable<Person> GetAll()
        => _people.AsEnumerable();
    public Person? GetPersonByName(string name)
        => _people.FirstOrDefault(x => x.Name == name);
    public Person Insert(string name, int age)
    {
        var result = new Person(name, age);
        _people.Add(result);
        return result;
    }
    public Person UpdateByName(string name, int age)
    {  
        var old = GetPersonByName(name) ?? throw new Exception();
        var result = old with { Age = age };
        _people.Remove(old);
        _people.Add(result);
        return result;
    }
    public void DeleteByName(string name)
    {
        var old = GetPersonByName(name) ?? throw new Exception();
        _people.Remove(old);
    }
}

[TestClass]
public class PersonService_Test
{
    PersonService _service;

    [ClassInitialize]
    public void Init()
    {
        _service = new();
    }

    [TestMethod]
    public void GetAllTest()
    {
        var perople = _service.GetAll();
        Assert.IsNotNull(perople);
    }

    [TestMethod]
    public void InsertTest()
    {
        var result = _service.Insert("Ali", 5);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void UpdateTest()
    {
        _service.Insert("Ali", 5);
        var result = _service.UpdateByName("Ali", 15);
        var excpected = 15;
        Assert.AreEqual(excpected, result.Age);
    }
}