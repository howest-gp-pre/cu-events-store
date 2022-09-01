using System;
namespace Pre.Events.Inventory.Core
{
    public class Supplier
    {
        public string Name { get; }

        public List<Product> Products { get; }

        public Supplier(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void ProductShortageHandlerSupplier(object sender, ProductShortageEventArgs e)
        {
            Console.WriteLine($"{e.ToBuy} of {e.Product} ordered with {Name}");
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
    }
}

