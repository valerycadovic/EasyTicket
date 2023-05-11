using Microsoft.Azure.Cosmos;

namespace EventApi.DataAccess.Venues
{
    public class VenuesContainerAdapter
    {
        public Container Container { get; }

        public VenuesContainerAdapter(Container container)
        {
            Container = container;
        }
    }
}
