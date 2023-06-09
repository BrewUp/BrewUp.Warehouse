﻿using Brewup.Warehouse.ApplicationService.Abstracts;
using Brewup.Warehouse.ReadModel.Abstracts;
using Brewup.Warehouse.ReadModel.Models;
using Brewup.Warehouse.Shared.Concretes;
using Brewup.Warehouse.Shared.CustomTypes;
using Brewup.Warehouse.Shared.Dtos;
using Microsoft.Extensions.Logging;

namespace Brewup.Warehouse.ApplicationService.Concretes;

internal sealed class BeerService : WarehouseBaseService, IBeerService
{
	public BeerService(ILoggerFactory loggerFactory,
		IPersister persister) : base(loggerFactory, persister)
	{
	}

	public async Task<string> CreateBeerAsync(BeerId beerId, BeerName beerName, CancellationToken cancellationToken)
	{
		try
		{
			var beer = await Persister.GetByIdAsync<WarehouseBeer>(beerId.Value, cancellationToken);
			if (!string.IsNullOrWhiteSpace(beer.Id))
				return beer.Id;

			beer = WarehouseBeer.CreateBeer(beerId, beerName);
			await Persister.InsertAsync(beer, cancellationToken);

			return beer.Id;
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}

	public async Task UpdateStoreQuantityAsync(BeerId beerId, Stock stock, Availability availability,
		CancellationToken cancellationToken)
	{
		try
		{
			var beer = await Persister.GetByIdAsync<WarehouseBeer>(beerId.Value, cancellationToken);

			beer.UpdateStoreQuantity(stock, availability);
			var propertiesToUpdate = new Dictionary<string, object>
			{
				{ "Stock", beer.Stock },
				{ "Availability", beer.Availability }
			};
			await Persister.UpdateOneAsync<WarehouseBeer>(beer.Id, propertiesToUpdate, cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}

	public async Task<BeerJson> GetBeerAsync(BeerId beerId, CancellationToken cancellationToken)
	{
		try
		{
			var beer = await Persister.GetByIdAsync<WarehouseBeer>(beerId.ToString(), cancellationToken);
			return beer.ToJson();
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}
}