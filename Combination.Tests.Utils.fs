module Combination_Tests_Utils

    open System
    open FSharp.Collections
    open Card
    
    type cardProducer = Rank -> Suit -> Card
    
    let Of cardRank cardSuit = RegularCard(cardRank, cardSuit)
    let a cardRank (fn : cardProducer) = fn cardRank
    let an = a
    let the cardRank (fn : cardProducer) tuple =
        tuple
        |> Seq.map (fn cardRank)
        |> Seq.toList