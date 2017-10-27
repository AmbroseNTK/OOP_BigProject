using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSBigHomework
{
    class LaptopList
    {
        private List<Laptop> list;
        public LaptopList()
        {
            list = new List<Laptop>();
        }
        public void Add(Laptop laptop)
        {
            list.Add(laptop);
        }
        public void Remove(Laptop lap)
        {
            list.Remove(lap);
        }
        public Laptop GetLaptop(int index)
        {
            return list[index];
        }
        public List<Laptop> GetList()
        {
            return list;
        }
        public void WriteToFile(string dir)
        {
            string data = "";
            foreach(Laptop laptop in list)
            {
                data += laptop.Sku + "\t" + laptop.Name + "\t" + laptop.PublishDate.ToShortDateString()  + "\t" + laptop.Price + "\t" + laptop.QualityOnHand + "\t" + laptop.MadeIn + Environment.NewLine;
            }
            using(StreamWriter writer =new StreamWriter(dir))
            {
                writer.Write(data);
            }
        }
        public void ReadFromFile(string dir)
        {
            try
            {
                using (StreamReader reader = new StreamReader(dir))
                {
                    while (!reader.EndOfStream)
                    {
                        string data = reader.ReadLine();
                        string[] listToken = data.Split('\t');
                        list.Add(new Laptop(listToken[0], listToken[1], DateTime.Parse(listToken[2]), double.Parse(listToken[3]), int.Parse(listToken[4]), listToken[5]));
                       
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
