module Combination_tests

    open Card
    open Combination_Tests_Utils
    open Combination
    open NUnit.Framework
    open FsUnit
    
    let pairCases =
        [|
            [| [ a Four Of Hearts; an Eight Of Spades; a Four Of Diamonds ];
                 
                 the Four Of [ Hearts; Diamonds] |]
            
            [| [ a Queen Of Spades; an Ace Of Spades; an Seven Of Clubs
                 an Eight Of Diamonds; a Queen Of Diamonds ];
                 
                 the Queen Of [Diamonds; Spades] |]
            
            [| the Ace Of [ Clubs; Spades]
               the Ace Of [ Clubs; Spades] |]
        |]
    
    [<TestCaseSource ("pairCases")>]
    let ``should find a pair combo`` (hand, expectedPair) =
        
        findSets hand |> should equivalent expectedPair
        
    let threeOfKindCases =
        [|
            [| [ an Eight Of Spades; a Queen Of Clubs
                 an Eight Of Hearts; a Two Of Clubs
                 an Ace Of Diamonds; an Eight Of Clubs];
                 
                 the Eight Of [ Hearts; Clubs; Spades ] |]
            
            [| [ a King Of Diamonds; a Three Of Hearts
                 a Three Of Spades; an Ace Of Clubs
                 a Three Of Clubs; a Jack Of Diamonds];
            
                 the Three Of [ Hearts; Clubs; Spades] |]
        |]
        
    [<TestCaseSource ("threeOfKindCases")>]
    let ``should find a three of a kind combo`` (hand, expectedThreeOfKind) =
        
        findSets hand |> should equivalent expectedThreeOfKind
        
    let fourOfKindCases =
        [|
            [| [ a Six Of Spades; a Six Of Diamonds; a Six Of Clubs
                 a Seven Of Diamonds; a Six Of Hearts ]
            
               the Six Of [ Hearts; Diamonds; Clubs; Spades] |]
            
            [| [ a Two Of Clubs; a Queen Of Diamonds; a Nine Of Hearts
                 a Two Of Diamonds; a Two Of Spades; a Five Of Hearts
                 a Two Of Hearts ]
            
               the Two Of [ Hearts; Diamonds; Clubs; Spades] |]
        |]
        
    [<TestCaseSource ("fourOfKindCases")>]
    let ``should find a four of a kind combo`` (hand, expectedFourOfKind) =
        
        findSets hand |> should equivalent expectedFourOfKind
        
    let noComboCases =
        [|
            [ a Three Of Diamonds ]
            [ a Six Of Hearts; a Two Of Spades; a Nine Of Diamonds ]
            [ a Queen Of Clubs; a Jack Of Clubs ]
        |]
    
    [<TestCaseSource ("noComboCases")>]
    let ``should find no combo`` (hand) =
        
        findSets hand |> should equalSeq list<Card>.Empty