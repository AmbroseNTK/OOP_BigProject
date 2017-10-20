using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    class Menu
    {
        public static void printTitle(string title)
        {
            Console.WriteLine(title);
        }
        public static int printMenu(List<string> menuItem,ConsoleColor foreColor,ConsoleColor backColor,ConsoleColor highlightColor,ConsoleColor highlightColor2)
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
