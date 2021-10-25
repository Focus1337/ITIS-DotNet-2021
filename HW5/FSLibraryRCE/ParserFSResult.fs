namespace FSLibraryRCE

open System
open FSLibraryRCE.CalculatorFs

module ParserFs =
  //  let wrongOperation = "Wrong operation"

    let parseCalculatorOperation arg =
        ResultBuilder(WrongOperation) {
            if arg = "+" || arg = "-" || arg = "*" || arg = "/" then
                match arg with
                | "+" -> return Operation.Plus
                | "-" -> return Operation.Minus
                | "*" -> return Operation.Multiply
                | _ -> return Operation.Divide
        }

   // let numberErrorMessage = "value is not int"
   // let private resultNumber = ResultBuilder(numberErrorMessage)
    let private resultNumber = ResultBuilder(WrongArgFormat)

    //надо эти 4 метода собрать в 1, вызывать в них T.TryParse. хз как это делать
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