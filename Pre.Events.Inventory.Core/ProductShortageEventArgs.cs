using System;
namespace Pre.Events.Inventory.Core
{
    public class ProductShortageEventArgs : EventArgs
    {
        public Product Product { get; }
        public int ToBuy { get; }

        public ProductShortageEventArgs(Product product, int tobuy)
        {
            Product = product;
            ToBuy = tobuy;
        }
    }
}


