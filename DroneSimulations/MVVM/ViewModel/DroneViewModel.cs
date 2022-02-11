﻿using DroneSimulations.Common;
using DroneSimulations.MVVM.View;
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
        public int Id { get; set; }

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

        private double _radius { get; set; }
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

        public double X
        {
            get => Points[0].X;
            set {
                Points[0] = new Point(value, Points[0].Y);
                OnPropertyChanged();
            }
        }

        public double Y
        {
            get => Points[0].Y;
            set {
                Points[0] = new Point(Points[0].X, value);
                OnPropertyChanged();
            }
        }

        public PointCollection Points { get; set; }

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

        public DroneViewModel() : base()
        {
            _radius = 0;
            _state = DroneStateEnum.Normal;
            Points = new PointCollection()
            {
                new Point(0, 0)
            };
        }
    }
}
