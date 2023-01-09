using Session001.Lesson04.ExceptionValidation.Results;

namespace Refactoring.Session06;

internal class NoSideEffect
{
    // No side-effect
    public Result<Guid> Login(string userName, string password)
        => userName == null || password == null
            ? Result<Guid>.CreateFail("Username and password cannot be empty.", status: -1)
            : Result<Guid>.CreateSuccess(Guid.NewGuid());

    // With side effect
    public Guid Bad_Login(string userName, string password) 
        => userName == null || password == null 
            ? throw new ArgumentNullException(nameof(userName)) 
            : Guid.NewGuid();
}