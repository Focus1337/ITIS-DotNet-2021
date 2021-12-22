namespace GiraffeHW12

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open GiraffeHW12
open CalculatorHandler
open WebAppHW12.Models

module private StartupUtil =        
    let webApp =
        choose [
            GET >=> choose [
                route "/china" >=> text "ching chang chong"
                route "/calculate" >=> CalculatorHttpHandler(CachedCalculator(Calculator()), ExpressionsCache())
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
