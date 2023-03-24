namespace Pre.Events.Inventory.Core;

public delegate void ProductShortageHandler(object sender, ProductShortageEventArgs e);

public class ProductInventory
{
    public string ProductName { get; }
    public int ItemsInStock { get; private set; }

    public event ProductShortageHandler? ProductShortage;


    public ProductInventory(string productName)
    {
        ProductName = productName;
        ItemsInStock = 0;
    }

    public int Buy(int amount)
    {
        ItemsInStock += amount;
        return ItemsInStock;
    }

    public int Sell(int amount)
    {
        if (ItemsInStock < amount)
        {
            ProductShortage?.Invoke(this, new ProductShortageEventArgs(ProductName, 10));
        }

        ItemsInStock = Math.Max(0, ItemsInStock - amount);
        return ItemsInStock;
    }
}