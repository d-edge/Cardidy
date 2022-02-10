using DEdge;
using NUnit.Framework;
using System.Linq;

namespace Tests;
public class RandomizedTests
{
    private readonly Cardizer _cardizer = new Cardizer();

    [Test(ExpectedResult = CardType.AmericanExpress)]
    public CardType ShouldIdentifyRandomAmex() => Cardidy.Identify(_cardizer.NextAmex()).First();

    [Test(ExpectedResult = CardType.Discover)]
    public CardType ShouldIdentifyRandomDiscover() => Cardidy.Identify(_cardizer.NextDiscover()).First();

    [Test(ExpectedResult = CardType.Jcb)]
    public CardType ShouldIdentifyRandomJcb() => Cardidy.Identify(_cardizer.NextJcb()).First();

    [Test(ExpectedResult = CardType.MasterCard)]
    public CardType ShouldIdentifyRandomMasterCard() => Cardidy.Identify(_cardizer.NextMasterCard()).First();

    [Test(ExpectedResult = CardType.Mir)]
    public CardType ShouldIdentifyRandomMir() => Cardidy.Identify(_cardizer.NextMir()).First();

    [Test(ExpectedResult = CardType.Uatp)]
    public CardType ShouldIdentifyRandomUatp() => Cardidy.Identify(_cardizer.NextUatp()).First();

    [Test(ExpectedResult = CardType.Verve)]
    public CardType ShouldIdentifyRandomVerve() => Cardidy.Identify(_cardizer.NextVerve()).First();

    [Test(ExpectedResult = CardType.Visa)]
    public CardType ShouldIdentifyRandomVisa() => Cardidy.Identify(_cardizer.NextVisa()).First();
}