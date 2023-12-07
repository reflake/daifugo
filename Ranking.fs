module Ranking

    type Title = | Tycoon
                 | Rich
                 | Commoner
                 | Poor
                 | Beggar
    
    let getTitle numberOfPlayers =
        
        let threePlayers = numberOfPlayers = 3
        let preLastPlace = numberOfPlayers - 2
        let lastPlace = numberOfPlayers - 1
        
        function
        | Some place ->
            match place with
            | 0 -> Tycoon
            | 1 when not threePlayers -> Rich
            | place when not threePlayers && place = preLastPlace -> Poor
            | place when place = lastPlace -> Beggar
            | _ -> Commoner
        | None -> invalidArg "place" "place should be Some(int)"