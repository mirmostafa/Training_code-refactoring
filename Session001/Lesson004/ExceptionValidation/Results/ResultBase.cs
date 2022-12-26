using System.Diagnostics;
using System.Text;

namespace Session001.Lesson004.ExceptionValidation.Results;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract class ResultBase : IEquatable<ResultBase?>
{
    private bool? _isSucceed;

    protected ResultBase(object? status = null, string? message = null)
        => (Status, Message) = (status, message);

    public List<(object? Id, object Data)> Errors { get; } = new();

    public Dictionary<string, object> Extra { get; } = new();

    public bool IsFailure => !IsSucceed;

    public virtual bool IsSucceed
    {
        get => _isSucceed ?? (Status is null or 0 or 200 && !Errors.Any());
        init => _isSucceed = value;
    }

    public string? Message { get; }

    public object? Status
    {
        get;
        protected set;
    }

    public static bool operator !=(ResultBase? left, ResultBase? right)
        => !(left == right);

    public static bool operator ==(ResultBase? left, ResultBase? right)
        => EqualityComparer<ResultBase>.Default.Equals(left, right);

    public void Deconstruct(out bool isSucceed, out string? message)
        => (isSucceed, message) = (IsSucceed, Message);

    public override bool Equals(object? obj)
        => Equals(obj as ResultBase);

    public bool Equals(ResultBase? other)
        => other is not null && Status == other.Status;

    public override int GetHashCode()
        => HashCode.Combine(Status, Message, Errors);

    public override string ToString()
    {
        var result = (IsSucceed ? new StringBuilder($"IsSucceed: {IsSucceed}") : new StringBuilder()).AppendLine();
        if (!string.IsNullOrEmpty(Message))
        {
            _ = result.AppendLine(Message);
        }
        if (string.IsNullOrEmpty(Message) && Errors.Count == 1)
        {
            _ = result.AppendLine(Errors[0].Data?.ToString() ?? "An error occurred.");
        }
        else
        {
            foreach (var errorMessage in Errors.Select(x => x.Data?.ToString()))
            {
                _ = result.AppendLine($"- {errorMessage}");
            }
        }

        return result.ToString();
    }

    internal static TResult Copy<TResult>(in ResultBase source, in TResult dest)
        where TResult : ResultBase
    {
        dest.Status = source.Status;

        dest.Errors.AddRange(source.Errors);
        foreach (var item in source.Extra)
        {
            dest.Extra.Add(item.Key, item.Value);
        }
        return dest;
    }

    internal void SetIsSucceed(bool? isSucceed)
        => _isSucceed = isSucceed;

    private string GetDebuggerDisplay()
        => ToString();
}