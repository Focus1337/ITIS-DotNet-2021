namespace WebApplication

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open WebApplication
open CalculatorHandler

module private StartupUtil = 
    let webApp =
        choose [
            GET >=> choose [
                route "/china" >=> text "ching chang chong"
                route "/calc" >=> CalculatorHttpHandler
                ]
            ]
        
open StartupUtil
type Startup() =
    member _.ConfigureServices(services: IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member _.Configure (app: IApplicationBuilder) (_: IHostEnvironment) (_: ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseStaticFiles().UseGiraffe(webApp)
