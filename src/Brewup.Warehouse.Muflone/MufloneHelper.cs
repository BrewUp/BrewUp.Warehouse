using Brewup.Warehouse.Muflone.Consumers.Commands;
using Brewup.Warehouse.Muflone.Consumers.Events;
using Brewup.Warehouse.Shared.Commands;
using Brewup.Warehouse.Shared.Configuration;
using Brewup.Warehouse.Shared.DomainEvents;
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
			new WarehouseCreatedConsumer(serviceProvider, azureBusConfiguration with { TopicName = nameof(WarehouseCreated)}, loggerFactory!),

			new AddBeerDepositConsumer(repository!, azureBusConfiguration with { TopicName = nameof(AddBeerDeposit)}, loggerFactory!),
			new BeerDepositAddedConsumer(serviceProvider, azureBusConfiguration with { TopicName = nameof(BeerDepositAdded)}, loggerFactory!),

			new AskForBeersAvailabilityConsumer(repository!, azureBusConfiguration with { TopicName = nameof(AskForBeersAvailability)}, loggerFactory!),
			new BeersAvailabilityAskedConsumer(serviceProvider, azureBusConfiguration with { TopicName = nameof(BeersAvailabilityAsked)}, loggerFactory!),

			new WithdrawalFromWarehouseConsumer(repository!, azureBusConfiguration with { TopicName = nameof(WithdrawalFromWarehouse)}, loggerFactory!),
			#endregion
		};

		services.AddMufloneTransportAzure(azureBusConfiguration with { TopicName = string.Empty }, consumers);

		return services;
	}
}