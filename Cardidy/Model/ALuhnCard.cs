namespace Dedge.Model;

internal abstract record ALuhnCard : ACard
{
    internal ALuhnCard(CardType name, IEnumerable<PaddedRange> prefixes, IEnumerable<int> lengths) : base(name, ValidationAlgorithm.Luhn, prefixes, lengths) { }

    internal ALuhnCard(CardType name, IEnumerable<int> prefixes, IEnumerable<int> lengths) : this(name, prefixes.Select(x => new PaddedRange(x)), lengths) { }

    internal ALuhnCard(CardType name, int prefix, IEnumerable<int> lengths) : this(name, new[] { new PaddedRange(prefix)}, lengths) { }
}
