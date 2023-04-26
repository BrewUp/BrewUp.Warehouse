using Brewup.Warehouse.Shared.CustomTypes;
using Brewup.Warehouse.Shared.Dtos;

namespace Brewup.Warehouse.Shared.Helpers;

public static class BeerDepositoRowHelper
{
	public static BeerDepositRow ToValueObject(BeerDepositRowJson json) => new BeerDepositRow(new BeerId(json.BeerId),
		new BeerName(json.BeerName), new MovementQuantity(json.MovementQuantity));
}