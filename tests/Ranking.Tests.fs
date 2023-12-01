module ranking_tests

    open Ranking
    open Game
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
        { Place = Some(2); NumberOfPlayers = 5; ExpectedTitle = Commoner }
        { Place = Some(1); NumberOfPlayers = 5; ExpectedTitle = Rich }
    |]
    
    [<TestCaseSource("testCases")>]
    let ``should return title for place`` (testCase) =
        
        getTitle testCase.NumberOfPlayers testCase.Place |> should equal testCase.ExpectedTitle