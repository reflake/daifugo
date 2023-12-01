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
                         | 2 -> Beggar