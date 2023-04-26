using Brewup.Warehouse.Shared.Dtos;

namespace Brewup.Warehouse.ApplicationService.Abstracts;

public interface IWarehouseOrchestrator
{
	Task<string> CreateWarehouse(WarehouseJson warehouseToCreate, CancellationToken cancellationToken);

	Task AddBeerDepositAsync(BeerDepositJson beerDeposit, CancellationToken cancellationToken);
}