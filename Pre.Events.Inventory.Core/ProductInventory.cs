namespace Pre.Events.Inventory.Core;

public delegate void ProductShortageHandler(object sender, ProductShortageEventArgs e);

public delegate void ProductExcessHandler(object sender, EventArgs e);

public class ProductInventory
{
    public string ProductName { get; }
    public int ItemsInStock { get; private set; }
    public event ProductShortageHandler? ProductShortage;
    public event ProductExcessHandler? ProductExcess;


    public ProductInventory(string productName)
    {
        ProductName = productName;
        ItemsInStock = 0;
    }

    public int Buy(int amount)
    {
        ItemsInStock += amount;

        if (ItemsInStock > 100)
        {
            ProductExcess?.Invoke(this, EventArgs.Empty);
        }

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


