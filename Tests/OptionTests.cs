using Dedge;
using NUnit.Framework;

namespace Tests;
public class OptionTests
{

    [TestCase("4", false, ExpectedResult = CardType.Visa)]
    [TestCase("510", false, ExpectedResult = CardType.MasterCard)]
    [TestCase("340", false, ExpectedResult = CardType.AmericanExpress)]
    [TestCase("4", true, ExpectedResult = CardType.Unknown)]
    [TestCase("510", true, ExpectedResult = CardType.Unknown)]
    [TestCase("340", true, ExpectedResult = CardType.Unknown)]
    public CardType ShouldIdentifyFragment(string cardNumber, bool validateLength) => Cardidy.Identify(cardNumber, validateLength);

    [TestCase("34-0000-0000-0000-0", true, ExpectedResult = CardType.AmericanExpress)]
    [TestCase("  341071000090 108", true, ExpectedResult = CardType.AmericanExpress)]
    [TestCase("3.-78967557334965", true, ExpectedResult = CardType.AmericanExpress)]
    [TestCase("34-0000-0000-0000-0", false, ExpectedResult = CardType.Unknown)]
    [TestCase("  341071000090 108", false, ExpectedResult = CardType.Unknown)]
    [TestCase("3.-78967557334965", false, ExpectedResult = CardType.Unknown)]
    public CardType ShouldIdentify(string cardNumber, bool ignoreNoise) => Cardidy.Identify(cardNumber, ignoreNoise: ignoreNoise);

    [TestCase("4169773####8##17", true, ExpectedResult = CardType.Visa)]
    [TestCase("4V15482254583145", true, ExpectedResult = CardType.Visa)]
    [TestCase("47CH1P0L4T4371UV", true, ExpectedResult = CardType.Visa)]
    [TestCase("4169773####8##17", false, ExpectedResult = CardType.Unknown)]
    [TestCase("4V15482254583145", false, ExpectedResult = CardType.Unknown)]
    [TestCase("47CH1P0L4T4371UV", false, ExpectedResult = CardType.Unknown)]
    public CardType ShouldIdentifyAnonymizedCard(string cardNumber, bool handleAnonymization) => Cardidy.Identify(cardNumber, handleAnonymization: handleAnonymization);
}