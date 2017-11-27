using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    abstract class FileInfo
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }

        public FileInfo(string name, string extension, string size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }
    }
}
