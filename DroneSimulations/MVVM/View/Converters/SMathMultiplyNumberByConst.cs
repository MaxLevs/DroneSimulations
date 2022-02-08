using System;
using System.Globalization;
using System.Windows.Data;

namespace DroneSimulations.MVVM.View.Converters
{
    public class SMathMultiplyNumberByConst : IValueConverter
    {
        public SMathMultiplyNumberByConst()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double times = 1;

            if (parameter != null)
            {
                double.TryParse(parameter.ToString()?.Replace('.', ','), out times);
            }

            if (double.TryParse(value.ToString(), out var number))
            {
                var result = number * times;
                return result;
            }

            else
            {
                return Binding.DoNothing;
            }
        }

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
