using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace DroneSimulations.MVVM.View.Converters
{
    public class DivideValuesConverter : IMultiValueConverter
    {
        public DivideValuesConverter()
        {

        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return values.Select(value => double.Parse(value.ToString() ?? string.Empty))
                             .Aggregate((acc, cur) => acc / cur);
            }

            catch
            {
                return Binding.DoNothing;
            }
        }

        const string convertBackErrorMessage = $"ConvertBack() is not implemented for {nameof(SubstractValuesConverter)}";
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(convertBackErrorMessage);
        }
    }
}
