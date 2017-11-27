using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class MovieFileInfo : FileInfo
    {
        public MovieFileInfo(string name, string extension, string size, string content, string resolutionX, string resolutionY, string lenghtHH, string lenghtMM)
            :base(name, extension, size)
        {
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
            LenghtHH = lenghtHH;
            LenghtMM = lenghtMM;
        }
        public string ResolutionX { get; set; }
        public string ResolutionY { get; set; }
        public string LenghtHH { get; set; }
        public string LenghtMM { get; set; }
    }
}
