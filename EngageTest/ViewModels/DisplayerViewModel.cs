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
        private BitmapImage _selectedImageSource;

        private Dictionary<int, int[]> _configurations = new Dictionary<int, int[]>
        {
            {0, new int[]{} },
            {1, new int[]{1} },
            {2, new int[]{1,3 } },
            {3, new int[]{1,3,9 } },
            {4, new int[]{1,3,6,9} },
            {5, new int[]{1,3,6,9,7} },
            {6, new int[]{1,3,6,9,7,8} },
            {7, new int[]{1,2,3,4,5,7,8} },
            {8, new int[]{1,2,3,4,5,6,7,8} },
            {9, new int[]{1,2,3,4,5,6,7,8,9} }
        };


        public ICommand PicturesChangeCommand
        {
            protected set; get;
        }

        public ICommand ImageClickedCommand { protected set; get; }

        public ICommand CloseImageCommand { protected set; get; }

        public DisplayerViewModel()
        {
            PicturesChangeCommand = new DelegateCommand<string>(ChangePictures);
            ImageClickedCommand = new DelegateCommand<string>(ImageClicked);
            CloseImageCommand = new DelegateCommand(CloseImage);
            ChangePictures("cats");
        }

        private void CloseImage()
        {
            SelectedImageSource = null;
        }

        private void ImageClicked(string imageNumber)
        {
            SelectedImageSource = GetSource(Int32.Parse(imageNumber));
        }

        private void ChangePictures(string type)
        {
            _photos = Models.ImageLoader.GetImageNames(type);
            RaisePropertyChanged("PhotosCount");

            RaisePropertyChanged("Photos");
            RaisePropertyChanged("Image1Source");

            RaisePropertyChanged("Image1RowSpan");
            RaisePropertyChanged("Image1ColumnSpan");
            RaisePropertyChanged("Image2RowSpan");
            RaisePropertyChanged("Image2ColumnSpan");
            RaisePropertyChanged("Image2Source");
            RaisePropertyChanged("Image3Source");
            RaisePropertyChanged("Image4Source");

            RaisePropertyChanged("Image5Source");
            RaisePropertyChanged("Image6Source");
            RaisePropertyChanged("Image7Source");
            RaisePropertyChanged("Image8Source");
            RaisePropertyChanged("Image9Source");


            RaisePropertyChanged("Image3RowSpan");
            RaisePropertyChanged("Image3ColumnSpan");
            RaisePropertyChanged("Image7ColumnSpan");
            RaisePropertyChanged("Image8ColumnSpan");

        }

        public List<string> Photos { get { return _photos; } }

        public int Image1RowSpan
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

        public int Image1ColumnSpan
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

        public BitmapImage GetSource(int imageNumber)
        {
            int[] indexArray = _configurations[Photos.Count];

            string filename = "";

            int index = Array.IndexOf(indexArray, imageNumber);

            if (index >= 0)
                filename = Photos[index];

            BitmapImage image = null;
            if (!string.IsNullOrEmpty(filename))
            {
                image = new BitmapImage(new Uri("ms-appx://EngageTest/" + filename));

            }

            return image;
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
                return 1;
            } }

        public int Image7ColumnSpan
        {
            get
            {
                if (PhotosCount == 5)
                    return 2;
                return 1;
            }
        }

        public int Image8ColumnSpan
        {
            get
            {
                if (PhotosCount == 8)
                    return 2;
                return 1;
            }
        }

        public BitmapImage Image1Source
        {
            get
            {
                return GetSource(1);
            }
        }

        public BitmapImage Image2Source
        {
            get
            {
                return GetSource(2);
            }
        }


        public BitmapImage Image3Source
        {
            get
            {
                return GetSource(3);
            }
        }


        public BitmapImage Image4Source
        {

            get
            {
                return GetSource(4);

            }
        }


        public BitmapImage Image5Source
        {

            get
            {
                return GetSource(5);

            }
        }
        public BitmapImage Image6Source
        {

            get
            {
                return GetSource(6);

            }
        }
        public BitmapImage Image7Source
        {

            get
            {
                return GetSource(7);

            }
        }
        public BitmapImage Image8Source
        {

            get
            {
                return GetSource(8);

            }
        }
        public BitmapImage Image9Source
        {

            get
            {
                return GetSource(9);

            }
        }

        public BitmapImage SelectedImageSource
        {
            get
            {
                return _selectedImageSource;
            }
            set
            {
                _selectedImageSource = value;
                RaisePropertyChanged("SelectedImageSource");
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
