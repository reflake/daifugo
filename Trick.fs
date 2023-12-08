module Trick

    open System
    open Card
    open Player
    open Table
    
    type Value =
        | Wild
        | Concrete of int
    
    let cardValue card =
        
        match card with
        | Joker -> Wild
        | RegularCard (Two, _) -> Concrete 15
        | RegularCard (rank, _) ->
            match rank with
            | Ace -> Concrete 14
            | King -> Concrete 13
            | Queen -> Concrete 12
            | Jack -> Concrete 11
            | Ten -> Concrete 10
            | Nine -> Concrete 9
            | Eight -> Concrete 8
            | Seven -> Concrete 7
            | Six -> Concrete 6
            | Five -> Concrete 5
            | Four -> Concrete 4
            | Three -> Concrete 3
            
    let hit table cards player =
        match player |> hand |> swap cards [] with
        | Error "No cards" -> invalidArg "cards" "Player cannot hit with cards he doesn't own"
        | Ok ( playerCards, topCards ) -> ( player |> setHand playerCards, table |> placeOnTop topCards )
        | _ -> failwith "Unexpected exception"
    
    let areSameRank cards =

        let sameRank (a, b) =
            match (a, b) with
            | (Concrete a, Concrete b) -> a = b
            | (_, Wild) -> true
            | (Wild, _) -> true
                
        match cards with
        | [_] -> false
        | [] -> raise (ArgumentException "cards should not be empty")
        | cards -> cards
                   |> List.map cardValue
                   |> List.pairwise
                   |> List.forall sameRank
        
    let areStraight cards =
        
        let isSuccessor (a, b) =
            match (a, b) with
            | ( Concrete a, Concrete b ) -> a + 1 = b
        
        cards
        |> List.map cardValue
        |> List.sort
        |> List.pairwise
        |> List.forall isSuccessor