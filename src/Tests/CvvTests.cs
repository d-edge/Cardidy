using DEdge;
using NUnit.Framework;

namespace Tests;
public class CvvTests
{
    [TestCase(null, CardType.Unknown, ExpectedResult = false)]
    [TestCase(null, CardType.Visa, ExpectedResult = false)]
    [TestCase("123", CardType.Unknown, ExpectedResult = false)]
    [TestCase("", CardType.Visa, ExpectedResult = false)]
    [TestCase(" ", CardType.Visa, ExpectedResult = false)]
    [TestCase("a", CardType.Visa, ExpectedResult = false)]
    [TestCase("1", CardType.Visa, ExpectedResult = false)]
    [TestCase("12", CardType.Visa, ExpectedResult = false)]
    [TestCase("123", CardType.Visa, ExpectedResult = true)]
    [TestCase("000", CardType.Visa, ExpectedResult = true)]
    [TestCase("999", CardType.Visa, ExpectedResult = true)]
    [TestCase("0000", CardType.Visa, ExpectedResult = false)]
    [TestCase("9999", CardType.Visa, ExpectedResult = false)]
    [TestCase("9A9", CardType.Visa, ExpectedResult = false)]
    [TestCase("123", CardType.AmericanExpress, ExpectedResult = false)]
    [TestCase("0000", CardType.AmericanExpress, ExpectedResult = true)]
    [TestCase("9999", CardType.AmericanExpress, ExpectedResult = true)]
    [TestCase(" 999", CardType.AmericanExpress, ExpectedResult = false)]
    public bool ShouldValidateCvv(string cvv, CardType cardType) => Cardidy.IsCvvValid(cvv, cardType);

}