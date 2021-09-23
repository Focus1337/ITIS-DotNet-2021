.assembly ILLibrary
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  ILLibrary.ILParser
    extends System.Object
{
//METHOD TryParseOperatorOrQuit
  .method public hidebysig static bool
    TryParseOperatorOrQuit(
      string arg,
      [out] valuetype ILLibrary.ILCalculator/Operation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool LOCAL_PLUS_BOOL,
      [1] bool LOCAL_MINUS_BOOL,
      [2] bool LOCAL_MULT_BOOL,
      [3] bool LOCAL_DIV_BOOL,
      [4] bool LOCAL_FINAL_BOOL
    )

    // if (arg == "+")
    ldarg.0      // arg
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    stloc.0      // LOCAL_PLUS_BOOL
    ldloc.0      // LOCAL_PLUS_BOOL
    brfalse.s    MINUS_ARG

    // operation = Calculator.Operation.Plus
    ldarg.1      // operation
    ldc.i4.0
    stind.i1
    br.s         METHOD_BOOL_INSTACK

    // else if (arg == "-")
    MINUS_ARG: ldarg.0      // arg
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    stloc.1      // LOCAL_MINUS_BOOL
    ldloc.1      // LOCAL_MINUS_BOOL
    brfalse.s    MULT_ARG

    //  operation = Calculator.Operation.Minus
    ldarg.1      // operation
    ldc.i4.1
    stind.i1
    br.s         METHOD_BOOL_INSTACK

    // else if (arg == "*")
    MULT_ARG: ldarg.0      // arg
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    stloc.2      // LOCAL_MULT_BOOL
    ldloc.2      // LOCAL_MULT_BOOL
    brfalse.s    DIV_ARG

    //  operation = Calculator.Operation.Multiply
    ldarg.1      // operation
    ldc.i4.3
    stind.i1
    br.s         METHOD_BOOL_INSTACK

    // else if (arg == "/")
    DIV_ARG: ldarg.0      // arg
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    stloc.3      // LOCAL_DIV_BOOL
    ldloc.3      // LOCAL_DIV_BOOL
    brfalse.s    PLUS_ARG

    // operation = Calculator.Operation.Divide
    ldarg.1      // operation
    ldc.i4.2
    stind.i1
    br.s         METHOD_BOOL_INSTACK

    // случай else
    PLUS_ARG: nop
    ldarg.1      // operation
    ldc.i4.0
    stind.i1
    // return true
    ldc.i4.1
    stloc.s      LOCAL_FINAL_BOOL
    br.s         RETURN_METHOD_BOOL

    // конец метода и return
    METHOD_BOOL_INSTACK: ldc.i4.0
    stloc.s      LOCAL_FINAL_BOOL
    br.s         RETURN_METHOD_BOOL
    RETURN_METHOD_BOOL: ldloc.s      LOCAL_FINAL_BOOL
    ret
  }

    // METHOD TryParseArgsOrQuit
  .method public hidebysig static bool
    TryParseArgsOrQuit(
      string arg,
      [out] int32& result
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool LOCAL_BOOL_0,
      [1] bool LOCAL_BOOL_1
    )

    // if (int.TryParse(arg, out result))
    ldarg.0      // arg
    ldarg.1      // result
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    stloc.0      // LOCAL_BOOL_0
    ldloc.0      // LOCAL_BOOL_0
    brfalse.s    PRINT_STR // не будет выводить, т.к. false

    // return false if (int.TryParse(arg, out result))
    ldc.i4.0
    stloc.1      // LOCAL_BOOL_1
    br.s         RETURN_METHOD_BOOL     // по сути работает как break

    //  print "Value isn't int: {arg}"
    PRINT_STR: ldstr        "Value isn't int: "
    ldarg.0      // arg
    call         string [System.Runtime]System.String::Concat(string, string)
    call         void [System.Console]System.Console::WriteLine(string)
    nop

    // конец метода и return true
    ldc.i4.1
    stloc.1      // LOCAL_BOOL_1
    br.s         RETURN_METHOD_BOOL   // по сути работает как break
    RETURN_METHOD_BOOL: ldloc.1      // LOCAL_BOOL_1
    ret

  }

 // METHOD CheckArgsLengthOrQuit
  .method public hidebysig static bool
    CheckArgsLengthOrQuit(
      string[] args
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool LOCAL_BOOL_0,
      [1] bool LOCAL_BOOL_1
    )

    // if (args.Length == 3)
    ldarg.0      // args
    ldlen
    conv.i4
    ldc.i4.3
    ceq         // проверяем равенство
    stloc.0      // LOCAL_BOOL_0

    ldloc.0      // LOCAL_BOOL_0
    brfalse.s    PRINT_STR

    // return false if (args.Length == 3)
    ldc.i4.0
    stloc.1      // LOCAL_BOOL_1
    br.s         RETURN_METHOD_BOOL // по сути работает как break

    // print "The program requires 3 CLI arguments, but {args.Length} provided"
    PRINT_STR: ldstr        "The program requires 3 CLI arguments, but {0} provided"
    ldarg.0      // args
    ldlen
    conv.i4
    box          [System.Runtime]System.Int32
    call         string [System.Runtime]System.String::Format(string, object)
    call         void [System.Console]System.Console::WriteLine(string)
    nop

    // return true
    ldc.i4.1
    stloc.1      // LOCAL_BOOL_1
    br.s         RETURN_METHOD_BOOL // по сути работает как break

    // конец метода и ретурн
    RETURN_METHOD_BOOL: ldloc.1      // LOCAL_BOOL_1
    ret
  }
}
