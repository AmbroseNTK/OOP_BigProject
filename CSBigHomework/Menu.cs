using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{

    /// <summary>
    /// Tạo Menu
    /// </summary>
    class Menu
    {
        /// <summary>
        /// In tiêu đề menu
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
        /// Xem chế độ cơ bản
        /// </summary>
        public static void Output()
        {
            Console.WriteLine("1. Add new laptop");
            Console.WriteLine("2. List laptop in details");
            Console.WriteLine("3. Go to advance");
            Console.WriteLine("4. Exit");
        }
        /// <summary>
        /// Nhận dữ liệu nhập vào đơn giản
        /// </summary>
        /// <returns>Chỉ số</returns>
        public static int GetChoice()
        {
            Console.WriteLine("Please select an operation (1-4):");
            int choice = 0;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Input invalid !!!");
                    Console.WriteLine("Please select an operation (1-4):");
                }

            } while (choice < 1 || choice > 4);
            return choice;
            
        }
        /// <summary>
        /// Tạo menu có giao diện lựa chọn
        /// </summary>
        /// <param name="title">Tiêu đề menu</param>
        /// <param name="menuItem">Danh sách các lựa chọn</param>
        /// <param name="foreColor">Màu cơ bản của menu</param>
        /// <param name="backColor">Màu nền cơ bản của menu</param>
        /// <param name="highlightColor">Màu in đậm 1</param>
        /// <param name="highlightColor2">Màu in đậm 2</param>
        /// <returns>Lựa chọn của người dùng</returns>
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
