using System.Diagnostics;
using System.Reflection;

using Xunit.Abstractions;
using Xunit.Sdk;

namespace Infrastructure.Test;

[CollectionDefinition("MyCollection")]
public class CalculatorCollectionFixture : ICollectionFixture<Calculator>
{
}

public class CalculatorFixture
{
    public CalculatorFixture()
        => Calculator = new Calculator();

    public Calculator Calculator { get; }
}

//[Collection("MyCollection")]
public class CalculatorTest
    : IClassFixture<CalculatorFixture>
{
    private readonly CalculatorFixture _fixture;

    private readonly ITestOutputHelper _output;

    public CalculatorTest(ITestOutputHelper output, CalculatorFixture fixture)
        => (_output, _fixture) = (output, fixture);

    public static IEnumerable<object[]> Data => new[] { new object[] { 5, 6, 11 }, new object[] { -1, 10, 9 }, new object[] { 0, 0, 0 } };

    [Fact]
    [Trait("Category", "Straight Forward")]
    public void Add_Basic()
    {
        // Arrange
        var calc = new Calculator();
        var x = 5;
        var y = 6;
        var expected = 11;

        // Act
        var actual = calc.Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [CalculatorData]
    public void Add_CustomAttribute_Expected(int x, int y, int expected)
    {
        // Arrange
        var calc = _fixture.Calculator;

        // Act
        var actual = calc.Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(5, 6)]
    [InlineData(-1, 10)]
    [InlineData(0, 0)]
    public void Add_InlineData(int x, int y)
    {
        // Arrange
        var calc = _fixture.Calculator;
        var expected = x + y;

        // Act
        var actual = calc.Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(5, 6, 11)]
    [InlineData(-1, 10, 9)]
    [InlineData(0, 0, 0)]
    public void Add_InlineData_Expected(int x, int y, int expected)
    {
        // Arrange
        var calc = _fixture.Calculator;

        // Act
        var actual = calc.Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void Add_MemberData_Expected(int x, int y, int expected)
    {
        // Arrange
        var calc = _fixture.Calculator;

        // Act
        var actual = calc.Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Trait("Category", "Exception Handling")]
    public void Div_DivisionByZero()
    {
        // Arrange
        var calc = new Calculator();
        var x = 5;
        var y = 0;
        //x var expected = 0;

        // Act & Assert
        var exception = Assert.Throws<DivideByZeroException>(() => calc.Div(x, y));
        _ = Assert.IsType<DivideByZeroException>(exception);
    }

    [Fact]
    public void FixtureTest()
    {
        // Arrange
        var calc = _fixture.Calculator;
        var x = 5;
        var y = 6;
        var expected = 11;

        // Act
        var actual = calc.Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Trait("Category", "Straight Forward")]
    public void Mul_Basic()
    {
        var stopwatch = Stopwatch.StartNew();
        // Arrange
        var calc = new Calculator();
        var x = 5;
        var y = 6;
        var expected = 30;

        // Act
        var actual = calc.Mul(x, y);

        // Assert
        Assert.Equal(expected, actual);

        _output.WriteLine($"This test took: {stopwatch.Elapsed}.");
    }

    [Fact(DisplayName = "This is to show how the failed tests are appeared.")]
    [Trait("Category", "Straight Forward")]
    public void Sub_Basic()
    {
        // Arrange
        var calc = new Calculator();
        var x = 11;
        var y = 5;
        var expected = 6;

        // Act
        var actual = calc.Sub(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Deactivated")]
    [Trait("Category", "Straight Forward")]
    public void Sub_Negative()
    {
        // Arrange
        var calc = new Calculator();
        var x = 11;
        var y = 5;
        var expected = 6;

        // Act
        var actual = calc.Sub(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}

public sealed class CalculatorDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod) 
        => new[] { new object[] { 5, 6, 11 }, new object[] { -1, 10, 9 }, new object[] { 0, 0, 0 } };
}