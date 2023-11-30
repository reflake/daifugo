module Game

    open System
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
    
    let newGameState = {
        CurrentPlayerIndex = 0
        Table = None
        Revolution = false
        Deck = []
    }

    type Players = Player list
        
    let hand (player : Player) = player.Cards

    let deal cards player =
        
        let updatedCards = (player |> hand) @ cards
        
        { player with Cards = updatedCards }
        
    let give = deal
    
    let toggleRevolution state = { state with Revolution = not state.Revolution }
    
    let trade givenCards recipient trader =
        
        if not (givenCards |> Set.ofList
                           |> Set.isSuperset ( trader |> hand |> Set.ofList ) ) then
            
            invalidArg "givenCards" "player cannot give givenCards he doesn't have"
        
        ( { trader with Cards = trader.Cards |> List.except givenCards },
          { recipient with Cards = recipient.Cards |> List.append givenCards } )