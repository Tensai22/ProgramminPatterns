using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6.Prototype
{
    public class Discount : ICloneable
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Discount(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }

        public object Clone()
        {
            return new Discount(Description, Amount);
        }
    }

}
