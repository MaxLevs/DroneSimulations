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

        public static readonly DependencyProperty XOriginProperty = DependencyProperty.Register(nameof(XOrigin), typeof(double), typeof(DisplayView));
        public double XOrigin
        {
            get => (double)GetValue(XOriginProperty);
            set => SetValue(XOriginProperty, value);
        }

        public static readonly DependencyProperty YOriginProperty = DependencyProperty.Register(nameof(YOrigin), typeof(double), typeof(DisplayView));
        public double YOrigin
        {
            get => (double)GetValue(YOriginProperty);
            set => SetValue(YOriginProperty, value);
        }

        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale), typeof(double), typeof(DisplayView));
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
