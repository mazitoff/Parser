using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class MovieFileList
    {
        private static FileInfo[] _fileList;
        private static int _curIndex;

        static MovieFileList()
        {
            _fileList = new FileInfo[20];
            _curIndex = 0;
        }

        public void Add(FileInfo f)
        {
            _fileList[_curIndex++] = f;
        }

        public void Print()
        {
            for (int i = 0; i < _curIndex; i++)
            {
                Console.WriteLine(_fileList[i].FileName);
            }
        }
    }
}
