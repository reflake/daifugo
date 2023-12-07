module deal_tests

    open Card
    open Player
    open NUnit.Framework
    open Tests_Utils
    open FsUnit
    open System
    
    [<Test>]
    let ``should deal a card`` () =
        
        let deck = [ a King Of Hearts ]
        let player = createPlayer
        
        let (_, player) = deck |> deal [ a King Of Hearts ] player
        
        player |> hand |> should equivalent [ a King Of Hearts ]
    
    [<Test>]
    let ``should deal two cards`` () =
        
        let deck = the Four Of [Clubs; Diamonds]
        let player = createPlayer
        
        let (_, player) = deck |> deal (the Four Of [Clubs; Diamonds]) player
        
        player |> hand |> should equivalent (the Four Of [Clubs; Diamonds])
    
    [<Test>]
    let ``should add two more cards to hand`` () =
        
        let deck = the Seven Of [Spades; Hearts]
        let player = createPlayer |> give [ a Five Of Diamonds; a Nine Of Clubs ]
                           
        let (_, player) = deck |> deal (the Seven Of [Spades; Hearts]) player

        player |> hand |> should equivalent (the Seven Of [Spades; Hearts] @ [ a Five Of Diamonds ; a Nine Of Clubs ])
        
    [<Test>]
    let ``raise an exception when not existent cards dealt`` () =
        
        let deck = [ Joker ]
        let player = createPlayer
        
        (fun () -> deck |> deal [ an Three Of Clubs ] player |> ignore) |> should throw typeof<ArgumentException>
    
    [<Test>]
    let ``deck should be empty after deal`` () =
        
        let deck = [ a Queen Of Spades ]
        let player = createPlayer
        
        let (deck, _) = deck |> deal [ a Queen Of Spades ] player
        
        deck |> should equivalent []
    
    [<Test>]
    let ``should left some cards in the deck after deal`` () =
        
        let deck = [ a Three Of Spades; an Eight Of Spades ]
        let player = createPlayer
        
        let (deck, _) = deck |> deal [ an Eight Of Spades ] player
        
        deck |> should equivalent [ a Three Of Spades ]