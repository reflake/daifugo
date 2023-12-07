module Player

    open Card
    open Ranking
    
    type Place = int option

    type Player<'identifier> = {
        Id: 'identifier
        Cards: Hand
        Points: int
        Place: Place
        Title: Title
    }

    type Players<'identifier> = Player<'identifier> list
        
    let hand (player : Player<'a>) = player.Cards
    
    let setHand cards player= { player with Cards = cards }
        
    let give cards player =
        
        let updatedCards = (player |> hand) @ cards
        
        { player with Cards = updatedCards }

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