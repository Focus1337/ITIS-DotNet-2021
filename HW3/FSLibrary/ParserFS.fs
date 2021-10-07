namespace FSLibrary

    open System
    
    module ParserFs =
        let ParseCalculatorOperation arg =
            match arg with
            | "+" -> CalculatorFs.Operation.Plus
            | "-" -> CalculatorFs.Operation.Minus
            | "*" -> CalculatorFs.Operation.Multiply
            | "/" -> CalculatorFs.Operation.Divide
            | _ -> CalculatorFs.Operation.Unassigned
                    
        let TryParseArgsOrQuit (arg:string) (result:outref<int>) =
             if Int32.TryParse(arg, &result) then
              false
             else
               printf($"Value isn't int: {arg}")
               true
        
        let CheckArgsLengthOrQuit args =
         match Array.length args with
         | 3 -> false
         | _ -> printf($"The program requires 3 CLI arguments, but {args.Length} provided")
                true