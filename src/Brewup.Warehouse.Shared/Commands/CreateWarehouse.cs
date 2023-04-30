using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Commands;

namespace Brewup.Warehouse.Shared.Commands;

public sealed class CreateWarehouse : Command
{
	public readonly WarehouseId WarehouseId;
	public readonly WarehouseName WarehouseName;

	public CreateWarehouse(WarehouseId aggregateId, WarehouseName warehouseName) : base(aggregateId)
	{
		WarehouseId = aggregateId;
		WarehouseName = warehouseName;
	}
}