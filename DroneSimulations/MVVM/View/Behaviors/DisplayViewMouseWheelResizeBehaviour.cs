using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DroneSimulations.MVVM.View.Behaviors
{
    /// <summary>
    /// Класс-поведение, реализующий изменение масштаба с использованием колёсико мыши внутри DisplayView
    /// </summary>
    public class DisplayViewMouseWheelResizeBehaviour : Behavior<DisplayView>
    {
        private bool IsOnResizableArea = false;

        #region Dependency Properties

        public static readonly DependencyProperty _scaleDelta = DependencyProperty.RegisterAttached(
            nameof(ScaleDelta),
            typeof(double),
            typeof(DisplayViewMouseWheelResizeBehaviour),
            new FrameworkPropertyMetadata()
            {
                DefaultValue = 1.0,
                AffectsMeasure = true,
                AffectsRender = true,
            }
        );
        public double ScaleDelta
        {
            get => (double)GetValue(_scaleDelta);
            set => SetValue(_scaleDelta, value);
        }

        public static readonly DependencyProperty _scaleMinValue = DependencyProperty.RegisterAttached(
            nameof(ScaleMinValue),
            typeof(double),
            typeof(DisplayViewMouseWheelResizeBehaviour),
            new FrameworkPropertyMetadata()
            {
                DefaultValue = 0.3,
                AffectsMeasure = true,
                AffectsRender = true,
            }
        );
        public double ScaleMinValue
        {
            get => (double)GetValue(_scaleMinValue);
            set => SetValue(_scaleMinValue, value);
        }

        public static readonly DependencyProperty _scaleMaxValue = DependencyProperty.RegisterAttached(
            nameof(ScaleMaxValue),
            typeof(double),
            typeof(DisplayViewMouseWheelResizeBehaviour),
            new FrameworkPropertyMetadata()
            {
                DefaultValue = 3.0,
                AffectsMeasure = true,
                AffectsRender = true,
            }
        );
        public double ScaleMaxValue
        {
            get => (double)GetValue(_scaleMaxValue);
            set => SetValue(_scaleMaxValue, value);
        }

        #endregion

        protected override void OnAttached()
        {
            AssociatedObject.MouseEnter += OnMouseEnter;
            AssociatedObject.MouseWheel += OnMouseWheelUsed;
            AssociatedObject.MouseLeave += OnMouseLeave;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseEnter -= OnMouseEnter;
            AssociatedObject.MouseWheel -= OnMouseWheelUsed;
            AssociatedObject.MouseLeave -= OnMouseLeave;

            base.OnDetaching();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            IsOnResizableArea = true;
            e.Handled = true;
        }

        private void OnMouseWheelUsed(object sender, MouseWheelEventArgs e)
        {
            if (!IsOnResizableArea)
            {
                e.Handled = false;
                return;
            }

            var delta = Math.Sign(e.Delta) * ScaleDelta;
            AssociatedObject.Scale += e.Delta * 0.001;

            if (AssociatedObject.Scale <= ScaleMinValue
             && delta < 0)
            {
                AssociatedObject.Scale = ScaleMinValue;
            }

            if (AssociatedObject.Scale >= ScaleMaxValue
             && delta > 0)
            {
                AssociatedObject.Scale = ScaleMaxValue;
            }

            e.Handled = true;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            IsOnResizableArea = false;
            e.Handled = true;
        }
    }
}
