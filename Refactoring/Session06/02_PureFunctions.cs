using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Refactoring.Session06;

[DebuggerStepThrough]
public static class StringHelper
{
    [return: NotNull]
    [Pure]
    public static IEnumerable<string> Compact(this IEnumerable<string?>? strings)
       => (strings?.Where(item => !item.IsNullOrEmpty()).Select(s => s!)) ?? Enumerable.Empty<string>();

    [return: NotNull]
    [Pure]
    public static string[] Compact(params string[] strings)
        => strings.Where(item => !item.IsNullOrEmpty()).ToArray();

    //[Pure]
    //public static bool IsNullOrEmpty([NotNullWhen(false)] this string? str)
    //    => str == null || str.Length == 0;

    [Pure]
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? str)
        => str is not null and { Length: > 0 };

    // Dark Method
    private static bool TryGetValidSegmentLength(ReadOnlySpan<char> address, char delimiter, out int value)
    {
        value = -1;
        int segments = 1;
        int validSegmentLength = 0;
        for (int i = 0; i < address.Length; i++)
        {
            if (address[i] == delimiter)
            {
                if (validSegmentLength == 0)
                {
                    validSegmentLength = i;
                }
                else if ((i - (segments - 1)) % validSegmentLength != 0)
                {
                    // segments - 1 = num of delimeters. Return false if new segment isn't the validSegmentLength
                    return false;
                }

                segments++;
            }
        }

        if (segments * validSegmentLength != 12)
        {
            return false;
        }

        value = validSegmentLength;
        return true;
    }
}