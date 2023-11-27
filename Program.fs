open Card

[<EntryPoint>]
let main _ =
    
    let myCard   = RegularCard(Two, Hearts)
    let yourCard = Joker
    
    printfn "My card is value %O" (myCard |> cardValue)
    printfn "Your card is value %O" (yourCard |> cardValue)
    0 // return an integer exit code
