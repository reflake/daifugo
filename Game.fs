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
        
    let hand (player : Player<'a>) = player.Cards
    
    let setHand cards player= { player with Cards = cards }
        
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
        | Error "No cards" -> invalidArg "cards" "Trading player cannot give cards he doesn't have"
        | Ok (traderCards, recipientCards) -> ( trader |> setHand traderCards, recipient |> setHand recipientCards )
        | _ -> failwith "Unexpected exception"

    let deal cards player (deck : Deck) =
        
        match deck |> swap cards player.Cards with
        | Error "No cards" -> invalidArg "cards" "Cannot deal cards deck doesn't contain"
        | Ok (deckCards, playerCards) -> ( deckCards, player |> setHand playerCards )
        | _ -> failwith "Unexpected exception"
    
    let toggleRevolution state = { state with Revolution = not state.Revolution }