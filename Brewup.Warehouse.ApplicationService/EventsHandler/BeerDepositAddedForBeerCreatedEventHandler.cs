using Brewup.Warehouse.ApplicationService.Abstracts;
using Brewup.Warehouse.Shared.Concretes;
using Brewup.Warehouse.Shared.DomainEvents;
using Microsoft.Extensions.Logging;

namespace Brewup.Warehouse.ApplicationService.EventsHandler;

public sealed class BeerDepositAddedForBeerCreatedEventHandler : DomainEventHandlerAsync<BeerDepositAdded>
{
	private readonly IBeerService _beerService;

	public BeerDepositAddedForBeerCreatedEventHandler(ILoggerFactory loggerFactory,
		IBeerService beerService) : base(loggerFactory)
	{
		_beerService = beerService;
	}

	public override async Task HandleAsync(BeerDepositAdded @event, CancellationToken cancellationToken = new())
	{
		try
		{
			foreach (var row in @event.Rows)
			{
				await _beerService.CreateBeerAsync(row.BeerId, row.BeerName, cancellationToken);
				await _beerService.UpdateStoreQuantityAsync(row.BeerId, row.Stock, row.Availability, cancellationToken);
			}
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}
}