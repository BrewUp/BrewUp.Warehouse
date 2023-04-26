using Brewup.Warehouse.Shared.CustomTypes;
using Muflone.Messages.Events;

namespace Brewup.Warehouse.Shared.IntegrationEvents;

public sealed class BroadcastBeerWithdrawn : IntegrationEvent
{
	public readonly WarehouseId WarehouseId;
	public readonly IEnumerable<BeerToDrawn> Beers;

	public BroadcastBeerWithdrawn(WarehouseId aggregateId, Guid commitId, IEnumerable<BeerToDrawn> beers)
		: base(aggregateId, commitId)
	{
		WarehouseId = aggregateId;
		Beers = beers;
	}
}