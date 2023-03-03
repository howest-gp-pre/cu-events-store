using System;
namespace Pre.Events.Inventory.Core
{
    public class Administration
    {
        public void ProductShortageHandlerAdministration(object sender, ProductShortageEventArgs e)
        {
            Console.WriteLine($"There is a shortage of {e.Name}.");
        }

        public void RunPromotion(object sender, EventArgs e)
        {
            Console.WriteLine("Run a promotion");
        }
    }
}



