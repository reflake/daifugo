﻿module Trick

    open Card
    
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