namespace Infrastructure;

public class Calculator
{
    public int Add(int x, int y)
        => x + y;

    public int Div(int x, int y)
        => x / y;

    public object Mul(int x, int y)
        => x * y;

    public int Sub(int x, int y)
        => x - y; //? mistake
}