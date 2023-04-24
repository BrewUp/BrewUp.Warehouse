using Brewup.Modules.Warehouse;
using Brewup.Modules.Warehouse.Endpoint;

namespace BrewUp.Warehouse.Modules;

public class WarehouseModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 0;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		return builder.Services.AddWarehouseModule();;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		var mapGroup = endpoints.MapGroup("v1/warehouses")
			.WithTags("Warehouses");

		mapGroup.MapPost("", WarehouseEndpoints.HandleCreateWarehouse)
			.Produces(StatusCodes.Status400BadRequest)
			.WithName("CreateWarehouse");

		mapGroup.MapPost("/deposit", WarehouseEndpoints.HandleAddBeerDeposit)
			.Produces(StatusCodes.Status400BadRequest)
			.WithName("AddBeerDeposit");

		//mapGroup.MapPost("/availability", WarehouseEndpoints.HandleCreateAvailability)
		//	.Produces(StatusCodes.Status400BadRequest)
		//	.WithName("CreateAvailability");

		return mapGroup;
	}
}