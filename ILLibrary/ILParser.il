.assembly ILLibrary
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  ILLibrary.ILParser
    extends System.Object
{

  .method public hidebysig static bool
    TryParseOperatorOrQuit(
      string arg,
      [out] valuetype ILLibrary.ILCalculator/Operation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] string V_0,
      [1] string V_1,
      [2] bool V_2
    )

    // [7 9 - 7 10]
    IL_0000: nop

    // [8 13 - 8 25]
    IL_0001: ldarg.0      // arg
    IL_0002: stloc.1      // V_1

    IL_0003: ldloc.1      // V_1
    IL_0004: stloc.0      // V_0

    IL_0005: ldloc.0      // V_0
    IL_0006: ldstr        "+"
    IL_000b: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldloc.0      // V_0
    IL_0013: ldstr        "-"
    IL_0018: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_0040
    IL_001f: ldloc.0      // V_0
    IL_0020: ldstr        "*"
    IL_0025: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0045
    IL_002c: ldloc.0      // V_0
    IL_002d: ldstr        "/"
    IL_0032: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_004a
    IL_0039: br.s         IL_004f

    // [11 21 - 11 59]
    IL_003b: ldarg.1      // operation
    IL_003c: ldc.i4.0
    IL_003d: stind.i1

    // [12 21 - 12 27]
    IL_003e: br.s         IL_0056

    // [14 21 - 14 60]
    IL_0040: ldarg.1      // operation
    IL_0041: ldc.i4.1
    IL_0042: stind.i1

    // [15 21 - 15 27]
    IL_0043: br.s         IL_0056

    // [17 21 - 17 63]
    IL_0045: ldarg.1      // operation
    IL_0046: ldc.i4.3
    IL_0047: stind.i1

    // [18 21 - 18 27]
    IL_0048: br.s         IL_0056

    // [20 21 - 20 61]
    IL_004a: ldarg.1      // operation
    IL_004b: ldc.i4.2
    IL_004c: stind.i1

    // [21 21 - 21 27]
    IL_004d: br.s         IL_0056

    // [23 21 - 23 41]
    IL_004f: ldarg.1      // operation
    IL_0050: ldc.i4.0
    IL_0051: stind.i1

    // [24 21 - 24 33]
    IL_0052: ldc.i4.1
    IL_0053: stloc.2      // V_2
    IL_0054: br.s         IL_005b

    // [25 14 - 25 15]
    IL_0056: nop

    // [26 13 - 26 26]
    IL_0057: ldc.i4.0
    IL_0058: stloc.2      // V_2
    IL_0059: br.s         IL_005b

    // [27 9 - 27 10]
    IL_005b: ldloc.2      // V_2
    IL_005c: ret

  } // end of method Parser::TryParseOperatorOrQuit

  .method public hidebysig static bool
    TryParseArgsOrQuit(
      string arg,
      [out] int32& result
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )

    // [29 9 - 29 10]
    IL_0000: nop

    // [30 13 - 30 48]
    IL_0001: ldarg.0      // arg
    IL_0002: ldarg.1      // result
    IL_0003: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0008: ldc.i4.0
    IL_0009: ceq
    IL_000b: stloc.0      // V_0

    IL_000c: ldloc.0      // V_0
    IL_000d: brfalse.s    IL_0025

    // [31 13 - 31 14]
    IL_000f: nop

    // [32 17 - 32 62]
    IL_0010: ldstr        "Value isn't int: "
    IL_0015: ldarg.0      // arg
    IL_0016: call         string [System.Runtime]System.String::Concat(string, string)
    IL_001b: call         void [System.Console]System.Console::WriteLine(string)
    IL_0020: nop

    // [33 17 - 33 29]
    IL_0021: ldc.i4.1
    IL_0022: stloc.1      // V_1
    IL_0023: br.s         IL_0029

    // [35 13 - 35 26]
    IL_0025: ldc.i4.0
    IL_0026: stloc.1      // V_1
    IL_0027: br.s         IL_0029

    // [36 9 - 36 10]
    IL_0029: ldloc.1      // V_1
    IL_002a: ret

  } // end of method Parser::TryParseArgsOrQuit

  .method public hidebysig static bool
    CheckArgsLengthOrQuit(
      string[] args
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )

    // [39 9 - 39 10]
    IL_0000: nop

    // [40 13 - 40 34]
    IL_0001: ldarg.0      // args
    IL_0002: ldlen
    IL_0003: conv.i4
    IL_0004: ldc.i4.3
    IL_0005: ceq
    IL_0007: ldc.i4.0
    IL_0008: ceq
    IL_000a: stloc.0      // V_0

    IL_000b: ldloc.0      // V_0
    IL_000c: brfalse.s    IL_002b

    // [41 13 - 41 14]
    IL_000e: nop

    // [42 17 - 42 104]
    IL_000f: ldstr        "The program requires 3 CLI arguments, but {0} provided"
    IL_0014: ldarg.0      // args
    IL_0015: ldlen
    IL_0016: conv.i4
    IL_0017: box          [System.Runtime]System.Int32
    IL_001c: call         string [System.Runtime]System.String::Format(string, object)
    IL_0021: call         void [System.Console]System.Console::WriteLine(string)
    IL_0026: nop

    // [43 17 - 43 29]
    IL_0027: ldc.i4.1
    IL_0028: stloc.1      // V_1
    IL_0029: br.s         IL_002f

    // [45 13 - 45 26]
    IL_002b: ldc.i4.0
    IL_002c: stloc.1      // V_1
    IL_002d: br.s         IL_002f

    // [46 9 - 46 10]
    IL_002f: ldloc.1      // V_1
    IL_0030: ret

  }
}