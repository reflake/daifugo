module Game

    open Card
    open Player

    type Table = Card list list
    
    let placeOnTop cards = List.append [ cards ]
        
    let top = List.head

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