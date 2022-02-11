using DEdge;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests;

public class OptionTests
{
    [TestCase("4", false, ExpectedResult = new[] { CardType.Visa })]
    [TestCase("510", false, ExpectedResult = new[]{ CardType.MasterCard})]
    [TestCase("340", false, ExpectedResult = new[] { CardType.AmericanExpress })]
    [TestCase("4", true, ExpectedResult = new CardType[] { })]
    [TestCase("510", true, ExpectedResult = new CardType[] { })]
    [TestCase("340", true, ExpectedResult = new CardType[] { })]
    public IEnumerable<CardType> ShouldIdentifyFragment(string cardNumber, bool validateLength) => Cardidy.Identify(cardNumber, validateLength, false);

    [TestCase("34-0000-0000-0000-0", true, ExpectedResult = new CardType[] { CardType.AmericanExpress })]
    [TestCase("  341071000090 108", true, ExpectedResult = new CardType[] { CardType.AmericanExpress })]
    [TestCase("3.-78967557334965", true, ExpectedResult = new CardType[] { CardType.AmericanExpress })]
    [TestCase("34-0000-0000-0000-0", false, ExpectedResult = new CardType[] { })]
    [TestCase("  341071000090 108", false, ExpectedResult = new CardType[] { })]
    [TestCase("3.-78967557334965", false, ExpectedResult = new CardType[] { })]
    public IEnumerable<CardType> ShouldIdentify(string cardNumber, bool ignoreNoise) => Cardidy.Identify(cardNumber, useCheck: false, ignoreNoise: ignoreNoise);

    [TestCase("4169773####8##17", true, ExpectedResult = new[] { CardType.Visa })]
    [TestCase("4V15482254583145", true, ExpectedResult = new[] { CardType.Visa })]
    [TestCase("47CH1P0L4T4371UV", true, ExpectedResult = new[] { CardType.Visa })]
    [TestCase("4169773####8##17", false, ExpectedResult = new CardType[] { })]
    [TestCase("4V15482254583145", false, ExpectedResult = new CardType[] { })]
    [TestCase("47CH1P0L4T4371UV", false, ExpectedResult = new CardType[] { })]
    public IEnumerable<CardType> ShouldIdentifyAnonymizedCard(string cardNumber, bool handleAnonymization) => Cardidy.Identify(cardNumber, useCheck: false, handleAnonymization: handleAnonymization);
}