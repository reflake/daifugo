module Combination_tests

    open Card
    open Combination
    open Xunit
    open FsUnit
    
    type cardProducer = Rank -> Suit -> Card
    
    let Of cardRank cardSuit = RegularCard(cardRank, cardSuit)
    let a cardRank (fn : cardProducer) = fn cardRank
    let an = a
    
    [<Fact>]
    let ``should find a pair combo`` () =
        
        let hand = [ a Four Of Hearts; an Eight Of Spades; a King Of Diamonds; a Four Of Diamonds; a Six Of Hearts ]
        let expected = [ a Four Of Hearts; a Four Of Diamonds ]
        
        findSets hand |> should equivalent expected
        
    [<Fact>]
    let ``should find a three of a kind combo`` () =
        
        let hand = [
            an Eight Of Spades; a Queen Of Clubs
            an Eight Of Hearts; a Two Of Clubs
            an Ace Of Diamonds; an Eight Of Clubs
        ]
        let expected = [ an Eight Of Spades; an Eight Of Hearts; an Eight Of Clubs ]
        
        findSets hand |> should equivalent expected