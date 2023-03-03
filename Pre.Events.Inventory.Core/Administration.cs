using System;
namespace Pre.Events.Inventory.Core
{
    public class Administration
    {
        public void ProductShortageHandlerAdministration(object sender, EventArgs e)
        {
            Console.WriteLine("There is a shortage of something.");
        }
    }
}



