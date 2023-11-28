module Combination

    open Card
    
    let findSets hand =
        
        let sameRank a b =
            match a with
            | RegularCard(a, _) ->
                match b with
                | RegularCard(b, _) -> a = b
                | _ -> false
            | Joker -> a = b
                
        let findCards elem = hand |> List.filter (sameRank elem)
        let moreThanOne elem = (findCards elem) |> List.length > 1
        
        hand |> List.filter moreThanOne