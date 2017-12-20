using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSBigHomework
{
    /// <summary>
    /// Hỗ trợ giao diện lựa chọn file
    /// </summary>
    class FileListViewer
    {
        /// <summary>
        /// Đường dẫn thư mục
        /// </summary>
        private List<string> listFile;
        /// <summary>
        /// Tạo ra giao diện duyệt file theo phong cách console
        /// </summary>
        /// <param name="directory">Đường dẫn file</param>
        public FileListViewer(string directory)
        {
            listFile = Directory.EnumerateFiles(directory).ToList<string>();
        }
        /// <summary>
        /// Lấy tất cả danh sách file trong thư mục Directory
        /// </summary>
        /// <returns>Tên file được chọn</returns>
        public string Open()
        {
            return listFile[Menu.printMenu("Open file list", listFile, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow)];

        }
       
    }
}
