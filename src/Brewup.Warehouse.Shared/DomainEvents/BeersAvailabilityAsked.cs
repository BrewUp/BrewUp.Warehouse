﻿using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Events;

namespace Brewup.Warehouse.Shared.DomainEvents;

public sealed class BeersAvailabilityAsked : DomainEvent
{
	public readonly WarehouseId WarehouseId;

	public readonly IEnumerable<BeerAvailability> Availabilities;


	public BeersAvailabilityAsked(WarehouseId aggregateId, Guid correlationId,
		IEnumerable<BeerAvailability> availabilities) : base(aggregateId, correlationId)
	{
		WarehouseId = aggregateId;
		Availabilities = availabilities;
	}
}