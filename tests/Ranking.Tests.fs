module ``Ranking Tests``

    open System
    open Ranking
    open Entities
    open FsUnit
    open NUnit.Framework
    
    type TestCase = {
        Place : Place
        NumberOfPlayers : int
        ExpectedTitle : Title
    }
    
    let testCases = [|
        { Place = Some(0); NumberOfPlayers = 4; ExpectedTitle = Tycoon }
        { Place = Some(1); NumberOfPlayers = 5; ExpectedTitle = Rich }
        { Place = Some(1); NumberOfPlayers = 3; ExpectedTitle = Commoner }
        { Place = Some(2); NumberOfPlayers = 3; ExpectedTitle = Beggar }
        { Place = Some(2); NumberOfPlayers = 5; ExpectedTitle = Commoner }
        { Place = Some(2); NumberOfPlayers = 4; ExpectedTitle = Poor }
        { Place = Some(4); NumberOfPlayers = 7; ExpectedTitle = Commoner }
        { Place = Some(16); NumberOfPlayers = 18; ExpectedTitle = Poor }
        { Place = Some(17); NumberOfPlayers = 18; ExpectedTitle = Beggar }
    |]
    
    [<TestCaseSource("testCases")>]
    let ``should return title for place`` (testCase) =
        
        getTitle testCase.NumberOfPlayers testCase.Place |> should equal testCase.ExpectedTitle
        
    [<Test>]
    let ``should throw when place is not taken`` () =
        
        (fun () -> getTitle 5 None |> ignore) |> should throw typeof<ArgumentException>