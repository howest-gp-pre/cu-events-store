using System;
using Pre.Events.Inventory.Core;

namespace Pre.Events.Inventory.Cons
{
    public class App
    {
        public void Run()
        {
            Administration administration = new Administration();
            Supplier fruitsSupplier = new Supplier("Groenten en fruit Janssen");

            Product apple = new Product("Apple", 2.19m);
            ProductInventory applesupply = new ProductInventory(apple, 10);
            applesupply.Supplier = fruitsSupplier;

            applesupply.ProductShortage += administration.ProductShortageHandlerAdministration;
            applesupply.ProductExcess += administration.RunPromotion;

            DoSimulation(applesupply);
        }

        public void DoSimulation(ProductInventory p)
        {
            Console.Write("buy or sell? ");
            string buyOrSell = Console.ReadLine();
            while (buyOrSell != "exit")
            {
                Console.Write("Enter amount: ");
                int amount = int.Parse(Console.ReadLine());

                int newamount = buyOrSell == "buy" ? p.Buy(amount) : p.Sell(amount);

                Console.WriteLine($"We now have {newamount} items of the product {p.Product}");

                Console.Write("buy or sell? ");
                buyOrSell = Console.ReadLine();
            }
        }
    }
}

