using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CSBigHomework
{
    /// <summary>
    /// Danh sách Laptop
    /// </summary>
    class LaptopList : List<Laptop>
    {
        /// <summary>
        /// Tạo và nhập một laptop
        /// </summary>
        public void AddNewLaptop()
        {
            Laptop laptop = new Laptop();
            laptop.Input();
            this.Add(laptop);
        }
        /// <summary>
        /// Xuất tất cả danh sách vào file
        /// </summary>
        /// <param name="dir">Đường dẫn file</param>
        public void WriteToFile(string dir)
        {
            
            using (StreamWriter writer = new StreamWriter(dir))
            {
                writer.Write(ToString());
            }
        }
        /// <summary>
        /// Đọc dữ liệu từ file và tạo đối tượng thêm vào danh sách
        /// </summary>
        /// <param name="dir">Đường dẫn file</param>
        public void AddFromFile(string dir)
        {
            this.Clear();
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
        /// Xem tất cả dữ liệu trong danh sách
        /// </summary>
        public void Output()
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Tạo chuỗi dữ liệu
        /// </summary>
        /// <returns>Chuỗi dữ liệu</returns>
        public override string ToString()
        {
            string data = "";
            foreach(Laptop laptop in this)
            {
                data += laptop.Sku + "|" + laptop.Name + "|" + laptop.MFG.ToShortDateString() + "|" + laptop.Price + "|" + laptop.QuantityOnHand + "|" + laptop.MadeIn + Environment.NewLine;
            }
            return data;
        }
        /// <summary>
        /// Biến đổi một List của Laptop thành LaptopList
        /// </summary>
        /// <param name="list">List của Laptop</param>
        /// <returns>LaptopList tương ứng</returns>
        public LaptopList ToList(List<Laptop> list)
        {
            LaptopList laptopList = new LaptopList();
            foreach(Laptop lap in list)
            {
                laptopList.Add(lap);
            }
            return laptopList;
        }
        /// <summary>
        /// Tìm kiếm Laptop dựa trên tiêu chí của key
        /// </summary>
        /// <param name="key">Laptop mẫu dùng để so sánh</param>
        /// <returns>Kết quả các laptop tìm được</returns>
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
