module Game

    open System
    open Card
    open Table

    [<Flags>]
    type Effects = | None       = 0x0
                   | Revolution = 0x1
    
    type State = {
        CurrentPlayerIndex: int
        Table: Table
        AppliedEffects: Effects
        Deck: Deck
    }
    
    let newGameState = {
        CurrentPlayerIndex = 0
        Table = []
        AppliedEffects = Effects.None
        Deck = []
    }
    
    let toggleEffect effect state = { state with AppliedEffects = state.AppliedEffects ^^^ effect }
        
    let hasEffect effect state = state.AppliedEffects.HasFlag effect