﻿using Brewup.Warehouse.Shared.DomainEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace Brewup.Warehouse.Muflone.Consumers.Events;

public sealed class BeersAvailabilityAskedConsumer : DomainEventConsumerBase<BeersAvailabilityAsked>
{
	protected override IEnumerable<IDomainEventHandlerAsync<BeersAvailabilityAsked>> HandlersAsync { get; }

	public BeersAvailabilityAskedConsumer(IServiceProvider serviceProvider,
		AzureServiceBusConfiguration azureServiceBusConfiguration,
		ILoggerFactory loggerFactory,
		ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
	{
		HandlersAsync = Enumerable.Empty<IDomainEventHandlerAsync<BeersAvailabilityAsked>>();
	}
}