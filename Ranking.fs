module Ranking

    type Title = | Tycoon
                 | Rich
                 | Commoner
                 | Poor
                 | Beggar
    
    let getTitle numberOfPlayers place =
        match place with
        | Some(number) -> match number with
                         | 0 -> Tycoon
                         | 1 when numberOfPlayers > 3 -> Rich
                         | 1 -> Commoner
                         | 2 when numberOfPlayers > 4 -> Commoner
                         | 2 when numberOfPlayers <= 4 -> Beggar