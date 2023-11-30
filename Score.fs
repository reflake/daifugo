module Score

    open System
    open Game
    
    let addPoints amount player = { player with Points = amount }