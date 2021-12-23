module GiraffeHW12.CalculatorAdapter

open Microsoft.FSharp.Core
open WebAppHW12.Models


let calculate (calculator: ICachedCalculator) (cache : ExpressionsCache) str : decimal =
    let str = ExpressionFixer.Fix(str)
    let expression = calculator.FromString(str)
    calculator.CalculateWithCache(expression, cache)