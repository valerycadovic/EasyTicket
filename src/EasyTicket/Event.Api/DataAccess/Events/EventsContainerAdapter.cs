using Microsoft.Azure.Cosmos;

namespace CommonLibrary.DataAccess.Events
{
    public class EventsContainerAdapter
    {
        public Container Container { get; }

        public EventsContainerAdapter(Container container)
        {
            Container = container;
        }
    }
}
