using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    /// <summary>
    /// Laptop
    /// </summary>
    class Laptop : Product,IProduct
    {
        /// <summary>
        /// Ngày sản xuất
        /// </summary>
        private DateTime mFG;
        /// <summary>
        /// Ngày sản xuất
        /// </summary>
        public DateTime MFG
        {
            get { return mFG; }
            set { mFG = value; }
        }
        /// <summary>
        ///Giá
        /// </summary>
        private double price;
        /// <summary>
        /// Giá
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// Số lượng tồn kho
        /// </summary>
        private int quantity;
        /// <summary>
        /// Số lượng tồn kho
        /// </summary>
        public int QuantityOnHand
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// Xuất xứ
        /// </summary>
        private string madeIn;

        /// <summary>
        /// Xuất xứ
        /// </summary>
        public string MadeIn
        {
            get { return madeIn; }
            set { madeIn = value; }
        }
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        public Laptop()
        {

            MFG = DateTime.Now;
            Price = 0d;
            QuantityOnHand = 0;
            MadeIn = "Unknown";
        }
        /// <summary>
        /// Tạo đối tượng mới với đầy đủ thuộc tính
        /// </summary>
        /// <param name="sku">Số SKU</param>
        /// <param name="name">Tên</param>
        /// <param name="publishDate">Ngày sản xuất</param>
        /// <param name="price">Giá thành</param>
        /// <param name="quantity">Số lượng tồn kho</param>
        /// <param name="madeIn">Xuất xứ</param>
        public Laptop(string sku, string name, DateTime publishDate, double price, int quantity, string madeIn)
            : base(sku, name)
        {
            MFG = publishDate;
            Price = price;
            QuantityOnHand = quantity;
            MadeIn = madeIn;
        }
        /// <summary>
        /// Nhập dữ liệu cho laptop
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
        /// In tất cả dữ liệu của laptop theo định dạng có sẵn
        /// </summary>
        public override void Output()
        {
            Console.WriteLine(GetOutput());
        }
        public string GetOutput()
        {
            return String.Format("|{0,12}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}", Sku, Name, MFG.ToShortDateString(), Price, QuantityOnHand, MadeIn);
        }
        /// <summary>
        /// Tạo chuỗi dữ liệu của các thuộc tính
        /// </summary>
        /// <returns>Chuỗi dữ liệu</returns>
        public override string ToString()
        {
            return base.ToString() + String.Format("|{0}|{1}|{2}|{3}", MFG.ToShortDateString(), Price, QuantityOnHand, MadeIn);
        }
        /// <summary>
        /// Tạo tiêu đề
        /// </summary>
        public static void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("|{0,12}|{1,15}|{2,15}|{3,8}|{4,5}|{5,10}", "SKU", "Name", "Publish Date", "Price", "QOH", "Made in");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// Xem mô tả của laptop
        /// </summary>
        public override void Describe()
        {
            Console.WriteLine(Name + " is the best Laptop");
        }
        /// <summary>
        /// Tính tổng tiền thanh toán
        /// </summary>
        /// <param name="discountPercent">Phần trăm giảm giá</param>
        /// <returns>Giá thành tiền</returns>
        public override double TotalPayment(double discountPercent)
        {
            return price - price * discountPercent;
        }
        /// <summary>
        /// Xem ngày sản xuất
        /// </summary>
        public override void ShowDate()
        {
            Console.WriteLine("Date = " + mFG);
        }
        /// <summary>
        /// Phát sinh biểu thức chính quy phục vụ tìm kiếm của đối tượng
        /// </summary>
        /// <returns>Biểu thức chính quy</returns>
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
        /// <summary>
        /// Triển khai phương pháp phân phối Laptop
        /// </summary>
        public void Distribute()
        {
            Console.WriteLine("Ship by Plane");
        }
        /// <summary>
        /// Tính giá cơ bản của laptop
        /// </summary>
        /// <returns>Giá thành cơ bản</returns>
        public double GetBasePrice()
        {
            return price - price * 0.1;
        }
    } 
}
