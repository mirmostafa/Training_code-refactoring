using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Session001.Lesson04.ExceptionValidation.Results;

namespace Session001.Lesson05;

[TestClass]
public class MethodTypesTest
{
    [TestMethod]
    public void MyTestMethod()
    {
        var numbers = Enumerable.Range(1, 3);
        var actual = MethodTypes.SumOrMul(numbers, false);
        Assert.AreEqual(6, actual);
    }
}

internal class MethodTypes
{
    // Method
    public void Method1()
    {
    }

    // Method
    public static void Method2()
    {

    }

    // Function
    public static int Add_Block(int x, int y)
    {
        return x + y;
    }

    // Expression-Bock Function
    public static int Add_Expression(int x, int y)
        => x + y;

    // Local Method
    // Principle: Avoid Indent
    public Result<object> RegisterAccount()
    {
        var user = registerUser();
        if (user.IsFailure)
        {
            return user.With(null!);
        }

        var account = createAccount(user);
        if (account.IsFailure)
        {
            return account;
        }

        account = activateAccount(account);
        return account;

        Result<object> registerUser()
        {
            var user = new object();
            //...
            return Result<object>.CreateSuccess(user);
        }
        Result<object> createAccount(object user)
        {
            var account = new object();
            return Result<object>.CreateSuccess(account);
        }
        Result<object> activateAccount(object account)
        {
            return Result<object>.CreateSuccess(account);
        }
    }

    // Straegy Pattern
    // Upper-Level Method
    public static int SumOrMul(IEnumerable<int> items, bool sum)
    {
        var result = sum ? 0 : 1;
        Func<int, int> oper = sum
            ? x => result + x
            : x => result * x;

        foreach (var item in items)
        {
            result = oper(item);
        }

        return result;
    }
}
