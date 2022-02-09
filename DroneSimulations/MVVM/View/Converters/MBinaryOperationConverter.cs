using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace DroneSimulations.MVVM.View.Converters
{
    /// <summary>
    /// Типы арифметических операций, поддерживаемых MBinaryOperatorConverter
    /// </summary>
    public enum MathBinaryOperationType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Modulo,
    }

    /// <summary>
    /// Класс-ковертер для мультибиндинга, позволяющий производить бинарные операции над двумя привязанными свойствами
    /// </summary>
    public class MBinaryOperationConverter : IMultiValueConverter
    {
        public MBinaryOperationConverter()
        {

        }

        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (parameter == null)
                {
                    throw new ArgumentException("Параметр типа операции должен быть задан");
                }

                if (parameter is MathBinaryOperationType operationType)
                {
                    var castedValues = values.OfType<double>().ToList();

                    if (castedValues.Count != 2)
                    {
                        throw new ArgumentException("Аргументов операции должно быть ровно два");
                    }

                    var arg1 = castedValues[0];
                    var arg2 = castedValues[1];

                    var result = operationType switch
                    {
                        MathBinaryOperationType.Add      => arg1 + arg2,
                        MathBinaryOperationType.Subtract => arg1 - arg2,
                        MathBinaryOperationType.Multiply => arg1 * arg2,
                        MathBinaryOperationType.Divide   => arg1 / arg2,
                        MathBinaryOperationType.Modulo   => arg1 % arg2,
                        _ => throw new ArgumentException($"Передано неверное значение параметра математической операции. Используйте значения, предоставляемые {nameof(MathBinaryOperationType)}"),
                    };

                    return result;
                }

                return Binding.DoNothing;
            }

            catch
            {
                return Binding.DoNothing;
            }
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string convertBackErrorMessage = $"ConvertBack() method is not implemented for {GetType().Name}";
            throw new NotImplementedException(convertBackErrorMessage);
        }
    }
}
