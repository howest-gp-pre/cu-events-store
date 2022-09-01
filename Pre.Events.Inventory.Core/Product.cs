using System;
namespace Pre.Events.Inventory.Core
{
    public class Product
    {

        public string Name { get; }

        private decimal price;
        public decimal Price {
            get {
                return price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value;
            }
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

