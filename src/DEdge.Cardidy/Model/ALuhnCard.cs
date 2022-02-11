using System.Collections.Generic;
using System.Linq;

namespace DEdge.Model;

internal abstract record ALuhnCard : ACard
{
    internal ALuhnCard(CardType name, IEnumerable<PaddedRange> prefixes, IEnumerable<int> lengths) : base(name, prefixes, lengths) { }

    internal ALuhnCard(CardType name, IEnumerable<int> prefixes, IEnumerable<int> lengths) : this(name, prefixes.Select(x => new PaddedRange(x)), lengths) { }

    internal ALuhnCard(CardType name, int prefix, IEnumerable<int> lengths) : this(name, new[] { new PaddedRange(prefix) }, lengths) { }

    public override bool Check(IEnumerable<int> digits) => CheckLuhn(digits);

    /// <summary>Compact Luhn check</summary>
    /// <remarks>
    /// Inspired from <a href="https://stackoverflow.com/users/3395015/garryp">garryp</a>'s
    /// <a href="https://stackoverflow.com/a/40491537/1248177">answer</a> published under CC BY-SA 3.0
    /// on <a href="https://stackoverflow.com/q/21249670/1248177">implementing luhn algorithm using c#</a>.
    /// </remarks>
    /// <param name="digits">The card digits to check</param>
    /// <returns>true/false depending on valid checkdigit</returns>
    private static bool CheckLuhn(IEnumerable<int> digits) => digits
        .Reverse()
        .Select((thisNum, i) =>
            i % 2 == 0
            ? thisNum
            : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum))
        .Sum() % 10 == 0;
}
