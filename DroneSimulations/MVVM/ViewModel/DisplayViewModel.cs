using DroneSimulations.Common;

namespace DroneSimulations.MVVM.ViewModel
{
    public class DisplayViewModel : NotifiableObject
    {
        public DisplayViewModel()
        {
        }

        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        private double _height;

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }
    }
}
