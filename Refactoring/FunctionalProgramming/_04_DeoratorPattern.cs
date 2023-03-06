using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Refactoring.FunctionalProgramming;

public static class DecoratorPatternSample
{
    public static T ConditionalLog<T>(T obj, Predicate<T> shouldLog)
    {
        if (shouldLog(obj))
        {
            // logger.Log(string.Format(format, obj);
        }
        return obj;
    }

    public static T Log<T>(this T obj, string? format = null)
    {
        _ = new object();
        // logger.Log(string.Format(format, obj);
        return obj;
    }

    public static bool IsEven(this int num)
    {
        return (num % 2 == 0);
    }

    public static T Process<T>(this T obj)
    {
        return obj;
    }
}

[TestClass]
public class DecoratorPatternTest
{
    //x Functional
    [TestMethod]
    public void _01_Simple()
    {
        var isEvenWithLog = (int x) => DecoratorPatternSample.Log(x).IsEven();
        
        var twoIsEven = isEvenWithLog(2);
        Assert.IsTrue(twoIsEven);

        var five = isEvenWithLog(5);
        Assert.IsFalse(five);
    }

    //! Decorator Pattern using function parameter
    [TestMethod]
    public void _02_FunctionParameter()
    {
        var logIfEven = (int x) => DecoratorPatternSample.ConditionalLog(x, DecoratorPatternSample.IsEven);
        var two = logIfEven(2);
        var five = logIfEven(5);
    }

    //! Decorator Pattern using function composition
    [TestMethod]
    public void _03_FunctionlComposition()
    {
        var log = (Person x) => DecoratorPatternSample.Log(x);
        var manipulate = (Person x) => DecoratorPatternSample.Process(x);
        var getData = () => new Person();
        var processWithLog = getData.Compose(log).Compose(manipulate).Compose(log);
        processWithLog();
    }

    //! Composition Pattern for muliple paamettered functions
    [TestMethod]
    public void _04_CompositionPatternForMuliplePaametteredFunctions()
    {
        var add2 = (int x, int y) => x + y;
        var add1 = (int x) => (int y) => add2(x, y);
        var plus = () => (int x) => (int y) => add2(x, y);
        var oper = plus();
        var plusFive = oper(5);
        var sum = plusFive(6);
        //var sum = plus()(5)(6);
        Assert.AreEqual(11, sum);

        var sum1 = plusFive(7);
        Assert.AreEqual(12, sum1);
    }
}

file record Person();
