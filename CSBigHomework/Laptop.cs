using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    class Laptop
    {
        private string sku;
        //Product's id
        public string Sku
        {
            get { return sku; }
            set { sku = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime publishDate;

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int quantity;

        public int QuantityOnHand
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private string madeIn;

        public string MadeIn
        {
            get { return madeIn; }
            set { madeIn = value; }
        }

        public Laptop()
        {
            Sku = String.Empty;
            Name = String.Empty;
            PublishDate = DateTime.Now;
            Price = 0d;
            QuantityOnHand = 0;
            MadeIn = Country.Unknown;
        }
        /// <summary>
        /// Create new laptop with all properties
        /// </summary>
        /// <param name="sku">Product ID</param>
        /// <param name="name">Laptop's name</param>
        /// <param name="publishDate">Published date</param>
        /// <param name="price">Laptop's price</param>
        /// <param name="quantity">Laptop quantity in the store</param>
        /// <param name="madeIn">Made in</param>
        public Laptop(string sku, string name, DateTime publishDate, double price, int quantity, string madeIn)
        {
            Sku = sku;
            Name = name;
            PublishDate = publishDate;
            Price = price;
            QuantityOnHand = quantity;
            MadeIn = madeIn;
        }
        /// <summary>
        /// Set new laptop's data
        /// </summary>
        public void Input()
        {
            Console.WriteLine("Enter Sku: ");
            Sku = Console.ReadLine();
            Console.WriteLine("Enter product's name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Publish date: ");
            PublishDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price: ");
            Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter QOH: ");
            QuantityOnHand = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Made in : ");
            MadeIn = Console.ReadLine();

        }
        /// <summary>
        /// Print all information of this laptop
        /// </summary>
        public void Output()
        {
            Console.WriteLine("|{0,7}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}|", Sku, Name, PublishDate.ToShortDateString(), Price, QuantityOnHand, MadeIn);
        }
        /// <summary>
        /// Get string which was formatted
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("|{0,7}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}|", Sku, Name, PublishDate.ToShortDateString(), Price, QuantityOnHand, MadeIn);
        }
        /// <summary>
        /// Print header of your list
        /// </summary>
        public static void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("|{0,7}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}|", "SKU", "Name", "Publish Date", "Price", "QOH", "Made in");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
