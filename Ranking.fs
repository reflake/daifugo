module Ranking

    type Title = | Tycoon
                 | Rich
                 | Commoner
                 | Poor
                 | Beggar
    
    let getTitle numberOfPlayers place =
        
        let (|First|Second|Middle|PreLast|Last|) =
               
               let threePlayers = numberOfPlayers = 3
               let preLastPlace = numberOfPlayers - 2
               let lastPlace = numberOfPlayers - 1
               
               function
               | Some(0) -> First
               | Some(1) when not threePlayers -> Second
               | Some(place) when not threePlayers && place = preLastPlace -> PreLast
               | Some(place) when place = lastPlace -> Last
               | _ -> Middle
        
        match place with
        | First -> Tycoon
        | Second -> Rich
        | Middle -> Commoner
        | PreLast -> Poor
        | Last -> Beggar