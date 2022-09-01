using System;
namespace Pre.Events.Inventory.Core
{
    public class Supplier
    {
        public string Name { get; }

        public List<ProductInventory> Products { get; }

        public Supplier(string name)
        {
            Name = name;
            Products = new List<ProductInventory>();
        }

        public void AddProduct(ProductInventory p)
        {
            Products.Add(p);
        }
    }
}

