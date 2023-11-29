module Combination

    open Card
    
    let findSets hand =
        
        let wildCards = hand |> List.filter isWildCard
        let findCards elem = hand |> List.filter (sameRank elem)
        let sameRankCards elem = (findCards elem |> List.length) + (wildCards |> List.length) > 1
        
        hand |> List.filter sameRankCards