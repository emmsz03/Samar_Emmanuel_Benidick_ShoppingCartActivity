using System;

class Product
{
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
}
