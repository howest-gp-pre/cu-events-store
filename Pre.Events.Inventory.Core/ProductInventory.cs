namespace Pre.Events.Inventory.Core;

public class ProductInventory
{
    public delegate void ProductShortageHandler(object sender, ProductShortageEventArgs e);
    public delegate void ProductExcessHandler(object sender, ProductExcessEventArgs e);

    public event ProductShortageHandler? ProductShortage;
    public event ProductExcessHandler? ProductExcess;

    private const int MinimumItems = 5;
    private const int ExcessAmount = 100;
    private const int DefaultToBuyAmount = 10;

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
            if (value < MinimumItems) ProductShortage?.Invoke(this, new ProductShortageEventArgs(Product, DefaultToBuyAmount));
            if (value > ExcessAmount) ProductExcess?.Invoke(this, new ProductExcessEventArgs(Product, value - ExcessAmount));
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


