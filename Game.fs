module Game

    open Ranking
    open Card

    type PlayerPlace = int option

    type Player<'identifier> = {
        Id: 'identifier
        Cards: Hand
        Points: int
        Place: PlayerPlace
        Title: Title
    }

    type Players<'identifier> = Player<'identifier> list

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
        
    let hand (player : Player<'a>) = player.Cards

    let deal cards player =
        
        let updatedCards = (player |> hand) @ cards
        
        { player with Cards = updatedCards }
        
    let give = deal
    
    let trade givenCards recipient trader =
        
        if not (givenCards |> Set.ofList
                           |> Set.isSuperset ( trader |> hand |> Set.ofList ) ) then
            
            invalidArg "givenCards" "player cannot give givenCards he doesn't have"
        
        ( { trader with Cards = trader.Cards |> List.except givenCards },
          { recipient with Cards = recipient.Cards |> List.append givenCards } )
    
    let toggleRevolution state = { state with Revolution = not state.Revolution }