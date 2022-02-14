using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using DroneSimulations.Common.Utills;

namespace DroneSimulations.MVVM.View
{
    /// <summary>
    /// Interaction logic for DisplayView.xaml
    /// </summary>
    [ContentProperty(nameof(ItemsProperty))]
    public partial class DisplayView : UserControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(nameof(Items), typeof(IList), typeof(DisplayView));
        public IList Items
        {
            get => (IList)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty XViewPointPositionProperty = DependencyProperty.RegisterAttached(nameof(XViewPointPosition), typeof(double), typeof(DisplayView), new FrameworkPropertyMetadata
        {
            AffectsRender = true,
            AffectsMeasure = true,
            SubPropertiesDoNotAffectRender = false,
            BindsTwoWayByDefault = true,
            DefaultValue = 0.0
        });
        public double XViewPointPosition
        {
            get => (double)GetValue(XViewPointPositionProperty);
            set => SetValue(XViewPointPositionProperty, value);
        }

        public static readonly DependencyProperty YViewPointPositionProperty = DependencyProperty.RegisterAttached(nameof(YViewPointPosition), typeof(double), typeof(DisplayView), new FrameworkPropertyMetadata
        {
            AffectsRender = true,
            AffectsMeasure = true,
            SubPropertiesDoNotAffectRender = false,
            BindsTwoWayByDefault = true,
            DefaultValue = 0.0
        });
        public double YViewPointPosition
        {
            get => (double)GetValue(YViewPointPositionProperty);
            set => SetValue(YViewPointPositionProperty, value);
        }

        public static readonly DependencyProperty ScaleProperty = DependencyProperty.RegisterAttached(nameof(Scale), typeof(double), typeof(DisplayView), new FrameworkPropertyMetadata
        {
            AffectsRender = true,
            AffectsMeasure = true,
            SubPropertiesDoNotAffectRender = false,
            BindsTwoWayByDefault = true,
            DefaultValue = 1.0
        });
        public double Scale
        {
            get => (double)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        #endregion

        public DisplayView()
        {
            InitializeComponent();

            DependencyPropertyDescriptor.FromProperty(XViewPointPositionProperty, typeof(DisplayView))
                                        .AddValueChanged(this, new EventHandler(AreaPropertyChanged));
            DependencyPropertyDescriptor.FromProperty(YViewPointPositionProperty, typeof(DisplayView))
                                        .AddValueChanged(this, new EventHandler(AreaPropertyChanged));
            DependencyPropertyDescriptor.FromProperty(ScaleProperty, typeof(DisplayView))
                                        .AddValueChanged(this, new EventHandler(AreaPropertyChanged));

            CoordinateGridElements.SizeChanged += AreaPropertyChanged;
        }

        public void AreaPropertyChanged(object? sender, EventArgs e)
        {
            const double baseDrawShift = 100.0;
            const double minDrawShift = 50.0;

            const double mainAxisThickness = 2;

            var xOffset = XViewPointPosition * Scale;
            var yOffset = YViewPointPosition * Scale;

            // CoordinateGridElements.Children.RemoveRange(2, int.MaxValue); // Не удалять две линии, указывающие на текущий вьюпоинт
            CoordinateGridElements.Children.Clear(); // Удалять всё (убрать вьюпоинт из отображения)

            var width = CoordinateGridElements.ActualWidth;
            var height = CoordinateGridElements.ActualHeight;
            var relatedDrawShift = (baseDrawShift * Scale) % (baseDrawShift - minDrawShift) + minDrawShift; // Цикличность зума
            var expandedArea = 2 * relatedDrawShift;

            var centerX = width / 2;
            var centerY = height / 2;


            var mainVertical = Utills.GetVerticalLine(centerX - xOffset, 0, height);
            mainVertical.StrokeThickness = mainAxisThickness;
            CoordinateGridElements.Children.Add(mainVertical);

            var xDrawShifts = GenerateOffsetsFromCenter(0 - expandedArea, width + expandedArea, relatedDrawShift)
                                                .Select(x => x - xOffset % relatedDrawShift)
                                                .ToList();
            foreach (var xShift in xDrawShifts)
            {
                var line = Utills.GetVerticalLine(xShift, 0 - expandedArea, height + expandedArea);
                CoordinateGridElements.Children.Add(line);
            }


            var mainHorizontal = Utills.GetHorizontalLine(0, width, centerY - yOffset);
            mainHorizontal.StrokeThickness = mainAxisThickness;
            CoordinateGridElements.Children.Add(mainHorizontal);

            var yDrawShifts = GenerateOffsetsFromCenter(0 - expandedArea, height + expandedArea, relatedDrawShift)
                                                .Select(y => y - yOffset % relatedDrawShift)
                                                .ToList();
            foreach (var yShift in yDrawShifts)
            {
                var line = Utills.GetHorizontalLine(0, width, yShift);
                CoordinateGridElements.Children.Add(line);
            }
        }

        public IEnumerable<double> GenerateOffsetsFromCenter(double startValue, double endValue, double offset)
        {
            if (offset <= 0)
            {
                throw new ArgumentException("This property must have a positive value", nameof(offset));
            }

            if (startValue >= endValue)
            {
                throw new ArgumentException("startValue must be lower than endValue");
            }

            var centerValue = (startValue + endValue) / 2.0;
            var maxOffset = centerValue - startValue;

            yield return centerValue;

            for (var currentOffset = offset; currentOffset < maxOffset; currentOffset += offset)
            {
                yield return centerValue + currentOffset;
                yield return centerValue - currentOffset;
            }

            yield break;
        }
    }
}
