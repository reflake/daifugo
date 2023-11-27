module Combination_tests

    open Card
    open Combination
    open Xunit
    open FsUnit
    
    type cardProducer = Rank -> Suit -> Card
    
    let Of cardRank cardSuit = RegularCard(cardRank, cardSuit)
    let a cardRank (fn : cardProducer) = fn cardRank
    
    [<Fact>]
    let ``should find a pair combo`` () =
        
        let hand = [ a Four Of Hearts; a Eight Of Spades; a King Of Diamonds; a Four Of Diamonds; a Six Of Hearts ]
        let actual = findSets hand
        let expected = [ a Four Of Hearts; a Four Of Diamonds ]
        
        actual |> should equivalent expected