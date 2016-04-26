open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq

type dbSchema = SqlDataConnection<"Data Source=localhost;Initial Catalog=kiosk;user=sa;password=flip2010">
let db = dbSchema.GetDataContext()
 
let querydb argv= 
    printfn "%A query" argv
    let query1 = 
        query {
            for row in db.FSI_PATRONS do
            where (row.USERNAME.Contains "9")
            select row
        }

    query1 |> Seq.iter (fun row -> printfn "%s %d" row.USERNAME row.ID) 
    0

let inserttodb argv= 
    printfn "%A insert" argv
    0

let deletedb argv = 
    printfn "%A delete" argv
    0
    
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let a = argv.[0]
    let b = 
        if a = "a" then querydb 
        elif a = "b" then deletedb 
        else inserttodb

    ignore (b a)

    0 // return an integer exit code
