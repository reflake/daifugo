module tests.tests

    open NUnit.Framework
    open FsUnit
    
    let add a b = a + b
    
    [<Test>]
    let ``hello world`` () =
        
        add 2 2 |> should equal 4