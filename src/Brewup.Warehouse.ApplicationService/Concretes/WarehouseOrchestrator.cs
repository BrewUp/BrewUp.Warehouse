﻿using Brewup.Warehouse.ApplicationService.Abstracts;
using Brewup.Warehouse.Shared.Commands;
using Brewup.Warehouse.Shared.CustomTypes;
using Brewup.Warehouse.Shared.Dtos;
using Brewup.Warehouse.Shared.Helpers;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace Brewup.Warehouse.ApplicationService.Concretes;

internal sealed class WarehouseOrchestrator : IWarehouseOrchestrator
{
	private readonly IBeerService _beerService;
	private readonly IServiceBus _serviceBus;
	private readonly ILogger _logger;

	public WarehouseOrchestrator(
		IBeerService beerService,
		IServiceBus serviceBus,
		ILoggerFactory loggerFactory)
	{
		_beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
		_serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));

		_logger = loggerFactory.CreateLogger(GetType());
	}

	public async Task<string> CreateWarehouse(WarehouseJson warehouseToCreate, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(warehouseToCreate.WarehouseId))
			warehouseToCreate.WarehouseId = Guid.NewGuid().ToString();

		var createWarehouse = new CreateWarehouse(new WarehouseId(new Guid(warehouseToCreate.WarehouseId)),
									new WarehouseName(warehouseToCreate.WarehouseName));

		await _serviceBus.SendAsync(createWarehouse, cancellationToken);

		return warehouseToCreate.WarehouseId;
	}

	public async Task AddBeerDepositAsync(BeerDepositJson beerDeposit, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(beerDeposit.MovementId))
			beerDeposit.MovementId = Guid.NewGuid().ToString();

		var addBeerDeposit = new AddBeerDeposit(new WarehouseId(new Guid(beerDeposit.WarehouseId)),
									new MovementId(Guid.NewGuid().ToString()),
									new MovementDate(beerDeposit.MovementDate),
									new CausalId(beerDeposit.CausalId),
									new CausalDescription(beerDeposit.CausalDescription),
									beerDeposit.Rows.Select(BeerDepositoRowHelper.ToValueObject));

		await _serviceBus.SendAsync(addBeerDeposit, cancellationToken);
	}
}