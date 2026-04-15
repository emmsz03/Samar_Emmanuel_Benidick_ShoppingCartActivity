# Shopping Cart System

## Description
Console-based shopping cart system in C# with stock tracking and discount.

## Project Progress

- Finished creating the Product class with all required attributes and functions.
- Added a constructor to make product initialization easier and cleaner.
- Organized and improved the overall code structure.
- Built the shopping cart system using a fixed-size array.
- Created the main menu where products are displayed for selection.
- Implemented user input handling with proper validation using `int.TryParse()`.
- Added checks to ensure users cannot buy items beyond available stock.
- Prevented adding items when the cart has reached its limit.
- Included logic to combine quantities when the same product is selected again.
- Completed the add-to-cart process with automatic stock deduction.
- Generated a receipt showing all purchased items and totals.
- Added discount feature for qualifying total purchases.
- Displayed updated inventory after checkout.
- Improved output formatting for better readability.
- Finalized the complete shopping cart program.

## AI Usage in This Project

- “Why am I getting errors about variables not being declared?”
  - Used to understand correct variable scope and how to properly initialize them.

- “How do I validate user input safely in C#?”
  - Helped implement `int.TryParse()` to avoid crashes from invalid inputs.

- “How do I stop users from entering invalid quantities like 0 or negative numbers?”
  - Used to add validation rules ensuring only valid purchase quantities are accepted.
