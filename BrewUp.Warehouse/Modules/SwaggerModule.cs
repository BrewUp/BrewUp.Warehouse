using Microsoft.OpenApi.Models;

namespace BrewUp.Warehouse.Modules
{
	public sealed class SwaggerModule : IModule
	{
		public bool IsEnabled => true;
		public int Order => 0;

		public IServiceCollection RegisterModule(WebApplicationBuilder builder)
		{
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
			{
				Description = "BrewUp Warehouse API",
				Title = "BrewUp Warehouse Api",
				Version = "v1",
				Contact = new OpenApiContact
				{
					Name = "BrewUp.Api"
				}
			}));

			return builder.Services;
		}

		public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
		{
			return endpoints;
		}
	}
}