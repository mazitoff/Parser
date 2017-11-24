using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class MovieFileInfo : FileInfo
    {
        static char[] _separates;

        private string _resolutionX;
        private string _resolutionY;
        private string _lenghtHH;
        private string _lenghtMM;

        static MovieFileInfo()
        {
            _separates = new char[]
            {
                '(',
                ')',
                ';',
                (char)1093,
                ';',
                'h',
                'm',
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
        public string LenghtHH
        {
            get { return _lenghtHH; }
            set { _lenghtHH = value; }
        }
        public string LenghtMM
        {
            get { return _lenghtMM; }
            set { _lenghtMM = value; }
        }
    }
}
