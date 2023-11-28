module Combination

    open Card
    
    let findSets hand =
                
        let findCards elem = hand |> List.filter (sameRank elem)
        let moreThanOne elem = (findCards elem) |> List.length > 1
        
        hand |> List.filter moreThanOne