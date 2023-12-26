module Trick

    open System
    open Card
    open Player
    open Table
    open Entities
    
    type Value =
        | Wild
        | Concrete of int
    
    let cardValue card =
        
        match card with
        | Joker -> Wild
        | RegularCard (rank, _) ->
            match rank with
            | Two -> Concrete 15
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
            | (_, Wild) -> true
            | (Wild, _) -> true
            | (a, b) -> a = b

        match cards with
        | [_] -> false
        | [] -> raise (ArgumentException "cards should not be empty")
        | cards -> cards
                   |> List.map cardValue
                   |> List.pairwise
                   |> List.forall sameRank
        
    let areStraight cards =
        
        let cardValues =
            cards
            |> List.map cardValue
            |> List.filter ((<>) Wild)
            |> List.map (function
                        | Concrete value -> value
                        | _ -> failwith "Unexpected exception")
            |> List.sort
        
        let rec checkSequence cardValues jokers =
            match cardValues with
            | [] | [_] -> true
            | a :: (b :: _ as tail) ->
                if b - a = 1 then
                    checkSequence tail jokers
                elif b - a - 1 <= jokers && jokers > 0 then
                    checkSequence tail (jokers - (b - a - 1))
                else
                    false
        
        let jokers = cards |> List.filter isWildCard |> List.length
            
        cards |> List.length > 2 && checkSequence cardValues jokers