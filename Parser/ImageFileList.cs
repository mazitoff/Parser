using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ImageFileList
    {
        private static ImageFileInfo[] _fileList;
        private static int _curIndex;

        static ImageFileList()
        {
            _fileList = new ImageFileInfo[20];
            _curIndex = 0;
        }

        public void Add(ImageFileInfo f)
        {
            _fileList[_curIndex++] = f;
        }

        public void Print()
        {
            Console.WriteLine("Images:");
            for (int i = 0; i < _curIndex; i++)
            {
                Console.WriteLine(ToString(_fileList[i]));
            }
        }
        public virtual string ToString(ImageFileInfo f)
        {
            return (char)9 + f.Name + "." + f.Extension + (char)10 + (char)13
                + (char)9 + (char)9 + "Extension: " + f.Extension + (char)10 + (char)13
                + (char)9 + (char)9 + "Size: " + f.Size + (char)10 + (char)13
                + (char)9 + (char)9 + "Resolution: " + f.ResolutionX + "x" + f.ResolutionY + (char)10 + (char)13;
        }
    }
}
