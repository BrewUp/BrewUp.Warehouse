using Brewup.Warehouse.Muflone.Consumers.Commands;
using Brewup.Warehouse.Shared.Commands;
using Brewup.Warehouse.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;
using Muflone.Transport.Azure;
using Muflone.Transport.Azure.Abstracts;
using Muflone.Transport.Azure.Models;

namespace Brewup.Warehouse.Muflone;

public static class MufloneHelper
{
	public static IServiceCollection AddMuflone(this IServiceCollection services, ServiceBusSettings serviceBusSettings)
	{
		services.AddSingleton<IServiceBus, ServiceBus>();
		services.AddSingleton<IEventBus, ServiceBus>();

		var serviceProvider = services.BuildServiceProvider();
		var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
		var repository = serviceProvider.GetService<IRepository>();

		var azureBusConfiguration =
			new AzureServiceBusConfiguration(serviceBusSettings.ConnectionString, nameof(AskForBeersAvailability),
				serviceBusSettings.ClientId);

		var consumers = new List<IConsumer>
		{
			#region Warehouse
			new CreateWarehouseConsumer(repository!, azureBusConfiguration with { TopicName = nameof(CreateWarehouse)}, loggerFactory!),
			//new WarehouseCreatedConsumer(serviceProvider, loggerFactory!),

			//new AddBeerDepositConsumer(repository!, loggerFactory!),
			//new BeerDepositAddedConsumer(serviceProvider, loggerFactory!),

			//new AskForBeersAvailabilityConsumer(repository!, loggerFactory!),

			//new WithdrawalFromWarehouseConsumer(repository!, loggerFactory!),
			#endregion
		};

		TransportAzureHelper.AddMufloneTransportAzure(services)

		services.AddMufloneTransportInMemory(consumers);

		return services;
	}
}