<br />

<p align="center">
    <img src="https://raw.githubusercontent.com/d-edge/cardidy/main/cardidy.png" alt="cardidy logo" height="140">
</p>

<p align="center">
    <a href="https://github.com/d-edge/Cardidy/actions" title="actions"><img src="https://github.com/d-edge/cardidy/actions/workflows/build.yml/badge.svg?branch=main" alt="actions build" /></a>
    <a href="https://www.nuget.org/packages/DEdge.Cardidy/" title="nuget"><img src="https://img.shields.io/nuget/vpre/DEdge.Cardidy" alt="version" /></a>
    <a href="https://www.nuget.org/stats/packages/DEdge.Cardidy?groupby=Version" title="stats"><img src="https://img.shields.io/nuget/dt/DEdge.Cardidy" alt="download" /></a>
    <a href="https://raw.githubusercontent.com/d-edge/cardidy/main/LICENSE" title="license"><img src="https://img.shields.io/github/license/d-edge/Cardidy" alt="license" /></a>
</p>

<br />

Cardidy is a .net library to identify credit card number and cvv. Maintained by folks at [D-EDGE](https://www.d-edge.com/).

## Features

* Easy to use
* Easy to extend
* Easy to maintain (Regex-free)
* Up-to-date with Wikipedia
* Check with the Luhn's algorithm
* Can check for Cvv
* Can guess anonymized credit card 
* Can guess truncated creditcard card
* Support for Visa credit card
* Support for Jcb credit card
* Support for Amex credit card
* Support for Discover credit card
* Support for MasterCard credit card
* Support for more...

## Getting Started as library

Install the [DEdge.Cardidy](https://www.nuget.org/packages/DEdge.Cardidy) NuGet package:

    PM> Install-Package DEdge.Cardidy

Alternatively you can also use the .NET CLI to add the packages:

    dotnet add package DEdge.Cardidy

Next create a .net application and use DEdge.Cardidy:

```csharp
var card = DEdge.Cardidy.Identify("4127540509730813").Single();
Console.WriteLine(card); // print Visa
```

or in F#:

```fsharp
open System

[<EntryPoint>]
let main _ =
    let isVisa = DEdge.Cardidy.Identify "4127540509730813" |> Seq.head = DEdge.CardType.Visa
    printfn "%b" isVisa
    0
```

## Getting Started working on Cardidy

- `git clone git@github.com:d-edge/Cardidy.git`
- `cd Cardidy`
- `dotnet test`

Let's go :smile:


## Note

The library mostly follows the Wikipedia's page: [Payment card number](https://en.wikipedia.org/wiki/Payment_card_number#Issuer_identification_number_(IIN)). On Cardidy, we made some modifications though:

- Diners Club International is known as Diners Club

## License

[MIT](https://raw.githubusercontent.com/d-edge/cardidy/main/LICENSE)
