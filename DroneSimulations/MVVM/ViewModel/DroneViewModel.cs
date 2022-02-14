using DroneSimulations.Common;
using DroneSimulations.MVVM.View;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DroneSimulations.MVVM.ViewModel
{
    public enum DroneStrategyEnum { Stupid, Smart }

    public enum DroneStateEnum { Normal, Crushed, Finished }

    public class DroneViewModel : NotifiableObject
    {
        public Guid Id { get; set; }

        #region Properties

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private double _radius;
        public double Radius { 
            get => _radius; 
            set
            {
                _radius = value;
                OnPropertyChanged();
            }
        }

        private Color _color;
        public Color DisplayColor
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        private DroneStrategyEnum _strategyType;
        public DroneStrategyEnum StrategyType
        {
            get => _strategyType;
            set
            {
                _strategyType = value;
                OnPropertyChanged();
            }
        }

        private DroneStateEnum _state;
        public DroneStateEnum State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CoursePoint> CoursePoints { get; set; }


        #endregion

        #region Commands

        private ICommand? selectItemCommand;
        public ICommand? SelectItemCommand
        {
            get => selectItemCommand;
            set
            {
                selectItemCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public DroneViewModel() : base()
        {
            _radius = 0;
            _state = DroneStateEnum.Normal;
            CoursePoints = new ObservableCollection<CoursePoint>
            {
                new CoursePoint
                {
                    X = default,
                    Y = default,
                    StartSpeed = default,
                }
            };
        }
    }

    /// <summary>
    /// Представляет точку маршрута и её параметры
    /// </summary>
    public class CoursePoint : NotifiableObject
    {
        private double _x;
        public double X
        {
            get => _x;
            set {
                _x = value;
                OnPropertyChanged();
            }
        }

        private double _y;
        public double Y
        {
            get => _y;
            set {
                _y = value;
                OnPropertyChanged();
            }
        }

        private double _startSpeed;
        public double StartSpeed
        {
            get => _startSpeed;
            set
            {
                _startSpeed = value;
                OnPropertyChanged();
            }
        }
    }
}
