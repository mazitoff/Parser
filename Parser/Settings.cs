using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Settings
    {
        public Settings()
        {
            _separatesTxt = new char[]
            {
                '.',
                '(',
                ')',
                ';',
                (char)13
            };
            _separatesImg = new char[]
            {
                '.',
                '(',
                ')',
                ';',
                (char)1093,   // 'x'
                (char)13
            };
            _separatesMov = new char[]
            {
                '.',
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

        private char[] _separatesTxt;
        private char[] _separatesImg;
        private char[] _separatesMov;

        public char[] SeparatesTxt => _separatesTxt;
        public char[] SeparatesImg => _separatesImg;
        public char[] SeparatesMov => _separatesMov;

        public int CountSeparatesTxt => _separatesTxt.Length;
        public int CountSeparatesImg => _separatesImg.Length;
        public int CountSeparatesMov => _separatesMov.Length;
    }
}
