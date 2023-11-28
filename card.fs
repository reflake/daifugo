module Card

type Rank = | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
type Suit = | Hearts | Diamonds | Clubs | Spades
type Card = | RegularCard of Rank * Suit
            | Joker
            
            override x.ToString() =
                match x with
                | RegularCard(rank, suit) -> "a " + rank.ToString() + " of " + suit.ToString()
                | Joker -> Joker.ToString()

let cardValue card =
    
    match card with
    | RegularCard (rank, _) ->
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