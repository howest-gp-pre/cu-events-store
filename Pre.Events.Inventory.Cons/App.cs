using System;
using Pre.Events.Inventory.Core;

namespace Pre.Events.Inventory.Cons
{
    public class App
    {
        public void Run()
        {
            Administration a = new Administration();

            ProductInventory apple = new ProductInventory("Apple");
            apple.ProductShortage += a.ProductShortageHandlerAdministration;

            DoSimulation(apple);
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

                Console.WriteLine($"We now have {newamount} items of the product {p.ProductName}");

                Console.Write("buy or sell? ");
                buyOrSell = Console.ReadLine();
            }
        }
    }
}