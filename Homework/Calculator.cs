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

        public static int Calculate(int val1, Operation operation, int val2)
        {
            return operation switch
            {
                Operation.Plus => val1 + val2,
                Operation.Minus => val1 - val2,
                Operation.Multiply => val1 * val2,
                Operation.Divide => val1 / val2,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}