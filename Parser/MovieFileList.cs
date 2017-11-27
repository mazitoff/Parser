using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class MovieFileList
    {
        private static MovieFileInfo[] _fileList;
        private static int _curIndex;

        static MovieFileList()
        {
            _fileList = new MovieFileInfo[20];
            _curIndex = 0;
        }

        public void Add(MovieFileInfo f)
        {
            _fileList[_curIndex++] = f;
        }

        public void Print()
        {
            Console.WriteLine("Movies:");
            for (int i = 0; i < _curIndex; i++)
            {
                Console.WriteLine(ToString(_fileList[i]));
            }
        }

        public virtual string ToString(MovieFileInfo f)
        {
            return (char)9 + f.Name + "." + f.Extension + (char)10 + (char)13
                + (char)9 + (char)9 + "Extension: " + f.Extension + (char)10 + (char)13
                + (char)9 + (char)9 + "Size: " + f.Size + (char)10 + (char)13
                + (char)9 + (char)9 + "Resolution: " + f.ResolutionX + "x" + f.ResolutionY + (char)10 + (char)13
                + (char)9 + (char)9 + "Length: " + f.LenghtHH + "h" + f.LenghtMM + "m" + (char)10 + (char)13;
        }
    }
}
