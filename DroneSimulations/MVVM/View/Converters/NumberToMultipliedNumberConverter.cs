using System;
using System.Globalization;
using System.Windows.Data;

namespace DroneSimulations.MVVM.View.Converters
{
    public class NumberToMultipliedNumberConverter : IValueConverter
    {
        public NumberToMultipliedNumberConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double times = 1;

            if (parameter != null)
            {
                double.TryParse(parameter.ToString(), out times);
            }

            if (double.TryParse(value.ToString(), out var number))
            {
                return number * times;
            }

            else
            {
                return Binding.DoNothing;
            }
        }

        const string convertBackErrorMessage = $"ConvertBack() is not implemented for {nameof(NumberToMultipliedNumberConverter)}";
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double times = 1;

            if (parameter != null)
            {
                double.TryParse(parameter.ToString(), out times);
            }

            if (double.TryParse(value.ToString(), out var number))
            {
                return number / times;
            }

            else
            {
                return Binding.DoNothing;
            }
        }
    }
}
