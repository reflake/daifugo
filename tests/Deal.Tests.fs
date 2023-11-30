module deal_tests

    open Card
    open Game
    open NUnit.Framework
    open Tests_Utils
    open FsUnit
    
    let dealOneCardCases = [|
        a King Of Hearts
        a Two Of Clubs
        Joker
        a Seven Of Diamonds
    |]
    
    [<TestCaseSource("dealOneCardCases")>]
    let ``should deal a card`` (card) =
        
        let player = {
            Name = ""
            Cards = []
            Points = 0
            Place = None
        }
        
        (deal card player).Cards |> should equivalent [ card ]
        
        

