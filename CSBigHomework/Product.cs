using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    abstract class Product
    {

        /// <summary>
        /// Số SKU
        /// </summary>
        protected string sku;
        //Số SKU
        public string Sku
        {
            get { return sku; }
            set { sku = value; }
        }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        protected string name;

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        public Product()
        {
            Sku = String.Empty;
            Name = String.Empty;
        }
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="sku">Số SKU</param>
        /// <param name="name">Tên sản phẩm</param>
        public Product(string sku, string name)
        {
            Sku = sku;
            Name = name;
        }
        /// <summary>
        /// Nhập dữ liệu cho sản phẩm
        /// </summary>
        public virtual void Input()
        {
            Console.WriteLine("Enter Sku: ");
            Sku = Console.ReadLine();
            Console.WriteLine("Enter product's name: ");
            Name = Console.ReadLine();
        }
        /// <summary>
        /// Xem dữ liệu của sản phẩm
        /// </summary>
        public virtual void Output()
        {
            Console.WriteLine(String.Format("|{0,12}|{1,15}", sku, name));
        }
        /// <summary>
        /// Tạo chuỗi dữ liệu
        /// </summary>
        /// <returns>Chuỗi dữ liệu</returns>
        public override string ToString()
        {
            return String.Format("{0}|{1}", sku, name);
        }
        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public abstract void Describe();
        /// <summary>
        /// Tính tổng tiền thanh toán
        /// </summary>
        /// <param name="discountPercent">Phần trăm giảm giá</param>
        /// <returns>Tiền thanh toán</returns>
        public abstract double TotalPayment(double discountPercent);
        /// <summary>
        /// Xem ngày sản xuất
        /// </summary>
        public abstract void ShowDate();
    }
}
