using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;
using System.Reflection;

namespace EngageTest.ViewModels
{
    class DisplayerViewModel : BindableBase
    {
        private List<string> _photos = new List<string>();

        private Dictionary<int, int[]> _configurations = new Dictionary<int, int[]>
        {
            {0, new int[]{} },
            {1, new int[]{0} },
            {2, new int[]{0,2 } },
            {3, new int[]{0,3,8 } }
        };


        public ICommand CatsPressedCommand
        {
            protected set; get;
        }

        public DisplayerViewModel()
        {
            CatsPressedCommand = new DelegateCommand(CatsPressed);
        }


        private void CatsPressed()
        {
            _photos = Models.ImageLoader.GetImageNames("cats");
            RaisePropertyChanged("PhotosCount");

            RaisePropertyChanged("Photos");
            RaisePropertyChanged("Image1Source");

            RaisePropertyChanged("Image1RowSpan");
            RaisePropertyChanged("Image1ColumnSpan");
            RaisePropertyChanged("Image2RowSpan");
            RaisePropertyChanged("Image2ColumnSpan");
            RaisePropertyChanged("Image2Source");
            RaisePropertyChanged("Image3Source");

            RaisePropertyChanged("Image3RowSpan");
            RaisePropertyChanged("Image3ColumnSpan");

        }

        public List<string> Photos { get { return _photos; } }

        public int Image1RowSpan
        {
            get
            {
                if (Photos.Count == 1 || PhotosCount == 2)
                    return 3;
                else if (Photos.Count > 2 && Photos.Count <= 6)
                    return 2;
                return 1;
            }
        }

        public int Image1ColumnSpan
        {
            get
            {
                if (Photos.Count <= 4)
                    return 3;
                else if (Photos.Count == 5 || Photos.Count == 6)
                    return 2;
                return 1;
            }
        }

        public string GetSource(int imageNumber)
        {
            int[] indexArray = _configurations[Photos.Count];

            string filename = "";

            int index = Array.IndexOf(indexArray, imageNumber);

            if (index >= 0)
                filename = Photos[index];

            return filename;
        }



        public int Image2RowSpan
        {
            get
            {
                if (PhotosCount >= 7)
                    return 1;
                return 1;
            }
        }
        public int Image2ColumnSpan
        {
            get
            {
                if (PhotosCount >= 7)
                    return 1;
                return 1;
            }
        }

        public BitmapImage Image1Source
        {
            get
            {
                BitmapImage image = null;
                string filename = GetSource(0);
                if (!string.IsNullOrEmpty(filename))
                {
                    image = new BitmapImage(new Uri("ms-appx://EngageTest/" + filename));

                }
                return image;
            }
        }

        public BitmapImage Image2Source
        {
            get
            {
                BitmapImage image = null;
                string filename = GetSource(1);
                if (!string.IsNullOrEmpty(filename))
                {
                    image = new BitmapImage(new Uri("ms-appx://EngageTest/" + filename));

                }
                return image;
            }
        }



        public int Image3RowSpan { get
            { 
                if (PhotosCount == 2)
                    return 3;
                else if (PhotosCount == 3 || PhotosCount == 7)
                    return 2;

                return 1;
            }
        }

        public int Image3ColumnSpan {
            get
            {
                if (PhotosCount == 2)
                    return 3;
                if (PhotosCount < 2)
                    return 0;
                return 1;
            } }

        public BitmapImage Image3Source
        {
            get
            {
                BitmapImage image = null;
                string filename = GetSource(2);
                if (!string.IsNullOrEmpty(filename))
                {
                    image = new BitmapImage(new Uri("ms-appx://EngageTest/" + filename));

                }
                return image;
            }
        }

        public int PhotosCount
        {
            get
            {
                return Photos.Count;
            }
        }

    }
}
