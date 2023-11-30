module revolution_tests

    open Game
    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``should toggle revolution ON`` () =
        
        let gameState = newGameState
        let expectedGameState = { gameState with Revolution = true }
    
        gameState |> toggleRevolution |> should equal expectedGameState
    
    [<Test>]
    let ``should toggle revolution OFF`` () =
        
        let gameState = { newGameState with Revolution = true }
        let expectedGameState = { gameState with Revolution = false }
        
        gameState |> toggleRevolution |> should equal expectedGameState