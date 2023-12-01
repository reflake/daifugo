module Ranking

    type Title = | Tycoon
                 | Rich
                 | Commoner
                 | Poor
                 | Beggar
    
    let getTitle numberOfPlayers place =
        
        let (|First|Second|Middle|PreLast|Last|) =
               
               function
               | Some(0) -> First
               | Some(1) when numberOfPlayers > 3 -> Second
               | Some(place) when numberOfPlayers > 3 && place = numberOfPlayers - 2 -> PreLast
               | Some(place) when place = numberOfPlayers - 1 -> Last
               | _ -> Middle
        
        match place with
        | First -> Tycoon
        | Second -> Rich
        | Middle -> Commoner
        | PreLast -> Poor
        | Last -> Beggar