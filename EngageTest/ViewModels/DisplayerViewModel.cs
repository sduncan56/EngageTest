using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;

namespace EngageTest.ViewModels
{
    class DisplayerViewModel : BindableBase
    {
        private List<string> _photos = new List<string>();

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
            OnPropertyChanged("PhotosCount");
            OnPropertyChanged("Photos");
        }

        public List<string> Photos { get { return _photos; } }


        public int PhotosCount
        {
            get
            {
                return Photos.Count;
            }
        }

    }
}
