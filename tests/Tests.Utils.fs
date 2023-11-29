module Tests_Utils

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
        
    let areEquivalent a b =
        let A = a |> List.sort
        let B = b |> List.sort
        
        A = B
        
    let rearrangeByIndices indices list =
        list |> List.mapi (fun i _ -> list |> List.item (indices |> List.item i))