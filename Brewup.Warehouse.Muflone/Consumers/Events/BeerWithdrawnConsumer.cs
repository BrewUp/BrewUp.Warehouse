using Brewup.Warehouse.Shared.DomainEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace Brewup.Warehouse.Muflone.Consumers.Events;

public sealed class BeerWithdrawnConsumer : DomainEventConsumerBase<BeerWithdrawn>
{
	protected override IEnumerable<IDomainEventHandlerAsync<BeerWithdrawn>> HandlersAsync { get; }

	public BeerWithdrawnConsumer(IServiceProvider serviceProvider,
		AzureServiceBusConfiguration azureServiceBusConfiguration,
		ILoggerFactory loggerFactory,
		ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
	{
		HandlersAsync = serviceProvider.GetServices<IDomainEventHandlerAsync<BeerWithdrawn>>();
	}
}