using Brewup.Warehouse.ApplicationService.Abstracts;
using Brewup.Warehouse.Shared.Concretes;
using Brewup.Warehouse.Shared.DomainEvents;
using Brewup.Warehouse.Shared.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone;

namespace Brewup.Warehouse.ApplicationService.EventsHandler;

public class WarehouseCreatedForBroadcastEventHandler : DomainEventHandlerAsync<WarehouseCreated>
{
	private readonly IEventBus _eventBus;

	public WarehouseCreatedForBroadcastEventHandler(ILoggerFactory loggerFactory,
		IEventBus eventBus) : base(loggerFactory)
	{
		_eventBus = eventBus;
	}

	public override async Task HandleAsync(WarehouseCreated @event, CancellationToken cancellationToken = new())
	{
		try
		{
			var broadcastWarehouseCreated = new BroadcastWarehouseCreated(@event.WarehouseId, @event.WarehouseName);
			await _eventBus.PublishAsync(broadcastWarehouseCreated, cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}
}