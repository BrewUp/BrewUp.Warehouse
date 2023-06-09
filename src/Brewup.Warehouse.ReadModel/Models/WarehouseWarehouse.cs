﻿using Brewup.Warehouse.ReadModel.Abstracts;
using Brewup.Warehouse.Shared.CustomTypes;

namespace Brewup.Warehouse.ReadModel.Models;

public class WarehouseWarehouse : ModelBase
{
	public string WarehouseName { get; private set; } = string.Empty;

	protected WarehouseWarehouse()
	{ }

	public static WarehouseWarehouse Create(WarehouseId warehouseId, WarehouseName warehouseName) =>
		new(warehouseId.ToString(), warehouseName.Value);

	private WarehouseWarehouse(string warehouseId, string warehouseName)
	{
		Id = warehouseId;
		WarehouseName = warehouseName;
	}
}