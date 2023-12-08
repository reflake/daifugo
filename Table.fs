module Table

    open Card
    
    type Table = Card list list
    
    let placeOnTop cards = List.append [ cards ]
        
    let top = List.head