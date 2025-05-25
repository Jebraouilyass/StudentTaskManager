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
         builder.Services.AddCors(fun options ->
             options.AddPolicy("AllowGitHubPages", fun builder ->
                 builder
                     .WithOrigins("https://Jebraouilyass.github.io", "http://localhost:5000")
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                 |> ignore
             )
         ) |> ignore
         let app = builder.Build()
         app.UseCors("AllowGitHubPages") |> ignore
         app.UseGiraffe(webApp)
         app.Run()
         0