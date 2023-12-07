module Trick

    open System
    open Card
    open Game
    
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