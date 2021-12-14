using System.Collections.Generic;

namespace Dedge.Model;

internal interface ICard
{
    internal CardType Name { get; }

    internal IEnumerable<int> Lengths { get; }

    internal IEnumerable<PaddedRange> Prefixes { get; }

    internal bool Check(IEnumerable<int> digits);
}
