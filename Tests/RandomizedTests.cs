using Dedge;
using NUnit.Framework;

namespace Tests;
public class RandomizedTests
{
    [Test(ExpectedResult = CardType.AmericanExpress)]
    public CardType ShouldIdentifyRandomAmex() => Cardidy.Identify(Cardizer.NextAmex()).First();

    [Test(ExpectedResult = CardType.Discover)]
    public CardType ShouldIdentifyRandomDiscover() => Cardidy.Identify(Cardizer.NextDiscover()).First();

    [Test(ExpectedResult = CardType.Jcb)]
    public CardType ShouldIdentifyRandomJcb() => Cardidy.Identify(Cardizer.NextJcb()).First();

    [Test(ExpectedResult = CardType.MasterCard)]
    public CardType ShouldIdentifyRandomMasterCard() => Cardidy.Identify(Cardizer.NextMasterCard()).First();

    [Test(ExpectedResult = CardType.Mir)]
    public CardType ShouldIdentifyRandomMir() => Cardidy.Identify(Cardizer.NextMir()).First();

    [Test(ExpectedResult = CardType.Uatp)]
    public CardType ShouldIdentifyRandomUatp() => Cardidy.Identify(Cardizer.NextUatp()).First();

    [Test(ExpectedResult = CardType.Verve)]
    public CardType ShouldIdentifyRandomVerve() => Cardidy.Identify(Cardizer.NextVerve()).First();

    [Test(ExpectedResult = CardType.Visa)]
    public CardType ShouldIdentifyRandomVisa() => Cardidy.Identify(Cardizer.NextVisa()).First();
}