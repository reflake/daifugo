module Score

    open System
    open Game
    
    let addPoints amount player = { player with Points = player.Points + amount }
    
    let earnedPoints playerAmount forPlayer =
        match forPlayer.Place with
        | Some(place) -> playerAmount - place - 1
        | None -> raise (ArgumentException("player did not take any place"))