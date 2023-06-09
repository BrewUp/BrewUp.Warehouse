﻿using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Events;

namespace Brewup.Warehouse.Shared.DomainEvents;

public sealed class BeerWithdrawn : DomainEvent
{
	public readonly WarehouseId WarehouseId;
	public readonly IEnumerable<BeerToDrawn> Beers;

	public BeerWithdrawn(WarehouseId aggregateId, Guid commitId, IEnumerable<BeerToDrawn> beers)
		: base(aggregateId, commitId)
	{
		WarehouseId = aggregateId;
		Beers = beers;
	}
}