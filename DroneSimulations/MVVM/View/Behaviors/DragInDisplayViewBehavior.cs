using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace DroneSimulations.MVVM.View.Behaviors
{
    /// <summary>
    /// Класс-поведение, реализующий перемещение элементов внутри DisplayView
    /// </summary>
    public class DragInDisplayBehavior : Behavior<DisplayView>
    {
        /// <summary>
        /// Флаг, указывающий, находится ли элемент в данный момент в состоянии перетаскивания
        /// </summary>
        private bool IsDragging = false;
        private Point MouseStartPosition;
        private Point ViewPoint;

        /// <inheritdoc/>
        protected override void OnAttached()
        {
            this.AssociatedObject.MouseLeftButtonDown += OnMouseLeftButtonDown;
            this.AssociatedObject.MouseMove += OnMouseMove;
            this.AssociatedObject.MouseLeftButtonUp += OnMouseLeftButtonUp;

            base.OnAttached();
        }

        /// <inheritdoc/>
        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            this.AssociatedObject.MouseMove -= OnMouseMove;
            this.AssociatedObject.MouseLeftButtonUp -= OnMouseLeftButtonUp;

            base.OnDetaching();
        }

        /// <summary>
        /// Обрабочкик события "Нажатие левой кнопки мыши"
        /// </summary>
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsDragging = true;

            MouseStartPosition = e.GetPosition(AssociatedObject);
            ViewPoint = new Point(AssociatedObject.XViewPointPosition, AssociatedObject.YViewPointPosition);

            AssociatedObject.CaptureMouse();
        }

        /// <summary>
        /// Обрабочкик события "Перемещение мыши"
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging == false)
            {
                return;
            }

            var mouseCurrentPosition = e.GetPosition(AssociatedObject);
            var mouseOffset = (Vector)((mouseCurrentPosition - MouseStartPosition) / AssociatedObject.Scale);
            mouseOffset = new Vector(-mouseOffset.X, mouseOffset.Y);

            var currentViewPoint = mouseOffset + ViewPoint;

            AssociatedObject.SetValue(DisplayView.XViewPointPositionProperty, currentViewPoint.X);
            AssociatedObject.SetValue(DisplayView.YViewPointPositionProperty, currentViewPoint.Y);
        }

        /// <summary>
        /// Обрабочкик события "Левую кнопку мыши отпустили"
        /// </summary>
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsDragging = false;
            AssociatedObject.ReleaseMouseCapture();
        }
    }
}
