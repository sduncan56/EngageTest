using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngageTest.Models
{
    class ImageLoader
    {
        public static List<string> GetImageNames(string folderName)
        {
            List<string> fileNames = new List<string>(System.IO.Directory.EnumerateFiles("Assets/"+folderName));

            return fileNames;
        }
    }
}
