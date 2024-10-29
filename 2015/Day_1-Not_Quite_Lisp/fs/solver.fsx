open System.IO

let filepath = "..\input.txt"
let lines = File.ReadAllText(filepath)

let mapBracets = 
    function
    | '(' -> 1
    | ')' -> -1
    | _ -> 0
    
let myModifiedList = [for i in lines do yield  mapBracets i ]

let res = 
    myModifiedList
    |> Seq.sum

printfn "result is %d" res

printfn "result is %d" res

//138