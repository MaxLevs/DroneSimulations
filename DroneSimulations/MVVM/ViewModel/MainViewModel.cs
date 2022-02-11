using DroneSimulations.Common;
using DroneSimulations.MVVM.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DroneSimulations.MVVM.ViewModel
{
    public class MainViewModel : NotifiableObject
    {
        #region Dependencies

        private readonly DroneViewModelFactory _droneFactory;

        #endregion

        #region Properties

        public ObservableCollection<DroneViewModel> Drones { get; private set; }

        #endregion

        #region Commands

        private ICommand? _addDroneCommand;
        public ICommand AddDroneCommand
        {
            get
            {
                if (_addDroneCommand == null)
                {
                    _addDroneCommand = new RelyCommand( _ => {
                        var droneViewModel = _droneFactory.CreateDefault();
                        droneViewModel.SelectItemCommand = SelectDroneFromViewModelCommand;

                        Drones.Add(droneViewModel);
                    }, DefaultCanExecute);
                }

                return _addDroneCommand;
            }
        }

        private ICommand? _removeSelectedDronesCommand;
        public ICommand RemoveSelectedDronesCommand
        {
            get
            {
                if (_removeSelectedDronesCommand == null)
                {
                    _removeSelectedDronesCommand = new RelyCommand(arg =>
                    {
                        IList items = (IList?)arg ?? new List<DroneViewModel>();
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
                    }, DefaultCanExecute);
                }

                return _removeSelectedDronesCommand;
            }
        }

        private ICommand? _clearDronesListCommand;
        public ICommand ClearDronesListCommand
        {
            get
            {
                if (_clearDronesListCommand == null)
                {
                    _clearDronesListCommand = new RelyCommand(_ =>
                    {
                        Drones.Clear();
                        _droneFactory.Reset();
                    }, DefaultCanExecute);
                }

                return _clearDronesListCommand;
            }
        }

        private ICommand? _selectDroneFromViewModelCommand;
        public ICommand SelectDroneFromViewModelCommand
        {
            get
            {
                if (_selectDroneFromViewModelCommand == null)
                {
                    var execute = (object? args) =>
                    {
                        var viewModel = (DroneViewModel?)args;

                        // [TODO] Execute method selecting

                        if (viewModel != null)
                        {
                            var message = $"Выбран дрон с именем {viewModel.Name}";
                            MessageBox.Show(message, "Кто-то тыкнул в дрона", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        else
                        {
                            var message = $"Дрон был тыкнут, но данные не получены";
                            MessageBox.Show(message, "Кто-то тыкнул в дрона", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    };

                    var canExecute = (object? args) =>
                    {
                        return args is DroneViewModel;
                    };

                    _selectDroneFromViewModelCommand = new RelyCommand(execute, canExecute);
                }

                return _selectDroneFromViewModelCommand;
            }
        }

        private bool DefaultCanExecute(object? args) => Drones != null && _droneFactory != null;

        #endregion

        public MainViewModel() : base()
        {
            var colorFacotry = new ColorFactory();
            _droneFactory = new DroneViewModelFactory(colorFacotry);
            Drones = new ObservableCollection<DroneViewModel>();
        }
    }
}
