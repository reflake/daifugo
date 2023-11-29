﻿module Card

type Rank = | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
type Suit = | Hearts | Diamonds | Clubs | Spades
type Card = | RegularCard of Rank * Suit
            | Joker
            
            override x.ToString() =
                match x with
                | RegularCard(rank, suit) -> "a " + rank.ToString() + " of " + suit.ToString()
                | Joker -> "a Joker"

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
     
let sameRank a b =
    match a with
    | RegularCard(a, _) ->
        match b with
        | RegularCard(b, _) -> a = b
        | _ -> false
    | Joker -> a = b
    
let isWildCard c =
    match c with
    | RegularCard _ -> false
    | Joker -> true