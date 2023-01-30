using System.Collections.ObjectModel;
using System.Drawing;

using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Refactoring.Session06;

[TestClass]
public class MethodArgumentsTest
{
    [TestMethod]
    public void ArgListCodingTime()
    {
        //x MethodArguments.Sum(new[] { 1, 2, 3, 4, 5, 6, 7, });
        MethodArguments.Sum();
        MethodArguments.Sum(1);
        MethodArguments.Sum(1, 2);
        MethodArguments.Sum(1, 2, 3); // Hard-coded
    }

    [TestMethod]
    public void ArgListRunTime()
    {
        var array = new[] { 1, 2, 3, 4, 5, 6, 7, };
        MethodArguments.Sum(array);

        var list = new List<int> { 1, 2, 3, };
        MethodArguments.Sum(list);

        var collection = new Collection<int> { 1, 2, 3,4 };

        MethodArguments.Sum(collection);
    }
}

internal class MethodArguments
{
    // Monad
    public static bool IsPrime(int x)
        => true;

    // Not Monad
    public static void Log(string message)
    {
        
    }

    // Not Monad
    public static int GetFirstPrimeNumber()
        => 1;

    // Monad
    public static int GetRandomNumber((int Min, int Max) ranage)
        => 10;

    // Flag
    public static int IncOrDec(int x, int y, bool inc)
        => inc ? x + y : x - y;

    // Dyadic
    public static int GetRandomNumber(int min, int max)
        => 10;

    // Triad
    public static void AssertEquals<T>(string message, T expected, T actual)
    {

    }

    // Triad
    public static Circle MakeCircle(double x, double y, double radius)
        => new();

    // Object Argument
    public static bool SavePerson(Person person)
        => true;

    // Object Argument
    public static Circle MakeCircle(Point center, double radius) 
        => new();

    // Argument List - Coding-Time
    public static int Sum(params int[] nums)
        => nums.Sum();

    // Argument List - Alternatve - Run-Time
    public static int Sum(IEnumerable<int> nums)
        => nums.Sum();
}