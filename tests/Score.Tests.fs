module score_tests

    open Game
    open Score
    open NUnit.Framework
    open FsUnit
    open Tests_Utils

    [<Test>]
    let ``should add points to player`` () =
        
        let player = createPlayer
        
        player |> addPoints 20 |> should equal { player with Points = 20 }
        
    [<Test>]
    let ``should accumulate added player points`` () =
        
        let player = { createPlayer with Points = 37 }
        
        player |> addPoints 20 |> should equal { player with Points = 57 }