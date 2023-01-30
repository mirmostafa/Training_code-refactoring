namespace Refactoring.Session01;

//! Use <Benchmark>

[TestClass]
public class Tests001
{
    [TestMethod]
    public void LazyLoading()
    {
        // Result
        var list = new List<int>();

        //! `for` test
        var numberList = getNumbers().ToList(); //! Error if not to use `.ToList()`.
        for (var index = 0; index < numberList.Count; index++)
        {
            if (numberList[index] % 2 == 0)
            {
                list.Add(numberList[index]);
            }
        }

        //! `foreach` test
        list.Clear();
        foreach (var number in getNumbers())
        {
            if (number % 2 == 0)
            {
                list.Add(number);
            }
        }


        //! Local method
        static IEnumerable<int> getNumbers()
        {
            foreach (var number in Enumerable.Range(1, 10))
            {
                yield return number;
            }
        }
    }
}