using System;

namespace Pre.Events.Inventory.Core
{
    public class ProductShortageEventArgs : EventArgs
    {
        public string Name { get; }
        public int ToBuy { get; }

        public ProductShortageEventArgs(string name, int tobuy)
        {
            Name = name;
            ToBuy = tobuy;
        }
    }
}