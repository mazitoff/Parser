using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ImageFileInfo : FileInfo
    {
        public ImageFileInfo(string name, string extension, string size, string resolutionX, string resolutionY)
            : base(name, extension, size)
        {
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
        }
        public string ResolutionX { get; set; }
        public string ResolutionY { get; set; }
    }
}
