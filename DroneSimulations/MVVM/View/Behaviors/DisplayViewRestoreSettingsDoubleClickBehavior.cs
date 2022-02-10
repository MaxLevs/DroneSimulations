using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using DroneSimulations.Common;

namespace DroneSimulations.MVVM.View.Behaviors
{
    /// <summary>
    /// Класс-поведение, реализующее возвращение к точке обзора и приближению по-умолчанию
    /// </summary>
    public class DisplayViewRestoreSettingsDoubleClickBehavior : Behavior<DisplayView>
    {
        /// <summary>
        ///     Параметр, задающий значение, может или нет поведение может быть реализовано
        /// </summary>
        private bool OnActionAvailable = false;

        #region Base Overridings

        /// <inheritdoc/>
        protected override void OnAttached()
        {
            AssociatedObject.MouseEnter += OnMouseEnter;
            AssociatedObject.MouseLeave += OnMouseLeave;
            AssociatedObject.MouseDoubleClick += OnMouseDoubleClick;

            base.OnAttached();
        }

        /// <inheritdoc/>
        protected override void OnDetaching()
        {
            AssociatedObject.MouseEnter -= OnMouseEnter;
            AssociatedObject.MouseLeave -= OnMouseLeave;
            AssociatedObject.MouseDoubleClick -= OnMouseDoubleClick;

            base.OnDetaching();
        }

        #endregion

        /// <summary>
        /// Обработчик события "Мышь находится над целевым объектом"
        /// </summary>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            OnActionAvailable = true;
        }

        /// <summary>
        /// Обработчик события "Мышь покинула целевой объект"
        /// </summary>
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            OnActionAvailable = false;
        }

        /// <summary>
        /// Обработчик события "Двойной клик мышью"
        /// </summary>
        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!OnActionAvailable)
            {
                e.Handled = false;
                return;
            }

            double targetX = 0;
            double targetY = 0;
            double targetScale = 1;

            var accelRatio = 0.6;
            var decelRatio = 0.3;
            var duration = TimeSpan.FromMilliseconds(500);

            AssociatedObject.AnimateDoubleProperty(DisplayView.XViewPointPositionProperty, targetX, duration, accelRatio, decelRatio);
            AssociatedObject.AnimateDoubleProperty(DisplayView.YViewPointPositionProperty, targetY, duration, accelRatio, decelRatio);
            AssociatedObject.AnimateDoubleProperty(DisplayView.ScaleProperty, targetScale, duration, accelRatio, decelRatio);
        }
    }
}
