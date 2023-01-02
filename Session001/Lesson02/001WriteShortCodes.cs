using System.Reflection.Metadata.Ecma335;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Session001.Lesson02;

[TestClass]
public class Math
{
    #region Write Short Units of Code
    public static int Add_Violation(int a, int b)
    {
        var result = 0;
        result = a + b;
        return result;
    }

    public static int Add_Obey(int a, int b)
    {
        return a + b;
    }

    public static int Add_ObeyBetter(int a, int b)
        => a + b;
    #endregion

    #region Less Indention
    public static int Div_Violation(int a, int b)
    {
        if (a == b)
            return 1;
        else if (b == 0)
            throw new DivideByZeroException();
        // Invalid. Just for instance
        else if (a == 1)
            return 1;
        else if (b == 1)
            return a;
        return a / b;
    }

    public static int Div_Obey(int a, int b)
        => a == b
               ? 1
               : (a, b) switch
               {
                   (_, 0) => throw new DivideByZeroException(),
                   (1, _) => b,
                   (_, 1) => a,
                   _ => a / b
               };
    #endregion

    #region Inline Methods (Strategy Pattern)

    public static IEnumerable<int> FindEvens_Violation(IEnumerable<int> numbers, bool evensRequired)
    {
        foreach (var number in numbers)
        {
            if (evensRequired)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
            else
            {
                if (number % 2 == 1)
                {
                    yield return number;
                }
            }
        }
    }
    public IEnumerable<int> FindEvens_Obey1(IEnumerable<int> numbers, bool evensRequired)
    {
        foreach (var number in numbers)
        {
            if (analyse(number) is { } r)
            //x if(analyse(number) is not null r)
            {
                yield return r;
            }
        }

        int? analyse(int number)
        {
            if (evensRequired)
            {
                if (number % 2 == 0)
                {
                    return number;
                }
            }
            else
            {
                if (number % 2 == 1)
                {
                    return number;
                }
            }
            return null;
        }
    }

    public IEnumerable<int> FindEvens_Obey2(IEnumerable<int> numbers, bool evensRequired)
    {
        Func<int, bool> isOk = evensRequired ? (int n) => n % 2 == 0 : (int n) => n % 2 == 1;
        foreach (var number in numbers)
        {
            if (isOk(number))
            {
                yield return number;
            }
        }
    }

    [TestMethod]
    public void FindEvens_Obey2Test()
    {
        var numbers = Enumerable.Range(1, 4);
        var odds = FindEvens_Obey2(numbers, false).ToList();
        var evens = FindEvens_Obey2(numbers, true).ToList(); //! Best practice: Add `numbers.ToArray()`
    }
    #endregion
}