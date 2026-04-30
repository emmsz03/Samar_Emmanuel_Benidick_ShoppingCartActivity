using System;

namespace ShoppingCartSystem
{
    class Receipt
    {
        public string ReceiptNo;
        public string DateTime;
        public CartItem[] Items;
        public int ItemCount;
        public double GrandTotal;
        public double Discount;
        public double FinalTotal;
        public double Payment;
        public double Change;

        public Receipt(string receiptNo, string dateTime, CartItem[] items, int itemCount,
                       double grandTotal, double discount, double finalTotal,
                       double payment, double change)
        {
            ReceiptNo  = receiptNo;
            DateTime   = dateTime;
            Items      = items;
            ItemCount  = itemCount;
            GrandTotal = grandTotal;
            Discount   = discount;
            FinalTotal = finalTotal;
            Payment    = payment;
            Change     = change;
        }

        public void PrintReceipt()
        {
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║             OFFICIAL RECEIPT             ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine($"  Receipt No : {ReceiptNo}");
            Console.WriteLine($"  Date/Time  : {DateTime}");
            Console.WriteLine("──────────────────────────────────────────");
            Console.WriteLine("  ITEMS PURCHASED:");
            for (int i = 0; i < ItemCount; i++)
                Items[i].Display(i + 1);
            Console.WriteLine("──────────────────────────────────────────");
            Console.WriteLine($"  Grand Total : PHP {GrandTotal:F2}");
            if (Discount > 0)
                Console.WriteLine($"  Discount    : PHP -{Discount:F2} (10% off)");
            Console.WriteLine($"  Final Total : PHP {FinalTotal:F2}");
            Console.WriteLine($"  Payment     : PHP {Payment:F2}");
            Console.WriteLine($"  Change      : PHP {Change:F2}");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine();
        }

        public void PrintSummary(int index)
        {
            Console.WriteLine($"  {index}. Receipt #{ReceiptNo} | {DateTime} | Total: PHP {FinalTotal:F2}");
        }
    }
}
