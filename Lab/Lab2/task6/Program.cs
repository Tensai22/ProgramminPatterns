namespace Name
{
    class Program
    {
        public static void Main(){
            MathOperations mo = new();

            Console.WriteLine("Result: " + mo.Add(1, 3));
        }
    }
    public class MathOperations
{
    public int Add(int a, int b)
    {
        int result = a + b;
        return result;
    }
}

}