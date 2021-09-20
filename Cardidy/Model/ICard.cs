namespace Dedge.Model;

internal interface ICard
{
    internal CardType Name { get; }

    internal IEnumerable<int> Lengths { get; }

    internal IEnumerable<PaddedRange> Prefixes { get; }

    internal virtual bool Check(IEnumerable<int> digits) => true;
}
