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
        
        static void AddToCart()
        {
            Console.Clear();
            Console.WriteLine("─────────────  ALL PRODUCTS  ─────────────");
            for (int i = 0; i < menu.Length; i++)
                menu[i].Display();
            Console.WriteLine("──────────────────────────────────────────");

            Console.Write("\n  Enter product number to add (0 to cancel): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int id) || id < 0 || id > menu.Length)
            {
                Console.WriteLine("  Invalid input.");
                PressAnyKey();
                return;
            }

            if (id == 0) return;

            Product selected = menu[id - 1];

            if (selected.Stock == 0)
            {
                Console.WriteLine($"  Sorry, {selected.Name} is out of stock.");
                PressAnyKey();
                return;
            }

            Console.Write($"  Enter quantity (available: {selected.Stock}): ");
            string qInput = Console.ReadLine();

            if (!int.TryParse(qInput, out int qty) || qty <= 0)
            {
                Console.WriteLine("  Invalid quantity.");
                PressAnyKey();
                return;
            }

            if (qty > selected.Stock)
            {
                Console.WriteLine($"  Not enough stock. Only {selected.Stock} left.");
                PressAnyKey();
                return;
            }

            bool found = false;
            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].Product.Id == selected.Id)
                {
                    cart[i].Quantity += qty;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                if (cartCount >= MAX_CART)
                {
                    Console.WriteLine("  Cart is full.");
                    PressAnyKey();
                    return;
                }
                cart[cartCount] = new CartItem(selected, qty);
                cartCount++;
            }

            selected.Stock -= qty;
            Console.WriteLine($"\n  Done! {selected.Name} x{qty} added to cart!");
            PressAnyKey();
        }
        
        static void CartMenu()
        {
            bool inCart = true;

            while (inCart)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║              CART MENU                   ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║  1. View Cart                            ║");
                Console.WriteLine("║  2. Update Item Quantity                 ║");
                Console.WriteLine("║  3. Remove an Item                       ║");
                Console.WriteLine("║  4. Clear Cart                           ║");
                Console.WriteLine("║  5. Back to Main Menu                    ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                Console.Write("\n  Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    ViewCart();
                    PressAnyKey();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    UpdateCartItem();
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    RemoveCartItem();
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    ClearCart();
                }
                else if (choice == "5")
                {
                    inCart = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("  Invalid choice. Please enter 1 to 5.");
                    PressAnyKey();
                }
            }
        }

        static void ViewCart()
        {
            if (cartCount == 0)
            {
                Console.WriteLine("  Your cart is empty.");
                return;
            }

            double total = 0;
            Console.WriteLine("─────────────  YOUR CART  ────────────────");
            for (int i = 0; i < cartCount; i++)
            {
                cart[i].Display(i + 1);
                total += cart[i].GetSubtotal();
            }

            double disc       = total >= DISCOUNT_MIN ? total * DISCOUNT_RATE : 0;
            double finalTotal = total - disc;

            Console.WriteLine("──────────────────────────────────────────");
            Console.WriteLine($"  Grand Total : PHP {total:F2}");
            if (disc > 0)
                Console.WriteLine($"  Discount    : PHP -{disc:F2} (10% off)");
            Console.WriteLine($"  Final Total : PHP {finalTotal:F2}");
            Console.WriteLine("──────────────────────────────────────────");
        }
        
        static void UpdateCartItem()
        {
            if (cartCount == 0)
            {
                Console.WriteLine("  Cart is empty.");
                PressAnyKey();
                return;
            }

            ViewCart();
            Console.Write("\n  Enter item number to update (0 to cancel): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int idx) || idx < 0 || idx > cartCount)
            {
                Console.WriteLine("  Invalid input.");
                PressAnyKey();
                return;
            }

            if (idx == 0) return;

            CartItem item  = cart[idx - 1];
            int maxAllowed = item.Product.Stock + item.Quantity;

            Console.WriteLine($"\n  Current quantity of {item.Product.Name}: {item.Quantity}");
            Console.Write($"  Enter new quantity (max: {maxAllowed}): ");
            string qInput = Console.ReadLine();

            if (!int.TryParse(qInput, out int newQty) || newQty <= 0)
            {
                Console.WriteLine("  Invalid quantity.");
                PressAnyKey();
                return;
            }

            if (newQty > maxAllowed)
            {
                Console.WriteLine($"  Not enough stock. Maximum allowed: {maxAllowed}");
                PressAnyKey();
                return;
            }

            int diff            = newQty - item.Quantity;
            item.Product.Stock -= diff;
            item.Quantity       = newQty;

            Console.WriteLine($"  Done! {item.Product.Name} quantity updated to {newQty}.");
            PressAnyKey();
        }

        static void RemoveCartItem()
        {
            if (cartCount == 0)
            {
                Console.WriteLine("  Cart is empty.");
                PressAnyKey();
                return;
            }

            ViewCart();
            Console.Write("\n  Enter item number to remove (0 to cancel): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int idx) || idx < 0 || idx > cartCount)
            {
                Console.WriteLine("  Invalid input.");
                PressAnyKey();
                return;
            }

            if (idx == 0) return;

            CartItem item       = cart[idx - 1];
            item.Product.Stock += item.Quantity;

            for (int i = idx - 1; i < cartCount - 1; i++)
                cart[i] = cart[i + 1];

            cart[cartCount - 1] = null;
            cartCount--;

            Console.WriteLine($"  Done! {item.Product.Name} removed from cart.");
            PressAnyKey();
        }

        static void ClearCart()
        {
            if (cartCount == 0)
            {
                Console.WriteLine("  Cart is already empty.");
                PressAnyKey();
                return;
            }

            Console.Write("  Are you sure you want to clear the cart? (Y/N): ");
            string confirm = Console.ReadLine().Trim().ToUpper();

            while (confirm != "Y" && confirm != "N")
            {
                Console.Write("  Invalid input. Please enter Y or N only: ");
                confirm = Console.ReadLine().Trim().ToUpper();
            }

            if (confirm == "N") return;

            for (int i = 0; i < cartCount; i++)
            {
                cart[i].Product.Stock += cart[i].Quantity;
                cart[i] = null;
            }

            cartCount = 0;
            Console.WriteLine("  Cart cleared successfully.");
            PressAnyKey();
        }

        static void Checkout()
        {
            Console.Clear();

            if (cartCount == 0)
            {
                Console.WriteLine("  Your cart is empty. Add items before checking out.");
                PressAnyKey();
                return;
            }

            ViewCart();

            double grandTotal = 0;
            for (int i = 0; i < cartCount; i++)
                grandTotal += cart[i].GetSubtotal();

            double discount   = grandTotal >= DISCOUNT_MIN ? grandTotal * DISCOUNT_RATE : 0;
            double finalTotal = grandTotal - discount;

            double payment = 0;
            while (true)
            {
                Console.Write($"\n  Enter payment amount (Final Total: PHP {finalTotal:F2}): ");
                string input = Console.ReadLine().Trim();

                if (!double.TryParse(input, out payment) || payment <= 0)
                {
                    Console.WriteLine("  Invalid input. Please enter a valid numeric amount.");
                    continue;
                }

                if (payment < finalTotal)
                {
                    Console.WriteLine($"  Insufficient payment. You need at least PHP {finalTotal:F2}.");
                    continue;
                }

                break;
            }

            double change = payment - finalTotal;

            receiptNo++;
            string receiptNumber = receiptNo.ToString("D4");
            string dateTime      = System.DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");

            CartItem[] snapshot = new CartItem[cartCount];
            for (int i = 0; i < cartCount; i++)
                snapshot[i] = cart[i];

            Receipt receipt = new Receipt(receiptNumber, dateTime, snapshot, cartCount,
                                          grandTotal, discount, finalTotal, payment, change);

            if (orderCount < MAX_ORDERS)
            {
                orderHistory[orderCount] = receipt;
                orderCount++;
            }

            receipt.PrintReceipt();
            ShowLowStockAlerts();

            for (int i = 0; i < cartCount; i++)
                cart[i] = null;
            cartCount = 0;

            Console.Write("  View order history? (Y/N): ");
            string ans = Console.ReadLine().Trim().ToUpper();

            while (ans != "Y" && ans != "N")
            {
                Console.Write("  Invalid input. Please enter Y or N only: ");
                ans = Console.ReadLine().Trim().ToUpper();
            }

            if (ans == "Y")
                ShowOrderHistory();
        }

        static void ShowOrderHistory()
        {
            Console.Clear();

            if (orderCount == 0)
            {
                 Console.WriteLine("  No completed orders yet.");
                PressAnyKey();
                return;
            }

            Console.WriteLine("─────────────  ORDER HISTORY  ────────────");
            for (int i = 0; i < orderCount; i++)
                orderHistory[i].PrintSummary(i + 1);
            Console.WriteLine("──────────────────────────────────────────");

            Console.Write("\n  View full receipt? (Y/N): ");
            string ans = Console.ReadLine().Trim().ToUpper();

            while (ans != "Y" && ans != "N")
            {
                Console.Write("  Invalid input. Please enter Y or N only: ");
                ans = Console.ReadLine().Trim().ToUpper();
            }

            if (ans == "N")
            {
                PressAnyKey();
                return;
            }

            Console.Write($"  Enter order number (1-{orderCount}): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int idx) || idx < 1 || idx > orderCount)
            {
                Console.WriteLine("  Invalid input.");
                PressAnyKey();
                return;
            }

            orderHistory[idx - 1].PrintReceipt();
            PressAnyKey();
        }

        static void ShowLowStockAlerts()
        {
            bool anyLow = false;

            Console.WriteLine("──────────  LOW STOCK ALERTS  ────────────");
            for (int i = 0; i < menu.Length; i++)
            {
                if (menu[i].Stock <= LOW_STOCK_LEVEL)
                {
                    Console.WriteLine($"  ! LOW STOCK: {menu[i].Name} has only {menu[i].Stock} unit(s) left!");
                    anyLow = true;
                }
            }

            if (!anyLow)
                Console.WriteLine("  All products have sufficient stock.");

            Console.WriteLine("──────────────────────────────────────────");
        }

        static void PressAnyKey()
        {
            Console.Write("\n  Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}


            

                
