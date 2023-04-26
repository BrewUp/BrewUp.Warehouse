using Brewup.Warehouse.Shared.CustomTypes;

namespace Brewup.Warehouse.ApplicationService.Abstracts;

public interface IWarehouseService
{
	Task CreateWarehouseAsync(WarehouseId warehouseId, WarehouseName warehouseName,
		CancellationToken cancellationToken);
}