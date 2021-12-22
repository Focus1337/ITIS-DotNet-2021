module GiraffeHW12.CalculatorHandler

open Giraffe.Core
open Giraffe
open WebAppHW12.Models

[<CLIMutable>]
type Values=
    {
        V1 : string
        V2 : string
        Op : string
    }

let CalculatorHttpHandler (calculator : ICachedCalculator, cache : ExpressionsCache) : HttpHandler =
    fun next ctx ->
        match ctx.GetQueryStringValue("expressionString") with
        | Ok str ->
            let res =
                CalculatorAdapter.calculate calculator cache str
            (setStatusCode 200 >=> json res) next ctx
        | Error e -> (setStatusCode 250 >=> json e) next ctx