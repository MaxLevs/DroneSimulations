using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DroneSimulations.MVVM.View.Behaviors
{
    public class DisplayViewRestoreSettingsDoubleClickBehavior : Behavior<DisplayView>
    {
        private bool OnActionAvailable = false;

        protected override void OnAttached()
        {
            AssociatedObject.MouseEnter += OnMouseEnter;
            AssociatedObject.MouseDoubleClick += OnMouseDoubleClick;
            AssociatedObject.MouseLeave += OnMouseLeave;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseEnter -= OnMouseEnter;
            AssociatedObject.MouseDoubleClick -= OnMouseDoubleClick;
            AssociatedObject.MouseLeave -= OnMouseLeave;

            base.OnDetaching();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            OnActionAvailable = true;
            e.Handled = true;
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!OnActionAvailable)
            {
                e.Handled = false;
                return;
            }

            AssociatedObject.XViewPointPosition = 0;
            AssociatedObject.YViewPointPosition = 0;
            AssociatedObject.Scale = 1;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            OnActionAvailable = false;
            e.Handled = true;
        }
    }
}
