#undef DO_LOGGING

using System.Diagnostics;

namespace Refactoring.Session09;

[TestClass]
public class AccountingTest
{
    [TestMethod]
    public void CreateTest()
    {
        Accounting acc = new();
        acc.Create(new(""));
    }
}

internal class Accounting
{
    private readonly ILogger _logger;

    public Accounting()
    {
#if LOG_IN_DB
        _logger = new DbLogger();
#endif
#if LOG_IN_FILE
        _logger = new FileLogger();
#endif
    }

    public void Create(Account account) =>
        // ...
        _logger.Log("Account created.");
}

public record Account(string Name);

internal class DbLogger : ILogger
{
    public void Log(string Name) 
        => Console.WriteLine("");
}

internal class FileLogger : ILogger
{
    public void Log(string Name)
        => Console.WriteLine("");
}