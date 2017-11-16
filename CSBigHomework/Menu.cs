using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    class Menu
    {
        /// <summary>
        /// Print menu's title
        /// </summary>
        public static void PrintHeader()
        {
            Console.WriteLine("\tCHUONG TRINH QUAN LY LAPTOP");
            Console.WriteLine("\tSINH VIEN THUC HIEN: NGUYEN TUAN KIET");
        }
        public static void printTitle(string title)
        {
            Console.WriteLine(title);
        }
        /// <summary>
        /// Show basic output
        /// </summary>
        public static void Output()
        {
            Console.WriteLine("1. Add new laptop");
            Console.WriteLine("2. List laptop in details");
            Console.WriteLine("3. Go to advance");
            Console.WriteLine("4. Exit");
        }
        /// <summary>
        /// Basic get choise
        /// </summary>
        /// <returns></returns>
        public static int GetChoise()
        {
            Console.WriteLine("Please select an operation (1-4):");
            int choise = 0;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out choise))
                {
                    Console.WriteLine("Input invalid !!!");
                    Console.WriteLine("Please select an operation (1-4):");
                }

            } while (choise < 1 || choise > 4);
            return choise;
            
        }
        /// <summary>
        /// Create choosable menu
        /// </summary>
        /// <param name="title">Menu's title</param>
        /// <param name="menuItem">Menu's list</param>
        /// <param name="foreColor">Normal fore color</param>
        /// <param name="backColor">Normal background color</param>
        /// <param name="highlightColor">Highlight color 1</param>
        /// <param name="highlightColor2">Highlight color 2</param>
        /// <returns></returns>
        public static int printMenu(string title, List<string> menuItem,ConsoleColor foreColor,ConsoleColor backColor,ConsoleColor highlightColor,ConsoleColor highlightColor2)
        {
            Console.WriteLine("Press Key Down and Key Up to select: ");
            int choose = 0;
            bool chosen = false;
            while (!chosen)
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        choose++;
                        break;
                    case ConsoleKey.UpArrow:
                        choose--;
                        break;
                    case ConsoleKey.Enter:
                        chosen = true;
                        break;
                }
                Console.Clear();
                Console.WriteLine(title);
                if (choose == menuItem.Count)
                    choose = 0;
                if (choose == -1)
                    choose = menuItem.Count - 1;
                for (int i = 0; i < menuItem.Count; i++)
                {
                    Console.ForegroundColor = foreColor;
                    Console.BackgroundColor = backColor;
                    if (i == choose)
                    {
                        Console.ForegroundColor = highlightColor2;
                        Console.BackgroundColor = highlightColor;
                        Console.Write(">>>");
                    }
                    Console.WriteLine("\t" + menuItem[i]);
                }
                Console.ForegroundColor = foreColor;
                Console.BackgroundColor = backColor;
            }
           
            return choose;
        }
    }
}
