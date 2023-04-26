using Brewup.Warehouse.Muflone.Consumers.Commands;
using Brewup.Warehouse.Muflone.Consumers.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;
using Muflone.Transport.InMemory;
using Muflone.Transport.InMemory.Abstracts;

namespace Brewup.Warehouse.Muflone;

public static class MufloneHelper
{
	public static IServiceCollection AddMuflone(this IServiceCollection services)
	{
		services.AddSingleton<IServiceBus, ServiceBus>();
		services.AddSingleton<IEventBus, ServiceBus>();

		var serviceProvider = services.BuildServiceProvider();
		var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
		var repository = serviceProvider.GetService<IRepository>();

		var consumers = new List<IConsumer>
		{
			#region Warehouse
			new CreateWarehouseConsumer(repository!, loggerFactory!),
			new WarehouseCreatedConsumer(serviceProvider, loggerFactory!),

			new AddBeerDepositConsumer(repository!, loggerFactory!),
			new BeerDepositAddedConsumer(serviceProvider, loggerFactory!),

			new AskForBeersAvailabilityConsumer(repository!, loggerFactory!),

			new WithdrawalFromWarehouseConsumer(repository!, loggerFactory!),
			#endregion
		};

		services.AddMufloneTransportInMemory(consumers);

		return services;
	}
}