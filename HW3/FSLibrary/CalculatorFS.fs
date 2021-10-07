namespace FSLibrary

open System

module CalculatorFs =
    let NotEnoughArgs = Exception("Not enough args")
     
    let WrongArgFormat = Exception("Wrong arg format")
     
    let WrongOperation = Exception("Wrong operation")
     
    let AttemptToDivideByZero = DivideByZeroException("Attempt to divide by zero")
    
    let OutOfRange = ArgumentOutOfRangeException("Argument out of range")
        
    type Operation =
    | Unassigned
    | Plus
    | Minus
    | Multiply
    | Divide
    
    let Calculate val1 val2 operation =
        match operation with
        | Unassigned -> raise OutOfRange
        | Plus -> val1 + val2
        | Minus -> val1 - val2
        | Multiply -> val1 * val2
        | Divide -> match val2 with
                    | 0 -> raise AttemptToDivideByZero
                    | _ -> val1/val2