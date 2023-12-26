module Entities
    
    open System
    open Ranking

    // Cards
    type Rank = | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
    type Suit = | Hearts | Diamonds | Clubs | Spades
    type Card = | RegularCard of Rank * Suit
                | Joker
                
                override x.ToString() =
                    match x with
                    | RegularCard(rank, suit) -> "a " + rank.ToString() + " of " + suit.ToString()
                    | Joker -> "a Joker"
    type Hand = Card list
    type Deck = Card list
    
    // Player
    type Place = int option

    type Player<'id> = {
        Id: 'id
        Cards: Hand
        Points: int
        Place: Place
        Title: Title
    }

    type Players<'id> = Player<'id> list
    
    type Table = Card list list

    [<Flags>]
    type Effects = | None       = 0x0
                   | Revolution = 0x1
    
    type State = {
        CurrentPlayerIndex: int
        Table: Table
        AppliedEffects: Effects
        Deck: Deck
    }