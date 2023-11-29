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
        
    [<Test>]
    let ``should shuffle deck`` () =
        
        let deck = [ a Two Of Hearts; an Eight Of Clubs; a Five Of Hearts ]
        let shuffleOrder = [2; 1; 0]
        let (shuffledDeck, random) = createShuffleCase deck shuffleOrder
         
        deck |> shuffle random |> should equivalent shuffledDeck
