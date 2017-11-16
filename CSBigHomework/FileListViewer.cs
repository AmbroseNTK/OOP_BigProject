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
        public FileListViewer(string directory)
        {
            listFile = Directory.EnumerateFiles(directory).ToList<string>();
        }
        public string Open()
        {
            return listFile[Menu.printMenu("Open file list", listFile, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Yellow)];

        }
       
    }
}
