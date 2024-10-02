using System;

namespace Name
{
    class Program
    {
        public static void Main(){
            Calculator calc = new();
            calc.PerformOperation(5, 8);
        }
    }
    public class Calculator{
    public void PerformOperation(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
}


