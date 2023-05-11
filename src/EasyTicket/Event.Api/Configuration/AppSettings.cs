namespace EventApi.Configuration
{
    public class AppSettings
    {
        public CosmosDb? CosmosDb { get; set; }
    }

    public class CosmosDb
    {
        public string? EndpointUri { get; set; }

        public string? PrimaryKey { get; set; }

        public string? DatabaseName { get; set; }

        public Containers? Containers { get; set; }
    }

    public class Containers
    {
        public string? Events { get; set; }

        public string? Venues { get; set; }
    }
}
