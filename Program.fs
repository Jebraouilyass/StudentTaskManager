module Program

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open Handlers
open Db

[<EntryPoint>]
let main args =
    initDb() // Initialize the database
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddGiraffe() |> ignore
    let app = builder.Build()
    app.UseGiraffe(webApp)
    app.Run()
    0