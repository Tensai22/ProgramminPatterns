namespace Name
{
    class Program
    {
        public static void Main(){
            OrderService order1 = new();
            order1.CreateOrder("Eggs", 10, 800);
        }
    }
    public class OrderService
{
    public void CreateOrder(string productName, int quantity, double price)
    {
        double totalPrice = CalculateTotalPrice(quantity, price);
        Console.WriteLine($"Order for {productName} created. Total: {totalPrice}");
    }

    public void UpdateOrder(string productName, int quantity, double price)
    {
        double totalPrice = CalculateTotalPrice(quantity, price);
        Console.WriteLine($"Order for {productName} updated. New total: {totalPrice}");
    }

    private double CalculateTotalPrice(int quantity, double price)
    {
        return quantity * price;
    }
}


}