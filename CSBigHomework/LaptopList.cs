using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSBigHomework
{
    class LaptopList : List<Laptop>
    {

        public void WriteToFile(string dir)
        {
            
            using (StreamWriter writer = new StreamWriter(dir))
            {
                writer.Write(ToString());
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
                        this.Add(new Laptop(listToken[0], listToken[1], DateTime.Parse(listToken[2]), double.Parse(listToken[3]), int.Parse(listToken[4]), listToken[5]));

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override string ToString()
        {
            string data = "";
            foreach(Laptop laptop in this)
            {
                data += laptop.Sku + "\t" + laptop.Name + "\t" + laptop.PublishDate.ToShortDateString() + "\t" + laptop.Price + "\t" + laptop.QualityOnHand + "\t" + laptop.MadeIn + Environment.NewLine;
            }
            return data;
        }
    }
}
