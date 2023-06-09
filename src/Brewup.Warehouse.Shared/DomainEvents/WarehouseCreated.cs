﻿using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Events;

namespace Brewup.Warehouse.Shared.DomainEvents;

public sealed class WarehouseCreated : DomainEvent
{
	public readonly WarehouseId WarehouseId;
	public readonly WarehouseName WarehouseName;

	public WarehouseCreated(WarehouseId aggregateId, WarehouseName warehouseName) : base(aggregateId)
	{
		WarehouseId = aggregateId;
		WarehouseName = warehouseName;
	}
}