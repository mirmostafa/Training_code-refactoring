using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Test;
public class FileName
{

    // A test case with an integer collection and a predicate that checks for even numbers
    [Fact]
    public void Filter_WithIntegerCollectionAndEvenPredicate_ReturnsOnlyEvenNumbers()
    {
        // Arrange
        var collection = new List<int>() { 1, 2, 3, 4, 5 };
        var predicate = new Func<int, bool>(x => x % 2 == 0);

        // Act
        var result = Filter(collection, predicate);

        // Assert
        Assert.Equal(new List<int>() { 2, 4 }, result);
    }

    // A test case with a string collection and a predicate that checks for non-empty strings
    [Fact]
    public void Filter_WithStringCollectionAndNonEmptyPredicate_ReturnsOnlyNonEmptyStrings()
    {
        // Arrange
        var collection = new List<string>() { "", "a", "b", "", "c" };
        var predicate = new Func<string, bool>(x => !string.IsNullOrEmpty(x));

        // Act
        var result = Filter(collection, predicate);

        // Assert
        Assert.Equal(new List<string>() { "a", "b", "c" }, result);
    }

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
