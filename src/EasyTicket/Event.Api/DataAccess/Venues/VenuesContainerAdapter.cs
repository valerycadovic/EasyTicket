using Microsoft.Azure.Cosmos;

namespace CommonLibrary.DataAccess.Venues
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
