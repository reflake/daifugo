module deal_tests

    open Card
    open Game
    open NUnit.Framework
    open Tests_Utils
    open FsUnit
    open System
    
    let dealOneCardCases = [|
        a King Of Hearts
        a Two Of Clubs
        Joker
        a Seven Of Diamonds
    |]
    
    [<TestCaseSource("dealOneCardCases")>]
    let ``should deal a card`` (card) =
        
        let deck = [ card ]
        let player = createPlayer
        
        let (deck, player) = deck |> deal [ card ] player
        
        deck |> should equivalent []
        player |> hand |> should equivalent [ card ]
    
    [<Test>]
    let ``should deal two cards`` () =
        
        let cards = the Four Of [Clubs; Diamonds]
        let deck = cards
        let player = createPlayer
        
        let (deck, player) = deck |> deal cards player
        
        deck |> should equivalent []
        player |> hand |> should equivalent cards
    
    [<Test>]
    let ``should add two more cards to hand`` () =
        
        let cards = the Seven Of [Spades; Hearts]
        let deck = cards @ [ a Six Of Hearts ]
        let player = createPlayer |> give [ a Five Of Diamonds; a Nine Of Clubs ]
        let expectedHand = the Seven Of [Spades; Hearts] @
                           [ a Five Of Diamonds ; a Nine Of Clubs ]
                           
        let (deck, player) = deck |> deal cards player

        deck |> should equivalent [ a Six Of Hearts ]
        player |> hand |> should equivalent expectedHand
        
    [<Test>]
    let ``raise an exception when not existent cards dealt`` () =
        
        let deck = [ Joker ]
        let player = createPlayer
        
        (fun () -> deck |> deal [ an Three Of Clubs ] player |> ignore) |> should throw typeof<ArgumentException>