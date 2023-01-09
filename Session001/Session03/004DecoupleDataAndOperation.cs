using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Session001.Lesson03;

static class PersonCrud
{
    public static PersonClass Insert(this PersonClass personDto)
    {
        //...
        return personDto;
    }
}

class PersonClass
{
    public int Age { get; set; }
    public string? Name { get; set; }
}
record struct PersonDto(int Age, string Name);

[TestClass]
public class Decoupling
{
    [TestMethod]
    public void PersonDto()
    {
        var personDto = new PersonClass();
        personDto.Insert();
    }
}
