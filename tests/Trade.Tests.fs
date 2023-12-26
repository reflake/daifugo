module ``Trade Tests``

    open System
    open Entities
    open Player
    open Tests_Utils
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``player 1 should trade a card with player 2`` () =
        
        let player1 = createPlayer |> give [ an Ace Of Hearts ]
        let player2 = createPlayer
        let (player1AfterTrade, player2AfterTrade) = player1 |> trade [ an Ace Of Hearts ] player2
        
        player1AfterTrade |> hand |> should equivalent []
        player2AfterTrade |> hand |> should equivalent [ an Ace Of Hearts ]

    [<Test>]
    let ``player 1 should trade some cards with player 2`` () =
        
        let player1 = createPlayer |> give [ a Two Of Clubs; an Eight Of Diamonds; a Six Of Spades ]
        let player2 = createPlayer
        let (player1AfterTrade, player2AfterTrade) = player1 |> trade [ a Two Of Clubs; an Eight Of Diamonds ] player2
        
        player1AfterTrade |> hand |> should equivalent [ a Six Of Spades ]
        player2AfterTrade |> hand |> should equivalent [ a Two Of Clubs; an Eight Of Diamonds ]
        
    [<Test>]
    let ``player 2 should receive another card from player 1`` () =
        
        let player1 = createPlayer |> give [ a Nine Of Spades ]
        let player2 = createPlayer |> give [ a Three Of Spades ]
        let (_, player2AfterTrade) = player1 |> trade [ a Nine Of Spades ] player2
        
        player2AfterTrade |> hand |> should equivalent [ a Nine Of Spades; a Three Of Spades ]
    
    [<Test>]
    let ``raise an exception when player 1 trades cards he doesn't own`` () =
        
        let player1 = createPlayer |> give [ Joker ]
        let player2 = createPlayer
        
        (fun () -> player1 |> trade [ an Three Of Clubs ] player2 |> ignore) |> should throw typeof<ArgumentException>