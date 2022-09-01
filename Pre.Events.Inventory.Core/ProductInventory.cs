namespace Pre.Events.Inventory.Core;

public class ProductInventory
{
    public string ProductName { get; }
    public int ItemsInStock { get; private set; }

    public delegate void ProductShortageHandler(object sender, ProductShortageEventArgs e);

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
            ProductShortageEventArgs args = new ProductShortageEventArgs(ProductName, 10);
            ProductShortage?.Invoke(this, args);
        }

        ItemsInStock -= amount;
        return ItemsInStock;
    }
}


