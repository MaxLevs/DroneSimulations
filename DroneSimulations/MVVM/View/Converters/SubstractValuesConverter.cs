using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace DroneSimulations.MVVM.View.Converters
{
    public class SubstractValuesConverter : MarkupExtension, IMultiValueConverter
    {
        public SubstractValuesConverter()
        {

        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var castedValues = values.OfType<double>().ToList();

                if (castedValues.Count != 2)
                {
                    return Binding.DoNothing;
                }

                return castedValues[0] - castedValues[1];
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

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
            {
                _converter = new SubstractValuesConverter();
            }

            return _converter;
        }

        private static SubstractValuesConverter? _converter;
    }
}
