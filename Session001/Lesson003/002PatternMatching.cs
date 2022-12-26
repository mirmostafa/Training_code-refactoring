using Session001.Models;

namespace Session001.Lesson003;

// https://gist.github.com/mirmostafa/085afcfdcff8836dd715b0cef38c6960
internal static class _002PatternMatching
{
    public static string A_SwitchCase(Shape randomShape)
        => randomShape switch
        {
            Circle { Diameter: 20 } c1 => "This is a special circle",
            Circle { Diameter: 10, Radius: < 5 and > 2, Area: <= 15 } c1 => "This is a very special circle",
            Circle _ => "This is a circle",
            Recatngle r when r.Width == r.Height => "This is a square",
            Recatngle => "This is a rectangle",
            { Area: 100 } => "This is a shape with area 100",
            { Area: > 100 } => "This is a shape with bigger than 100",
            _ => throw new NotImplementedException(),
        };

    // switch pattern matching
    public static string B_Display(this Person person)
    {
        return (person?.Age < 50, person?.Age > 40, person?.Age < 10, person) switch
        {
            (_, _, _, Student p) => $"{p.Name} is a student and he studies {p.CourseOfStudy}.",// His birth year is {p.GetBirthYear()}",
            (_, _, _, Teacher { Age: 43 } p) => $"{p.Name} is same as me and he teaches {p.CourseOfTeach}",
            (_, true, _, Teacher p) => $"{p.Name} is a young teacher and he teaches {p.CourseOfTeach}",
            (true, _, _, Teacher p) => $"{p.Name} is a teacher and he teaches {p.CourseOfTeach}",
            (_, _, _, null) => "Null? kidding?",
            (_, _, _, { Age: 0, Name: var name }) => $"I don't know how old is '{name}'",
            (_, _, true, { } p) => $"{p.Name} is a baby. He is {p.Age}",
            (_, _, _, { } p) => $"{p.Name} is a person and he {p.Age} is"
        };
    }

    public static void C_Conditional(Shape randomShape)
    {
        if (randomShape is Circle { Diameter: 10, Radius: < 5 and > 2, Area: <= 15 } c)
        {
            Console.WriteLine($"This is my circle. Area: {c.Area}");
        }
        if (randomShape is not null)
        {
        }
        if (randomShape is not Recatngle)
        {
        }
        if (randomShape is not null and not Recatngle)
        {
        }

        if (randomShape is Circle { Name.Length: >= 0 })
        {
        }
        //x if (randomShape is not null r)
        if (randomShape is { } r)
        {
            
        }
    }

    public static void D__Property(Person a)
    {
        if ((a is { } b) && (b is Student and { Age: > 5 }))
        {
        }
    }

    public static bool E_IsWeekend() => DateTime.Now.DayOfWeek switch
    {
        DayOfWeek.Sunday or DayOfWeek.Monday => true,
        _ => false
    };

    /// <summary>
    /// Determines whether the specified c is english.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <returns>
    ///   <c>true</c> if the specified c is english; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsEnglish(char c) => (c is (>= 'A' and <= 'Z') or (>= 'a' and <= 'z'));
}

[TestClass]
public class Z_002Tests
{
    [TestMethod]
    public void SwitchCaseTest01()
    {
        var shape = new Recatngle { Height = 10, Width = 20 };
        var actual = _002PatternMatching.A_SwitchCase(shape);
        var expected = "This is a rectangle";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SwitchCaseTest02()
    {
        var shape = new Recatngle { Height = 20, Width = 20 };
        var actual = _002PatternMatching.A_SwitchCase(shape);
        var expected = "This is a square";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SwitchCaseTest03()
    {
        var shape = new Circle { Diameter = 20 };
        var actual = _002PatternMatching.A_SwitchCase(shape);
        var expected = "This is a special circle";
        Assert.AreEqual(expected, actual);
    }
}