using System.Windows.Controls;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;

namespace Simulateur_Personnage.Utilities
{
    public static class EventAggregatorClass
    {
        public static IEventAggregator EventAggregator = new EventAggregator();
    }

    public class EventAggregatorLoadMapEvent : CompositePresentationEvent<object> { }
}
