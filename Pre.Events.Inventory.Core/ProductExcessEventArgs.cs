using System;
namespace Pre.Events.Inventory.Core
{
    public class ProductExcessEventArgs
    {

        public Product Product { get; }
        public int ExcessAmount { get; }

        public ProductExcessEventArgs(Product product, int excessAmount)
        {
            Product = product;
            ExcessAmount = excessAmount;
        }
    }
}

