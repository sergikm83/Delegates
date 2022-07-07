using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action an Func *****");
            // Использовать делегат Action<> для указания на DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);
            Console.WriteLine();
            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine($"40 + 40 = {result}");
            Console.WriteLine();
            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2.Invoke(90, 300);
            Console.WriteLine($"90 + 300 = {sum}");
        }

        // Это цель для делегата Action<>.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i=0;i<printCount;i++)
            {
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = previous;
        }
        // Цель для делегата Func<>.
        static int Add(int x, int y) => x + y;
        static string SumToString(int x, int y) => $"{x + y}";
    }
}
