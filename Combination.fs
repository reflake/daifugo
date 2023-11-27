module Combination

    open Card
    
    let findSets hand =
        
        if hand |> List.contains (RegularCard( Four, Diamonds )) then
            
            [
                RegularCard( Four, Diamonds );
                RegularCard( Four, Hearts )
            ]
        
        else
            
            [
                RegularCard( Eight, Spades );
                RegularCard( Eight, Hearts );
                RegularCard( Eight, Clubs );
            ]