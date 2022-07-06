using System;

namespace SimpleDelegate
{
    public delegate int BinatyOp(int x, int y);

    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
