using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSBigHomework
{
    /// <summary>
    /// Giao dịch
    /// </summary>
    class Transaction
    {
        /// <summary>
        /// Danh sách laptop đang có
        /// </summary>
        private static LaptopList laptopList;
        /// <summary>
        /// Giỏ hàng
        /// </summary>
        private List<CartItem> cart;
        
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        public Transaction()
        {
            cart = new List<CartItem>();
        }

        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="laptopList">Danh sách laptop cần giao dịch</param>
        public Transaction(LaptopList laptopList)
        {
            Transaction.laptopList = laptopList;
        }
        /// <summary>
        /// Danh sách laptop đang có
        /// </summary>
        public static LaptopList LaptopList { get => laptopList; set => laptopList = value; }
        /// <summary>
        /// Giỏ hàng
        /// </summary>
        public List<CartItem> Cart { get => cart;}

        /// <summary>
        /// Bắt đầu giao dịch
        /// </summary>
        public void StartTransaction()
        {
            while (true)
            {
                Console.WriteLine("Enter search pattern: ");
                Laptop key = new Laptop();
                key.Input();
                Console.WriteLine("Search result:");
                Laptop.PrintHeader();
                Console.BackgroundColor = ConsoleColor.Blue;
                LaptopList result = laptopList.Search(key);
                foreach (Laptop lap in result)
                {
                    lap.Output();
                }
                
                while (true)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    List<string> listLaptopStr = new List<string>();
                    foreach (Laptop lap in result)
                    {
                        listLaptopStr.Add(lap.ToString());
                    }
                    listLaptopStr.Add("CANCEL TRANSACTION !!!");
                    int ind = Menu.printMenu("Sell item(s)", listLaptopStr, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow);
                    if (ind == listLaptopStr.Count - 1)
                        break;
                    Console.WriteLine("Sell quantity: ");
                    int quan = int.Parse(Console.ReadLine());
                    if (result[ind].QuantityOnHand >= quan)
                    {
                        Cart.Add(new CartItem(result[ind], quan));
                        result[ind].QuantityOnHand-=quan;
                        Console.WriteLine("Item(s) added");
                    }
                    else
                    {
                        Console.WriteLine("Cannot transaction");
                    }
                }
                if (Menu.printMenu("Sell another items", new List<string> { "Yes", "No" }, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow) == 1)
                    break;
                
            }
            Console.WriteLine("Transaction finished");

        }

        /// <summary>
        /// Kết thúc giao dịch
        /// </summary>
        public void EndTransaction()
        {
            Console.WriteLine("Receipt----------");
            CartItem.PrintHeader();
            cart.ForEach((cartItem) => cartItem.Output());
            Console.WriteLine("End transaction");
        }


        /// <summary>
        /// Xuất dữ liệu giao dịch ra file
        /// </summary>
        /// <param name="dir">Đường dẫn file</param>
        public void ExportToFile(string dir)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(dir);
                foreach(CartItem cartItem in cart)
                {
                    streamWriter.WriteLine(cartItem.ToString());
                }
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }

        }
        
        /// <summary>
        /// Tạo hóa đơn thanh toán
        /// </summary>
        /// <returns>Nội dung hóa đơn thanh toán</returns>
        public string GetReceipt()
        {
            string result = "Receipt\nDate " + DateTime.Now + "\n";
            result += CartItem.GetPrintHeader() + "\n";
            foreach(CartItem item in cart)
            {
                result += item.GetOutput() + "\n";
            }
            double total = cart.Sum((item) => (item.Price * item.Quantity));
            result += "------------------------\nTotal = " + total;
            return result;
        }
        public void PrintReceipt()
        {
            string receipt = GetReceipt();
            Console.WriteLine(receipt);
            Console.WriteLine("Save receipt directory: ");
            string dir = Console.ReadLine();
            try
            {
                StreamWriter streamWriter = new StreamWriter(dir);
                streamWriter.Write(receipt);
                streamWriter.Close();
                Console.WriteLine("Saved");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
        }
    }
}
