using System;

namespace SimpleDelegate
{
    public delegate int BinatyOp(int x, int y);

    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int SquareNumber(int a) => a * a;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");
            BinatyOp b = new BinatyOp(SimpleMath.Add);
            Console.WriteLine("10 + 10 is {0}", b(10,10));
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach(Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method NAme: {0}", d.Method);
                Console.WriteLine(("Type Name: {0}",d.Target);
            }
        }
    }
}
