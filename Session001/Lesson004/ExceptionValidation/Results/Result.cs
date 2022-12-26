using System.Diagnostics.CodeAnalysis;

namespace Session001.Lesson004.ExceptionValidation.Results;

public class Result : ResultBase
{
    private static readonly Dictionary<string, object> _staticFields = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="status">The status.</param>
    public Result(in object? status = null)
            : base(status) { }

    public Result(object? status, string? message) : base(status, message)
    {
    }

    public static Result Empty { get; } = GetStaticValue("Empty", NewEmpty);

    public static Result Fail => GetStaticValue("Fail", () => CreateFail());

    public static Result Success => GetStaticValue("Success", () => CreateSuccess());

    public static Result CreateFail(in string? message = null, in object? error = null)
        => new(error ?? -1, message) { IsSucceed = false };

    public static Result CreateSuccess(in string? message = null, in object? status = null)
        => new(status, message) { IsSucceed = true };

    public static explicit operator Result(bool b)
            => b ? Success : Fail;

    public static Result From([DisallowNull] in ResultBase other)
        => Copy(other, new Result());

    public static Result From([DisallowNull] in Result @this, in Result other)
        => Copy(@this, other);

    public static implicit operator bool(Result result)
        => result.IsSucceed;

    public static Result New()
        => new();

    public static Result NewEmpty()
        => New();

    public static Result operator +(Result left, Result right)
        => left.With(right);

    public Task<Result> ToAsync()
        => Task.FromResult(this);

    public Result With(in Result other)
        => From(this, other);

    private static T GetStaticValue<T>(string propName, Func<T> geDefaultValue)
    {
        if (!_staticFields.ContainsKey(propName))
        {
            _staticFields.Add(propName, geDefaultValue);
        }

        return (T)_staticFields[propName];
    }
}