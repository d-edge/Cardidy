namespace Dedge.Model;

internal interface ICard
{
    internal CardType Name { get; }

    internal ValidationAlgorithm Algorithm { get; }

    internal IEnumerable<int> Lengths { get; }

    internal IEnumerable<PaddedRange> Prefixes { get; }
}
