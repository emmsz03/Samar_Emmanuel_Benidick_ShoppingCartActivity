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
        Console.WriteLine($"{Id}. {Name} - PHP {Price} (Stock: {RemainingStock})");
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 30000, RemainingStock = 5 },
            new Product { Id = 2, Name = "Mouse", Price = 500, RemainingStock = 0 },
            new Product { Id = 3, Name = "Keyboard", Price = 1500, RemainingStock = 7 },
            new Product { Id = 4, Name = "Headset", Price = 1200, RemainingStock = 3 },
            new Product { Id = 5, Name = "USB Flash Drive", Price = 350, RemainingStock = 0 }
        };

        int[] cartQty = new int[products.Length];
        double grandTotal = 0;

        Console.WriteLine("\n--- STORE MENU ---");
        foreach (var p in products)
        {
            p.DisplayProduct();
        }

        Console.Write("Enter product number: ");
        if (!int.TryParse(Console.ReadLine(), out int productChoice) ||
            productChoice < 1 || productChoice > products.Length)
        {
            Console.WriteLine("Invalid product.");
            return;
        }

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        Product selected = products[productChoice - 1];

        if (selected.RemainingStock == 0)
        {
            Console.WriteLine("Out of stock.");
            return;
        }

        if (!selected.HasEnoughStock(qty))
        {
            Console.WriteLine("Not enough stock.");
            return;
        }

        cartQty[productChoice - 1] += qty;

        double itemTotal = selected.GetItemTotal(qty);
        grandTotal += itemTotal;

        selected.DeductStock(qty);

        Console.WriteLine("Added to cart!");

        Console.WriteLine("\nRECEIPT:");
        for (int i = 0; i < products.Length; i++)
        {
            if (cartQty[i] > 0)
            {
                double total = products[i].GetItemTotal(cartQty[i]);
                Console.WriteLine($"{products[i].Name} x{cartQty[i]} = PHP {total}");
            }
        }

        Console.WriteLine($"Grand Total: PHP {grandTotal}");

        double discount = 0;
        if (grandTotal >= 5000)
        {
            discount = grandTotal * 0.10;
            Console.WriteLine($"Discount: PHP {discount}");
        }

        Console.WriteLine($"Final Total: PHP {grandTotal - discount}");

        Console.WriteLine("\nUPDATED STOCK:");
        foreach (var p in products)
        {
            p.DisplayProduct();
        }
    }
}
