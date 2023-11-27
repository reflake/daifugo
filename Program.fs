type Suit = | Hearts | Diamonds | Clubs | Spades
type Rank = | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
type Card = | RegularCard of Suit * Rank
            | Joker

[<EntryPoint>]
let main _ =
    
    let myCard   = RegularCard(Hearts, Two)
    let yourCard = Joker
    
    printfn "My card is %O" myCard
    printfn "Your card is %O" yourCard
    0 // return an integer exit code
