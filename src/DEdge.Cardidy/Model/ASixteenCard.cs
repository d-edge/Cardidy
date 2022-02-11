namespace DEdge.Model;

// OOP-afficionados, is this worthwile?
internal abstract record ASixteenCard : ACard
{
    private static readonly int[] Sixteen = { 16 };

    internal ASixteenCard(CardType name, IEnumerable<PaddedRange> prefixes) : base(name, prefixes, Sixteen) { }

    internal ASixteenCard(CardType name, IEnumerable<int> prefixes) : this(name, prefixes.Select(x => new PaddedRange(x))) { }

    internal ASixteenCard(CardType name, int prefix) : this(name, new[] { new PaddedRange(prefix) }) { }
}
