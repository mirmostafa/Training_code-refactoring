namespace Refactoring.FunctionalProgramming;

[TestClass]
public class PartialApplication
{
    [TestMethod]
    public void _01_Sample()
    {
        var name = "Mohammad";
        Console.WriteLine(string.Format("Hello. My name is {0}", name));

        var cw1 = (string format, string name) => Console.WriteLine(string.Format(format, name));
        cw1("Hello. My name is {0}", name);

        var cw2 = (string name) => cw1("Hello. My name is {0}", name);
        cw2(name);

        //! Partial application
        var getData = () => new List<string>(); // Let's suppose that data comes from database
        var names = getData();
        names.ForEach(cw2);

        // Instead of
        //x var data = getData();
        //x foreach (var item in data)
        //x {
        //x     cw1("Hello. My name is {0}", item);
        //x }
        // Use Partial Application
    }

    //! Just for review
    [TestMethod]
    public void _02_AnOtherSample()
    {
        // Define a function that takes two parameters
        var add = (int x, int y) => x + y;

        // Partially apply one parameter to create a new function
        var addOne = (int x) => add(1, x);

        // Call the new function with one parameter
        var result = addOne(2); // result is 3

        Assert.AreEqual(3, result);
    }

    ////! Requires EF.

    //[TestMethod]
    //public void _03_DependncyIndejct()
    //{
    //    var getById = (long id) => this.GetById<Person>(id);
    //    _ = this.UpdateEntity(getById, 10);
    //}

    //public TEntity? GetById<TEntity>(long id, DbContext db)
    //{
    //    var query = from entity in db.Set<TEntity>()
    //                where entity.Id == id
    //                select entity;
    //    return query.FirstOrDefault();
    //}

    //public TEntity? GetById<TEntity>(long id)
    //{
    //    var db = GetDataContextFromServiceCollection();
    //    return GetById<TEntity>(id, db);
    //}

    //private TEntity UpdateEntity<TEntity>(Func<long, TEntity> getById, long id)
    //    //where TEntity : IHasUpdateDate

    //{
    //    var entity = getById(id);
    //    entity.UpdateDate = DateTime.Now;
    //    return entity;
    //}
}