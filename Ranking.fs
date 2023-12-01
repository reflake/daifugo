module Ranking

    open System

    type Title = | Tycoon
                 | Rich
                 | Commoner
                 | Poor
                 | Beggar
    
    let nextTitle a b = Beggar