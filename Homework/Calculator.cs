namespace Calculator
{
    public static class Calculator
    {
        public enum Operation : byte
        {
            Plus,
            Minus,
            Divide,
            Multiply
        }

        // public static int Calculate(int val1, Operation operation, int val2)
        // {
        //     return operation switch
        //     {
        //         Operation.Plus => val1 + val2,
        //         Operation.Minus => val1 - val2,
        //         Operation.Multiply => val1 * val2,
        //         Operation.Divide => val1 / val2,
        //         _ => throw new System.NotImplementedException()
        //     };
        // }
        
        public static bool Calculate(int val1, Operation operation, int val2, out int result)
        {
            result = 0;
            switch (operation)
            {
                case Calculator.Operation.Plus:
                    result = val1 + val2;
                    break;
                case Calculator.Operation.Minus:
                    result = val1 - val2;
                    break;
                case Calculator.Operation.Multiply:
                    result = val1 * val2;
                    break;
                case Calculator.Operation.Divide:
                    if (val2 == 0)
                    {
                        return true;
                    }
                    result = val1 / val2;
                    break;
            }
            return false;
        }
    }
}