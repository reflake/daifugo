module revolution_tests

    open Card
    open Game
    open Tests_Utils
    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``should toggle revolution ON`` () =
        
        let gameState = newGameState
        let expectedGameState = { newGameState with Revolution = true }
    
        gameState |> toggleRevolution |> should equal expectedGameState
    