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
        
    let swap cards destination source =
        
        // check if source list has cards that are going to be dealt
        if not (cards |> Set.ofList
                      |> Set.isSuperset ( source |> Set.ofList ) ) then
            
            Error "No cards"
        else
            Ok ( source |> List.except cards, destination |> List.append cards )
            
    
    let trade cards recipient trader =
        
        match trader.Cards |> swap cards recipient.Cards with
        | Error _ -> invalidArg "cards" "Trading player cannot give cards he doesn't have"
        | Ok (traderCards, recipientCards) -> 
                    ( { trader with Cards = traderCards },
                      { recipient with Cards = recipientCards } )

    let deal cards player (deck : Deck) =
        
        match deck |> swap cards player.Cards with
        | Error _ -> invalidArg "cards" "cannot deal cards deck doesn't contain"
        | Ok (deckCards, playerCards) ->
                    ( deckCards,
                      { player with Cards = playerCards } )
    
    let toggleRevolution state = { state with Revolution = not state.Revolution }