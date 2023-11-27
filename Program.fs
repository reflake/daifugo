type Suit = | Hearts | Diamonds | Clubs | Spades
type Rank = | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
type Card = | RegularCard of Suit * Rank
            | Joker

let cardValue card =
    
    match card with
    | RegularCard (_, rank) ->
        match rank with
        | Two -> 2
        | Three -> 3
        | Four -> 4
        | Five -> 5
        | Six -> 6
        | Seven -> 7
        | Eight -> 8
        | Nine -> 9
        | Ten -> 10
        | Jack -> 11
        | Queen -> 12
        | King -> 13
        | Ace -> 14
    | Joker -> 15

[<EntryPoint>]
let main _ =
    
    let myCard   = RegularCard(Hearts, Two)
    let yourCard = Joker
    
    printfn "My card is value %O" (myCard |> cardValue)
    printfn "Your card is value %O" (yourCard |> cardValue)
    0 // return an integer exit code
