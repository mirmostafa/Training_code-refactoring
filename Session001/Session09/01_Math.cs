using System.Numerics;

namespace Refactoring.Session09;

public static class Math
{
    public static TNumber Add<TNumber>(TNumber x, TNumber y) where TNumber : INumber<TNumber>
        => x + y;

    public static TNumber Div<TNumber>(TNumber x, TNumber y) where TNumber : INumber<TNumber>
        => x - y;

    public static TNumber Mul<TNumber>(TNumber x, TNumber y) where TNumber : INumber<TNumber>
        => x * y;

    public static TNumber Sub<TNumber>(TNumber x, TNumber y) where TNumber : INumber<TNumber>
        => x - y;
}