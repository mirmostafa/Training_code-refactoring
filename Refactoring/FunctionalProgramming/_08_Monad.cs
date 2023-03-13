using Refactoring.Results;

namespace Refactoring.FunctionalProgramming;

[TestClass]
public class MonadTest
{
    [TestMethod]
    public void _01_MonadMethod()
    {
        var monad = new Monad();
        monad.Method(new object());
        monad.MonadMethod(new object());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void _02_ErrorHandling()
    {
        var monad = new ErrorHandlingApproach();
        monad.BadMethod(new object());
        _ = monad.GoodMethod(new object());
        _ = monad.BetterMethod(new object());
    }
}

file static class ResultExtension
{
    public static Result<T> OnSucceed<T>(this Result<T> result, Func<T, Result<T>> actor)
        => !result! ? result : actor(result);

    public static Result<T> ThrowOnFail<T>(this Result<T> result)
        => result! ? result : throw (Exception)result.Status!;
}

file class ErrorHandlingApproach
{
    public void BadMethod(object arg)
    {
        if (!this.Validate(arg))
        {
            return;
        }

        if (!this.CreateUser(arg))
        {
            return;
        }

        if (!this.CreateProfile(arg))
        {
            return;
        }

        if (!this.CreateAccount(arg))
        {
            return;
        }
    }

    public Result<object?> BetterMethod(object arg)
       => this.Validate(arg)
            .OnSucceed(this.CreateUser)
            .OnSucceed(this.CreateProfile)
            .OnSucceed(this.CreateAccount)
            .ThrowOnFail();

    public Result<object?> CreateAccount(object? arg)
        => Result<object?>.CreateSuccess(arg);

    public Result<object?> CreateProfile(object? arg)
        => Result<object?>.CreateFail(status: new ArgumentNullException(nameof(arg)));

    public Result<object?> CreateUser(object? arg)
        => Result<object?>.CreateSuccess(arg);

    public Result<object?> GoodMethod(object arg)
        => this.Validate(arg)
            .OnSucceed(this.CreateUser)
            .OnSucceed(this.CreateProfile)
            .OnSucceed(this.CreateAccount);

    public Result<object?> Validate(object? arg)
        => Result<object?>.CreateSuccess(arg);
}

file class Monad
{
    public object? DoSomething(object o)
        => o;

    public Task<object?> DoSomethingAsync(object? o)
        => Task.FromResult(o);

    public object? DoSomethingEmpty(object o)
            => null;

    public void Method(object arg1)
    {
        if (arg1 != null)
        {
            var arg2 = this.DoSomething(arg1);
            if (arg2 != null)
            {
                var arg3 = this.DoSomething(arg2);
                if (arg3 != null)
                {
                    var arg4 = this.DoSomething(arg3);
                    if (arg4 != null)
                    {
                        var arg5 = this.DoSomething(arg3);
                        if (arg5 != null)
                        {
                            //...
                        }
                    }
                }
            }
        }
    }

    public void MonadMethod(object arg1)
    {
        var arg2 = Bind(arg1, this.DoSomething);
        var arg3 = Bind(arg2, this.DoSomething);
        var arg4 = Bind(arg3, this.DoSomethingEmpty);
        var arg5 = Bind(arg4, this.DoSomething);

        static object? Bind(object? arg, Func<object, object?> action)
            => arg != null ? action(arg) : arg;
    }

    public async Task MonadMethodAsync(object arg1)
    {
        var arg2 = await BindAsync(arg1, this.DoSomethingAsync);
        var arg3 = await BindAsync(arg2, this.DoSomethingAsync);
        var arg4 = await BindAsync(arg3, this.DoSomethingAsync);
        var arg5 = await BindAsync(arg4, this.DoSomethingAsync);

        static Task<object?> BindAsync(object? arg, Func<object, Task<object?>> action)
            => arg != null ? action(arg) : Task.FromResult(arg);
    }
}