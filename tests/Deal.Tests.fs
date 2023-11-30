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
    
    let createPlayer = {
                            Name = ""
                            Cards = []
                            Points = 0
                            Place = None
                        }
    
    [<TestCaseSource("dealOneCardCases")>]
    let ``should deal a card`` (card) =
        
        let player = createPlayer
        
        deal [ card ] player |> getHand |> should equivalent [ card ]
    
    [<Test>]
    let ``should deal two cards`` () =
        
        let cards = the Four Of [Clubs; Diamonds]
        let player = createPlayer
        
        deal cards player |> getHand |> should equivalent cards
    
    [<Test>]
    let ``should add two more cards to hand`` () =
        
        let cards = the Seven Of [Spades; Hearts]
        let player = createPlayer |> give [ a Five Of Diamonds; a Nine Of Clubs ]
        let expectedHand = the Seven Of [Spades; Hearts] @
                           [ a Five Of Diamonds ; a Nine Of Clubs ]

        deal cards player |> getHand |> should equivalent expectedHand