using FluentAssertions;

namespace Refactoring.Session09;

[TestClass]
public class MathTest
{
    [TestMethod]
    public void _01_Add_BasicIntTest()
    {
        // Arrange
        var x = 5;
        var y = 6;

        // Act
        var actual = Math.Add(x, y);
        var expected = 12;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod]
    public void _02_Add_OverflowIntTest()
    {
        // Arrange
        var x = int.MaxValue;
        var y = 1;

        // Act
        var actual = Math.Add(x, y);
        var expected = (x + y) * -1;

        // Assert
        _ = actual.Should().Be(expected);
    }
}