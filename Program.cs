using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public double GetItemTotal(int quantity)
    {
        return Price * quantity;
    }

    public bool HasEnoughStock(int quantity)
    {
        return quantity <= RemainingStock;
    }

    public void DeductStock(int quantity)
    {
        RemainingStock -= quantity;
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
    }
}
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
    }
}

class Program
{
static void Main()
{
    Product[] products = new Product[]
    {
        new Product { Id = 1, Name = "Laptop", Price = 30000, RemainingStock = 5 },
        new Product { Id = 2, Name = "Mouse", Price = 500, RemainingStock = 10 },
        new Product { Id = 3, Name = "Keyboard", Price = 1500, RemainingStock = 7 }
    };

    Console.WriteLine("STORE MENU:");
    foreach (var p in products)
    {
        p.DisplayProduct();
    }

    Console.Write("Enter product number: ");
    string inputProduct = Console.ReadLine();

    if (!int.TryParse(inputProduct, out int productChoice) || productChoice < 1 || productChoice > products.Length)
    {
        Console.WriteLine("Invalid product number.");
        return;
    }

    Console.Write("Enter quantity: ");
    string inputQty = Console.ReadLine();

    if (!int.TryParse(inputQty, out int quantity) || quantity <= 0)
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    Product selected = products[productChoice - 1];

    if (selected.RemainingStock == 0)
    {
        Console.WriteLine("Product is out of stock.");
        return;
    }

    if (!selected.HasEnoughStock(quantity))
    {
        Console.WriteLine("Not enough stock available.");
        return;
    }

    double total = selected.GetItemTotal(quantity);
    selected.DeductStock(quantity);

    Console.WriteLine($"Added to cart! Total: ₱{total}");
}
