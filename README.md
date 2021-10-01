![Cardidy Logo ](https://raw.githubusercontent.com/d-edge/cardidy/main/cardidy.png)

# Cardidy

A .net library to identify credit card number and cvv.

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
static void Main(string[] args)
{
    var isVisa = Dedge.Cardidy.Indentify("4127540509730813").Single() == Dedge.CardType.Visa;
    Console.WriteLine(isVisa); // true
}
```

or in F#:

```fsharp
open System

[<EntryPoint>]
let main _ =
    let isVisa = Dedge.Cardidy.Indentify "4127540509730813" |> List.head = Dedge.CardType.Visa
    printfn "%b" isVisa
    0
```

## License

[MIT](https://raw.githubusercontent.com/d-edge/cardidy/main/LICENSE)
