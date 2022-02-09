using DroneSimulations.Common;
using DroneSimulations.MVVM.View;
using System;
using System.Windows.Data;
using System.Windows.Media;

namespace DroneSimulations.MVVM.ViewModel
{
    public class DroneViewModelFactory
    {
        private int nextId = 1;
        private readonly ColorFactory _colorFactory;

        public double DefaultRadius { get; set; } = 15.0;

        public DroneViewModelFactory(ColorFactory colorFactory)
        {
            _colorFactory = colorFactory;
        }

        public DroneViewModel CreateDefault()
        {
            int id = nextId++;
            string name = $"Drone-{id}";
            Color color = _colorFactory.GetRandomColor();

            var viewModel = new DroneViewModel
            {
                Id = id,
                X = Random.Shared.Next(-300, 300),
                Y = Random.Shared.Next(-150, 150),
                Name = name,
                DisplayColor = color,
                Radius = DefaultRadius,
                StrategyType = DroneStrategyEnum.Stupid,
            };

            return viewModel;
        }

        public DroneViewModel CreateWithStrategy(DroneStrategyEnum strategy)
        {
            int id = nextId++;
            string name = $"Drone-{id}";
            Color color = _colorFactory.GetRandomColor();

            return new DroneViewModel
            {
                Id = id,
                Name = name,
                DisplayColor = color,
                Radius = DefaultRadius,
                StrategyType = strategy
            };
        }

        public void Reset()
        {
            nextId = 1;
        }
    }
}
