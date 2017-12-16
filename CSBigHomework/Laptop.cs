using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    class Laptop : Product
    {
        private DateTime mFG;

        public DateTime MFG
        {
            get { return mFG; }
            set { mFG = value; }
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

            MFG = DateTime.Now;
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
            : base(sku, name)
        {
            MFG = publishDate;
            Price = price;
            QuantityOnHand = quantity;
            MadeIn = madeIn;
        }
        /// <summary>
        /// Set new laptop's data
        /// </summary>
        public override void Input()
        {
            base.Input();
            Console.WriteLine("Enter MFG date: ");
            DateTime.TryParse(Console.ReadLine(),out mFG);
            Console.WriteLine("Enter Price: ");
            if(!double.TryParse(Console.ReadLine(),out price))
            {
                price = double.NaN;
            }
            Console.WriteLine("Enter QOH: ");
            if(!int.TryParse(Console.ReadLine(),out quantity))
            {
                quantity = -1;
            }
            Console.WriteLine("Enter Made in : ");
            MadeIn = Console.ReadLine();

        }
        /// <summary>
        /// Print all information of this laptop
        /// </summary>
        public override void Output()
        {
            Console.WriteLine(String.Format("|{0,12}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}",Sku,Name, MFG.ToShortDateString(), Price, QuantityOnHand, MadeIn));
            //Console.WriteLine(ToString());
        }
        /// <summary>
        /// Get string which was formatted
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + String.Format("|{0}|{1}|{2}|{3}", MFG.ToShortDateString(), Price, QuantityOnHand, MadeIn);
        }
        /// <summary>
        /// Print header of your list
        /// </summary>
        public static void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("|{0,12}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}", "SKU", "Name", "Publish Date", "Price", "QOH", "Made in");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// Show the describability of this laptop
        /// </summary>
        public override void Describe()
        {
            Console.WriteLine(Name + " is the best Laptop");
        }
        /// <summary>
        /// Calculating total payment
        /// </summary>
        /// <param name="discountPercent">Discount percent</param>
        /// <returns></returns>
        public override double TotalPayment(double discountPercent)
        {
            return price - price * discountPercent;
        }

        public override void ShowDate()
        {
            Console.WriteLine("Date = " + mFG);
        }
        public string ToRegExpression()
        {
            string expr = "";
            if (Sku == "")
                expr += "(.*?)\\|";
            else
                expr += Sku + "\\|";
            if (Name == "")
                expr += "(.*?)\\|";
            else
                expr += Name + "\\|";
            if (MFG.Year == 1)
                expr += "(.*?)\\|";
            else
                expr += MFG.ToShortDateString()+"\\|";
            expr += Price+"\\|";
            if (QuantityOnHand == -1)
                expr += "(.*?)\\|";
            else
                expr += QuantityOnHand+"\\|";
            if (MadeIn == "")
                expr += "(.*?)";
            else 
                expr += MadeIn;

            expr = expr.Replace("NaN", "(.*?)");
            return expr;
        }
    } 
}
