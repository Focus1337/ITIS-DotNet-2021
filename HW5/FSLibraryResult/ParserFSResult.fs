namespace FSLibraryResult

open System
open FSLibraryResult.CalculatorFs

module ParserFs =
    let parseCalculatorOperation arg =
        ResultBuilder(WrongOperation) {
            if arg = "+" || arg = "-" || arg = "*" || arg = "/" then
                match arg with
                | "+" -> return Operation.Plus
                | "-" -> return Operation.Minus
                | "*" -> return Operation.Multiply
                | _ -> return Operation.Divide
        }

    let private resultNumber = ResultBuilder(WrongArgFormat)

    let parseInt (str: string) =
        resultNumber {
            let success, result = Int32.TryParse str
            if success then return result
        }

    let parseDouble (str: string) =
        resultNumber {
            let success, result = Double.TryParse str
            if success then return result
        }

    let parseFloat (str: string) =
        resultNumber {
            let success, result = Single.TryParse str
            if success then return result
        }

    let parseDecimal (str: string) =
        resultNumber {
            let success, result = Decimal.TryParse str
            if success then return result
        }