module score_tests

    open Game
    open Score
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``should add points to player`` () =
        
        let player = {
            Name = ""
            Cards = []
            Points = 0
            Place = None
        }
        
        player |> addPoints 20 |> should equal { player with Points = 20 }