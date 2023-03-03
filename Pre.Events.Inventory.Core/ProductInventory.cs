namespace Pre.Events.Inventory.Core;

public class ProductInventory
{
    private const int MINIMUM_ITEMS = 5;
    private const int EXCESS_AMOUNT = 100;
    private const int DEFAULT_BUY_AMOUNT = 10;

    public Product Product { get; }

    private int itemsInStock;
    public int ItemsInStock
    {
        get
        {
            return itemsInStock;
        }

        set
        {
            if (value < 0) throw new ArgumentException("Not enough in stock");
            if (value < MINIMUM_ITEMS) ProductShortage?.Invoke(this, new ProductShortageEventArgs(Product, DEFAULT_BUY_AMOUNT));
            if (value > EXCESS_AMOUNT) ProductExcess?.Invoke(this, new ProductExcessEventArgs(Product, value - EXCESS_AMOUNT));
            itemsInStock = value;
        }
    }

    private Supplier? supplier;
    public Supplier? Supplier
    {
        get
        {
            return supplier;
        }

        set
        {
            if (supplier != null)
            {
                supplier.RemoveProduct(Product);
                ProductShortage -= supplier.ProductShortageHandlerSupplier;
            }
            supplier = value;
            if (supplier != null)
            {
                supplier.AddProduct(Product);
                ProductShortage += supplier.ProductShortageHandlerSupplier;
            }
        }
    }

    public delegate void ProductShortageHandler(object sender, ProductShortageEventArgs e);
    public delegate void ProductExcessHandler(object sender, ProductExcessEventArgs e);

    public event ProductShortageHandler? ProductShortage;
    public event ProductExcessHandler? ProductExcess;


    public ProductInventory(Product product, int initialStock)
    {
        Product = product;
        ItemsInStock = initialStock;
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


