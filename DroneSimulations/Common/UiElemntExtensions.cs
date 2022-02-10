using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace DroneSimulations.Common
{
    public static class UiElemntExtensions
    {
        /// <summary>
        /// Сконфигурировать и начать анимацию указанного double-проперти
        /// </summary>
        /// <param name="property">Анимируемое проперти</param>
        /// <param name="toValue">Конечное значение анимации</param>
        /// <param name="duration">Продолжительность анимации</param>
        public static void AnimateDoubleProperty(this UIElement animationTarget, DependencyProperty property, double toValue, TimeSpan duration, double? accelRatio, double? decelRatio)
        {
            var xOffsetAnimation = new DoubleAnimation(toValue, duration, FillBehavior.Stop)
            {
                AccelerationRatio = accelRatio ?? 0.5,
                DecelerationRatio = decelRatio ?? 0.5
            };

            EventHandler? OnActionIsOver = null;
            OnActionIsOver = (sender, args) =>
            {
                animationTarget.SetValue(property, toValue);

                xOffsetAnimation.Completed -= OnActionIsOver;
            };

            xOffsetAnimation.Completed += OnActionIsOver;

            animationTarget.BeginAnimation(property, xOffsetAnimation);
        }
    }
}
