﻿using Brewup.Warehouse.Shared.CustomTypes;
using Brewup.Warehouse.Shared.Dtos;

namespace Brewup.Warehouse.ApplicationService.Abstracts;

public interface IBeerService
{
	Task<string> CreateBeerAsync(BeerId beerId, BeerName beerName, CancellationToken cancellationToken);
	Task UpdateStoreQuantityAsync(BeerId beerId, Stock stock, Availability availability,
		CancellationToken cancellationToken);

	Task<BeerJson> GetBeerAsync(BeerId beerId, CancellationToken cancellationToken);
}