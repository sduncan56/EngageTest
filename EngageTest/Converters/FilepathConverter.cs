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
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int index = Int32.Parse(parameter.ToString()) - 1;

            List<string> filenames = (List<string>)value;
            string filename = "";
            if (index < filenames.Count)
                filename = filenames[index];

            return filename;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
