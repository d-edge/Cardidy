using System.Collections.Generic;
using System.Linq;

namespace DEdge.Model;

internal abstract record ACard : ICard
{
    protected static readonly int[] Fifteen = { 15 };
    protected static readonly int[] Sixteen = { 16 };
    protected static readonly int[] Nineteen = { 19 };
    protected static readonly int[] From12To19 = { 12, 13, 14, 15, 16, 17, 18, 19 };
    protected static readonly int[] From14To19 = { 14, 15, 16, 17, 18, 19 };
    protected static readonly int[] From16To19 = { 16, 17, 18, 19 };

    internal ACard(CardType name, IEnumerable<PaddedRange> prefixes, IEnumerable<int>
        lengths)
    {
        Prefixes = prefixes;
        Lengths = lengths;
        Name = name;
    }

    internal ACard(CardType name, IEnumerable<int> prefixes, IEnumerable<int>
        lengths) : this(name, prefixes.Select(x => new PaddedRange(x)), lengths)
    {
    }

    internal ACard(CardType name, int prefix, IEnumerable<int>
lengths) : this(name, new[] { new PaddedRange(prefix) }, lengths)
    {
    }

    public CardType Name { get; }
    public IEnumerable<PaddedRange> Prefixes { get; }
    public IEnumerable<int> Lengths { get; }

    public virtual bool Check(IEnumerable<int> digits) => true;
}
