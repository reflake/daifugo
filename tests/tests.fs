module tests.tests

    open System
    open NUnit.Framework
    open FsUnit
    
    let add a b = a + b
    
    [<Test>]
    let ``hello world`` () =
        
        add 2 2 |> should equal 4
        
    [<Test>]
    let ``should raise exception`` () =
        
        (fun () -> failwith "Hello, world!" |> ignore) |> should (throwWithMessage "Hello, world!") typeof<Exception>