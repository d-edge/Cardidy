<br />

<p align="center">
    <img src="https://raw.githubusercontent.com/d-edge/cardidy/main/cardidy.png" alt="cardidy logo" height="140">
</p>

<p align="center">
    <a href="https://www.nuget.org/packages/Dedge.Cardidy/" title="nuget"><img src="https://img.shields.io/nuget/vpre/Dedge.Cardidy" alt="version" /></a>
    <a href="https://www.nuget.org/stats/packages/Dedge.Cardidy?groupby=Version" title="stats"><img src="https://img.shields.io/nuget/dt/Dedge.Cardidy" alt="download" /></a>
    <a href="https://raw.githubusercontent.com/d-edge/cardidy/main/LICENSE" title="license"><img src="https://img.shields.io/github/license/d-edge/Cardidy" alt="license" /></a>
</p>

<br />

Cardidy is a .net library to identify credit card number and cvv.

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

## Getting Started

Install the [Dedge.Cardidy](https://www.nuget.org/packages/Dedge.Cardidy) NuGet package:

    PM> Install-Package Dedge.Cardidy

Alternatively you can also use the .NET CLI to add the packages:

    dotnet add package Dedge.Cardidy

Next create a .net application and use Dedge.Cardidy:

```csharp
var card = Dedge.Cardidy.Identify("4127540509730813").Single();
Console.WriteLine(card); // print Visa
```

or in F#:

```fsharp
open System

[<EntryPoint>]
let main _ =
    let isVisa = Dedge.Cardidy.Identify "4127540509730813" |> List.head = Dedge.CardType.Visa
    printfn "%b" isVisa
    0
```

## License

[MIT](https://raw.githubusercontent.com/d-edge/cardidy/main/LICENSE)
