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
    class Program
    {
        public static LaptopList listLaptop;
        static void Main(string[] args)
        {
            listLaptop = new LaptopList();
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
                        listLaptop.AddNewLaptop();
                        break;
                    case 2:
                        Console.WriteLine("Enter file's directory:");
                        string dir = Console.ReadLine();
                        listLaptop.AddFromFile(dir);
                        listLaptop.Output();
                        break;
                    case 3:
                        AdvanceMode();
                        break;
                    case 4:
                        return;
                }
            } while (choise != 4);


            Console.ReadLine();
        }
        /// <summary>
        /// Show advance mode
        /// </summary>
        public static void AdvanceMode()
        {
            Console.Clear();
            bool isExit = false;
            //Menu.printTitle(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Title.txt") + "\t\tWelcome to Kiet's Laptop Shop\nPlease select:\n");
            FileListViewer viewer = new FileListViewer(AppDomain.CurrentDomain.BaseDirectory);
            while (!isExit)
            {
                switch (Menu.printMenu("Function Menu", new List<string> { "Add new Laptop", "Show List", "Save to file", "Load from file", "Delete a laptop", "Edit data","Search","Sell", "Exit" }, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow))
                {
                    case 0:
                        Laptop laptop = new Laptop();
                        laptop.Input();
                        listLaptop.Add(laptop);
                        break;
                    case 1:
                        Laptop.PrintHeader();
                        Console.BackgroundColor = ConsoleColor.Blue;
                        foreach (Laptop lap in listLaptop)
                        {
                            lap.Output();
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case 2:
                        Console.WriteLine("Enter directory: ");
                        listLaptop.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Enter directory: ");
                        viewer = new FileListViewer(AppDomain.CurrentDomain.BaseDirectory);
                        listLaptop.AddFromFile(viewer.Open());
                        break;
                    case 4:
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
                    case 5:
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
                    case 6:
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
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:
                        return;
                }
            }
        }
    }
}