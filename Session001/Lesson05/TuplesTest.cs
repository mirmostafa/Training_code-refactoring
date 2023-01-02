global using T = Session001.Lesson05.Tuples;

namespace Session001.Lesson05;

[TestClass]
public class TuplesTest
{

    [TestMethod]
    public void SortInRecordTest()
    {
        var sorted = SortInRecord(11, 9);
        Assert.AreEqual(sorted.First, 9);
        Assert.AreEqual(sorted.Second, 11);
    }

    [TestMethod]
    public void SortInTupleTest()
    {
        var (first, second) = SortInTuple(11, 9);
        Assert.AreEqual(first, 11);
        Assert.AreEqual(second, 9);
    }

    [TestMethod]
    public void OtherUseCases()
    {
        var o = new OtherUseCasesClass(1, 2);

        (var x1, var y1) = o;

        var (x2, y2) = o;

        var (x3, _) = o;

        var r = GetNumbers();
        Assert.AreEqual(r.One, 1);
    }

    [TestMethod]
    public void GetNumbersTest()
    {
        var (one, two) = GetNumbers();
        Assert.AreEqual(one, 1);
        Assert.AreEqual(two, 2);
    }

    [TestMethod]
    public void ComplicatedTest()
    {
        var account = RegisterAccount(("Ali", "Rezai"), 5000, DateTime.Now, ("Home", "Street1"), ("Work", "Street2"), ("", ""));
    }

    [TestMethod]
    public void StringSortTest()
    {
        var sorted = Sort("C", "A", "B");
        Assert.AreEqual(sorted.str1, "A");
        Assert.AreEqual(sorted.str2, "B");
        Assert.AreEqual(sorted.str3, "C");
    }
}
