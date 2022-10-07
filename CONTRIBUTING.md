# Contributing to Cardidy

:+1::tada: First off, thanks for taking the time to contribute! :tada::+1:

The following is a set of guidelines for contributing to Cardidy, which are hosted in the [D-EDGE Organization](https://github.com/d-edge) on GitHub. These are mostly guidelines, not rules. Use your best judgment, and feel free to propose changes to this document in a pull request.

## Code of Conduct

This project and everyone participating in it is governed by the [D-EDGE Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to [softwarecraft@d-edge.com](mailto:softwarecraft@d-edge.com).

## Styleguides

### Git Commit Messages

Cardidy follows the [Conventional commits specification](https://www.conventionalcommits.org/en/v1.0.0/). You can rely on [commitizen](https://commitizen-tools.github.io/commitizen/) to help format your commit message.

### C# Styleguide

All C# code should follow the official [C# Style rules](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/).

## Contributing

Help and feedback is always welcome and pull requests get accepted. 

Here is the contribution flow ([more information on dataschool.io](https://www.dataschool.io/how-to-contribute-on-github/)):

* Open or answer an issue to discuss the changes
*  Fork the project after the change has been formally approved
* Create a [feature branch](https://www.martinfowler.com/bliki/FeatureBranch.html)
* Follow the code convention by examining existing code (mostly Microsoft's guidelines)
* Edit the code with the changes
* Add/modify unit tests as required
* Submit your PR against the main branch

PRs can only be approved and merged when all checks succeed (builds on Windows, MacOs and Linux)

## Add a new card

In a library like Cardidy, one of the main way to contribute is by adding a new credit card. Below is a step-by-step guide:

- Select a card. Lets say Xxx.
- Clone the project and checkout the `main` branch
- From `main` create a new branch named `feat/addXxx`
- Create a card for Xxx
  - Open `src/DEdge.Cardidy/Model/Cards.cs`
  - Add a new record for you card

```csharp
internal record Xxx : ALuhnCard
{
    public Xxx() : base(CardType.Xxx, prefixes, lengths) { }
}
```

* Use `ALuhnCard` for a card check with `Luhn or `ACard` otherwise.
* Create a new `CardType` entry for the new card
* Replace `prefixes` with an array of `PaddedRange`, an array of `int` or an `int`. 
* Replace `lengths` with either `Sixteen`, `From12To19`, `From16To19`, or an array of lengths

For example:

| Issuing network  | IIN ranges                                   | Active  | Length      | Validation     |
|:----------------:|:--------------------------------------------:|:-------:|:-----------:|:--------------:|
| Maestro UK       | 6759, 676770, 676774[11]                     | Yes     | 12–19       | Luhn algorithm |
| Verve            | 506099–506198, 650002–650027, 507865-507964  | Yes     | 16, 18, 19  | Luhn algorithm |

will be:

```csharp
internal record MaestroUk : ALuhnCard
{
    public MaestroUk() : base(CardType.MaestroUk, new[] { 6759, 676770, 676774 }, From12To19) { }
}

internal record Verve : ALuhnCard
{
    public Verve() : base(CardType.Verve, new[] { 
        new PaddedRange(506099, 506198), new PaddedRange(650002, 650027), new PaddedRange(507865, 507964) 
    }, new[] { 16, 18, 19 })
    { }
}
```

- Then, open `src/DEdge.Cardidy/Cardidy.cs`
- And add the new card to the array `knownCards`

- Test your code
  - Open `src/Tests/IdentifyTests.cs`
  - Add a unit test for your generator:

```csharp
[TestCase("676770-0000901089", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901089", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-000090", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-00009012", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-000090123", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901234", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-00009012345", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-000090123456", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901234567", ExpectedResult = CardType.MaestroUk)]
public CardType ShouldIdentifyAsMaestroUk(string cardNumber) => Cardidy.Identify(cardNumber, useCheck: false, ignoreNoise: true).First();

[TestCase("5060990000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("5061230000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("5061980000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500020000000001", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500100000000001", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500270000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500270000000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500020000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
[TestCase("6500100000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
[TestCase("6500270000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
[TestCase("65002700000000000", false, ExpectedResult = new[] { CardType.Discover })]
[TestCase("650027000000000000", false, ExpectedResult = new[] { CardType.Discover })]
[TestCase("6500270000000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
public IEnumerable<CardType> ShouldIdentifyAsVerve(string cardNumber, bool useCheck) => Cardidy.Identify(cardNumber, useCheck: useCheck).ToArray();
```

- Test your test with `dotnet test`
- Push you branch to [d-edge/Cardidy](https://github.com/d-edge/Cardidy) and open a Pull Request.

Thank you!

## Update a card

In a library like Cardidy, one of the main way to contribute is by updating a credit card. Below is a step-by-step guide:

- Select a card. Lets say Xxx.
- Clone the project and checkout the `main` branch
- From `main` create a new branch named `feat/updateXxx`
- Update a card for Xxx
  - Open `src/DEdge.Cardidy/Model/Cards.cs`
  - Find the existing record for you card

```csharp
internal record Xxx : ALuhnCard
{
    public Xxx() : base(CardType.Xxx, prefixes, lengths) { }
}
```

* Use `ALuhnCard` for a card check with `Luhn or `ACard` otherwise.
* Create a new `CardType` entry for the new card if there is a name change and remove the previous one
* Replace `prefixes` with an array of `PaddedRange`, an array of `int` or an `int`. 
* Replace `lengths` with either `Sixteen`, `From12To19`, `From16To19`, or an array of lengths

For example:

| Issuing network  |          IIN ranges           | Active  | Length  |   Validation   |
|:----------------:|:-----------------------------:|:-------:|:-------:|:--------------:|
| Maestro UK       | 6759, 676770, 676774          | Yes     | 12–19   | Luhn algorithm |
| Verve            | 506099–506198, 650002–650027  | Yes     | 16, 19  | Unknown        |

will be:

```csharp
internal record MaestroUk : ALuhnCard
{
    public MaestroUk() : base(CardType.MaestroUk, new[] { 6759, 676770, 676774 }, From12To19) { }
}

internal record Verve : ACard
{
    public Verve() : base(
      CardType.Verve,
      new[] { new PaddedRange(506099, 506198), new PaddedRange(650002, 650027) },
      new[] { 16, 19 }) { }
}
```

- Then, open `src/DEdge.Cardidy/Cardidy.cs`
- And rename if needed the card in the array `knownCards`

- Test your code
  - Open `src/Tests/IdentifyTests.cs`
  - Update the unit tests of card:

```csharp
[TestCase("676770-0000901089", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901089", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-000090", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-00009012", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-000090123", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901234", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-00009012345", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-000090123456", ExpectedResult = CardType.MaestroUk)]
[TestCase("676774-0000901234567", ExpectedResult = CardType.MaestroUk)]
public CardType ShouldIdentifyAsMaestroUk(string cardNumber) => Cardidy.Identify(cardNumber, useCheck: false, ignoreNoise: true).First();

[TestCase("5060990000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("5061230000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("5061980000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500020000000001", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500100000000001", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500270000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500270000000000000", true, ExpectedResult = new[] { CardType.Verve })]
[TestCase("6500020000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
[TestCase("6500100000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
[TestCase("6500270000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
[TestCase("65002700000000000", false, ExpectedResult = new[] { CardType.Discover })]
[TestCase("650027000000000000", false, ExpectedResult = new[] { CardType.Discover })]
[TestCase("6500270000000000000", false, ExpectedResult = new[] { CardType.Verve, CardType.Discover })]
public IEnumerable<CardType> ShouldIdentifyAsVerve(string cardNumber, bool useCheck) => Cardidy.Identify(cardNumber, useCheck: useCheck).ToArray();
```

- Test your test with `dotnet test`
- Push you branch to [d-edge/Cardidy](https://github.com/d-edge/Cardidy) and open a Pull Request.

Thank you!
