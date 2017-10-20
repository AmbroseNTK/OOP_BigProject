using System;
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


            Laptop.PrintHeading();
            listLaptop = new List<Laptop>();
            listLaptop.Add(new Laptop("123", "Dell XPS15", DateTime.Parse("1/1/2016"), 200.50d, 10, Country.US));
            listLaptop.Add(new Laptop("456", "Asus Gaming", DateTime.Parse("12/5/2015"), 500, 20, Country.Taiwan));
            foreach (Laptop lap in listLaptop)
            {
                lap.Output();
            }
            Console.ReadLine();
        }
    }
}
