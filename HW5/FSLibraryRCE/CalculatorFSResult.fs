namespace FSLibraryRCE

open System

type ResultBuilder(errorMessage: string) =
    member b.Zero() = Error errorMessage

    member b.Bind(x, f) =
        match x with
        | Ok x -> f x
        | Error _ -> x

    member b.Return x = Ok x
    member b.Combine(x, f) = f x


module CalculatorFS =
    let private defaultResult = ResultBuilder("unknown error")

    //let devByZero = "val2 was 0"
    
    let NotEnoughArgs = Exception("Not enough args")
    
    let WrongArgFormat = Exception("Wrong arg format")
     
    let WrongOperation = Exception("Wrong operation")
     
    let AttemptToDivideByZero = DivideByZeroException("Attempt to divide by zero")
    
    let OutOfRange = ArgumentOutOfRangeException("Argument out of range")

    type Operation =
        | Plus
        | Minus
        | Divide
        | Multiply

    let inline calculate
        (val1: Result<'T, string> when 'T: (static member (+) : 'T * 'T -> 'T) and 'T: (static member (-) :
                   'T * 'T -> 'T) and 'T: (static member (*) : 'T * 'T -> 'T) and 'T: (static member (/) : 'T * 'T -> 'T))
        (val2: Result<'T, string>)
        (operation: Result<Operation, string>)
        =
        match operation with
        | Ok operation ->
            ResultBuilder(AttemptToDivideByZero.Message) {
                let! val11 = val1
                let! val22 = val2
                match operation with
                | Plus -> return val11 + val22
                | Divide ->
                    if val22 <> new 'T() then
                        return val11 / val22
                | Minus -> return val11 - val22
                | Multiply -> return val11 * val22
            }
        | Error operationError -> Error operationError