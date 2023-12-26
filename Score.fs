module Score

    open Entities
    
    let addPoints amount player = { player with Points = player.Points + amount }
    
    let earnedPoints playerAmount player =
        match player.Place with
        | Some(place) -> playerAmount - place - 1
        | None -> invalidArg "player" "player did not take any place"