﻿namespace Refactoring.Results;

public sealed class TryMethodResult<TResult> : Result<TResult?>
{
    public TryMethodResult(bool isSucceed, TResult? result) : base(result)
        => IsSucceed = isSucceed;

    public static explicit operator bool(TryMethodResult<TResult?> result) => result.IsSucceed;

    public static explicit operator TResult?(TryMethodResult<TResult> result) => result.Value;
}