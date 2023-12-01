module ranking_tests

    open Ranking
    open Game
    open Tests_Utils
    open FsUnit
    open NUnit.Framework
    
    type TestCase = {
        Place : PlayerPlace
        NumberOfPlayers : int
        ExpectedTitle : Title
    }
    
    let testCases = [|
        { Place = Some(2); NumberOfPlayers = 3; ExpectedTitle = Beggar }
    |]
    
    [<TestCaseSource("testCases")>]
    let ``should return title when player takes place`` (testCase) =
        
        let player = { createPlayer with Place = testCase.Place }
    
        player |> nextTitle testCase.NumberOfPlayers |> should equal testCase.ExpectedTitle