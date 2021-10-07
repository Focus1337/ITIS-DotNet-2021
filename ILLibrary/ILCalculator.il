.assembly ILLibrary
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  ILLibrary.ILCalculator
    extends System.Object
{

  .class nested public sealed auto ansi
    Operation
      extends System.Enum
  {
    .field public specialname rtspecialname unsigned int8 value__
    .field public static literal valuetype ILLibrary.ILCalculator/Operation Plus = unsigned int8(0)
    .field public static literal valuetype ILLibrary.ILCalculator/Operation Minus = unsigned int8(1)
    .field public static literal valuetype ILLibrary.ILCalculator/Operation Divide = unsigned int8(2)
    .field public static literal valuetype ILLibrary.ILCalculator/Operation Multiply = unsigned int8(3)
  }

  .method public hidebysig static bool
    Calculate(
      int32 val1,
      valuetype ILLibrary.ILCalculator/Operation operation,
      int32 val2,
      [out] int32& result
    ) cil managed
  {
    .maxstack 3
    .locals init (
      [0] valuetype ILLibrary.ILCalculator/Operation V_0,
      [1] valuetype ILLibrary.ILCalculator/Operation V_1,
      [2] bool V_2,
      [3] bool V_3
    )

    // инициализация result = 0
    ldarg.3 
    ldc.i4.0
    stind.i4

    // switch operation
    ldarg.1      // operation
    stloc.1      // V_1
    ldloc.1      // V_1
    stloc.0      // V_0
    ldloc.0      // V_0
    switch       (RESULT_PLUS, RESULT_SUB, DIV_ARGUMENT, RESULT_MULT) // 
    br.s         RETURN_FALSE // break when switch case

    // plus case
    RESULT_PLUS: ldarg.3
    ldarg.0      // val1
    ldarg.2      // val2
    add         // суммируем
    stind.i4

    // plus case break
    br.s         RETURN_FALSE

    // minus case
    RESULT_SUB: ldarg.3
    ldarg.0      // val1
    ldarg.2      // val2
    sub          // вычитаем
    stind.i4

    // minus case break
    br.s         RETURN_FALSE

    // multiply case
    RESULT_MULT: ldarg.3
    ldarg.0      // val1
    ldarg.2      // val2
    mul          // умножаем
    stind.i4

    // multiply case break
    br.s         RETURN_FALSE

    // check if val2 == 0
    DIV_ARGUMENT: ldarg.2      // val2
    ldc.i4.0
    ceq           // проверяем равенство
    stloc.2      // V_2
    ldloc.2      // V_2
    brfalse.s    RESULT_DIV
    ldc.i4.1
    stloc.3      // V_3
    br.s         RETURN_METHOD_BOOL

    // divide case
    RESULT_DIV: ldarg.3
    ldarg.0      // val1
    ldarg.2      // val2
    div          // делим
    stind.i4

    // divide case break
    br.s         RETURN_METHOD_BOOL

    // return false
    RETURN_FALSE: ldc.i4.0
    stloc.3      // V_3
    br.s         RETURN_METHOD_BOOL
    RETURN_METHOD_BOOL: ldloc.3      // V_3
    ret

  }
}

