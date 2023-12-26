module State

    open Entities
    
    let newGameState = {
        CurrentPlayerIndex = 0
        Table = []
        AppliedEffects = Effects.None
        Deck = []
    }
    
    let toggleEffect effect state = { state with AppliedEffects = state.AppliedEffects ^^^ effect }
        
    let hasEffect effect state = state.AppliedEffects.HasFlag effect