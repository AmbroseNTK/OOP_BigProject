using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    abstract class Product
    {
        protected string sku;
        //Product's id
        public string Sku
        {
            get { return sku; }
            set { sku = value; }
        }
        protected string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Product()
        {
            Sku = String.Empty;
            Name = String.Empty;
        }
        public Product(string sku, string name)
        {
            Sku = sku;
            Name = name;
        }
        public virtual void Input()
        {
            Console.WriteLine("Enter Sku: ");
            Sku = Console.ReadLine();
            Console.WriteLine("Enter product's name: ");
            Name = Console.ReadLine();
        }
        public virtual void Output()
        {
            Console.WriteLine(String.Format("|{0,12}|{1,15}", sku, name));
        }
        public override string ToString()
        {
            return String.Format("{0}|{1}", sku, name);
        }
        public abstract void Describe();
        public abstract double TotalPayment(double discountPercent);
        public abstract void ShowDate();
    }
}
