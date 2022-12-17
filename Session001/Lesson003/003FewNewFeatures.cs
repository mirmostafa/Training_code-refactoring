namespace Session001.Lesson003;

// ILSpy
internal record PersonRecord(string Name, int Age);

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Information
}

public interface ILogger
{
    // 💖
    static ILogger New() => new Logger();

    void Debug(object message) => Log(message, LogLevel.Debug);

    void Info(object message) => Log(message, LogLevel.Info);

    void Log(object message, LogLevel logLevel);
}

internal class Logger : ILogger
{
    public void Log(object message, LogLevel logLevel)
    { }
}

internal class RquiredPerson
{
    public int Age { get; set; }

    public required string FirstName { get; set; }
}

[TestClass]
public class Z_003Tests
{
    [TestMethod]
    public void InterfaceTest()
    {
        var logger = ILogger.New();
        logger.Info("Info");
    }

    [TestMethod]
    public void RquiredPersonTest()
    {
        //! Error
        //x var p = new RquiredPerson();

        _ = new RquiredPerson { FirstName = "Ali" };
    }
}