﻿using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Commands;

namespace Brewup.Warehouse.Shared.Commands;

public sealed class AskForBeersAvailability : Command
{
	public readonly WarehouseId WarehouseId;
	public readonly IEnumerable<BeerId> Beers;

	public AskForBeersAvailability(WarehouseId aggregateId, Guid commitId, IEnumerable<BeerId> beers)
		: base(aggregateId, commitId)
	{
		WarehouseId = aggregateId;
		Beers = beers;
	}
}