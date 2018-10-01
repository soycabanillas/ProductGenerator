// Learn more about F# at http://fsharp.org

open System



open Microsoft.OpenApi
open Microsoft.OpenApi.Readers
open System
open System.Net.Http

module Temporal =
    open System.Linq
    open System.Linq
    open System.Collections

    let printDiagnostics (errors : OpenApiDiagnostic) =
        errors.Errors |> Seq.iter (fun x -> printfn "%s: %s" x.Pointer x.Message)

    let printoperations (operations : System.Collections.Generic.IDictionary<Models.OperationType, Models.OpenApiOperation>) =
        operations |> Seq.iter (fun x -> printfn "%A" x.Key; printfn "%A" <| Enumerable.First(x.Value.Responses))
        ()
        
    let read =
        let httpClient = new HttpClient()
        //httpClient.BaseAddress <- new Uri("https://api-sandbox.marketpay.io/")
        httpClient.BaseAddress <- new Uri("http://localhost:8080/")
        let stream = httpClient.GetStreamAsync("/swagger/plugin/swagger.json").Result
        let openApiStreamReader = new OpenApiStreamReader(new OpenApiReaderSettings())
        let (nj, diagnostics) = openApiStreamReader.Read(stream)
        printDiagnostics diagnostics
        //ol.Errors |> Seq.iter (fun x -> printfn "%A" x; printfn "")
        //nj.Paths |> Seq.iter (fun x -> printfn "-- %A --"  x.Key; printoperations x.Value.Operations; printfn "")
        ()


 
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    Temporal.read
    0 // return an integer exit code