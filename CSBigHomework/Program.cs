using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSBigHomework
{
    class Program
    {
        //List of laptop
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
                switch (Menu.GetChoise())
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
            Menu.printTitle(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Title.txt") + "\t\tWelcome to Kiet's Laptop Shop\nPlease select:\n");
            FileListViewer viewer = new FileListViewer(AppDomain.CurrentDomain.BaseDirectory);
            while (!isExit)
            {
                switch (Menu.printMenu("Function Menu", new List<string> { "Add new Laptop", "Show List", "Save to file", "Load from file", "Delete a laptop", "Buy a laptop", "Exit" }, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow))
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
                    case 6:
                        return;
                }
            }
        }
    }
}
