using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Project OOP - Quản lý laptop
/// </summary>
namespace CSBigHomework
{
    /// <summary>
    /// Chương trình chính
    /// </summary>
    class Program
    {
        /// <summary>
        /// Danh sách laptop
        /// </summary>
        public static LaptopList listLaptop;
        static void Main(string[] args)
        {
            listLaptop = new LaptopList();
            Transaction.LaptopList = listLaptop;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Menu.PrintHeader();
            int choise = 0;
            do
            {
                Menu.Output();
                switch (Menu.GetChoice())
                {
                    case 1:
                        //Thêm một laptop
                        listLaptop.AddNewLaptop();
                        break;
                    case 2:
                        //Lưu danh sách ra file
                        Console.WriteLine("Enter file's directory:");
                        string dir = Console.ReadLine();
                        listLaptop.AddFromFile(dir);
                        listLaptop.Output();
                        break;
                    case 3:
                        //Chế độ mở rộng nhiều chức năng
                        AdvanceMode();
                        break;
                    case 4:
                        return;
                }
            } while (choise != 4);


            Console.ReadLine();
        }
        /// <summary>
        /// Hiển thị chế độ mở rộng
        /// </summary>
        public static void AdvanceMode()
        {
            Console.Clear();
            bool isExit = false;
            FileListViewer viewer = new FileListViewer(AppDomain.CurrentDomain.BaseDirectory);
            while (!isExit)
            {
                switch (Menu.printMenu("Function Menu", new List<string> { "Add new Laptop", "Show List", "Save to file", "Load from file", "Delete a laptop", "Edit data","Search","Sell", "Exit" }, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow))
                {
                    
                    case 0: //Thêm laptop
                        Laptop laptop = new Laptop();
                        laptop.Input();
                        listLaptop.Add(laptop);
                        break;
                    case 1: //Hiển thị danh sách
                        Laptop.PrintHeader();
                        Console.BackgroundColor = ConsoleColor.Blue;
                        foreach (Laptop lap in listLaptop)
                        {
                            lap.Output();
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case 2: //Lưu ra file
                        Console.WriteLine("Enter directory: ");
                        listLaptop.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + Console.ReadLine());
                        break;
                    case 3: //Đọc dữ liệu từ file
                        Console.WriteLine("Enter directory: ");
                        viewer = new FileListViewer(AppDomain.CurrentDomain.BaseDirectory);
                        listLaptop.AddFromFile(viewer.Open());
                        break;
                    case 4: //Xóa dữ liệu
                        List<string> listLaptopStr = new List<string>();
                        foreach (Laptop lap in listLaptop)
                        {
                            listLaptopStr.Add(lap.ToString());
                        }
                        listLaptopStr.Add("CANCEL DELETE FUNCTION !!!");
                        Laptop.PrintHeader();
                        int ind = Menu.printMenu("Deletion list", listLaptopStr, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow);
                        if (ind == listLaptopStr.Count - 1)
                            break;
                        listLaptop.RemoveAt(ind);
                        break;
                    case 5: //Chỉnh sửa dữ liệu
                        listLaptopStr = new List<string>();
                        foreach (Laptop lap in listLaptop)
                        {
                            listLaptopStr.Add(lap.ToString());
                        }
                        listLaptopStr.Add("CANCEL EDIT FUNCTION !!!");
                        Laptop.PrintHeader();
                        ind = Menu.printMenu("Edit list", listLaptopStr, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow);
                        if (ind == listLaptopStr.Count - 1)
                            break;
                        Console.Write("SKU: Replace " + listLaptop[ind].Sku + " to: ");
                        listLaptop[ind].Sku = Console.ReadLine();
                        Console.Write("Name: Replace " + listLaptop[ind].Name + " to: ");
                        listLaptop[ind].Name = Console.ReadLine();
                        Console.Write("MFG: Replace " + listLaptop[ind].MFG + " to: ");
                        listLaptop[ind].MFG = DateTime.Parse(Console.ReadLine());
                        Console.Write("Price: Replace " + listLaptop[ind].Price + " to: ");
                        listLaptop[ind].Price = double.Parse(Console.ReadLine());
                        Console.Write("Quantity on hand: Replace " + listLaptop[ind].QuantityOnHand + " to: ");
                        listLaptop[ind].QuantityOnHand = int.Parse(Console.ReadLine());
                        Console.Write("Made in: Replace " + listLaptop[ind].MadeIn + " to: ");
                        listLaptop[ind].MadeIn = Console.ReadLine();
                        break;
                    case 6: //Tìm kiếm dữ liệu
                        Console.WriteLine("Enter search pattern: ");
                        Laptop key = new Laptop();
                        key.Input();
                        Console.WriteLine("Search result:");
                        Laptop.PrintHeader();
                        Console.BackgroundColor = ConsoleColor.Blue;
                        LaptopList result = listLaptop.Search(key);
                        foreach (Laptop lap in result)
                        {
                            lap.Output();
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        
                        break;
                    case 7: //Bán laptop
                        Transaction transaction = new Transaction();
                        transaction.StartTransaction();
                        transaction.EndTransaction();
                        transaction.PrintReceipt();
                        break;
                    case 8:
                        return;
                }
            }
        }
    }
}