#r "paket:
nuget Fake.Core.Target
nuget Fake.DotNet //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.DotNet
open Fake.Core
open System.Diagnostics

let processInstallPaket = new Process()
processInstallPaket.StartInfo.FileName <- "dotnet"
processInstallPaket.StartInfo.Arguments <- """ tool install paket --version "[5.179.403]" --tool-path ".paket" --add-source https://www.myget.org/F/paket-netcore-as-tool/api/v3/index.json"""
//processInstallPaket.StartInfo.CreateNoWindow <- true;
//processInstallPaket.StartInfo.UseShellExecute <- false;
processInstallPaket.Start()
printfn

// File system information
let solutionFile  = "ProductGenerator.sln"

Target.create "Restore" (fun _ ->
    solutionFile
    |> DotNet.restore id
)