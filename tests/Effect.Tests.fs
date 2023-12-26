module ``Effect Tests``

    open Entities
    open Effect
    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``should toggle revolution ON`` () =
        
        Effects.None |> toggleEffect Effects.Revolution
                     |> hasEffect Effects.Revolution
                     |> should equal true
    
    [<Test>]
    let ``should toggle revolution OFF`` () =
        
        Effects.Revolution |> toggleEffect Effects.Revolution
                           |> hasEffect Effects.Revolution
                           |> should equal false