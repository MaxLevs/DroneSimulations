using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DroneSimulations.MVVM.View.Behaviors
{
    public class DisplayViewTouchpadZoomBehavior : Behavior<DisplayView>
    {
        protected override void OnAttached()
        {
            AssociatedObject.ManipulationStarted += OnManipulationStarted;
            AssociatedObject.ManipulationDelta += OnManipulationDelta;
            AssociatedObject.ManipulationCompleted += OnManipulationCompleted;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.ManipulationStarted -= OnManipulationStarted;
            AssociatedObject.ManipulationDelta -= OnManipulationDelta;
            AssociatedObject.ManipulationCompleted -= OnManipulationCompleted;

            base.OnDetaching();
        }

        private void OnManipulationStarted(object? sender, ManipulationStartedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnManipulationDelta(object? sender, ManipulationDeltaEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnManipulationCompleted(object? sender, ManipulationCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
