module trick_tests

    open Card
    open Game
    open Trick
    open FsUnit
    open NUnit.Framework
    open Tests_Utils
    
    let createGameState =
        {
            CurrentPlayerIndex = 0
            Table = None
            Revolution = false
            Deck = []
        }
    
    [<Test>]
    let ``should hit empty table with a card`` () =
        
        let card = [ a Seven Of Clubs ]
        let gameState = { createGameState with Table = None }
        
        gameState |> hit card |> should equal { gameState with Table = Some( [ a Seven Of Clubs ] ) }