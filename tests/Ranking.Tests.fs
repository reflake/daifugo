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
        { Place = Some(0); NumberOfPlayers = 4; ExpectedTitle = Tycoon }
    |]
    
    [<TestCaseSource("testCases")>]
    let ``should return title for place`` (testCase) =
        
        getTitle testCase.NumberOfPlayers testCase.Place |> should equal testCase.ExpectedTitle