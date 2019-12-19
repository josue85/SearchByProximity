using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    //For unattended runs, such as automated testing
    class FileInteraction : UserInteraction
    {
        private readonly string _filePath;

        public FileInteraction(string filePath)
        {
            this._filePath = filePath;
        }

        public void Message(string message)
        {
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(message);
            }
        }
    }
}
