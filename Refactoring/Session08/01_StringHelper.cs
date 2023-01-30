namespace Refactoring.Session08;

public static class StringHelper
{
    public static bool IsNullOrEmpty(this string? s)
        => s is null or { Length: 0 };
    
    internal static bool IsAli(string? s)
        => s == "Ali";
}