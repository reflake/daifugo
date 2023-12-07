module score_tests

    open System
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
    
    type earnedPointsCase = {
        NumberOfPlayers : int
        Place: int option
        ExpectedEarnedPoints: int
    }
    
    let earnedPointsCases = [|
        { NumberOfPlayers = 4; Place = Some(0); ExpectedEarnedPoints = 3 }
        { NumberOfPlayers = 4; Place = Some(3); ExpectedEarnedPoints = 0 }
        { NumberOfPlayers = 3; Place = Some(1); ExpectedEarnedPoints = 1 }
    |]
    
    [<TestCaseSource("earnedPointsCases")>]
    let ``should calculate earned points when player takes place`` (testCase) =
        
        let player = { createPlayer with Place = testCase.Place }
        
        player |> earnedPoints testCase.NumberOfPlayers |> should equal testCase.ExpectedEarnedPoints
        
    [<Test>]
    let ``should raise exception when calculate player's earned points who didn't take place`` () =
        
        let player = { createPlayer with Place = None }
        let numberOfPlayers = 4
        
        (fun () -> player |> earnedPoints numberOfPlayers |> ignore) |> should throw typeof<ArgumentException>