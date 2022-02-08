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

namespace DroneSimulations.MVVM.View
{
    /// <summary>
    /// Interaction logic for DisplayView.xaml
    /// </summary>
    [ContentProperty(nameof(ItemsProperty))]
    public partial class DisplayView : UserControl
    {
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

        public DisplayView()
        {
            InitializeComponent();
        }
    }
}
