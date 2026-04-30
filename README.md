# Shopping Cart System

## Progress for ShoppingCartSystem (Part 1)

- Completed the basic requirements for the project (Product class, Fields, and Methods).
- Added `HasEnoughStock`, `DeductStock`, and `GetItemTotal` methods to the Product class.
- Added a fixed-size array to hold the product menu and cart quantities.
- Added main shopping loop with product display and product selection.
- Added quantity input with validation to prevent zero or negative values.
- Added out-of-stock and insufficient stock checking before adding to cart.
- Added receipt generation showing item name, quantity, and subtotal per item.
- Added grand total computation with 10% discount for orders PHP 5,000 and above.
- Added updated stock display after purchase.
- Shopping Cart System (Part 1) Finished.

---

## Progress for EnhancedShoppingCartSystem (Part 2)

- Separated the classes into different source code files (Product.cs, CartItem.cs, Receipt.cs, Program.cs).
- Added a `Category` field to the Product class to support filtering.
- Added a `CartItem` class to hold a product reference and its quantity together.
- Added a `Receipt` class for storing and printing receipt details.
- Used `const` for fixed values such as discount rate, low stock level, and array sizes so they cannot be changed during execution.
- Made the product menu, cart, and order history arrays `static` so all methods can access them.
- Used a constructor for the Product, CartItem, and Receipt classes for easier object creation.
- Added an 8-option Main Menu for full navigation of the system.
- Added Browse All Products to display the full product list with category and stock.
- Added Product Search by name with partial and case-insensitive matching.
- Added Browse by Category to filter products by Electronics, Clothing, or Food.
- Added Add to Cart with stock deduction, out-of-stock checking, and merging of duplicate items.
- Added a Cart Management submenu with 5 options.
- Added View Cart showing all items, subtotals, discount preview, and final total.
- Added Update Item Quantity with proper stock adjustment when quantity increases or decreases.
- Added Remove Item from Cart with automatic stock restoration.
- Added Clear Cart with Y/N confirmation and full stock restoration for all items.
- Added Checkout with payment validation loop that re-prompts until sufficient payment is entered.
- Added change computation after payment.
- Added receipt printing with zero-padded receipt number (e.g. 0001) and formatted date and time.
- Added Low Stock Alert after every checkout for products with 5 or fewer units remaining.
- Added Order History that stores all completed transactions during the program run.
- Added View Order History with option to view the full receipt of a specific order.
- Made all Y/N prompts re-prompt until valid input is entered.
- Made all menu inputs re-prompt until a valid number within range is entered.
- Added `PressAnyKey` helper method for cleaner screen transitions using `Console.Clear`.
- Enhanced Shopping Cart System (Part 2) Finished.

---

## Problems Encountered

- Encountered a problem where stock was going negative when the user entered a quantity larger than what was available. **(SOLVED)**
- Encountered a problem where the same product was being added as a duplicate cart entry instead of updating the existing quantity. **(SOLVED)**
- Encountered a problem where removing an item from the cart did not return the stock back to the product. **(SOLVED)**
- Encountered a problem where updating the cart quantity was not adjusting the product stock correctly. **(SOLVED)**
- Encountered a problem where Y/N prompts accepted any input other than "N" as yes instead of strictly checking for "Y" and "N". **(SOLVED)**
- Encountered a problem where all classes were inside one Program.cs file instead of being in separate files. **(SOLVED)**

---

## AI Usage in This Project

- **"How do I validate user input in C# using int.TryParse?"**
  - Used it as a guide for implementing input validation so invalid inputs do not crash the program, applied to all menu choices and quantity inputs.

- **"How do I prevent users from entering negative or zero values for quantity?"**
  - Used it for adding conditional checks to ensure only positive whole numbers are accepted as valid quantities.

- **"How do I check if a string is strictly Y or N in C# and keep re-prompting?"**
  - Used it to strengthen the Y/N validation loop across all confirmation prompts in the program.

- **"How do I separate classes into different files in C# and make them work together?"**
  - Used it as a beginner-friendly guide for splitting Product, CartItem, Receipt, and Program into their own source code files under the same namespace.

- **"How do I generate a zero-padded receipt number like 0001 in C#?"**
  - Used it to learn the `ToString("D4")` format specifier for generating formatted receipt numbers.

- **"How do I get and format the current date and time in C#?"**
  - Used it to learn `DateTime.Now` and format strings like `"MMMM dd, yyyy hh:mm tt"` for the receipt timestamp.

- **"How do I restore stock when removing an item from a fixed-size array cart in C#?"**
  - Used it to understand how to add quantity back to the product stock when items are removed or the cart is cleared.

- **"What functions can I use to cleanly format console output in C#?"**
  - Helped with formatting and alignment of the receipt, menus, and cart display throughout the program.

