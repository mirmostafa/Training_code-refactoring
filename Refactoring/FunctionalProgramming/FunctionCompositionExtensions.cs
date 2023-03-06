using Refactoring.Results;

namespace Refactoring.FunctionalProgramming;

internal static class FunctionCompositionExtensions
{
    public static Func<TResult1> Compose<TResult1, TArg>(this Func<TResult1> create, Action<TResult1, TArg> action, TArg arg)
        => () =>
        {
            var result = create();
            action?.Invoke(result, arg);
            return result;
        };
    public static Func<TArg, TResult1> Compose<TResult1, TArg>(this Func<TArg, TResult1> create)
        => x =>
        {
            return create(x);
        };
    public static Func<TArg1, TArg2, TResult1> Compose<TResult1, TArg1, TArg2>(this Func<TArg1, TArg2, TResult1> create)
        => (TArg1 x, TArg2 y) =>
        {
            return create(x, y);
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