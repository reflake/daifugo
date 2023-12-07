module trick_tests

    open Card
    open Game
    open Trick
    open Player
    open FsUnit
    open NUnit.Framework
    open Tests_Utils
    
    [<Test>]
    let ``should hit empty table with a card`` () =
        
        let player = createPlayer |> give [ a Seven Of Clubs ]
        let table = []
        let ( player, table ) = player |> hit table [ a Seven Of Clubs ]
        
        player |> hand |> should equivalent []
        table |> top |> should equivalent [ a Seven Of Clubs ]
        
    [<Test>]
    let ``should hit empty table with some cards`` () =
    
        let player = createPlayer |> give (the Four Of [Clubs; Diamonds] @ [ an Ace Of Spades ])
        let table = []
        let (player, table) = player |> hit table (the Four Of [Clubs; Diamonds])
        
        player |> hand |> should equivalent [ an Ace Of Spades ]
        table |> top |> should equivalent (the Four Of [Clubs; Diamonds])
        
    [<Test>]
    let ``should stack cards on table`` () =
        
        let player = createPlayer |> give [ a Nine Of Spades; a Jack Of Hearts ]
        let table = [
            [ a Five Of Clubs; an Eight Of Clubs ]
            [ a Jack Of Diamonds ]
        ]
        let (_, table) = player |> hit table [ a Nine Of Spades;]
        
        table |> should equal [
            [ a Nine Of Spades ] // top cards
            [ a Five Of Clubs; an Eight Of Clubs ]
            [ a Jack Of Diamonds ]
        ]