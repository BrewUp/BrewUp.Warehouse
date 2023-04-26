using Brewup.Modules.Warehouse.Abstracts;
using Brewup.Warehouse.ReadModel.Abstracts;
using Brewup.Warehouse.Shared.Concretes;
using Brewup.Warehouse.Shared.CustomTypes;
using Microsoft.Extensions.Logging;

namespace Brewup.Modules.Warehouse.Concretes;

internal sealed class WarehouseService : WarehouseBaseService, IWarehouseService
{
	public WarehouseService(ILoggerFactory loggerFactory,
		IPersister persister) : base(loggerFactory, persister)
	{
	}

	public async Task CreateWarehouseAsync(WarehouseId warehouseId, WarehouseName warehouseName,
		CancellationToken cancellationToken)
	{
		try
		{
			var warehouse = Brewup.Warehouse.ReadModel.Models.WarehouseWarehouse.Create(warehouseId, warehouseName);

			await Persister.InsertAsync(warehouse, cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}
}