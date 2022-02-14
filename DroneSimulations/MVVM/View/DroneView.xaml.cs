using DroneSimulations.MVVM.View.Converters;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using DroneSimulations.MVVM.ViewModel;

namespace DroneSimulations.MVVM.View
{
    /// <summary>
    /// Interaction logic for DroneView.xaml
    /// </summary>
    public partial class DroneView : UserControl
    {
        public static readonly DependencyProperty XProperty = DependencyProperty.RegisterAttached("X", typeof(double), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure = true,
            AffectsRender = true,
            SubPropertiesDoNotAffectRender = false,
            DefaultValue = 0.0
        });

        public static readonly DependencyProperty YProperty = DependencyProperty.RegisterAttached("Y", typeof(double), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure = true,
            AffectsRender = true,
            SubPropertiesDoNotAffectRender = false,
            DefaultValue = 0.0
        });

        public static readonly DependencyProperty CoursePointsProperty = DependencyProperty.RegisterAttached(nameof(CoursePoints), typeof(IList), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure = true,
            AffectsRender = true,
            SubPropertiesDoNotAffectRender = false,
        });
        public IList CoursePoints
        {
            get => (IList)GetValue(CoursePointsProperty);
            set => SetValue(CoursePointsProperty, value);
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
            set => SetValue(RadiusProperty, value);
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.RegisterAttached(nameof(Color), typeof(Color), typeof(DroneView), new FrameworkPropertyMetadata
        {
            AffectsMeasure= true,
            AffectsRender= true,
            SubPropertiesDoNotAffectRender = false
        });
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly DependencyProperty SelectCommandProperty = DependencyProperty.Register(nameof(SelectCommand), typeof(ICommand), typeof(DroneView));
        public ICommand SelectCommand
        {
            get => (ICommand)GetValue(SelectCommandProperty);
            set => SetValue(SelectCommandProperty, value);
        }

        public DroneView()
        {
            InitializeComponent();

            DependencyPropertyDescriptor.FromProperty(CoursePointsProperty, typeof(DroneView))
                                        .AddValueChanged(this, (sender, e) =>
            {
                var value = ((IList)GetValue(CoursePointsProperty)).Cast<CoursePoint>().FirstOrDefault();
                SetValue(XProperty, value?.X ?? 0);
                SetValue(YProperty, value?.Y ?? 0);
            });
        }
    }
}
