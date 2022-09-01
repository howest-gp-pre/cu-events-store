using System;
namespace Pre.Events.Inventory.Core
{
    public class Administration
    {
        public void ProductShortageHandlerAdministration(object sender, ProductShortageEventArgs e)
        {
            Console.WriteLine($"There is a shortage of {e.Product}. Please buy {e.ToBuy}");
        }

        public void RunPromotion(object sender, ProductExcessEventArgs e)
        {
            Console.WriteLine($"Run a promotion for {e.Product}. There is an excess of {e.ExcessAmount}.");
        }
    }
}



