using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace EngageTest.Converters
{
    class FilepathConverter : IValueConverter
    {
        private int[] twoContains = {0, 2};
        private Dictionary<int, int[]> configurations = new Dictionary<int, int[]>
        {
            {0, new int[]{} },
            {1, new int[]{0} },
            {2, new int[]{0,3 } },
            {3, new int[]{0,3,8 } }
        };


        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int imageNumber = Int32.Parse(parameter.ToString());

            List<string> filenames = (List<string>)value;


            int[] indexArray = configurations[filenames.Count];

            string filename = "";

            int index = Array.IndexOf(indexArray, imageNumber);

            if (index >= 0)
                filename = filenames[index];

            return filename;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
