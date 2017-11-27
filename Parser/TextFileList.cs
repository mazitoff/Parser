using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class TextFileList
    {
        private static TextFileInfo[] _fileList;
        private static int _curIndex;

        static TextFileList()
        {
            _fileList = new TextFileInfo[20];
            _curIndex = 0;
        }

        public void Add(TextFileInfo f)
        {
            _fileList[_curIndex++] = f;
        }

        public void Print()
        {
            Console.WriteLine("Text files:");
            for (int i = 0; i < _curIndex; i++)
            {
                Console.WriteLine(ToString(_fileList[i]));
            }
        }
        public virtual string ToString(TextFileInfo f)
        {
            return (char)9 + f.Name + "." + f.Extension + (char)10 + (char)13
                + (char)9 + (char)9 + "Extension: " + f.Extension + (char)10 + (char)13
                + (char)9 + (char)9 + "Size: " + f.Size + (char)10 + (char)13
                + (char)9 + (char)9 + "Content: " + f.Content + (char)10 + (char)13;
        }
    }
}
