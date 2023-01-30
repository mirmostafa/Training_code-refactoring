using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Session03;

#region Write Simple Units of Code
public static class Math
{
    public static int Add_Kiss_Va(int x, int y)
    {
        try
        {
            return x + y;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public static int Add_Kiss_Ob(int x, int y)
        => x + y;

    public static int Add_Yagni_Va(int x, int y, ILogger? logger, Action<Exception> onException)
        => x + y;

    public static int? Div_Yagni_Inc_Ob(int x, int y, Action<Exception>? exceptionLogger = null)
    {
        try
        {
            return x / y;
        }
        catch (Exception ex)
        {
            exceptionLogger?.Invoke(ex);
            return null;
        }
    }

    public static int Calc_Srp_Va(int x, int y, bool add, bool sub)
    {
        if (add)
            return x + y;
        if (sub)
            return x - y;
        return 0;
    }
}
#endregion