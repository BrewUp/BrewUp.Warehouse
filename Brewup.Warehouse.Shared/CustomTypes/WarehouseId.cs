﻿using Muflone.Core;

namespace Brewup.Warehouse.Shared.CustomTypes;

public sealed class WarehouseId : DomainId
{
	public WarehouseId(Guid value) : base(value)
	{
	}
}