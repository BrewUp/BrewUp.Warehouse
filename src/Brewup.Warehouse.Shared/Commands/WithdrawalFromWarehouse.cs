﻿using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Commands;

namespace Brewup.Warehouse.Shared.Commands;

public sealed class WithdrawalFromWarehouse : Command
{
	public readonly WarehouseId WarehouseId;
	public readonly IEnumerable<BeerToDrawn> Beers;

	public WithdrawalFromWarehouse(WarehouseId aggregateId, Guid commitId, IEnumerable<BeerToDrawn> beers)
		: base(aggregateId, commitId)
	{
		WarehouseId = aggregateId;
		Beers = beers;
	}
}