using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class TextFileInfo : FileInfo
    {
        public TextFileInfo(string name, string extension, string size, string content)
            : base(name, extension, size)
        {
            Content = content;
        }
        public string Content { get; set; }
    }
}
