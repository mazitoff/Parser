using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ImageFileInfo : FileInfo
    {
        static char[] _separates;

        private string _resolutionX;
        private string _resolutionY;

        static ImageFileInfo()
        {
            _separates = new char[]
            {
                '(',
                ')',
                ';',
                (char)1093,
                (char)13
            };
        }
        public char[] Separates => _separates;

        public int CountSeparates => _separates.Length;

        public string ResolutionX
        {
            get { return _resolutionX; }
            set { _resolutionX = value; }
        }
        public string ResolutionY
        {
            get { return _resolutionY; }
            set { _resolutionY = value; }
        }
    }
}
