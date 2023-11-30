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
        CurrentPlayerIndex: int
        Table: TableState
        Revolution: bool
        Deck: Deck
    }
    
    type Players = Player list
    
    let deal cards (player : Player) =
        
        let updatedCards = cards
        
        { player with Cards = updatedCards }
        
    let getHand (player : Player) = player.Cards