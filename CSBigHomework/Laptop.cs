﻿using System;
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
        private int qualityOnHand;

        public int QualityOnHand
        {
            get { return qualityOnHand; }
            set { qualityOnHand = value; }
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
            QualityOnHand = 0;
            MadeIn = Country.Unknown;
        }
        public Laptop(string sku, string name, DateTime publishDate, double price, int qualityOnHand, string madeIn)
        {
            Sku = sku;
            Name = name;
            PublishDate = publishDate;
            Price = price;
            QualityOnHand = qualityOnHand;
            MadeIn = madeIn;
        }
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
            QualityOnHand = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Made in : ");
            MadeIn = Console.ReadLine();

        }
        public void Output()
        {
            Console.WriteLine("|{0,7}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}|", Sku, Name, PublishDate.ToShortDateString(), Price, QualityOnHand, MadeIn);
        }
        public string ToString()
        {
            return String.Format("|{0,7}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}|", Sku, Name, PublishDate.ToShortDateString(), Price, QualityOnHand, MadeIn);
        }
        public static void PrintHeading()
        {
            Console.WriteLine("|{0,7}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}|", "SKU", "Name", "Publish Date", "Price", "QOH", "Made in");
        }
    }
}