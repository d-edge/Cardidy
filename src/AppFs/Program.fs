[<EntryPoint>]
let main _ =
    let card = "4127540509730813"
    let isVisa = Dedge.Cardidy.Identify card |> Seq.head = Dedge.CardType.Visa
    printfn "Is %s a visa: %b" card isVisa
    0