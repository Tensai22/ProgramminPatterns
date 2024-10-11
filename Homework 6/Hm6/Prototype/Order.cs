using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6.Prototype
{

    public class Order : ICloneable
    {
        public List<Product> Products { get; set; }
        public decimal DeliveryCost { get; set; }
        public List<Discount> Discounts { get; set; }
        public string PaymentMethod { get; set; }

        public Order()
        {
            Products = new List<Product>();
            Discounts = new List<Discount>();
        }

        public object Clone()
        {
            Order clonedOrder = new Order
            {
                DeliveryCost = this.DeliveryCost,
                PaymentMethod = this.PaymentMethod
            };

            foreach (var product in Products)
            {
                clonedOrder.Products.Add((Product)product.Clone());
            }

            foreach (var discount in Discounts)
            {
                clonedOrder.Discounts.Add((Discount)discount.Clone());
            }

            return clonedOrder;
        }
    }

}
