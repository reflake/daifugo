module State

    open Entities
    
    let newGameState = {
        CurrentPlayerIndex = 0
        Table = []
        AppliedEffects = Effects.None
        Deck = []
    }