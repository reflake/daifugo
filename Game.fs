module Game

    open Card
    
    type PlayerPlace = int option
    
    type Player = {
        Name: string
        Cards: Hand
        Points: int
        Place: PlayerPlace
    }
    
    type TableState = Card list option
    
    type State = {
        Players: Player list
        CurrentPlayerIndex: int
        Table: TableState
        Revolution: bool
        Deck: Deck
    }