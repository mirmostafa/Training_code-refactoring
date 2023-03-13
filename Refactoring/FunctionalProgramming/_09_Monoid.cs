using Refactoring.Results;

namespace Refactoring.FunctionalProgramming;

[TestClass]
public class MonoidTest
{
    [TestMethod]
    public void _03_SimplifyAggregation()
    {
        var monad = new Monoid();
        monad.SimplifyAggregationBadMethod();

        _ = monad.SimplifyAggregationGoodMethod();
        _ = monad.SimplifyAggregationBetterMethod();
    }
}

file class Monoid
{
    public void SimplifyAggregationBadMethod()
    {
        var orderItems = new List<OrderItem>
        {
            new(10, 20),
            new(15, 30),
            new(5, 10)
        };

        var qty = 0;
        var total = 0;
        foreach (var item in orderItems)
        {
            qty += item.Qty;
            total += item.Total;
        }
        
        //(var a, var b) = (2, 3);
        //var c = a + b;
        //(string Name, int Age) person = ("Ali", 20);
        //(string name, int age) = person;
        //Console.WriteLine(name);
    }

    public (int Qty, int Total) SimplifyAggregationBetterMethod()
    {
        var orderItems = new List<OrderItem>
        {
            new(10, 20),
            new(15, 30),
            new(5, 10)
        };
        var result = orderItems.Aggregate<OrderItem, (int Qty, int Total)>(default, (x, o) => (x.Qty, x.Total) = (x.Qty + o.Qty, x.Total + o.Total));
        return Result<(int, int)>.CreateSuccess(result);
    }

    public (int Qty, int Total) SimplifyAggregationGoodMethod()
    {
        var orderItems = new List<OrderItem>
        {
            new(10, 20),
            new(15, 30),
            new(5, 10)
        };
        var result = orderItems.Aggregate<OrderItem, (int Qty, int Total)>(
            (0, 0),
            ((int Qty, int Total) x, OrderItem o) => (x.Qty, x.Total) = (x.Qty + o.Qty, x.Total + o.Total));
        return result;
    }
}

file record OrderItem(int Qty, int Total);