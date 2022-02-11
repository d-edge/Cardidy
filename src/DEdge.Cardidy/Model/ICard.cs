using System.Collections.Generic;

namespace DEdge.Model;

internal interface ICard
{
    internal CardType Name { get; }

    internal IEnumerable<int> Lengths { get; }

    internal IEnumerable<PaddedRange> Prefixes { get; }

    internal bool Check(IEnumerable<int> digits);
}
