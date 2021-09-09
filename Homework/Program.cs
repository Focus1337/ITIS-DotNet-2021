using System;

namespace Homework
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 3)
                Console.WriteLine($"The program requires 3 " + $"CLI arguments but {args.Length} provided");

            var isVal1 = int.TryParse(args[0], out var val1);
            var operation = args[1];
            var isVal2 = int.TryParse(args[2], out var val2);

            var result = 0;
            switch (operation)
            {
                case "+": result = val1 + val2; break;
                case "-": result = val1 - val2; break;
                case "*": result = val1 * val2; break;
                case "/": result = val1 / val2; break;
            };

            if (!isVal1)
            {
                Console.WriteLine($"Val1 is not int: {args[2]}");
                return 1;
            }

            if (!isVal2)
            {
                Console.WriteLine($"Val1 is not int: {args[0]}");
                return 1;
            }

            Console.WriteLine($"Result = {result}");
            
            return 0;
        }
    }
}
