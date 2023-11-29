module shuffle_tests
    
    open Card
    open Tests_Utils
    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``should shuffle deck`` () =
        
        let deck = [ a Two Of Hearts; an Eight Of Clubs; a Five Of Hearts ]
        let random: (int32 * int -> int) =
            let shuffleOrder = [2; 1; 0]
            
            fun (i, _) -> shuffleOrder.[i]
        let shuffledDeck = [ a Five Of Hearts; an Eight Of Clubs; a Two Of Hearts ]
         
        deck |> shuffle random |> should equivalent shuffledDeck
