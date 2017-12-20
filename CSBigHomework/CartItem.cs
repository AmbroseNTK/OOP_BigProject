using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    /// <summary>
    /// Latop trong giỏ
    /// </summary>
    class CartItem:Laptop
    {
        /// <summary>
        /// Số lượng bỏ giỏ
        /// </summary>
        private int quantity;
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        public CartItem()
        {
        }
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="sku">Số SKU</param>
        /// <param name="name">Tên laptop</param>
        /// <param name="publishDate">Ngày sản xuất</param>
        /// <param name="price">Giá</param>
        /// <param name="quantityOnHand">Tồn kho</param>
        /// <param name="madeIn">Xuất xứ</param>
        /// <param name="quantity">Số lượng mua</param>
        public CartItem(string sku, string name, DateTime publishDate, double price, int quantityOnHand, string madeIn, int quantity) : base(sku, name, publishDate, price, quantityOnHand, madeIn)
        {
            Quantity = quantity;
        }
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="laptop">Laptop cần bỏ giỏ</param>
        /// <param name="quantity">Số lượng mua</param>
        public CartItem(Laptop laptop, int quantity): base(laptop.Sku, laptop.Name, laptop.MFG, laptop.Price, laptop.QuantityOnHand, laptop.MadeIn)
        {
            Quantity = quantity;
        }
        /// <summary>
        /// In tiêu đề
        /// </summary>
        public new static void PrintHeader()
        {
            Console.WriteLine(GetPrintHeader());
        }
        /// <summary>
        /// Lấy dữ liệu tiêu đề
        /// </summary>
        /// <returns>Tiêu đề</returns>
        public static string GetPrintHeader()
        {
            return String.Format("|{0,12}|{1,15}|{2,15}|{3,8}|{4,10}|{5,15}", "SKU", "Name", "MFG", "Price", "Made in", "Sell Quantity");
        }
        /// <summary>
        /// In món hàng
        /// </summary>
        public new void Output()
        {
            Console.WriteLine(GetOutput());
        }
        /// <summary>
        /// Lấy dữ liệu món hàng
        /// </summary>
        /// <returns>Dữ liệu món hàng</returns>
        public string GetOutput()
        {
            return String.Format("|{0,12}|{1,15}|{2,15}|{3,8}|{4,10}|{5,15}", Sku, Name, MFG.ToShortDateString(), Price, MadeIn, quantity);
        }
        /// <summary>
        /// Chuyển đổi dữ liệu của đối tượng thành chuỗi phân cách bằng dấu |
        /// </summary>
        /// <returns>Chuỗi dữ liệu</returns>
        public override string ToString()
        {
            return base.ToString() + "|" + quantity;
        }
        /// <summary>
        /// Số lượng mua
        /// </summary>
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
