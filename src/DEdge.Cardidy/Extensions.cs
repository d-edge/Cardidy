using System;
using System.Collections.Generic;
using System.Linq;

namespace DEdge;

internal static class Extensions
{
    /// <summary>
    /// Measure the 'length' of an integer (e.g. 121 would be 3).
    /// </summary>
    /// <remarks>
    /// Inspired from <a href="https://stackoverflow.com/users/411022/ilmari-karonen">Ilmari Karonen</a>'s <a href="https://stackoverflow.com/a/6865024/1248177">answer</a> published under <a href="https://creativecommons.org/licenses/by-sa/4.0/">CC BY-SA 3.0</a> on <a href="https://stackoverflow.com/q/6864991/1248177">How to get the size of a number in .net?</a>.
    ///</remarks>
    /// <param name="number">The number to measure.</param>
    /// <returns>The length measured.</returns>
    private static int Measure(this int number) => (int)(Math.Log10(Math.Max(Math.Abs(number), 0.5)) + 1);

    internal static int PadRight(this int source, int totalWidth, int paddingValue)
    {
        var missingLength = totalWidth - source.Measure();
        var paddedNumber = source * (int)Math.Pow(10, missingLength);
        if (missingLength == 0)
        {
            return paddedNumber;
        }

        var top = Enumerable.Repeat(paddingValue, missingLength).ToNumber();
        return paddedNumber + top;
    }

    internal static int ToNumber(this IEnumerable<int> digits) => digits.Aggregate((digit, sum) => digit * 10 + sum);
}