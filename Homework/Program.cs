using System;

namespace Homework
{
   
    class Program
    {

        private static bool CheckArgLength(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine($"The program requires 3 " + $"CLI arguments but {args.Length} provided");
                return false;
            }
            return true;
        }

        private static bool TryParseOrQuit(string str, out int result)
        {
            Console.WriteLine($"Val1 is not int");
            return int.TryParse(str, out result);
        }

        private const int NotEnoughArgs = 1;
        private const int WrongArgFormat = 2;


        static int Main(string[] args)
        {
            if (CheckArgLength(args))
                return NotEnoughArgs;

            var operation = args[1];

            if (TryParseOrQuit(args[0], out var val1) || TryParseOrQuit(args[2], out var val2))
            {
                Console.WriteLine($"Val1 is not int: {args[0]}");
                return WrongArgFormat;
            }


            var result = Calculator.Calculate(val1, val2, operation);
            Console.WriteLine($"Result = {result}");

            return 0;
        }
    }


}
