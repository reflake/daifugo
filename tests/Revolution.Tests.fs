module revolution_tests

    open Game
    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``should toggle revolution ON`` () =
        
        let gameState = newGameState
    
        gameState
        |> toggleEffect Effects.Revolution
        |> hasEffect Effects.Revolution
        |> should equal true
    
    [<Test>]
    let ``should toggle revolution OFF`` () =
        
        let gameState = { newGameState with AppliedEffects = Effects.Revolution }
        
        gameState
        |> toggleEffect Effects.Revolution
        |> hasEffect Effects.Revolution
        |> should equal false