using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBigHomework
{
    /// <summary>
    /// Giao diện thể hiện công việc cần làm của mỗi Product
    /// </summary>
    interface IProduct
    {
        /// <summary>
        /// Phương pháp phân phối sản phẩm
        /// </summary>
        void Distribute();
        /// <summary>
        /// Lấy giá sản xuất
        /// </summary>
        /// <returns>Giá sản xuất</returns>
        double GetBasePrice();

    }
}
