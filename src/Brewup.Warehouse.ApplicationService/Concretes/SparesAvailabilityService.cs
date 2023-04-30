using Brewup.Warehouse.ApplicationService.Abstracts;
using Brewup.Warehouse.ReadModel.Abstracts;
using Brewup.Warehouse.ReadModel.Models;
using Brewup.Warehouse.Shared.Concretes;
using Brewup.Warehouse.Shared.CustomTypes;
using Brewup.Warehouse.Shared.Dtos;
using Microsoft.Extensions.Logging;

namespace Brewup.Warehouse.ApplicationService.Concretes;

internal sealed class SparesAvailabilityService : WarehouseBaseService, ISparesAvailabilityService
{
	public SparesAvailabilityService(ILoggerFactory loggerFactory,
		IPersister persister) : base(loggerFactory, persister)
	{
	}

	public async Task CreateAvailabilityAsync(SpareId spareId, Stock stock, Availability availability,
		ProductionCommitted productionCommitted, SalesCommitted salesCommitted, SupplierOrdered supplierOrdered,
		CancellationToken cancellationToken)
	{
		try
		{
			var sparesAvailability = SparesAvailability.CreateSparesAvailability(spareId, stock, availability,
				productionCommitted, salesCommitted, supplierOrdered);

			await Persister.InsertAsync(sparesAvailability, cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}

	public async Task<SpareAvailabilityJson> GetAvailabilityAsync(SpareId spareId, CancellationToken cancellationToken)
	{
		try
		{
			var sparesAvailability = await Persister.GetByIdAsync<SparesAvailability>(spareId.ToString(), cancellationToken);

			return sparesAvailability.ToJson();
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}
}