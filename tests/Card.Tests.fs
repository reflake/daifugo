module card_tests

    open Card
    open FsUnit
    open NUnit.Framework
    open Tests_Utils
    
    type wildCardTestCase = {
        Card : Card
        Expected : bool
    }
    
    let wildCardCases = [|
        { Card = Joker; Expected = true }
        { Card = a Two Of Clubs; Expected = false }
        { Card = an Eight Of Diamonds; Expected = false }
    |]
    
    [<TestCaseSource("wildCardCases")>]
    let ``should check if card is wild`` ( case ) =
        
        case.Card |> isWildCard |> should equal case.Expected
        
    type sameRankTestCase = {
        CardA : Card
        CardB : Card
        Expected : bool
    } 
    
    let sameRankCases = [|
        { CardA = a Queen Of Clubs; CardB = a Seven Of Clubs; Expected = false }
        { CardA = a Jack Of Diamonds; CardB = a Jack Of Spades; Expected = true }
        { CardA = Joker; CardB = Joker; Expected = true }
        { CardA = a Three Of Spades; CardB = a Three Of Diamonds; Expected = true }
        { CardA = a Six Of Clubs; CardB = a Seven Of Diamonds; Expected = false }
        { CardA = Joker; CardB = a Seven Of Diamonds; Expected = false }
    |]

    [<TestCaseSource("sameRankCases")>]
    let ``should condition if cards have same rank`` ( case ) =
        
        case.CardA |> sameRank case.CardB |> should equal case.Expected