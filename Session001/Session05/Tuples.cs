namespace Session001.Lesson05;

internal static class Tuples
{
    // SortInClass
    public static SortClass SortInClass(int x, int y)
        => y > x ? (new(x, y)) : (new(y, x));

    // SortInRecord
    public static SortRecord SortInRecord(int x, int y)
        => y > x ? (new(x, y)) : (new(y, x));

    // SortInTuple
    public static (int First, int Second) SortInTuple(int x, int y)
        => y > x ? (y, x) : (x, y);

    public static (int One, int Two) GetNumbers()
        => (1, 2);

    public static ((int Id, string UserName) UserProfile, int AccountId) RegisterAccount((string FirstName, string LastName) userInfo
        , long amount, DateTime registrationDate, params (string Name, string Address)[] Addresses)
    {
        // ..
        return ((654651, $"{userInfo.FirstName}{userInfo.LastName}"), 5213541);
    }

    public static (string name, int age) GetPersonInfo(int id)
    {

        //...
        return new("Ali", 5);
    }

    public static (string str1, string str2, string str3) Sort(string str1, string str2, string str3)
    {
        var sorted = new[] { str1, str2, str3 }.Order().ToArray();
        return (sorted[0], sorted[1], sorted[2]);
    }
}

// SortClass
internal readonly struct SortClass
{
    public SortClass(int first, int second)
    {
        First = first;
        Second = second;
    }

    public int First { get; }

    public int Second { get; }
}

//SortRecord
internal record struct SortRecord(int First, int Second);

// Other use-cases
public class OtherUseCasesClass
{

    // ctor
    public OtherUseCasesClass(int x, int y)
        => (this.X, this.Y) = (x, y);

    public void Deconstruct(out int x, out int y)
        => (x, y) = (this.X, this.Y);

    public int X { get; }
    public int Y { get; }
}