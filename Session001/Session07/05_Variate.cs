using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Session07;

[TestClass]
public class VariateTest
{
    [TestMethod]
    public void OutTest()
    {
        int s;
        Add(5, 6, out s);

        Add(5, 6, out var result);

        int x = 5;
        Add(x, 6);
        //! result
    }

    static void Add(int x, int y, out int sum)
        => sum = x + y;

    static int Add(in int x, int y)
        => x + y;

    static void Sub(int x, int y)
    {
        x = 5;
        var result = x + y;
    }

    static void IsNull(in object?  obj)
    {
        //x obj = new object();
    }
}

interface IAdd1<T>
{
    T Add(T x);
}

interface IAdd2<out T>
{
    //x T Add(T x);
    T Add();
}

interface IAdd<in T>
{
    //x T Add(T x);
    int Add(T x);
}