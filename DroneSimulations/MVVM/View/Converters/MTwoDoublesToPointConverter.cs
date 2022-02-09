using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DroneSimulations.MVVM.View.Converters
{
    /// <summary>
    /// Класс-ковертер для мультибиндинга, позволяющий производить бинарные операции над двумя привязанными свойствами
    /// </summary>
    public class MTwoDoublesToPointConverter : IMultiValueConverter
    {
        public MTwoDoublesToPointConverter()
        {

        }

        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (targetType == typeof(Point)
                    && values != null
                    && values.Length == 2
                    && double.TryParse(values[0].ToString(), out var x)
                    && double.TryParse(values[1].ToString(), out var y))
                {
                    return new Point(x, y);
                }

                throw new ArgumentException("Конвертер ожидает на входе два значения числового типа и возвращает объект типа Point");
            }

            catch
            {
                return Binding.DoNothing;
            }
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null && value is Point pt)
                {
                    return (new[] { pt.X, pt.Y }).Cast<object>().ToArray();
                }

                throw new ArgumentException("Конвертер ожидает на входе объект типа Point и возвращает массив из 2 чисел");
            }

            catch
            {
                return new[] { Binding.DoNothing, Binding.DoNothing };
            }
        }
    }
}
