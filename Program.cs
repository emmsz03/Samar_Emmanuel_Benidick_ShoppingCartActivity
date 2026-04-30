using System;

namespace ShoppingCartSystem
{
    class Program
    {
        const int MAX_CART        = 20;
        const int MAX_ORDERS      = 50;
        const int LOW_STOCK_LEVEL = 5;
        const double DISCOUNT_MIN  = 5000;
        const double DISCOUNT_RATE = 0.10;

        static Product[]  menu         = new Product[9];
        static CartItem[] cart         = new CartItem[MAX_CART];
        static int        cartCount    = 0;
        static Receipt[]  orderHistory = new Receipt[MAX_ORDERS];
        static int        orderCount   = 0;
        static int        receiptNo    = 0;

        static void Main()
        {
            menu[0] = new Product(1, "Laptop",         30000, 5,   "Electronics");
            menu[1] = new Product(2, "Mouse",           500,   10,  "Electronics");
            menu[2] = new Product(3, "Keyboard",        1500,  7,   "Electronics");
            menu[3] = new Product(4, "Headset",         1200,  3,   "Electronics");
            menu[4] = new Product(5, "USB Flash Drive", 350,   6,   "Electronics");
            menu[5] = new Product(6, "T-Shirt",         299,   20,  "Clothing");
            menu[6] = new Product(7, "Jeans",           899,   15,  "Clothing");
            menu[7] = new Product(8, "Rice (5kg)",      250,   30,  "Food");
            menu[8] = new Product(9, "Instant Noodles", 15,    100, "Food");

            bool running = true;

            while (running)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    BrowseAllProducts();
                }
                else if (choice == "2")
                {
                    SearchProduct();
                }
                else if (choice == "3")
                {
                    BrowseByCategory();
                }
                else if (choice == "4")
                {
                    AddToCart();
                }
                else if (choice == "5")
                {
                    CartMenu();
                }
                else if (choice == "6")
                {
                    Checkout();
                }
                else if (choice == "7")
                {
                    ShowOrderHistory();
                }
                else if (choice == "8")
                {
                    Console.Clear();
                    Console.WriteLine("\n  Thank you for shopping with us! Goodbye!");
                    running = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n  Invalid choice. Please enter 1 to 8.");
                    PressAnyKey();
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║    WELCOME TO THE ENHANCED SHOP v2.0    ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. Browse All Products                  ║");
            Console.WriteLine("║  2. Search Product by Name               ║");
            Console.WriteLine("║  3. Browse by Category                   ║");
            Console.WriteLine("║  4. Add Item to Cart                     ║");
            Console.WriteLine("║  5. Manage Cart                          ║");
            Console.WriteLine("║  6. Checkout                             ║");
            Console.WriteLine("║  7. View Order History                   ║");
            Console.WriteLine("║  8. Exit                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("\n  Enter your choice: ");
        }

        static void BrowseAllProducts()
        {
            Console.Clear();
            Console.WriteLine("─────────────  ALL PRODUCTS  ─────────────");
            for (int i = 0; i < menu.Length; i++)
                menu[i].Display();
            Console.WriteLine("──────────────────────────────────────────");
            PressAnyKey();
        }

static void SearchProduct()
        {
            Console.Clear();
            Console.Write("  Enter product name to search: ");
            string keyword = Console.ReadLine().Trim().ToLower();

            bool found = false;
            Console.WriteLine("\n  Search Results:");
            Console.WriteLine("──────────────────────────────────────────");
            for (int i = 0; i < menu.Length; i++)
            {
                if (menu[i].Name.ToLower().Contains(keyword))
                {
                    menu[i].Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("  No products matched your search.");

            Console.WriteLine("──────────────────────────────────────────");
            PressAnyKey();
        }

static void BrowseByCategory()
        {
            Console.Clear();
            Console.WriteLine("─────────────  CATEGORIES  ───────────────");
            Console.WriteLine("  [1] Electronics");
            Console.WriteLine("  [2] Clothing");
            Console.WriteLine("  [3] Food");
            Console.WriteLine("──────────────────────────────────────────");
            Console.Write("  Enter choice: ");

            string input = Console.ReadLine();
            string selected = "";

            if (input == "1")       selected = "Electronics";
            else if (input == "2")  selected = "Clothing";
            else if (input == "3")  selected = "Food";
            else
            {
                Console.WriteLine("  Invalid choice.");
                PressAnyKey();
                return;
            }

            Console.Clear();
            Console.WriteLine($"─────────────  {selected.ToUpper()}  ─────────────");
            bool found = false;
            for (int i = 0; i < menu.Length; i++)
            {
                if (menu[i].Category == selected)
                {
                    menu[i].Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("  No products in this category.");

            Console.WriteLine("──────────────────────────────────────────");
            PressAnyKey();
        }
