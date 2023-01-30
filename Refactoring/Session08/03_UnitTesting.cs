namespace Refactoring.Session08;

public record Person(string Name, int Age);

public class PersonService
{
    private readonly List<Person> _people = new();

    public void DeleteByName(string name)
    {
        var old = GetPersonByName(name) ?? throw new Exception();
        _ = _people.Remove(old);
    }

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
        _ = _people.Remove(old);
        _people.Add(result);
        return result;
    }
}

[TestClass]
public class PersonService_Test
{
    private PersonService _service = default!;

    [TestMethod]
    public void GetAllTest()
    {
        var people = _service.GetAll();
        Assert.IsNotNull(people);
    }

    [ClassInitialize]
    public void Init() => _service = new();

    [TestMethod]
    public void InsertTest()
    {
        var result = _service.Insert("Ali", 5);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void UpdateTest()
    {
        _ = _service.Insert("Ali", 5);
        var result = _service.UpdateByName("Ali", 15);
        var excepted = 15;
        Assert.AreEqual(excepted, result.Age);
    }
}