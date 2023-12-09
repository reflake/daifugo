module trick_tests

open System
open Card
open Table
open Trick
open Player
open FsUnit
open NUnit.Framework
open Tests_Utils

module ``Hit table`` =

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

module ``Same Rank`` =

    [<Test>]
    let ``two cards should be fives of same rank`` () =
        
        let cards = [ a Five Of Clubs; a Five Of Diamonds ]
        
        cards |> areSameRank |> should equal true
        
    [<Test>]
    let ``two cards should not be same rank`` () =
        
        let cards = [ a Nine Of Hearts; a Three Of Hearts ]
        
        cards |> areSameRank |> should equal false
        
    [<Test>]
    let ``three cards should not be same rank`` () =
        
        let cards = [ a Jack Of Hearts; a Queen Of Hearts; a Jack Of Spades ]
        
        cards |> areSameRank |> should equal false
    
    [<Test>]
    let ``single card should not be same rank`` () =
        
        let cards = [ an Ace Of Spades ]
        
        cards |> areSameRank |> should equal false
        
    [<Test>]
    let ``no cards should raise exception`` () =
        
        (fun () -> [] |> areSameRank |> ignore) |> should throw typeof<ArgumentException>
        
    [<Test>]
    let ``wild card should be counted as same rank`` () =
        
        let cards = [ Joker; an Eight Of Hearts ]
        
        cards |> areSameRank |> should equal true

module Straights =

    [<Test>]
    let ``three cards should be straight`` () =
        
        let cards = [ a Three Of Hearts; a Four Of Clubs; a Five Of Diamonds ]
        
        cards |> areStraight |> should equal true
        
    [<Test>]
    let ``three cards should not be straight`` () =
        
        let cards = [ a Jack Of Spades; a Nine Of Hearts; a Nine Of Spades ]
        
        cards |> areStraight |> should equal false
        
    [<Test>]
    let ``four cards should be straight`` () =
        
        let cards = [ a Ten Of Spades; a Jack Of Spades; a Queen Of Hearts; a King Of Hearts ]
        
        cards |> areStraight |> should equal true
        
    [<Test>]
    let ``wilds should be counted for straight`` () =
        
        let cards = [ a Five Of Diamonds; Joker; Joker; an Eight Of Clubs ]
        
        cards |> areStraight |> should equal true