namespace ShoppingCartSystem
{
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
        public int Stock;

        public Product(int id, string name, double price, int stock, string category)
        {
            Id       = id;
            Name     = name;
            Price    = price;
            Stock    = stock;
            Category = category;
        }

        public void Display()
        {
            Console.WriteLine($"  [{Id}] {Name} | {Category} | PHP {Price:F2} | Stock: {Stock}");
        }
    }
}
