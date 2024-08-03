using System.Windows;
using System.Windows.Interactivity;

namespace WpfProjectTemplate.App.EventTriggers
{
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        private RoutedEvent _routedEvent;

        public RoutedEvent RoutedEvent
        {
            get 
            { 
                return _routedEvent; 
            }
            set 
            { 
                _routedEvent = value; 
            }
        }

        private void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            base.OnEvent(args);
        }

        protected override void OnAttached()
        {
            var behavior = AssociatedObject as Behavior;
            var associatedElement = AssociatedObject as FrameworkElement;

            if (behavior is not null)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }

            if (associatedElement is null)
            {
                throw new ArgumentException("Routed Event trigger can only be associated to framework elements");
            }

            if (RoutedEvent is not null)
            {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
            }
        }

        protected override string GetEventName()
        {
            return RoutedEvent.Name;
        }
    }
}
