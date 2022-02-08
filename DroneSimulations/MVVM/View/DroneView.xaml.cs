using DroneSimulations.MVVM.View.Converters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DroneSimulations.MVVM.View
{
    /// <summary>
    /// Interaction logic for DroneView.xaml
    /// </summary>
    public partial class DroneView : UserControl
    {
        public static readonly DependencyProperty XProperty = DependencyProperty.RegisterAttached(nameof(X), typeof(double), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure = true,
            AffectsRender = true,
            SubPropertiesDoNotAffectRender = false,
            DefaultValue = 0.0
        });
        public double X
        {
            get => (double)GetValue(XProperty);
            set
            {
                SetValue(XProperty, value);
            }
        }

        public static readonly DependencyProperty YProperty = DependencyProperty.RegisterAttached(nameof(Y), typeof(double), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure = true,
            AffectsRender = true,
            SubPropertiesDoNotAffectRender = false,
            DefaultValue = 0.0
        });
        public double Y
        {
            get => (double)GetValue(YProperty);
            set
            {
                SetValue(YProperty, value);
            }
        }


        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(nameof(Radius), typeof(double), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure= true,
            AffectsRender= true,
            SubPropertiesDoNotAffectRender = false,
            DefaultValue = 0.0
        });
        public double Radius
        {
            get => (double)GetValue(RadiusProperty);
            set
            {
                SetValue(RadiusProperty, value);
            }
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof(Color), typeof(Color), typeof(DroneView));
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public DroneView()
        {
            InitializeComponent();

            var radiusBinding = new Binding(nameof(Radius));
            radiusBinding.Source = this;
            radiusBinding.Mode = BindingMode.TwoWay;

            var xPositionBinding = new Binding(nameof(X));
            xPositionBinding.Source = this;
            xPositionBinding.Mode = BindingMode.TwoWay;

            var yPositionBinding = new Binding(nameof(Y));
            yPositionBinding.Source = this;
            yPositionBinding.Mode = BindingMode.TwoWay;

            var leftBinding = new MultiBinding();
            leftBinding.Converter = new SubstractValuesConverter();
            leftBinding.Mode = BindingMode.TwoWay;
            leftBinding.Bindings.Add(xPositionBinding);
            leftBinding.Bindings.Add(radiusBinding);
            SetBinding(Canvas.LeftProperty, leftBinding);

            var topBinding = new MultiBinding();
            topBinding.Converter = new SubstractValuesConverter();
            topBinding.Mode = BindingMode.TwoWay;
            topBinding.Bindings.Add(yPositionBinding);
            topBinding.Bindings.Add(radiusBinding);
            SetBinding(Canvas.TopProperty, topBinding);
        }
    }
}
