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
        
    let give cards player =
        
        let updatedCards = (player |> hand) @ cards
        
        { player with Cards = updatedCards }
    
    let trade givenCards recipient trader =
        
        if not (givenCards |> Set.ofList
                           |> Set.isSuperset ( trader |> hand |> Set.ofList ) ) then
            
            invalidArg "givenCards" "player cannot give givenCards he doesn't have"
        
        ( { trader with Cards = trader.Cards |> List.except givenCards },
          { recipient with Cards = recipient.Cards |> List.append givenCards } )

    let deal cards player (deck : Deck) =
        
        if not (cards |> Set.ofList
                      |> Set.isSuperset ( deck |> Set.ofList ) ) then
            
            invalidArg "cards" "cannot deal cards deck doesn't contain"
        
        ( deck |> List.except cards,
          { player with Cards = player.Cards |> List.append cards } )
    
    let toggleRevolution state = { state with Revolution = not state.Revolution }