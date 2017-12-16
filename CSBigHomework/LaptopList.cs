using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CSBigHomework
{
    class LaptopList : List<Laptop>
    {
        /// <summary>
        /// Create new laptop
        /// </summary>
        public void AddNewLaptop()
        {
            Laptop laptop = new Laptop();
            laptop.Input();
            this.Add(laptop);
        }
        /// <summary>
        /// Write all list's data to a file
        /// </summary>
        /// <param name="dir">File's directory</param>
        public void WriteToFile(string dir)
        {
            
            using (StreamWriter writer = new StreamWriter(dir))
            {
                writer.Write(ToString());
            }
        }
        /// <summary>
        /// Add exist data from file to this list
        /// </summary>
        /// <param name="dir">File's directory</param>
        public void AddFromFile(string dir)
        {
            try
            {
                using (StreamReader reader = new StreamReader(dir))
                {
                    while (!reader.EndOfStream)
                    {
                        string data = reader.ReadLine();
                        string[] listToken = data.Split('|');
                        this.Add(new Laptop(listToken[0], listToken[1], DateTime.Parse(listToken[2]), double.Parse(listToken[3]), int.Parse(listToken[4]), listToken[5]));

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Show all data in this list
        /// </summary>
        public void Output()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            string data = "";
            foreach(Laptop laptop in this)
            {
                data += laptop.Sku + "|" + laptop.Name + "|" + laptop.MFG.ToShortDateString() + "|" + laptop.Price + "|" + laptop.QuantityOnHand + "|" + laptop.MadeIn + Environment.NewLine;
            }
            return data;
        }
        public LaptopList ToList(List<Laptop> list)
        {
            LaptopList laptopList = new LaptopList();
            foreach(Laptop lap in list)
            {
                laptopList.Add(lap);
            }
            return laptopList;
        }
        public LaptopList Search(Laptop key)
        {
            LaptopList result = new LaptopList();
            string expr = key.ToRegExpression();
            foreach(Laptop lap in this)
            {
                string input = lap.ToString();
                input = input.Replace("/", "\\/");
                if (Regex.IsMatch(lap.ToString(), expr))
                    result.Add(lap);
            }
            return result;
        }
    }
}
