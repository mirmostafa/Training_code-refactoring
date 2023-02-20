using Microsoft.VisualStudio.TestTools.UnitTesting;

using Refactoring.Results;

namespace Refactoring.FunctionalProgramming;

[TestClass]
public class FunctionalProgramming
{
    [TestMethod]
    public void _00_Delegates()
    {
        var s = Add(5, 6);
        var sum = Add;
        var b = sum(11, 12);
        var sum1 = sum;
        AddDelegate add = Add;
        Action c = MyMethod;
        Action<object> d = MyMethod1;
        d(5);
        Func<string> e = MyMethod2;
        var r1 = e();
        Func<int, int, int> g = Add;
    }

    [TestMethod]
    public void _01_SimpleSamples()
    {
        var five = () => 5;
        var n1 = five();

        var addFive1 = (int x) => x + 5;
        var n2 = addFive1(five());

        var addFive2 = (Func<int> num) => num() + 5;
        var n3 = addFive2(five);

        var add_nums1 = (int x, int y) => x + y;
        var n4 = add_nums1(5, 6);

        // Higher Order
        var add_nums2 = (int x) => (int y) => x + y;
        var addFive3 = add_nums2(5);
        var n5 = addFive3(6);
        var addNine = add_nums2(9);
        var n7 = addNine(2);

        var transform_num = (int x, Func<int, int> transformer) => transformer(x);
        var n6 = transform_num(5, addNine);
    }

    [TestMethod]
    public void _02_FunctionAsParameter()
    {
        var numbers = Enumerable.Range(10, 100);
        var odds = new List<int>();

        foreach (var number in numbers)
        {
            if (number % 2 == 1)
            {
                odds.Add(number);
            }
        }

        //x Immutable
        odds = Where(numbers, n => n % 2 == 1).ToList();

        // Re-start
        Fold(numbers, n => n % 2 == 1, odds.Add);
    }

    [TestMethod]
    public void _03_TypeComposition()
    {
        var a = 5;
        var b = 6;
        var expected = 11;

        var actual = positiveAdd(a, b);
        Assert.AreEqual(expected, actual);

        static int positiveAdd(int x, int y)
        {
            var isXPositive = x >= 0;
            var isYPositive = y >= 0;
            var areArgumentsValid = isXPositive && isYPositive; // Types composed
            return areArgumentsValid ? x + y : -1;
        }
    }

    [TestMethod]
    public void _04_Composition_02_AddTest2()
    {
        var add = (int x) => (int y) => x + y;
        var result = add(3)(4);
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void _04_Composition_02_SimpleTest()
    {
        var five = () => 5;
        var addFive = (int x) => x + 5;
        var subFive = (int x) => x - 5;

        var starting = five;
        var adding = starting.Compose(addFive).Compose(addFive);
        var ended = adding.Compose(subFive);
        var result = ended();

        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void _04_Composition_03_AddTest_Simple()
    {
        var start = () => 5;
        var add = (int x) => x + 5;
        var sub = (int x) => x - 5;

        var starting = start;
        var adding = starting.Compose(add);
        var ended = adding.Compose(sub);
        var result = ended();

        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void _04_Composition_03_AddTest3()
    {
        var add3 = (int x) => (int y) => (int z) => x + y + z;
        var result = add3(3)(4)(5);
        Assert.AreEqual(12, result);
    }

    [TestMethod]
    public void _04_Composition_03_AddTest4()
    {
        var three = () => 3;
        var four = () => 4;
        var add = (Func<int> x) => (Func<int> y) => x() + y();
        var result = add(three)(four);

        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void _04_Composition_04_ResultTest()
    {
        var start = () => Result<int>.CreateSuccess(5);
        var step = (int x) => Result<int>.CreateSuccess(x + 1);
        var err = (int x) => Result<int>.CreateFail(value: x);
        var fail = (Result<int> x) => x;

        var actual = start.Compose(step, fail).Compose(step, fail).Compose(err, fail).Compose(step, fail).Compose(step, fail)();
        Assert.AreEqual(7, actual);
    }

    [TestMethod]
    public void _04_Composition_05_ComplexTest2()
    {
        var start = () => 5;
        var add = (int x) => x + 5;
        var sub = (int x) => x - 5;
        var log = (string x) => Console.WriteLine(x);
        var log1 = (string message) => log(message);
        var log2 = (int x, string message) => log(message);
        var log3 = ((int X, int Step) x) => log($"Step {x.Step} - {x.X}");

        var starting = start.Compose(log2, "Start");
        var adding1 = starting.Compose(add).Compose(log1, x => $"Step 1 - {x}");
        var adding2 = adding1.Compose(add).Compose(log2, x => $"Step 2 - {x}");
        var ended = adding2.Compose(sub).Compose(log3, x => (x, 3));
        var result = catchException(ended);
        
        Assert.IsTrue(result);
        Assert.AreEqual(10, result);

        static Result<T?> catchException<T>(Func<T> method)
        {
            try
            {
                return Result<T?>.CreateSuccess(method());
            }
            catch
            {
                return Result<T>.Fail;
            }
        }
    }

    [TestMethod]
    public void _04_Composition_06_Div()
    {
        var div = (int x, int y, Func<int> fail, Func<int, int> ok) => y != 0 ? ok(x / y) : fail();
        var ifFail = () => -100;
        var ifOk = (int x) => x;
        var act = (ifFail, ifOk);

        var res1 = div(5, 1, act.ifFail, act.ifOk);
        Assert.AreEqual(ifOk(res1), res1);

        var res2 = div(5, 0, act.ifFail, act.ifOk);
        Assert.AreEqual(ifFail(), res2);

    }

    [TestMethod]
    public void _05_BeHonest_01_Bad_Div()
    {
        static int div_bad(int x, int y) => y == 0 ? throw new ArgumentOutOfRangeException() : x / y;
        _ = div_bad(10, 0);
    }

    [TestMethod]
    public void _05_BeHonest_02_VERY_Bad_Div()
    {
        static int div_bad(int x, int y) => x / y;
        _ = div_bad(10, 0);
    }

    [TestMethod]
    public void _05_BeHonest_03_GOOD_Div()
    {
        static Result<int> div_good(int x, int y) => y == 0 ? Result<int>.Fail : Result<int>.CreateSuccess(x / y);

        var arg1 = 10;
        var arg2 = 0;
        var a = div_good(arg1, arg2);
        Assert.IsFalse(a);

        int c = div_good(10, 5);
        Assert.AreEqual(2, c);
    }

    [TestMethod]
    public void _06_ParameterizeEveryThing()
    {
        void log_bad(object obj)
        { }
        log_bad(5); // How will be logged?

        void log_good(object obj, string format = $"{nameof(_06_ParameterizeEveryThing)} : {{0}}")
        { }
        log_good(5);
        log_good(5, "This was five!!!"); // Localization

        void log_better(object obj, Func<string> format)
        { }
        var format = () => $"{nameof(_06_ParameterizeEveryThing)} : {{0}}";

        log_better(5, format);

        var hello = (string x) => Console.WriteLine($"Hello {x}");

        var names = new[] { "Ali", "Reza", "Sara" };
        ForEach(names, hello);
    }

    public int Add(int x, int y) => x + y;

    public void MyMethod()
    {
    }

    public void MyMethod1(object arg)
    {
    }

    public string MyMethod2() => string.Empty;

    private void Fold<T>(IEnumerable<T> numbers, Predicate<T> predicate, Action<T> folder)
    {
        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                folder(number);
            }
        }
    }

    private void ForEach<T>(IEnumerable<T> numbers, Action<T> folder)
    {
        foreach (var number in numbers)
        {
            folder(number);
        }
    }

    private IEnumerable<int> Where(IEnumerable<int> numbers, Predicate<int> predicate)
    {
        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                yield return number;
            }
        }
    }

    // Custom Delegate
    public delegate int AddDelegate(int x, int y);
}

internal static class FunctionCompositionExtensions
{
    public static Func<TResult1> Compose<TResult1, TArg>(this Func<TResult1> create, Action<TResult1, TArg> action, TArg arg)
        => () =>
        {
            var result = create();
            action?.Invoke(result, arg);
            return result;
        };

    public static Func<TResult1> Compose<TResult1, TArg>(this Func<TResult1> create, Action<TArg> action, Func<TResult1, TArg> getArg)
        => () =>
        {
            var result = create();
            action?.Invoke(getArg(result));
            return result;
        };

    public static Func<TResult1> Compose<TResult1, TArg>(this Func<TResult1> create, Action<TResult1, TArg> action, Func<TResult1, TArg> getArg)
        => () =>
        {
            var result = create();
            action?.Invoke(result, getArg(result));
            return result;
        };

    public static Func<TResult2> Compose<TResult1, TResult2>(this Func<TResult1> create, Func<TResult1, TResult2> func)
        => () => func(create());

    public static Func<Result<TResult2>> Compose<TResult1, TResult2>(this Func<Result<TResult1>> create, Func<TResult1, Result<TResult2>> func, Func<Result<TResult1>, Result<TResult2>>? onFail = null)
        => () =>
        {
            var result = create();
            return result.IsSucceed
                ? func(result.Value)
                : onFail?.Invoke(result) ?? Result<TResult2>.From(result, default!);
        };
}