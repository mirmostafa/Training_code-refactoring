using Refactoring.Results;

namespace Refactoring.FunctionalProgramming;

[TestClass]
public class UseOfRecordInInputAndOutput {

    [TestMethod]
    public void _00_Folding() {
        var nums = Enumerable.Range(1, 100);
        var sum = nums.Fold((int x, int y) => x + y, 0);
        Assert.AreEqual(5050, sum);
    }

    [TestMethod]
    public void _01_Folding() {
        var nums = Enumerable.Range(1, 100);
        var sum = nums.Fold(args => args.Result + args.Current, 0);
        Assert.AreEqual(5050, sum);
    }

    [TestMethod]
    public void _0201_Folding() {
        var nums = Enumerable.Range(1, 100);
        var div = nums.Fold(args => args.Current == 0
                            ? Result<int>.CreateFail("Division by zero")
                            : Result<int>.CreateSuccess(args.Result / args.Current), 1);
        Assert.AreEqual(0, div);
    }

    [TestMethod]
    public void _02_Folding() {
        var nums = Enumerable.Range(1, 100);
        var sum = nums.FoldByResult(args => Result<int>.CreateSuccess(args.Result + args.Current), 0);
        Assert.AreEqual(5050, sum);
    }

    [TestMethod]
    public void _03_Calc_Deconstruct() {
        var (sum, sub, mul, div) = Practices.Calc(5, 6);
        Assert.AreEqual(11, sum);
        Assert.AreEqual(-1, sub);
        Assert.AreEqual(30, mul);
        Assert.AreEqual(0, div);
    }

    [TestMethod]
    public void _03_Calc() {
        var calcResult = Practices.Calc(5, 6);
        Assert.AreEqual(11, calcResult.Sum);
        Assert.AreEqual(-1, calcResult.Sub);
        Assert.AreEqual(30, calcResult.Mul);
        Assert.AreEqual(0, calcResult.Div);
    }
}

internal static class Practices {

    public static (int Sum, int Sub, int Mul, int Div) Calc(in int x, in int y)
        => (x + y, x - y, x * y, x / y);

    public static T Fold<T>(this IEnumerable<T> items, Func<T, T, T> folder, T initialValue) {
        var result = initialValue;
        foreach (var item in items) {
            result = folder(result, item);
        }
        return result;
    }

    public static T Fold<T>(this IEnumerable<T> items, Func<SimpleFoldArgs<T>, T> folder, T initialValue) {
        var result = initialValue;
        foreach (var item in items) {
            result = folder(new(result, item));
        }
        return result;
    }

    public static Result<T> Fold<T>(this IEnumerable<T> items, Func<ResultFoldArgs<T>, Result<T>> folder, T initialValue) {
        var result = Result<T>.CreateSuccess(initialValue);
        foreach (var item in items) {
            result = folder(new(result, item));
        }
        return result;
    }

    public static Result<T> Fold<T>(this IEnumerable<T> items, Func<(Result<T> Result, T Current), Result<T>> folder, T initialValue,
        Action<Result<T>> onSucceed,
        Action<Result<T>> onFailed,
        Func<Result<T>, Exception, Result<T>> onExceptionOccurred) {
        var result = Result<T>.CreateSuccess(initialValue);
        foreach (var item in items) {
            try {
                result = folder((result, item));
            }
            catch (Exception ex) {
                result = onExceptionOccurred(result, ex);
                break;
            }
            if (result.IsFailure) {
                break;
            }
        }
        if (result.IsSucceed) {
            onSucceed(result);
        }
        else {
            onFailed(result);
        }

        return result;
    }

    public static Result<T> Fold<T>(this IEnumerable<T> items, FoldArgs<T> args, T initialValue) {
        //! توجه
        var (folder, onSucceed, onFailed, onExceptionOccurred) = args;
        var result = Result<T>.CreateSuccess(initialValue);
        foreach (var item in items) {
            try {
                result = folder((result, item));
            }
            catch (Exception ex) {
                result = onExceptionOccurred(result, ex);
                break;
            }
            if (result.IsFailure) {
                break;
            }
        }
        if (result.IsSucceed) {
            onSucceed(result);
        }
        else {
            onFailed(result);
        }

        return result;
    }

    public static Result<T> FoldByResult<T>(this IEnumerable<T> items, Func<(Result<T> Result, T Current), Result<T>> folder, T initialValue) {
        var result = Result<T>.CreateSuccess(initialValue);
        foreach (var item in items) {
            result = folder((result, item));
            if (result.IsFailure) {
                break;
            }
        }
        return result;
    }
}

public record SimpleFoldArgs<T>(T Result, T Current);
public record ResultFoldArgs<T>(Result<T> Result, T Current);

public record FoldArgs<T>(
    Func<(Result<T> Result, T Current), Result<T>> folder,
    Action<Result<T>> onSucceed,
    Action<Result<T>> onFailed,
    Func<Result<T>, Exception, Result<T>> onExceptionOccurred);