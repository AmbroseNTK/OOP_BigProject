using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSBigHomework
{
    class FileListViewer
    {
        private List<string> listFile;
        /// <summary>
        /// Create file browser in console style
        /// </summary>
        /// <param name="directory">File directory</param>
        public FileListViewer(string directory)
        {
            listFile = Directory.EnumerateFiles(directory).ToList<string>();
        }
        /// <summary>
        /// Get list of file in the directory
        /// </summary>
        /// <returns></returns>
        public string Open()
        {
            return listFile[Menu.printMenu("Open file list", listFile, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow)];

        }
       
    }
}
