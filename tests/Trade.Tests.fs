module trade_tests

    open Card
    open Game
    open Tests_Utils
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``player 1 should trade a card with player 2`` () =
        
        let player1 = createPlayer |> give [ an Ace Of Hearts ]
        let player2 = createPlayer
        let (player1AfterTrade, player2AfterTrade) = player1 |> trade [ an Ace Of Hearts ] player2
        
        player1AfterTrade |> getHand |> should equivalent []
        player2AfterTrade |> getHand |> should equivalent [ an Ace Of Hearts ]
