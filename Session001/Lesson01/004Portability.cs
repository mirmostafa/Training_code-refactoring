namespace Session001.Lesson01;

internal static class Math
{
    public static int Add(int a, int b, ILogger? logger = null)
    {
        var result = a + b;
        logger?.Log($"Result is {result}");
        return result;
    }

    public static IEnumerable<int> FindEvens(IEnumerable<int> numbers, Action<string>? log = null)
    {
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                log?.Invoke($"Found {number}.");
                yield return number;
            }
        }
    }

    public static IEnumerable<int> FindOdds(IEnumerable<int> numbers, Action<string>? log = null)
    {
        var innerLog = log ?? new Action<string>(s => { });
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                innerLog($"Found {number}.");
                yield return number;
            }
        }
    }
}

public interface ILogger
{
    void Log(string message);
}