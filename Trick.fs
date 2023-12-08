module Trick

    open System
    open Card
    open Player
    open Table
    
    let cardValue card =
        
        match card with
        | Joker -> 16
        | RegularCard (Two, _) -> 15
        | RegularCard (rank, _) ->
            match rank with
            | Ace -> 14
            | King -> 13
            | Queen -> 12
            | Jack -> 11
            | Ten -> 10
            | Nine -> 9
            | Eight -> 8
            | Seven -> 7
            | Six -> 6
            | Five -> 5
            | Four -> 4
            | Three -> 3
            
    let hit table cards player =
        match player |> hand |> swap cards [] with
        | Error "No cards" -> invalidArg "cards" "Player cannot hit with cards he doesn't own"
        | Ok ( playerCards, topCards ) -> ( player |> setHand playerCards, table |> placeOnTop topCards )
        | _ -> failwith "Unexpected exception"
    
    let areSameRank cards =

        let sameRank (a, b) = a = b
                
        match cards with
        | [_] -> false
        | [] -> raise (ArgumentException "cards should not be empty")
        | cards -> cards
                   |> List.map cardValue
                   |> List.pairwise
                   |> List.forall sameRank
        
    let areStraight cards =
        
        let isSuccessor (a, b) = a + 1 = b
        
        cards
        |> List.map cardValue
        |> List.sort
        |> List.pairwise
        |> List.forall isSuccessor