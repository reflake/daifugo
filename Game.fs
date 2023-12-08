module Game

    open Card
    open Table

    type State = {
        CurrentPlayerIndex: int
        Table: Table
        Revolution: bool
        Deck: Deck
    }
    
    let newGameState = {
        CurrentPlayerIndex = 0
        Table = []
        Revolution = false
        Deck = []
    }
    
    let toggleRevolution state = { state with Revolution = not state.Revolution }