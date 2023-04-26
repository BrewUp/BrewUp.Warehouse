using Brewup.Warehouse.Muflone;
using Brewup.Warehouse.ReadModel.MongoDb;
using Brewup.Warehouse.Shared.Configuration;
using Muflone.Eventstore;
using Muflone.Saga.Persistence.MongoDb;

namespace BrewUp.Warehouse.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 99;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddMongoDb(builder.Configuration.GetSection("BrewUp:MongoDbSettings").Get<MongoDbSettings>()!);
		builder.Services.AddEventstoreMongoDb(builder.Configuration.GetSection("BrewUp:MongoDbSettings").Get<MongoDbSettings>()!);
		builder.Services.AddMongoSagaStateRepository(new MongoSagaStateRepositoryOptions(builder.Configuration["BrewUp:MongoDbSettings:ConnectionString"]!,
			builder.Configuration["BrewUp:MongoDbSettings:DatabaseName"]!));

		builder.Services.AddMufloneEventStore(builder.Configuration["BrewUp:EventStoreSettings:ConnectionString"]!);
		builder.Services.AddMuflone();

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}