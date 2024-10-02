namespace Name
{
    class Program
    {
        public static void Main()
        {
            var items = new List<Item>{
                new Item("item1", 100),
                new Item("item2", 200)
            };

            var invoice = new Invoice(1, items, 0.2); 
            var calculator = new InvoiceCalculator();
            double total = calculator.CalculateTotal(invoice);

            var repository = new InvoiceRepository();
            repository.SaveToDatabase(invoice);

            Console.WriteLine($"Total invoice amount: {total}");

        }
        public class Invoice
        {
            public int Id { get; set; }
            public List<Item> Items { get; set; }
            public double TaxRate { get; set; }

            public Invoice(int id, List<Item> items, double taxRate)
            {
                Id = id;
                Items = items;
                TaxRate = taxRate;
            }
        }

        public class InvoiceCalculator
        {
            public double CalculateTotal(Invoice invoice)
            {
                double subTotal = 0;
                foreach (var item in invoice.Items)
                {
                    subTotal += item.Price;
                }
                return subTotal + (subTotal * invoice.TaxRate);
            }
        }

        public class InvoiceRepository
        {
            public void SaveToDatabase(Invoice invoice)
            {

            }
        }

        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public Item(string name, double price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}