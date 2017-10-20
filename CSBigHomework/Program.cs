﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    class Program
    {
        public static List<Laptop> listLaptop;
        static void Main(string[] args)
        {
            listLaptop = new List<Laptop>();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            bool isExit = false;
            Menu.printTitle("\t\tWelcome to Kiet's Laptop Shop\nPlease select:\n");
            while (!isExit)
            {
                switch (Menu.printMenu(new List<string> { "Add new Laptop", "Show List", "Delete a laptop", "Buy a laptop", "Exit" }, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow))
                {
                    case 0:
                        Laptop laptop = new Laptop();
                        laptop.Input();
                        listLaptop.Add(laptop);
                        break;
                    case 1:
                        Laptop.PrintHeading();
                        foreach(Laptop lap in listLaptop)
                        {
                            lap.Output();
                        }
                        break;
                    case 4:
                        isExit = true;
                        break;
                }
            }
            Laptop.PrintHeading();
            //listLaptop = new List<Laptop>();
            //listLaptop.Add(new Laptop("123", "Dell XPS15", DateTime.Parse("1/1/2016"), 200.50d, 10, Country.US));
            //listLaptop.Add(new Laptop("456", "Asus Gaming", DateTime.Parse("12/5/2015"), 500, 20, Country.Taiwan));
            //foreach (Laptop lap in listLaptop)
            //{
            //    lap.Output();
            //}
            Console.ReadLine();
        }
    }
}
