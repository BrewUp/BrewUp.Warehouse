﻿using Brewup.Warehouse.ReadModel.Abstracts;
using Brewup.Warehouse.Shared.CustomTypes;
using Brewup.Warehouse.Shared.Dtos;

namespace Brewup.Warehouse.ReadModel.Models;

public class WarehouseBeer : ModelBase
{
	public string BeerName { get; private set; }

	public double Stock { get; private set; }
	public double Availability { get; private set; }
	public double SalesCommitted { get; private set; }

	protected WarehouseBeer()
	{ }

	public static WarehouseBeer CreateBeer(BeerId beerId, BeerName beerName) => new(beerId.Value, beerName.Value);

	private WarehouseBeer(string beerId, string beerName)
	{
		Id = beerId;
		BeerName = beerName;

		Stock = 0;
		Availability = 0;
		SalesCommitted = 0;
	}

	public void UpdateStoreQuantity(Stock stock, Availability availability)
	{
		Stock = stock.Value;
		Availability = availability.Value;
	}

	public BeerJson ToJson() => new()
	{
		BeerId = Id,
		BeerName = BeerName
	};
}