module shuffle_tests
    
    open Card
    open Tests_Utils
    open NUnit.Framework
    open FsUnit
    
    let createShuffleCase deck shuffleIndices =
        
        let deckSize = deck |> List.length
        
        assert (deckSize = (shuffleIndices |> List.length))
        assert (shuffleIndices |> areEquivalent [0 .. deckSize - 1])
        
        let shuffledDeck = deck |> rearrangeByIndices shuffleIndices    
        let random (i, _) = shuffleIndices |> List.item i
        
        (shuffledDeck, random)
        
    let testCases : (array<array<list<obj>>>) = [|
        [|
            [ a Two Of Hearts; an Eight Of Clubs; a Five Of Hearts ]
            [2; 1; 0]
        |]
        [|
            [ an Ace Of Diamonds; a Nine Of Diamonds ]
            [0; 1]
        |]
    |]
        
    [<TestCaseSource("testCases")>]
    let ``should shuffle deck`` (deck, shuffleOrder) =
        
        let deck = deck |> List.map unbox
        let shuffleOrder = shuffleOrder |> List.map unbox
        let (shuffledDeck, random) = createShuffleCase deck shuffleOrder
         
        deck |> shuffle random |> should equivalent shuffledDeck
