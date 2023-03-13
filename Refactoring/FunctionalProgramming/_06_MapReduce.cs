namespace Refactoring.FunctionalProgramming;

[TestClass]
public class MapReduce
{
    [TestMethod]
    public void _01_MapTest()
    {
        // Create a list of integers
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };

        // Use Select() to apply a mapping function to each element
        var doubled = numbers.Select(x => x * 2).ToList();

        // Print the result
        Console.WriteLine(string.Join(", ", doubled));
        
    }

    [TestMethod]
    public void _02_ReduceTest()
    {
        // Create a list of integers
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };

        // Use Aggregate() to apply a reducing function to each pair of elements
        var sum = numbers.Aggregate(0, (acc, x) => acc + x);
        
        var mul = numbers.Aggregate(1, (acc, x) => acc * x);

    }

    [TestMethod]
    public void _03_FilterTest()
    {
        // Create a list of characters
        var myList = new List<char>() { 'A', 'B', 'C', 'A', 'D', 'E' };

        // Define a condition for filtering
        static bool condition(char x) => x == 'A';

        // Call the filter function with the list and the condition
        var filteredList = Filter(myList, condition);

        // Print the filtered list
        Console.WriteLine(string.Join(", ", filteredList));
    }



    // Define a generic filter function that takes a collection and a predicate as parameters
    private static List<T> Filter<T>(IEnumerable<T> collection, Func<T, bool> predicate)
    {
        // Create an empty list to store the filtered elements
        var result = new List<T>();

        // Loop through each element in the collection
        foreach (var element in collection)
        {
            // If the element satisfies the predicate, add it to the result list
            if (predicate(element))
            {
                result.Add(element);
            }
        }

        // Return the result list
        return result;
    }
}