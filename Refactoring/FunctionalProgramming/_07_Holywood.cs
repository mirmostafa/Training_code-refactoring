using Refactoring.Results;

namespace Refactoring.FunctionalProgramming;

[TestClass]
public class Hollywood
{
    [TestMethod]
    public void UpdateDatabaseTest()
    {
        var result = this.UpdateDatabase(new object(), onError: ResponseFormatter<int>.OnErrorThrow);
        //if (result.IsFailure)
        //{
        //    //...
        //}
        Assert.AreEqual(5, result);
    }

    public Result<int> UpdateDatabase(object entity)
    {
        var result = !update(entity)
            ? Result<int>.CreateFail("Cannot update database", status: new NullReferenceException())
            : Result<int>.CreateSuccess(1);
        return result;

        static bool update(object entity) => true;
    }

    public Result<int> UpdateDatabase(object entity,
                               Func<Exception, Result<int>> onError,
                               Func<Result<int>> onSuccess)
    {
        var result = update(entity);
        return result.IsSucceed ? onSuccess() : onError(result.Exception!);

        static (bool IsSucceed, Exception? Exception) update(object entity) => (true, null);
    }

    public Result<int> UpdateDatabase(object entity,
                               Func<Exception, Result<int>>? onError = null,
                               Func<int, Result<int>>? onSuccess = null)
    {
        var ok = onSuccess ?? ResponseFormatter<int>.OnSuccess;
        var error = onError ?? ResponseFormatter<int>.OnError;
        var result = update(entity);
        return result.IsSucced ? ok(1) : error(result.Exception!);

        static (bool IsSucced, Exception? Exception) update(object entity) => (true, null);
    }
}

public static class ResponseFormatter<T>
{
    public static Result<T> OnError(Exception ex)
        => Result<T>.CreateFail(message: ex.Message, status: ex)!;

    public static Result<T> OnErrorThrow(Exception ex)
        => throw ex;

    public static Result<T> OnSuccess(T value)
        => Result<T>.CreateSuccess(value);
}
