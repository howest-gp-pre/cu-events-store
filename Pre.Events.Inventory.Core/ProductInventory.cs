namespace Pre.Events.Inventory.Core;
public class ProductInventory
{
    public string ProductName { get; }
    public int ItemsInStock { get; private set; }

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
        ItemsInStock -= amount;
        return ItemsInStock;
    }
}


