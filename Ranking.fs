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
            | Some place ->
                match place with
                | 0 -> First
                | 1 when not threePlayers -> Second
                | place when not threePlayers && place = preLastPlace -> PreLast
                | place when place = lastPlace -> Last
                | _ -> Middle
        
        match place with
        | First -> Tycoon
        | Second -> Rich
        | Middle -> Commoner
        | PreLast -> Poor
        | Last -> Beggar