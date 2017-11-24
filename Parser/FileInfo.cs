using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class FileInfo
    {
        private string _fileName;
        private string _size;

        public string FileName
        {
            get => _fileName;
            set { _fileName = value; }
        }

        public string Size
        {
            get => _size;
            set { _size = value; }
        }

        //public char[] Separates => _separates;
        //public int CountSeparates => _separates.Length;
    }
}
