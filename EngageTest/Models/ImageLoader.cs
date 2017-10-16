using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngageTest.Models
{
    class ImageLoader
    {
        /// <summary>
        /// The closest thing to 'business logic' this has - just loads the image names.
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public static List<string> GetImageNames(string folderName)
        {
            List<string> fileNames = new List<string>(System.IO.Directory.EnumerateFiles("Assets/"+folderName));

            return fileNames;
        }
    }
}
