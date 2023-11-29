open System
open Card

[<EntryPoint>]
let main _ =
    
    let random = Random()
    let deck = defaultDeck
    let shuffledDeck = shuffle random.Next deck
    
    printfn "Standard deck contains %A" deck
    printfn "Deck after shuffle %A" shuffledDeck
    0 // return an integer exit code
