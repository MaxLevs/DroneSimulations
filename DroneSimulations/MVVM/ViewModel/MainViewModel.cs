using DroneSimulations.Common;
using DroneSimulations.MVVM.View;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DroneSimulations.MVVM.ViewModel
{
    public class MainViewModel : NotifiableObject
    {
        private readonly DroneViewModelFactory _droneFactory;

        public DisplayViewModel DisplayViewModel { get; set; }
        public ObservableCollection<DroneViewModel> Drones { get; private set; }

        public MainViewModel() : base()
        {
            var colorFacotry = new ColorFactory();
            _droneFactory = new DroneViewModelFactory(colorFacotry);
            Drones = new ObservableCollection<DroneViewModel>();
            DisplayViewModel = new DisplayViewModel();

            AddDroneCommand = new RelyCommand(_ =>
            {
                var droneViewModel = _droneFactory.CreateDefault();
                Drones.Add(droneViewModel);
            });

            RemoveSelectedDronesCommand = new RelyCommand(arg =>
            {
                IList items = ((IList) arg);
                var selectedDrones = items.Cast<DroneViewModel>().ToList();

                if (!selectedDrones.Any())
                {
                    return;
                }

                foreach(DroneViewModel drone in selectedDrones)
                {
                    Drones.Remove(drone);
                }

                if (!Drones.Any())
                {
                    _droneFactory.Reset();
                }
            });

            ClearDronesListCommand = new RelyCommand(_ =>
            {
                Drones.Clear();
                _droneFactory.Reset();
            });
        }

        public RelyCommand AddDroneCommand { get; set; }
        public RelyCommand RemoveSelectedDronesCommand { get; set; }
        public RelyCommand ClearDronesListCommand { get; set; }
    }
}
