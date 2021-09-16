namespace Dedge.Model;

// Based on https://en.wikipedia.org/wiki/Payment_card_number
internal record AmericanExpress : ACard
{
    public AmericanExpress() : base(CardType.AmericanExpress, new[] { 34, 37 }, new[] { 15 }) { }
}

internal record Uatp : ACard
{
    public Uatp() : base(CardType.Uatp, 1, new[] { 15 }) { }
}

internal record Mir : ACard
{
    public Mir() : base(CardType.Mir, new[] { new PaddedRange(2200, 2204) }, From16To19) { }
}

internal record VisaElectron : ASixteenCard
{
    public VisaElectron() : base(CardType.VisaElectron, new[] { 4026, 417500, 4508, 4844, 4913, 4917 }) { }
}

internal record Visa : ACard
{
    public Visa() : base(CardType.Visa, 4, new[] { 13, 16 }) { }
}

internal record UnionPay : ASixteenCard
{
    public UnionPay() : base(CardType.UnionPay, 31) { }
}

internal record Verve : ACard
{
    public Verve() : base(CardType.Verve, new[] { new PaddedRange(506099, 506198), new PaddedRange(650002, 650027) }, new[] { 16, 19 })
    { }
}

internal record Discover : ACard
{
    public Discover() : base(CardType.Discover, new[] {
        new PaddedRange(6011), new PaddedRange(622126, 622925), new PaddedRange(644, 649), new PaddedRange(65)
    }, From16To19)
    { }
}

internal record MaestroUk : ACard
{
    public MaestroUk() : base(CardType.MaestroUk, new[] { 6759, 676770, 676774 }, From12To19) { }
}

internal record Maestro : ACard
{
    public Maestro() : base(CardType.Maestro, new[] { 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763 }, From12To19) { }
}

internal record MasterCard : ASixteenCard
{
    public MasterCard() : base(CardType.MasterCard, new[] { new PaddedRange(51, 55), new PaddedRange(2221, 2720) }) { }
}

internal record Jcb : ACard
{
    public Jcb() : base(CardType.Jcb, new[] { new PaddedRange(3528, 3589) }, From16To19) { }
}
