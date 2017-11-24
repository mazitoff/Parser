using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class TextFileInfo : FileInfo
    {
        static char[] _separates;

        private string _content;

        static TextFileInfo()
        {
            _separates = new char[]
            {
                '(',
                ')',
                ';',
                (char)13
            };
        }

        public char[] Separates => _separates;

        public int CountSeparates => _separates.Length;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
