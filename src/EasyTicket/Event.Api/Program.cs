using EventApi.Configuration;
using EventApi.DataAccess;
using EventApi.DataAccess.Events;
using EventApi.DataAccess.Venues;
using EventApi.Models.Events;
using EventApi.Models.Venues;
using EventApi.Services.Events;
using EventApi.Services.Venues;
using Microsoft.Azure.Cosmos;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.Get<AppSettings>()!;

CosmosClient cosmosClient = new(settings.CosmosDb!.EndpointUri, settings.CosmosDb.PrimaryKey);

Container eventsContainer = cosmosClient.GetContainer(settings.CosmosDb.DatabaseName, settings.CosmosDb.Containers!.Events);
Container venuesContainer = cosmosClient.GetContainer(settings.CosmosDb.DatabaseName, settings.CosmosDb.Containers.Venues);

builder.Services.AddSingleton(new EventsContainerAdapter(eventsContainer));
builder.Services.AddSingleton(new VenuesContainerAdapter(venuesContainer));

builder.Services.AddScoped<IRepository<Event, EventsFilter>, EventsRepository>();
builder.Services.AddScoped<IVenuesRepository, VenuesRepository>();

builder.Services.AddScoped<IEventsRetrievingService, EventsRetrievingService>();
builder.Services.AddScoped<IEventsModifyingService, EventsModifyingService>();
builder.Services.AddScoped<IVenuesRetrievingService, VenuesRetrievingService>();
builder.Services.AddScoped<IVenuesModifyingService, VenuesModifyingService>();

builder.Services.AddControllers().AddDapr();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Events API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
